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
            label1.Location = new Point(186, 25);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(165, 28);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Franklin Gothic Heavy", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(144, 40);
            label3.Name = "label3";
            label3.Size = new Size(396, 37);
            label3.TabIndex = 2;
            label3.Text = "Fortnite Adventure Game";
            // 
            // BattleRoyalBTN
            // 
            BattleRoyalBTN.BackColor = Color.Khaki;
            BattleRoyalBTN.Font = new Font("Franklin Gothic Heavy", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            BattleRoyalBTN.Location = new Point(251, 142);
            BattleRoyalBTN.Margin = new Padding(3, 2, 3, 2);
            BattleRoyalBTN.Name = "BattleRoyalBTN";
            BattleRoyalBTN.Size = new Size(173, 53);
            BattleRoyalBTN.TabIndex = 3;
            BattleRoyalBTN.Text = "Battle Royal";
            BattleRoyalBTN.UseVisualStyleBackColor = false;
            BattleRoyalBTN.Click += BattleRoyalBTN_Click;
            // 
            // SaveWorldBTN
            // 
            SaveWorldBTN.BackColor = Color.Khaki;
            SaveWorldBTN.Font = new Font("Franklin Gothic Heavy", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            SaveWorldBTN.Location = new Point(382, 142);
            SaveWorldBTN.Margin = new Padding(3, 2, 3, 2);
            SaveWorldBTN.Name = "SaveWorldBTN";
            SaveWorldBTN.Size = new Size(170, 53);
            SaveWorldBTN.TabIndex = 4;
            SaveWorldBTN.Text = "Save The World";
            SaveWorldBTN.UseVisualStyleBackColor = false;
            SaveWorldBTN.Visible = false;
            SaveWorldBTN.Click += SaveWorldBTN_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(382, 96);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // ipAdress
            // 
            ipAdress.Location = new Point(382, 119);
            ipAdress.Margin = new Padding(3, 2, 3, 2);
            ipAdress.Name = "ipAdress";
            ipAdress.Size = new Size(170, 23);
            ipAdress.TabIndex = 6;
            ipAdress.Visible = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            BackgroundImage = Properties.Resources.download__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(700, 338);
            Controls.Add(ipAdress);
            Controls.Add(checkBox1);
            Controls.Add(SaveWorldBTN);
            Controls.Add(BattleRoyalBTN);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
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