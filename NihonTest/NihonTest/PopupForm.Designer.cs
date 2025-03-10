namespace NihonTest
{
    partial class PopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            contentTexbox = new RichTextBox();
            progressBar = new ProgressBar();
            aButton = new Button();
            bButton = new Button();
            cButton = new Button();
            dButton = new Button();
            previousButton = new Button();
            nextButton = new Button();
            SuspendLayout();
            // 
            // contentTexbox
            // 
            contentTexbox.BorderStyle = BorderStyle.None;
            contentTexbox.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            contentTexbox.Location = new Point(0, 0);
            contentTexbox.Name = "contentTexbox";
            contentTexbox.Size = new Size(613, 250);
            contentTexbox.TabIndex = 5;
            contentTexbox.Text = "";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(613, 189);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(386, 14);
            progressBar.TabIndex = 1;
            progressBar.Visible = false;
            // 
            // aButton
            // 
            aButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            aButton.Location = new Point(612, 0);
            aButton.Name = "aButton";
            aButton.Size = new Size(388, 50);
            aButton.TabIndex = 2;
            aButton.Text = "A";
            aButton.UseVisualStyleBackColor = true;
            aButton.Click += aButton_Click;
            // 
            // bButton
            // 
            bButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bButton.Location = new Point(612, 48);
            bButton.Name = "bButton";
            bButton.Size = new Size(388, 50);
            bButton.TabIndex = 3;
            bButton.Text = "B";
            bButton.UseVisualStyleBackColor = true;
            bButton.Click += bButton_Click;
            // 
            // cButton
            // 
            cButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cButton.Location = new Point(612, 96);
            cButton.Name = "cButton";
            cButton.Size = new Size(388, 50);
            cButton.TabIndex = 4;
            cButton.Text = "C";
            cButton.UseVisualStyleBackColor = true;
            cButton.Click += cButton_Click;
            // 
            // dButton
            // 
            dButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dButton.Location = new Point(612, 144);
            dButton.Name = "dButton";
            dButton.Size = new Size(388, 50);
            dButton.TabIndex = 5;
            dButton.Text = "D";
            dButton.UseVisualStyleBackColor = true;
            dButton.Click += dButton_Click;
            // 
            // previousButton
            // 
            previousButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previousButton.Location = new Point(612, 202);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(194, 48);
            previousButton.TabIndex = 6;
            previousButton.Text = "<<<<<";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            nextButton.Location = new Point(806, 202);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(194, 48);
            nextButton.TabIndex = 7;
            nextButton.Text = ">>>>>";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // PopupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 250);
            Controls.Add(nextButton);
            Controls.Add(previousButton);
            Controls.Add(dButton);
            Controls.Add(cButton);
            Controls.Add(bButton);
            Controls.Add(aButton);
            Controls.Add(progressBar);
            Controls.Add(contentTexbox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PopupForm";
            Text = "PopupForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox contentTexbox;
        private ProgressBar progressBar;
        private Button aButton;
        private Button bButton;
        private Button cButton;
        private Button dButton;
        private Button previousButton;
        private Button nextButton;
    }
}