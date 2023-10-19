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
            defaultSkinBTN.BackgroundImage = Properties.Resources.default_skin;
            defaultSkinBTN.BackgroundImageLayout = ImageLayout.Stretch;
            defaultSkinBTN.ForeColor = SystemColors.ActiveCaptionText;
            defaultSkinBTN.Location = new Point(28, 28);
            defaultSkinBTN.Name = "defaultSkinBTN";
            defaultSkinBTN.Size = new Size(120, 170);
            defaultSkinBTN.TabIndex = 0;
            defaultSkinBTN.UseVisualStyleBackColor = true;
            defaultSkinBTN.Click += renegaterBTN_Click;
            // 
            // skullTrooperBTN
            // 
            skullTrooperBTN.BackgroundImage = Properties.Resources.skull_trooper;
            skullTrooperBTN.BackgroundImageLayout = ImageLayout.Stretch;
            skullTrooperBTN.ForeColor = SystemColors.ActiveCaptionText;
            skullTrooperBTN.Location = new Point(627, 28);
            skullTrooperBTN.Name = "skullTrooperBTN";
            skullTrooperBTN.Size = new Size(120, 170);
            skullTrooperBTN.TabIndex = 1;
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
            Controls.Add(defaultSkinBTN);
            Name = "Locker";
            Text = "Locker";
            ResumeLayout(false);
        }

        #endregion

        private Button defaultSkinBTN;
        private Button skullTrooperBTN;
    }
}