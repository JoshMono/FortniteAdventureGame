namespace AdventureGame
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            BattleRoyalBTN = new Button();
            SaveWorldBTN = new Button();
            checkBox1 = new CheckBox();
            ipAdress = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 33);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(189, 37);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Franklin Gothic Heavy", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(165, 53);
            label3.Name = "label3";
            label3.Size = new Size(490, 47);
            label3.TabIndex = 2;
            label3.Text = "Fortnite Adventure Game";
            // 
            // BattleRoyalBTN
            // 
            BattleRoyalBTN.BackColor = Color.Khaki;
            BattleRoyalBTN.Font = new Font("Franklin Gothic Heavy", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            BattleRoyalBTN.Location = new Point(190, 189);
            BattleRoyalBTN.Name = "BattleRoyalBTN";
            BattleRoyalBTN.Size = new Size(198, 71);
            BattleRoyalBTN.TabIndex = 3;
            BattleRoyalBTN.Text = "Battle Royal";
            BattleRoyalBTN.UseVisualStyleBackColor = false;
            BattleRoyalBTN.Click += BattleRoyalBTN_Click;
            // 
            // SaveWorldBTN
            // 
            SaveWorldBTN.BackColor = Color.Khaki;
            SaveWorldBTN.Font = new Font("Franklin Gothic Heavy", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            SaveWorldBTN.Location = new Point(437, 189);
            SaveWorldBTN.Name = "SaveWorldBTN";
            SaveWorldBTN.Size = new Size(194, 71);
            SaveWorldBTN.TabIndex = 4;
            SaveWorldBTN.Text = "Save The World";
            SaveWorldBTN.UseVisualStyleBackColor = false;
            SaveWorldBTN.Click += SaveWorldBTN_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(437, 128);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(101, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ipAdress
            // 
            ipAdress.Location = new Point(437, 159);
            ipAdress.Name = "ipAdress";
            ipAdress.Size = new Size(194, 27);
            ipAdress.TabIndex = 6;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            BackgroundImage = Properties.Resources.download__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 451);
            Controls.Add(ipAdress);
            Controls.Add(checkBox1);
            Controls.Add(SaveWorldBTN);
            Controls.Add(BattleRoyalBTN);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenu";
            Text = " ";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button BattleRoyalBTN;
        private Button SaveWorldBTN;
        private CheckBox checkBox1;
        private TextBox ipAdress;
    }
}