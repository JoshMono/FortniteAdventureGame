namespace AdventureGame
{
    partial class Settings
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
            sadasd = new Label();
            musicOn = new CheckBox();
            SuspendLayout();
            // 
            // sadasd
            // 
            sadasd.AutoSize = true;
            sadasd.Font = new Font("Franklin Gothic Heavy", 18F, FontStyle.Regular, GraphicsUnit.Point);
            sadasd.Location = new Point(11, 89);
            sadasd.Name = "sadasd";
            sadasd.Size = new Size(101, 38);
            sadasd.TabIndex = 0;
            sadasd.Text = "Music";
            // 
            // musicOn
            // 
            musicOn.Checked = true;
            musicOn.CheckState = CheckState.Checked;
            musicOn.Font = new Font("Franklin Gothic Heavy", 18F, FontStyle.Regular, GraphicsUnit.Point);
            musicOn.Location = new Point(141, 101);
            musicOn.Margin = new Padding(3, 4, 3, 4);
            musicOn.Name = "musicOn";
            musicOn.Size = new Size(45, 20);
            musicOn.TabIndex = 1;
            musicOn.UseVisualStyleBackColor = true;
            musicOn.CheckedChanged += musicOn_CheckedChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(213, 451);
            Controls.Add(musicOn);
            Controls.Add(sadasd);
            MaximizeBox = false;
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sadasd;
        private CheckBox musicOn;
    }
}