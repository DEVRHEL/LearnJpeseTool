namespace NihonTest
{
    partial class NihonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NihonForm));
            LeftPanel = new Panel();
            topicListBox = new ListBox();
            RightPanel = new Panel();
            timerLabel = new Label();
            timerTexbox = new TextBox();
            setTimerCheckbox = new CheckBox();
            progressBar = new ProgressBar();
            nextButton = new Button();
            previousButton = new Button();
            dButton = new Button();
            cButton = new Button();
            bButton = new Button();
            aButton = new Button();
            contentTexbox = new RichTextBox();
            popupCheckbox = new CheckBox();
            romajiCheckbox = new CheckBox();
            learnRadio = new RadioButton();
            testRadio = new RadioButton();
            LeftPanel.SuspendLayout();
            RightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // LeftPanel
            // 
            LeftPanel.Controls.Add(topicListBox);
            LeftPanel.Location = new Point(0, 1);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(333, 766);
            LeftPanel.TabIndex = 0;
            // 
            // topicListBox
            // 
            topicListBox.Dock = DockStyle.Fill;
            topicListBox.FormattingEnabled = true;
            topicListBox.ItemHeight = 20;
            topicListBox.Location = new Point(0, 0);
            topicListBox.Name = "topicListBox";
            topicListBox.Size = new Size(333, 766);
            topicListBox.TabIndex = 0;
            topicListBox.SelectedIndexChanged += topicListBox_SelectedIndexChanged;
            // 
            // RightPanel
            // 
            RightPanel.Controls.Add(timerLabel);
            RightPanel.Controls.Add(timerTexbox);
            RightPanel.Controls.Add(setTimerCheckbox);
            RightPanel.Controls.Add(progressBar);
            RightPanel.Controls.Add(nextButton);
            RightPanel.Controls.Add(previousButton);
            RightPanel.Controls.Add(dButton);
            RightPanel.Controls.Add(cButton);
            RightPanel.Controls.Add(bButton);
            RightPanel.Controls.Add(aButton);
            RightPanel.Controls.Add(contentTexbox);
            RightPanel.Controls.Add(popupCheckbox);
            RightPanel.Controls.Add(romajiCheckbox);
            RightPanel.Controls.Add(learnRadio);
            RightPanel.Controls.Add(testRadio);
            RightPanel.Location = new Point(334, 1);
            RightPanel.Name = "RightPanel";
            RightPanel.Size = new Size(1030, 766);
            RightPanel.TabIndex = 1;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Location = new Point(823, 6);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(15, 20);
            timerLabel.TabIndex = 16;
            timerLabel.Text = "s";
            // 
            // timerTexbox
            // 
            timerTexbox.ImeMode = ImeMode.Off;
            timerTexbox.Location = new Point(773, 3);
            timerTexbox.Name = "timerTexbox";
            timerTexbox.Size = new Size(48, 27);
            timerTexbox.TabIndex = 15;
            timerTexbox.Text = "10";
            timerTexbox.TextChanged += timerTextbox_TextChanged;
            timerTexbox.KeyPress += timerTextbox_KeyPress;
            // 
            // setTimerCheckbox
            // 
            setTimerCheckbox.AutoSize = true;
            setTimerCheckbox.Location = new Point(603, 6);
            setTimerCheckbox.Name = "setTimerCheckbox";
            setTimerCheckbox.Size = new Size(164, 24);
            setTimerCheckbox.TabIndex = 14;
            setTimerCheckbox.Text = "Tự động chuyển câu";
            setTimerCheckbox.UseVisualStyleBackColor = true;
            setTimerCheckbox.CheckedChanged += setTimerCheckbox_CheckedChanged;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.White;
            progressBar.ForeColor = Color.Lime;
            progressBar.Location = new Point(5, 435);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1015, 10);
            progressBar.TabIndex = 12;
            progressBar.Visible = false;
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            nextButton.Location = new Point(517, 705);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(503, 46);
            nextButton.TabIndex = 11;
            nextButton.Text = ">>>>>";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // previousButton
            // 
            previousButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previousButton.Location = new Point(3, 705);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(503, 46);
            previousButton.TabIndex = 10;
            previousButton.Text = "<<<<<";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // dButton
            // 
            dButton.BackColor = Color.Transparent;
            dButton.BackgroundImageLayout = ImageLayout.None;
            dButton.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            dButton.Location = new Point(517, 586);
            dButton.Name = "dButton";
            dButton.Size = new Size(503, 113);
            dButton.TabIndex = 9;
            dButton.Text = "D";
            dButton.UseVisualStyleBackColor = false;
            dButton.Visible = false;
            dButton.Click += dButton_Click;
            // 
            // cButton
            // 
            cButton.BackColor = Color.Transparent;
            cButton.BackgroundImageLayout = ImageLayout.None;
            cButton.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            cButton.Location = new Point(3, 586);
            cButton.Name = "cButton";
            cButton.Size = new Size(503, 113);
            cButton.TabIndex = 8;
            cButton.Text = "C";
            cButton.UseVisualStyleBackColor = false;
            cButton.Visible = false;
            cButton.Click += cButton_Click;
            // 
            // bButton
            // 
            bButton.BackColor = Color.Transparent;
            bButton.BackgroundImageLayout = ImageLayout.None;
            bButton.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            bButton.Location = new Point(517, 467);
            bButton.Name = "bButton";
            bButton.Size = new Size(503, 113);
            bButton.TabIndex = 7;
            bButton.Text = "B";
            bButton.UseVisualStyleBackColor = false;
            bButton.Visible = false;
            bButton.Click += bButton_Click;
            // 
            // aButton
            // 
            aButton.BackColor = Color.Transparent;
            aButton.BackgroundImageLayout = ImageLayout.None;
            aButton.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            aButton.Location = new Point(3, 467);
            aButton.Name = "aButton";
            aButton.Size = new Size(503, 113);
            aButton.TabIndex = 6;
            aButton.Text = "A";
            aButton.UseVisualStyleBackColor = false;
            aButton.Visible = false;
            aButton.Click += aButton_Click;
            // 
            // contentTexbox
            // 
            contentTexbox.BorderStyle = BorderStyle.None;
            contentTexbox.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            contentTexbox.Location = new Point(5, 36);
            contentTexbox.Name = "contentTexbox";
            contentTexbox.Size = new Size(1015, 398);
            contentTexbox.TabIndex = 5;
            contentTexbox.Text = "";
            // 
            // popupCheckbox
            // 
            popupCheckbox.AutoSize = true;
            popupCheckbox.Location = new Point(459, 6);
            popupCheckbox.Name = "popupCheckbox";
            popupCheckbox.Size = new Size(138, 24);
            popupCheckbox.TabIndex = 4;
            popupCheckbox.Text = "Đổi sang popup";
            popupCheckbox.UseVisualStyleBackColor = true;
            popupCheckbox.CheckedChanged += PopupCheckbox_CheckedChanged;
            // 
            // romajiCheckbox
            // 
            romajiCheckbox.AutoSize = true;
            romajiCheckbox.Location = new Point(345, 6);
            romajiCheckbox.Name = "romajiCheckbox";
            romajiCheckbox.Size = new Size(108, 24);
            romajiCheckbox.TabIndex = 3;
            romajiCheckbox.Text = "Ẩn Romanji";
            romajiCheckbox.UseVisualStyleBackColor = true;
            romajiCheckbox.CheckedChanged += romajiCheckbox_CheckedChanged;
            // 
            // learnRadio
            // 
            learnRadio.AutoSize = true;
            learnRadio.Checked = true;
            learnRadio.Location = new Point(3, 3);
            learnRadio.Name = "learnRadio";
            learnRadio.Size = new Size(112, 24);
            learnRadio.TabIndex = 2;
            learnRadio.TabStop = true;
            learnRadio.Text = "Học từ vựng";
            learnRadio.UseVisualStyleBackColor = true;
            learnRadio.CheckedChanged += learnRadio_CheckedChanged;
            // 
            // testRadio
            // 
            testRadio.AutoSize = true;
            testRadio.Location = new Point(126, 3);
            testRadio.Name = "testRadio";
            testRadio.Size = new Size(133, 24);
            testRadio.TabIndex = 0;
            testRadio.Text = "Thi trắc nghiệm";
            testRadio.UseVisualStyleBackColor = true;
            testRadio.CheckedChanged += testRadio_CheckedChanged;
            // 
            // NihonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 768);
            Controls.Add(RightPanel);
            Controls.Add(LeftPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NihonForm";
            Text = "Learn Japanese";
            LeftPanel.ResumeLayout(false);
            RightPanel.ResumeLayout(false);
            RightPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel LeftPanel;
        private ListBox topicListBox;
        private Panel RightPanel;
        private RadioButton learnRadio;
        private RadioButton testRadio;
        private CheckBox romajiCheckbox;
        private CheckBox popupCheckbox;
        private RichTextBox contentTexbox;
        private Button aButton;
        private Button bButton;
        private Button dButton;
        private Button cButton;
        private Button previousButton;
        private Button nextButton;
        private ProgressBar progressBar;
        private CheckBox setTimerCheckbox;
        private Label timerLabel;
        private TextBox timerTexbox;
    }
}