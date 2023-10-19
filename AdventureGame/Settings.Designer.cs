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
            musicVolumeSlider = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)musicVolumeSlider).BeginInit();
            SuspendLayout();
            // 
            // sadasd
            // 
            sadasd.AutoSize = true;
            sadasd.Font = new Font("Franklin Gothic Heavy", 18F, FontStyle.Regular, GraphicsUnit.Point);
            sadasd.Location = new Point(10, 67);
            sadasd.Name = "sadasd";
            sadasd.Size = new Size(80, 30);
            sadasd.TabIndex = 0;
            sadasd.Text = "Music";
            // 
            // musicOn
            // 
            musicOn.Checked = true;
            musicOn.CheckState = CheckState.Checked;
            musicOn.Font = new Font("Franklin Gothic Heavy", 18F, FontStyle.Regular, GraphicsUnit.Point);
            musicOn.Location = new Point(123, 76);
            musicOn.Name = "musicOn";
            musicOn.Size = new Size(39, 15);
            musicOn.TabIndex = 1;
            musicOn.UseVisualStyleBackColor = true;
            musicOn.CheckedChanged += musicOn_CheckedChanged;
            // 
            // musicVolumeSlider
            // 
            musicVolumeSlider.BackColor = SystemColors.HotTrack;
            musicVolumeSlider.Location = new Point(10, 100);
            musicVolumeSlider.Name = "musicVolumeSlider";
            musicVolumeSlider.Size = new Size(164, 45);
            musicVolumeSlider.TabIndex = 2;
            musicVolumeSlider.TickStyle = TickStyle.None;
            musicVolumeSlider.Scroll += musicVolumeSlider_Scroll;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(186, 338);
            Controls.Add(musicVolumeSlider);
            Controls.Add(musicOn);
            Controls.Add(sadasd);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Settings";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)musicVolumeSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sadasd;
        private CheckBox musicOn;
        private TrackBar musicVolumeSlider;
    }
}