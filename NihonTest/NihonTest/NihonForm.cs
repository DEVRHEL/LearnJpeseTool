using NihonTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NihonTest
{
    public partial class NihonForm : Form
    {
        private Dictionary<string, List<Vocabulary>> vocabularyTopics = new Dictionary<string, List<Vocabulary>>();
        private string currentTopic;
        private int currentVocabularyIndex = 0;
        private Vocabulary correctAnswer;
        private Random random = new Random();
        private int emptyLines = 1;
        private System.Windows.Forms.Timer progressTimer;
        private int progressValue = 0;
        private PopupForm popupForm;
        private int totalTime;

        public NihonForm()
        {
            InitializeComponent();
            LoadVocabularyData();
        }

        private void LoadVocabularyData()
        {
            string dataFolder = Path.Combine(Application.StartupPath, "Data");

            foreach (string file in Directory.GetFiles(dataFolder, "*.txt"))
            {
                string topicName = Path.GetFileNameWithoutExtension(file);
                List<Vocabulary> vocabularyList = File.ReadAllLines(file)
                    .Skip(1) // Bỏ qua dòng tiêu đề
                    .Select(line =>
                    {
                        var parts = line.Split('|');
                        return new Vocabulary
                        {
                            Hiragana = parts[0],
                            Romanji = parts[1],
                            Vietnamese = parts[2],
                            Kanji = parts[3]
                        };
                    })
                    .OrderBy(x => Guid.NewGuid()) // Xáo trộn ngẫu nhiên
                    .ToList();

                vocabularyTopics[topicName] = vocabularyList;
            }

            // **Sắp xếp theo số thứ tự đúng**
            var sortedTopics = vocabularyTopics.Keys
                .OrderBy(x => ExtractNumber(x))
                .ToArray();

            topicListBox.Items.AddRange(sortedTopics);

            // **Chọn mục đầu tiên nếu danh sách có ít nhất một phần tử**
            if (topicListBox.Items.Count > 0)
            {
                topicListBox.SelectedIndex = 0;
            }
        }

        // **Hàm trích xuất số từ chuỗi để sắp xếp đúng thứ tự**
        private int ExtractNumber(string topicName)
        {
            Match match = Regex.Match(topicName, @"\d+"); // Tìm số trong chuỗi
            return match.Success ? int.Parse(match.Value) : int.MaxValue; // Nếu không có số, đặt giá trị lớn nhất
        }

        private void learnRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAnswerButonOnOff(false);
            UpdateVocabularyDisplay();
        }

        private void testRadio_CheckedChanged(object sender, EventArgs e)
        {
            setAnswerButonOnOff(true);
            UpdateVocabularyDisplay();
        }

        private void setAnswerButonOnOff(bool isOn)
        {
            if (isOn)
            {
                aButton.Visible = true;
                aButton.BackColor = Color.White;
                bButton.Visible = true;
                bButton.BackColor = Color.White;
                cButton.Visible = true;
                cButton.BackColor = Color.White;
                dButton.Visible = true;
                dButton.BackColor = Color.White;
            }
            else
            {
                aButton.Visible = false;
                aButton.BackColor = Color.White;
                bButton.Visible = false;
                bButton.BackColor = Color.White;
                cButton.Visible = false;
                cButton.BackColor = Color.White;
                dButton.Visible = false;
                dButton.BackColor = Color.White;
            }
        }

        private void topicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTopic = (sender as ListBox).SelectedItem.ToString();
            currentVocabularyIndex = 0;
            UpdateVocabularyDisplay();
        }

        private void UpdateVocabularyDisplay()
        {
            if (currentTopic == null) return;

            if (learnRadio.Checked)
            {
                UpdateVocabularyDisplayByLearn();
            }
            else
            {
                UpdateVocabularyDisplayByTest();
            }
        }

        private void UpdateVocabularyDisplayByLearn()
        {
            runProgressBar();

            var currentVocab = vocabularyTopics[currentTopic][currentVocabularyIndex];

            var kanjiLabel = string.IsNullOrEmpty(currentVocab.Kanji) ? "\r\n" : $" - {currentVocab.Kanji}\r\n";
            var vocabularyLabel = currentVocab.Hiragana + kanjiLabel;
            var romanjiLabel = romajiCheckbox.Checked ? "" : $"({currentVocab.Romanji})\r\n";
            var meaningLabel = currentVocab.Vietnamese;

            // Căn giữa theo chiều dọc bằng cách thêm dòng trống phía trên
            contentTexbox.Text = new string('\n', emptyLines) + vocabularyLabel + romanjiLabel + "---------------\r\n" + meaningLabel;
            contentTexbox.SelectAll();
            contentTexbox.SelectionAlignment = HorizontalAlignment.Center;
            contentTexbox.DeselectAll();
        }

        private void UpdateVocabularyDisplayByTest()
        {
            if (!vocabularyTopics.ContainsKey(currentTopic) || vocabularyTopics[currentTopic].Count < 4)
            {
                contentTexbox.Text = new string('\n', emptyLines) + "Không đủ từ vựng để tạo câu hỏi!";
                contentTexbox.SelectAll();
                contentTexbox.SelectionAlignment = HorizontalAlignment.Center;
                contentTexbox.DeselectAll();

                setAnswerButonOnOff(false);
                resetProgressBar();

                return;
            }
            runProgressBar();
            setAnswerButonOnOff(true);

            // 1️ Chọn từ đúng (random từ danh sách)
            correctAnswer = vocabularyTopics[currentTopic][random.Next(vocabularyTopics[currentTopic].Count)];

            // 2️ Lấy 3 đáp án sai (từ danh sách nhưng khác từ đúng)
            List<Vocabulary> wrongAnswers = vocabularyTopics[currentTopic]
                .Where(v => v.Hiragana != correctAnswer.Hiragana)
                .OrderBy(x => random.Next()) // Trộn ngẫu nhiên
                .Take(3)
                .ToList();

            // 3️ Gom 4 đáp án (bao gồm từ đúng)
            List<Vocabulary> options = new List<Vocabulary>(wrongAnswers) { correctAnswer };
            options = options.OrderBy(x => random.Next()).ToList(); // Trộn thứ tự

            // 4️ Hiển thị câu hỏi (Hiragana) và các lựa chọn (Vietnamese)
            var romanjiLabel = romajiCheckbox.Checked ? "" : $"\r\n({correctAnswer.Romanji})";
            contentTexbox.Text = new string('\n', emptyLines) + correctAnswer.Hiragana + romanjiLabel + "\r\n---------------\r\nCó nghĩa là?";
            contentTexbox.SelectAll();
            contentTexbox.SelectionAlignment = HorizontalAlignment.Center;
            contentTexbox.DeselectAll();
            aButton.Text = options[0].Vietnamese;
            bButton.Text = options[1].Vietnamese;
            cButton.Text = options[2].Vietnamese;
            dButton.Text = options[3].Vietnamese;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            resetProgressBar();
            if (currentVocabularyIndex > 0)
            {
                currentVocabularyIndex--;
                UpdateVocabularyDisplay();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            resetProgressBar();
            if (currentTopic != null &&
                currentVocabularyIndex < vocabularyTopics[currentTopic].Count - 1)
            {
                currentVocabularyIndex++;
                UpdateVocabularyDisplay();
            }
        }

        private void aButton_Click(object sender, EventArgs e)
        {
            var isCorrect = isCorrectAnswer(aButton.Text);
            if (isCorrect)
            {
                aButton.BackColor = Color.Green;
            }
            else
            {
                aButton.BackColor = Color.Red;
            }
        }

        private void bButton_Click(object sender, EventArgs e)
        {
            var isCorrect = isCorrectAnswer(bButton.Text);
            if (isCorrect)
            {
                bButton.BackColor = Color.Green;
            }
            else
            {
                bButton.BackColor = Color.Red;
            }
        }

        private void cButton_Click(object sender, EventArgs e)
        {
            var isCorrect = isCorrectAnswer(cButton.Text);
            if (isCorrect)
            {
                cButton.BackColor = Color.Green;
            }
            else
            {
                cButton.BackColor = Color.Red;
            }
        }

        private void dButton_Click(object sender, EventArgs e)
        {
            var isCorrect = isCorrectAnswer(dButton.Text);
            if (isCorrect)
            {
                dButton.BackColor = Color.Green;
            }
            else
            {
                dButton.BackColor = Color.Red;
            }
        }

        private bool isCorrectAnswer(string answer)
        {
            if (string.IsNullOrEmpty(answer)) return false;
            if (correctAnswer == null) return false;
            if (correctAnswer.Vietnamese.Equals(answer)) return true;
            return false;
        }

        private void runProgressBar()
        {
            resetProgressBar();
            if (!setTimerCheckbox.Checked)
            {
                progressBar.Visible = false;
                return;
            };
            progressBar.Visible = true;

            if (!int.TryParse(timerTexbox.Text, out totalTime) || totalTime < 1)
            {
                totalTime = 1; // Đảm bảo thời gian tối thiểu là 1 giây
            }

            progressValue = 0;
            progressBar.Value = 0; // Reset ProgressBar
            progressBar.Maximum = totalTime * 10; // Tổng số bước (cập nhật mỗi 100ms)

            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 100; // Cập nhật mỗi 100ms
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void resetProgressBar()
        {
            if (progressTimer != null)
            {
                progressTimer.Stop();
                progressTimer.Dispose();
            }
            progressValue = 0;
            progressBar.Value = 0;
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            progressValue++;

            if (progressValue <= progressBar.Maximum)
            {
                progressBar.Value = progressValue;
            }
            else
            {
                progressTimer.Stop();
                progressTimer.Dispose();
                nextButton_Click(nextButton, EventArgs.Empty); // Gọi sự kiện nextButton_Click
            }
        }

        private void timerTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0-9) và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void timerTextbox_TextChanged(object sender, EventArgs e)
        {
            if (timerTexbox.Text != "")
            {
                // Chuyển đổi giá trị nhập sang số
                if (int.TryParse(timerTexbox.Text, out int value))
                {
                    // Nếu nhỏ hơn 1, đặt lại thành 1
                    if (value < 1)
                    {
                        timerTexbox.Text = "1";
                    }
                    // Nếu lớn hơn 999, đặt lại thành 999
                    else if (value > 999)
                    {
                        timerTexbox.Text = "999";
                    }

                    // Đưa con trỏ về cuối văn bản
                    timerTexbox.SelectionStart = timerTexbox.Text.Length;
                }
            }
        }

        private void PopupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (popupCheckbox.Checked)
            {
                ShowPopup();
            }
        }

        private void ShowPopup()
        {
            if (popupForm != null) return;

            // Tạo form popup nhỏ
            popupForm = new PopupForm(
                vocabularyTopics,
                currentTopic,
                currentVocabularyIndex,
                correctAnswer,
                random,
                emptyLines,
                progressTimer,
                progressValue,
                totalTime,
                setTimerCheckbox.Checked,
                romajiCheckbox.Checked,
                learnRadio.Checked,
                testRadio.Checked
            );

            // Vị trí ở góc dưới phải màn hình
            int screenX = Screen.PrimaryScreen.WorkingArea.Width - popupForm.Width - 10;
            int screenY = Screen.PrimaryScreen.WorkingArea.Height - popupForm.Height - 10;
            popupForm.Location = new Point(screenX, screenY);
            popupForm.FormClosed += (s, e) =>
            {
                // Cập nhật giá trị currentVocabularyIndex từ Popup
                currentVocabularyIndex = popupForm.ReturnedIndex;
                // Hủy đối tượng PopupForm
                popupForm.Dispose();
                popupForm = null;
                // Bỏ chọn checkbox và hiện lại RightPanel
                popupCheckbox.Checked = false;
                RightPanel.Visible = true;
                // Cập nhật lại giao diện nếu cần
                UpdateVocabularyDisplay();
            };
            popupForm.Show();

            RightPanel.Visible = false; // Ẩn RightPanel
        }

        private void setTimerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVocabularyDisplay();
        }

        private void romajiCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVocabularyDisplay();
        }
    }
}
