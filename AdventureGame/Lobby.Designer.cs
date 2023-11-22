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
            itemShopPannel = new Panel();
            skinAvaterIMG = new PictureBox();
            winsLabel = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            lockerPannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinAvaterIMG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            lobbyBTN.Location = new Point(238, 17);
            lobbyBTN.Margin = new Padding(3, 2, 3, 2);
            lobbyBTN.Name = "lobbyBTN";
            lobbyBTN.Size = new Size(100, 38);
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
            lockerBTN.Location = new Point(337, 17);
            lockerBTN.Margin = new Padding(3, 2, 3, 2);
            lockerBTN.Name = "lockerBTN";
            lockerBTN.Size = new Size(100, 38);
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
            shopBTN.Location = new Point(435, 17);
            shopBTN.Margin = new Padding(3, 2, 3, 2);
            shopBTN.Name = "shopBTN";
            shopBTN.Size = new Size(100, 38);
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
            settingsBTN.Location = new Point(18, 19);
            settingsBTN.Margin = new Padding(3, 2, 3, 2);
            settingsBTN.Name = "settingsBTN";
            settingsBTN.Size = new Size(39, 38);
            settingsBTN.TabIndex = 3;
            settingsBTN.UseVisualStyleBackColor = false;
            settingsBTN.Click += settingsBTN_Click;
            // 
            // settingsPannel
            // 
            settingsPannel.Location = new Point(0, 0);
            settingsPannel.Margin = new Padding(3, 2, 3, 2);
            settingsPannel.Name = "settingsPannel";
            settingsPannel.Size = new Size(179, 344);
            settingsPannel.TabIndex = 4;
            settingsPannel.Visible = false;
            // 
            // zBucksLabel
            // 
            zBucksLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            zBucksLabel.FlatStyle = FlatStyle.Flat;
            zBucksLabel.Font = new Font("Franklin Gothic Heavy", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            zBucksLabel.Location = new Point(624, 14);
            zBucksLabel.Name = "zBucksLabel";
            zBucksLabel.Size = new Size(74, 33);
            zBucksLabel.TabIndex = 1;
            zBucksLabel.Text = "0";
            zBucksLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.download__4_;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(578, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 41);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // playBTN
            // 
            playBTN.BackColor = Color.Yellow;
            playBTN.Font = new Font("Franklin Gothic Heavy", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            playBTN.Location = new Point(493, 265);
            playBTN.Margin = new Padding(3, 2, 3, 2);
            playBTN.Name = "playBTN";
            playBTN.Size = new Size(197, 70);
            playBTN.TabIndex = 6;
            playBTN.Text = "Play";
            playBTN.UseVisualStyleBackColor = false;
            playBTN.Click += playBTN_Click;
            // 
            // lockerPannel
            // 
            lockerPannel.Controls.Add(itemShopPannel);
            lockerPannel.Location = new Point(13, 62);
            lockerPannel.Margin = new Padding(3, 2, 3, 2);
            lockerPannel.Name = "lockerPannel";
            lockerPannel.Size = new Size(681, 273);
            lockerPannel.TabIndex = 7;
            lockerPannel.Visible = false;
            // 
            // itemShopPannel
            // 
            itemShopPannel.Location = new Point(-1, 0);
            itemShopPannel.Margin = new Padding(3, 2, 3, 2);
            itemShopPannel.Name = "itemShopPannel";
            itemShopPannel.Size = new Size(681, 273);
            itemShopPannel.TabIndex = 8;
            itemShopPannel.Visible = false;

            // 
            // skinAvaterIMG
            // 
            skinAvaterIMG.BackColor = Color.Transparent;
            skinAvaterIMG.BackgroundImageLayout = ImageLayout.Stretch;
            skinAvaterIMG.Location = new Point(289, 141);
            skinAvaterIMG.Margin = new Padding(3, 2, 3, 2);
            skinAvaterIMG.Name = "skinAvaterIMG";
            skinAvaterIMG.Size = new Size(131, 159);
            skinAvaterIMG.TabIndex = 0;
            skinAvaterIMG.TabStop = false;
            // 
            // winsLabel
            // 
            winsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            winsLabel.FlatStyle = FlatStyle.Flat;
            winsLabel.Font = new Font("Franklin Gothic Heavy", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            winsLabel.Location = new Point(172, 22);
            winsLabel.Name = "winsLabel";
            winsLabel.Size = new Size(46, 33);
            winsLabel.TabIndex = 9;
            winsLabel.Text = "0";
            winsLabel.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.winsIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(63, 17);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(106, 41);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;

            // 
            // Lobby
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.lobbyBG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(701, 340);
            Controls.Add(settingsBTN);
            Controls.Add(settingsPannel);
            Controls.Add(winsLabel);
            Controls.Add(pictureBox1);
            Controls.Add(skinAvaterIMG);
            Controls.Add(lockerPannel);
            Controls.Add(zBucksLabel);
            Controls.Add(playBTN);
            Controls.Add(pictureBox2);
            Controls.Add(shopBTN);
            Controls.Add(lockerBTN);
            Controls.Add(lobbyBTN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Lobby";
            Text = "Lobby";

            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            lockerPannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)skinAvaterIMG).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private Panel itemShopPannel;
        private Label winsLabel;
        private PictureBox pictureBox1;
    }
}