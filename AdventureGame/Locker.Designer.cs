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
            renegaterBTN = new Button();
            skullTrooperBTN = new Button();
            SuspendLayout();
            // 
            // renegaterBTN
            // 
            renegaterBTN.BackgroundImage = Properties.Resources.renegadetorSkin;
            renegaterBTN.BackgroundImageLayout = ImageLayout.Stretch;
            renegaterBTN.ForeColor = SystemColors.ActiveCaptionText;
            renegaterBTN.Location = new Point(12, 45);
            renegaterBTN.Name = "renegaterBTN";
            renegaterBTN.Size = new Size(106, 137);
            renegaterBTN.TabIndex = 0;
            renegaterBTN.Text = "Renegater";
            renegaterBTN.UseVisualStyleBackColor = true;
            renegaterBTN.Click += renegaterBTN_Click;
            // 
            // skullTrooperBTN
            // 
            skullTrooperBTN.BackgroundImage = Properties.Resources.download;
            skullTrooperBTN.BackgroundImageLayout = ImageLayout.Stretch;
            skullTrooperBTN.ForeColor = SystemColors.ActiveCaptionText;
            skullTrooperBTN.Location = new Point(656, 45);
            skullTrooperBTN.Name = "skullTrooperBTN";
            skullTrooperBTN.Size = new Size(106, 137);
            skullTrooperBTN.TabIndex = 1;
            skullTrooperBTN.Text = "Skull Trooper";
            skullTrooperBTN.UseVisualStyleBackColor = true;
            skullTrooperBTN.Click += skullTrooperBTN_Click;
            // 
            // Locker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(776, 450);
            Controls.Add(skullTrooperBTN);
            Controls.Add(renegaterBTN);
            Name = "Locker";
            Text = "Locker";
            ResumeLayout(false);
        }

        #endregion

        private Button renegaterBTN;
        private Button skullTrooperBTN;
    }
}