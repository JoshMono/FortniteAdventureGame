namespace AdventureGame
{
    partial class Lobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lobby));
            lobbyBTN = new Button();
            lockerBTN = new Button();
            shopBTN = new Button();
            settingsBTN = new Button();
            settingsPannel = new Panel();
            zBucksLabel = new Label();
            pictureBox2 = new PictureBox();
            playBTN = new Button();
            lockerPannel = new Panel();
            skinAvaterIMG = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)skinAvaterIMG).BeginInit();
            SuspendLayout();
            // 
            // lobbyBTN
            // 
            lobbyBTN.BackColor = Color.FromArgb(255, 255, 128);
            lobbyBTN.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            lobbyBTN.FlatAppearance.BorderSize = 2;
            lobbyBTN.FlatStyle = FlatStyle.Flat;
            lobbyBTN.Font = new Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lobbyBTN.ForeColor = Color.Black;
            lobbyBTN.Location = new Point(227, 25);
            lobbyBTN.Name = "lobbyBTN";
            lobbyBTN.Size = new Size(114, 51);
            lobbyBTN.TabIndex = 0;
            lobbyBTN.Text = "Lobby";
            lobbyBTN.UseVisualStyleBackColor = false;
            lobbyBTN.Click += lobbyBTN_Click;
            // 
            // lockerBTN
            // 
            lockerBTN.BackColor = Color.Transparent;
            lockerBTN.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            lockerBTN.FlatAppearance.BorderSize = 2;
            lockerBTN.FlatStyle = FlatStyle.Flat;
            lockerBTN.Font = new Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lockerBTN.ForeColor = Color.Black;
            lockerBTN.Location = new Point(341, 25);
            lockerBTN.Name = "lockerBTN";
            lockerBTN.Size = new Size(114, 51);
            lockerBTN.TabIndex = 1;
            lockerBTN.Text = "Locker";
            lockerBTN.UseVisualStyleBackColor = false;
            lockerBTN.Click += lockerBTN_Click;
            // 
            // shopBTN
            // 
            shopBTN.BackColor = Color.Transparent;
            shopBTN.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            shopBTN.FlatAppearance.BorderSize = 2;
            shopBTN.FlatStyle = FlatStyle.Flat;
            shopBTN.Font = new Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            shopBTN.ForeColor = Color.Black;
            shopBTN.Location = new Point(453, 25);
            shopBTN.Name = "shopBTN";
            shopBTN.Size = new Size(114, 51);
            shopBTN.TabIndex = 2;
            shopBTN.Text = "Shop";
            shopBTN.UseVisualStyleBackColor = false;
            // 
            // settingsBTN
            // 
            settingsBTN.BackColor = Color.FromArgb(0, 0, 192);
            settingsBTN.BackgroundImage = Properties.Resources._4619355_200;
            settingsBTN.BackgroundImageLayout = ImageLayout.Stretch;
            settingsBTN.FlatAppearance.BorderColor = Color.MidnightBlue;
            settingsBTN.FlatAppearance.BorderSize = 2;
            settingsBTN.FlatStyle = FlatStyle.Flat;
            settingsBTN.Font = new Font("Franklin Gothic Demi Cond", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            settingsBTN.ForeColor = Color.Black;
            settingsBTN.Location = new Point(21, 25);
            settingsBTN.Name = "settingsBTN";
            settingsBTN.Size = new Size(45, 51);
            settingsBTN.TabIndex = 3;
            settingsBTN.UseVisualStyleBackColor = false;
            settingsBTN.Click += settingsBTN_Click;
            // 
            // settingsPannel
            // 
            settingsPannel.Location = new Point(0, 0);
            settingsPannel.Name = "settingsPannel";
            settingsPannel.Size = new Size(205, 459);
            settingsPannel.TabIndex = 4;
            settingsPannel.Visible = false;
            // 
            // zBucksLabel
            // 
            zBucksLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            zBucksLabel.FlatStyle = FlatStyle.Flat;
            zBucksLabel.Font = new Font("Franklin Gothic Heavy", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            zBucksLabel.Location = new Point(713, 19);
            zBucksLabel.Name = "zBucksLabel";
            zBucksLabel.Size = new Size(85, 44);
            zBucksLabel.TabIndex = 1;
            zBucksLabel.Text = "0";
            zBucksLabel.TextAlign = ContentAlignment.MiddleLeft;
            zBucksLabel.Click += label1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.download__4_;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(661, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 55);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // playBTN
            // 
            playBTN.BackColor = Color.Yellow;
            playBTN.Font = new Font("Franklin Gothic Heavy", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            playBTN.Location = new Point(563, 353);
            playBTN.Name = "playBTN";
            playBTN.Size = new Size(225, 93);
            playBTN.TabIndex = 6;
            playBTN.Text = "Play";
            playBTN.UseVisualStyleBackColor = false;
            playBTN.Click += playBTN_Click;
            // 
            // lockerPannel
            // 
            lockerPannel.Location = new Point(15, 82);
            lockerPannel.Name = "lockerPannel";
            lockerPannel.Size = new Size(778, 364);
            lockerPannel.TabIndex = 7;
            lockerPannel.Visible = false;
            // 
            // skinAvaterIMG
            // 
            skinAvaterIMG.BackColor = Color.Transparent;
            skinAvaterIMG.BackgroundImage = Properties.Resources.download;
            skinAvaterIMG.BackgroundImageLayout = ImageLayout.Stretch;
            skinAvaterIMG.Location = new Point(329, 152);
            skinAvaterIMG.Name = "skinAvaterIMG";
            skinAvaterIMG.Size = new Size(163, 254);
            skinAvaterIMG.TabIndex = 0;
            skinAvaterIMG.TabStop = false;
            // 
            // Lobby
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.lobbyBG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(801, 453);
            Controls.Add(skinAvaterIMG);
            Controls.Add(settingsBTN);
            Controls.Add(settingsPannel);
            Controls.Add(lockerPannel);
            Controls.Add(zBucksLabel);
            Controls.Add(playBTN);
            Controls.Add(pictureBox2);
            Controls.Add(shopBTN);
            Controls.Add(lockerBTN);
            Controls.Add(lobbyBTN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Lobby";
            Text = "Lobby";
            Load += Lobby_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)skinAvaterIMG).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button lobbyBTN;
        private Button lockerBTN;
        private Button shopBTN;
        private Button settingsBTN;
        private Panel settingsPannel;
        private Button playBTN;
        private PictureBox pictureBox2;
        private Label zBucksLabel;
        private Panel lockerPannel;
        private PictureBox skinAvaterIMG;
    }
}