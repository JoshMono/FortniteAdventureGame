namespace AdventureGame
{
    partial class FightingMinigame
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
            components = new System.ComponentModel.Container();
            player = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            gameBoxPicture = new PictureBox();
            label1 = new Label();
            slot6 = new PictureBox();
            slot4 = new PictureBox();
            slot2 = new PictureBox();
            slot5 = new PictureBox();
            slot3 = new PictureBox();
            slot1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gameBoxPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)slot1).BeginInit();
            SuspendLayout();
            // 
            // player
            // 
            player.BackgroundImage = Properties.Resources.bolt;
            player.BackgroundImageLayout = ImageLayout.Stretch;
            player.Location = new Point(463, 162);
            player.Name = "player";
            player.Size = new Size(65, 60);
            player.TabIndex = 0;
            player.TabStop = false;
            player.Click += pictureBox1_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += mainGameTimerEvent;
            // 
            // gameBoxPicture
            // 
            gameBoxPicture.BackColor = SystemColors.Control;
            gameBoxPicture.Location = new Point(216, 12);
            gameBoxPicture.Name = "gameBoxPicture";
            gameBoxPicture.Size = new Size(572, 426);
            gameBoxPicture.TabIndex = 1;
            gameBoxPicture.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 71);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 2;
            // 
            // slot6
            // 
            slot6.BackColor = SystemColors.ButtonHighlight;
            slot6.BackgroundImageLayout = ImageLayout.Stretch;
            slot6.Location = new Point(120, 293);
            slot6.Margin = new Padding(3, 4, 3, 4);
            slot6.Name = "slot6";
            slot6.Size = new Size(77, 80);
            slot6.TabIndex = 24;
            slot6.TabStop = false;
            // 
            // slot4
            // 
            slot4.BackColor = SystemColors.ButtonHighlight;
            slot4.BackgroundImageLayout = ImageLayout.Stretch;
            slot4.Location = new Point(120, 170);
            slot4.Margin = new Padding(3, 4, 3, 4);
            slot4.Name = "slot4";
            slot4.Size = new Size(77, 80);
            slot4.TabIndex = 23;
            slot4.TabStop = false;
            // 
            // slot2
            // 
            slot2.BackColor = SystemColors.ButtonHighlight;
            slot2.BackgroundImageLayout = ImageLayout.Stretch;
            slot2.Location = new Point(120, 54);
            slot2.Margin = new Padding(3, 4, 3, 4);
            slot2.Name = "slot2";
            slot2.Size = new Size(77, 80);
            slot2.TabIndex = 22;
            slot2.TabStop = false;
            // 
            // slot5
            // 
            slot5.BackColor = SystemColors.ButtonHighlight;
            slot5.BackgroundImageLayout = ImageLayout.Stretch;
            slot5.Location = new Point(12, 293);
            slot5.Margin = new Padding(3, 4, 3, 4);
            slot5.Name = "slot5";
            slot5.Size = new Size(77, 80);
            slot5.TabIndex = 21;
            slot5.TabStop = false;
            // 
            // slot3
            // 
            slot3.BackColor = SystemColors.ButtonHighlight;
            slot3.BackgroundImageLayout = ImageLayout.Stretch;
            slot3.Location = new Point(12, 170);
            slot3.Margin = new Padding(3, 4, 3, 4);
            slot3.Name = "slot3";
            slot3.Size = new Size(77, 80);
            slot3.TabIndex = 20;
            slot3.TabStop = false;
            // 
            // slot1
            // 
            slot1.BackColor = SystemColors.ButtonHighlight;
            slot1.BackgroundImageLayout = ImageLayout.Stretch;
            slot1.Location = new Point(12, 54);
            slot1.Margin = new Padding(3, 4, 3, 4);
            slot1.Name = "slot1";
            slot1.Size = new Size(77, 80);
            slot1.TabIndex = 19;
            slot1.TabStop = false;
            // 
            // FightingMinigame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(slot6);
            Controls.Add(slot4);
            Controls.Add(slot2);
            Controls.Add(slot5);
            Controls.Add(slot3);
            Controls.Add(slot1);
            Controls.Add(label1);
            Controls.Add(player);
            Controls.Add(gameBoxPicture);
            Name = "FightingMinigame";
            Text = "FightingMinigame";
            KeyDown += FightingMinigame_KeyDown;
            KeyPress += FightingMinigame_KeyPress;
            KeyUp += FightingMinigame_KeyUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)gameBoxPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot6).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot4).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot2).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot5).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot3).EndInit();
            ((System.ComponentModel.ISupportInitialize)slot1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private PictureBox gameBoxPicture;
        private Button button1;
        private Label label1;
        private PictureBox slot6;
        private PictureBox slot4;
        private PictureBox slot2;
        private PictureBox slot5;
        private PictureBox slot3;
        private PictureBox slot1;
    }
}