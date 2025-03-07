namespace NihonTest
{
    public class Vocabulary
    {
        public string Hiragana { get; set; }
        public string Romanji { get; set; }
        public string Vietnamese { get; set; }
        public string Kanji { get; set; }
    }

    public partial class Form1 : Form
    {
        private Dictionary<string, List<Vocabulary>> vocabularyTopics = new Dictionary<string, List<Vocabulary>>();
        private string currentTopic;
        private int currentVocabularyIndex = 0;
        private bool isRomanjiVisible = true;

        public Form1()
        {
            InitializeComponent();
            LoadVocabularyData();
            SetupUI();
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
        }

        private void SetupUI()
        {
            // Thiết lập kích thước form
            this.Size = new Size(1366, 768);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Panel menu chủ đề bên trái
            Panel topicPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = this.ClientSize.Width / 3
            };

            // ListBox chọn chủ đề
            ListBox topicListBox = new ListBox
            {
                Dock = DockStyle.Fill
            };
            topicListBox.Items.AddRange(vocabularyTopics.Keys.ToArray());
            topicListBox.SelectedIndexChanged += TopicListBox_SelectedIndexChanged;
            topicPanel.Controls.Add(topicListBox);

            // Panel chính bên phải
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill
            };

            // Radio button Ẩn/Hiện Romanji
            RadioButton romanjiVisibleRadio = new RadioButton
            {
                Text = "Hiện Romanji",
                Checked = true,
                Location = new Point(10, 10)
            };
            romanjiVisibleRadio.CheckedChanged += (s, e) =>
            {
                isRomanjiVisible = romanjiVisibleRadio.Checked;
                UpdateVocabularyDisplay();
            };

            // Tab control cho học và thi
            TabControl modeTabControl = new TabControl
            {
                Dock = DockStyle.Top,
                Height = 50
            };
            TabPage studyTab = new TabPage("Học Từ Vựng");
            TabPage testTab = new TabPage("Thi Trắc Nghiệm");
            modeTabControl.TabPages.Add(studyTab);
            modeTabControl.TabPages.Add(testTab);

            // Nội dung panel học từ vựng
            Panel studyPanel = CreateStudyPanel();
            studyTab.Controls.Add(studyPanel);

            // Nội dung panel thi trắc nghiệm
            Panel testPanel = CreateTestPanel();
            testTab.Controls.Add(testPanel);

            // Thêm các control vào form
            this.Controls.Add(mainPanel);
            mainPanel.Controls.Add(modeTabControl);
            mainPanel.Controls.Add(romanjiVisibleRadio);

            this.Controls.Add(topicPanel);
        }

        private Panel CreateStudyPanel()
        {
            // Implement study panel logic here
            return new Panel();
        }

        private Panel CreateTestPanel()
        {
            // Implement test panel logic here
            return new Panel();
        }

        private void TopicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTopic = (sender as ListBox).SelectedItem.ToString();
            currentVocabularyIndex = 0;
            UpdateVocabularyDisplay();
        }

        private void UpdateVocabularyDisplay()
        {
            if (currentTopic == null) return;

            var currentVocab = vocabularyTopics[currentTopic][currentVocabularyIndex];

            vocabularyLabel.Text = $"{currentVocab.Hiragana} - {currentVocab.Kanji}";
            romanjiLabel.Text = isRomanjiVisible ? currentVocab.Romanji : "";
            meaningLabel.Text = currentVocab.Vietnamese;
        }

        // Popup minimize mode method
        private Form CreatePopupForm()
        {
            Form popupForm = new Form
            {
                Size = new Size(500, 200),
                StartPosition = FormStartPosition.Manual,
                Location = new Point(10, Screen.PrimaryScreen.Bounds.Height - 250),
                FormBorderStyle = FormBorderStyle.None,
                TopMost = true
            };

            return popupForm;
        }

        private void RomanjiRadio_CheckedChanged(object sender, EventArgs e)
        {
            isRomanjiVisible = romanjiRadio.Checked;
            UpdateVocabularyDisplay();
        }

        private void ModeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi chuyển giữa tab học và thi
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (currentVocabularyIndex > 0)
            {
                currentVocabularyIndex--;
                UpdateVocabularyDisplay();
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentTopic != null &&
                currentVocabularyIndex < vocabularyTopics[currentTopic].Count - 1)
            {
                currentVocabularyIndex++;
                UpdateVocabularyDisplay();
            }
        }
    }
}
