namespace AdventureGame
{
    partial class Locker
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
            defaultSkinBTN = new Button();
            skullTrooperBTN = new Button();
            SuspendLayout();
            // 
            // defaultSkinBTN
            // 
            defaultSkinBTN.BackColor = Color.Gray;
            defaultSkinBTN.BackgroundImage = Properties.Resources.defaultSkin;
            defaultSkinBTN.BackgroundImageLayout = ImageLayout.Stretch;
            defaultSkinBTN.ForeColor = SystemColors.ActiveCaptionText;
            defaultSkinBTN.Location = new Point(24, 21);
            defaultSkinBTN.Margin = new Padding(3, 2, 3, 2);
            defaultSkinBTN.Name = "defaultSkinBTN";
            defaultSkinBTN.Size = new Size(105, 128);
            defaultSkinBTN.TabIndex = 0;
            defaultSkinBTN.UseVisualStyleBackColor = false;
            defaultSkinBTN.Click += deafaultSkinBTN_Click;
            // 
            // skullTrooperBTN
            // 
            skullTrooperBTN.BackColor = Color.Gray;
            skullTrooperBTN.BackgroundImage = Properties.Resources.skullTrooper;
            skullTrooperBTN.BackgroundImageLayout = ImageLayout.Stretch;
            skullTrooperBTN.Font = new Font("Franklin Gothic Heavy", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            skullTrooperBTN.ForeColor = Color.DeepSkyBlue;
            skullTrooperBTN.Image = Properties.Resources.lockIcon;
            skullTrooperBTN.Location = new Point(549, 21);
            skullTrooperBTN.Margin = new Padding(3, 2, 3, 2);
            skullTrooperBTN.Name = "skullTrooperBTN";
            skullTrooperBTN.Size = new Size(105, 128);
            skullTrooperBTN.TabIndex = 1;
            skullTrooperBTN.Text = "Need 5 Wins";
            skullTrooperBTN.UseVisualStyleBackColor = false;
            skullTrooperBTN.Click += skullTrooperBTN_Click;
            // 
            // Locker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(679, 338);
            Controls.Add(skullTrooperBTN);
            Controls.Add(defaultSkinBTN);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Locker";
            Text = "Locker";
            ResumeLayout(false);
        }

        #endregion

        private Button defaultSkinBTN;
        private Button skullTrooperBTN;
    }
}