namespace NihonTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Thiết lập các thuộc tính của Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Text = "Học Từ Vựng Tiếng Nhật";
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.MaximumSize = new System.Drawing.Size(1366, 768);

            // Panel chủ đề bên trái
            this.topicPanel = new Panel();
            this.topicPanel.Dock = DockStyle.Left;
            this.topicPanel.Width = this.ClientSize.Width / 3;
            this.topicPanel.BorderStyle = BorderStyle.FixedSingle;

            // ListBox chủ đề
            this.topicListBox = new ListBox();
            this.topicListBox.Dock = DockStyle.Fill;
            this.topicListBox.Font = new System.Drawing.Font("Arial", 10);
            this.topicListBox.SelectedIndexChanged += TopicListBox_SelectedIndexChanged;
            this.topicPanel.Controls.Add(this.topicListBox);

            // Radio button Romanji
            this.romanjiRadio = new RadioButton();
            this.romanjiRadio.Text = "Hiện Romanji";
            this.romanjiRadio.Checked = true;
            this.romanjiRadio.Location = new System.Drawing.Point(10, 10);
            this.romanjiRadio.CheckedChanged += RomanjiRadio_CheckedChanged;

            // Tab Control cho học và thi
            this.modeTabControl = new TabControl();
            this.modeTabControl.Dock = DockStyle.Top;
            this.modeTabControl.Height = 50;

            // Tab học từ vựng
            this.studyTab = new TabPage("Học Từ Vựng");
            this.studyTab.BackColor = System.Drawing.Color.White;

            // Tab thi trắc nghiệm
            this.testTab = new TabPage("Thi Trắc Nghiệm");
            this.testTab.BackColor = System.Drawing.Color.White;

            this.modeTabControl.TabPages.Add(this.studyTab);
            this.modeTabControl.TabPages.Add(this.testTab);
            this.modeTabControl.SelectedIndexChanged += ModeTabControl_SelectedIndexChanged;

            // Panel nội dung chính
            this.mainContentPanel = new Panel();
            this.mainContentPanel.Dock = DockStyle.Fill;
            this.mainContentPanel.BorderStyle = BorderStyle.FixedSingle;

            // Label hiển thị từ vựng
            this.vocabularyLabel = new Label();
            this.vocabularyLabel.Dock = DockStyle.Top;
            this.vocabularyLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.vocabularyLabel.Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold);

            // Label Romanji
            this.romanjiLabel = new Label();
            this.romanjiLabel.Dock = DockStyle.Top;
            this.romanjiLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.romanjiLabel.Font = new System.Drawing.Font("Arial", 12);

            // Label nghĩa tiếng Việt
            this.meaningLabel = new Label();
            this.meaningLabel.Dock = DockStyle.Top;
            this.meaningLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.meaningLabel.Font = new System.Drawing.Font("Arial", 12);

            // Nút điều hướng
            this.backButton = new Button();
            this.backButton.Text = "Quay Lại";
            this.backButton.Dock = DockStyle.Left;
            this.backButton.Width = 100;
            this.backButton.Click += BackButton_Click;

            this.nextButton = new Button();
            this.nextButton.Text = "Tiếp Theo";
            this.nextButton.Dock = DockStyle.Right;
            this.nextButton.Width = 100;
            this.nextButton.Click += NextButton_Click;

            // Thêm các control vào form
            this.Controls.Add(this.mainContentPanel);
            this.Controls.Add(this.modeTabControl);
            this.Controls.Add(this.romanjiRadio);
            this.Controls.Add(this.topicPanel);

            // Thêm các control vào panel nội dung
            this.mainContentPanel.Controls.Add(this.nextButton);
            this.mainContentPanel.Controls.Add(this.backButton);
            this.mainContentPanel.Controls.Add(this.meaningLabel);
            this.mainContentPanel.Controls.Add(this.romanjiLabel);
            this.mainContentPanel.Controls.Add(this.vocabularyLabel);
        }

        #endregion

        private Panel topicPanel;
        private ListBox topicListBox;
        private RadioButton romanjiRadio;
        private TabControl modeTabControl;
        private TabPage studyTab;
        private TabPage testTab;
        private Panel mainContentPanel;
        private Label vocabularyLabel;
        private Label romanjiLabel;
        private Label meaningLabel;
        private Button backButton;
        private Button nextButton;
    }
}
