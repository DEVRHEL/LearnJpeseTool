using NihonTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NihonTest
{
    public partial class PopupForm : Form
    {
        public int ReturnedIndex { get; private set; }
        private Dictionary<string, List<Vocabulary>> vocabularyTopics;
        private string currentTopic;
        private int currentVocabularyIndex;
        private Vocabulary correctAnswer;
        private Random random;
        private int emptyLines;
        private System.Windows.Forms.Timer progressTimer;
        private int progressValue;
        private int totalTime;
        private bool setTimerCheckbox;
        private bool romajiCheckbox;
        private bool learnRadio;
        private bool testRadio;

        public PopupForm(Dictionary<string, List<Vocabulary>> _vocabularyTopics,
            string _currentTopic,
            int _currentVocabularyIndex,
            Vocabulary _correctAnswer,
            Random _random,
            int _emptyLines,
            System.Windows.Forms.Timer _progressTimer,
            int _progressValue,
            int _totalTime,
            bool _setTimerCheckbox,
            bool _romajiCheckbox,
            bool _learnRadio,
            bool _testRadio
        )
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            TopMost = true;
            ShowInTaskbar = false;

            vocabularyTopics = _vocabularyTopics;
            currentTopic = _currentTopic;
            currentVocabularyIndex = _currentVocabularyIndex;
            correctAnswer = _correctAnswer;
            random = _random;
            emptyLines = _emptyLines;
            progressTimer = _progressTimer;
            progressValue = _progressValue;
            totalTime = _totalTime;
            setTimerCheckbox = _setTimerCheckbox;
            romajiCheckbox = _romajiCheckbox;
            learnRadio = _learnRadio;
            testRadio = _testRadio;

            setAnswerButonOnOff(false);
            UpdateVocabularyDisplay();
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

        private void UpdateVocabularyDisplay()
        {
            if (currentTopic == null) return;

            if (learnRadio)
            {
                UpdateVocabularyDisplayByLearn();
            }
            else
            {
                UpdateVocabularyDisplayByTest();
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

        private void UpdateVocabularyDisplayByLearn()
        {
            runProgressBar();
            var currentVocab = vocabularyTopics[currentTopic][currentVocabularyIndex];

            var kanjiLabel = string.IsNullOrEmpty(currentVocab.Kanji) ? "\r\n" : $" - {currentVocab.Kanji}\r\n";
            var vocabularyLabel = currentVocab.Hiragana + kanjiLabel;
            var romanjiLabel = romajiCheckbox ? "" : $"({currentVocab.Romanji})\r\n";
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
            var romanjiLabel = romajiCheckbox ? "" : $"\r\n({correctAnswer.Romanji})";
            contentTexbox.Text = new string('\n', emptyLines) + correctAnswer.Hiragana + romanjiLabel + "\r\n---------------\r\nCó nghĩa là?";
            contentTexbox.SelectAll();
            contentTexbox.SelectionAlignment = HorizontalAlignment.Center;
            contentTexbox.DeselectAll();
            aButton.Text = options[0].Vietnamese;
            bButton.Text = options[1].Vietnamese;
            cButton.Text = options[2].Vietnamese;
            dButton.Text = options[3].Vietnamese;
        }

        private void runProgressBar()
        {
            if (!setTimerCheckbox)
            {
                resetProgressBar();
                progressBar.Visible = false;
                return;
            };

            progressBar.Visible = true;
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

        private bool isCorrectAnswer(string answer)
        {
            if (string.IsNullOrEmpty(answer)) return false;
            if (correctAnswer == null) return false;
            if (correctAnswer.Vietnamese.Equals(answer)) return true;
            return false;
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
    }
}
