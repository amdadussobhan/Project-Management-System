namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class SavingProgress
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
            this.Prb_Copier = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Prb_Copier
            // 
            this.Prb_Copier.Location = new System.Drawing.Point(10, 13);
            this.Prb_Copier.Name = "Prb_Copier";
            this.Prb_Copier.Size = new System.Drawing.Size(400, 15);
            this.Prb_Copier.TabIndex = 5;
            // 
            // Saving_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(419, 41);
            this.Controls.Add(this.Prb_Copier);
            this.Location = new System.Drawing.Point(1490, 950);
            this.MaximizeBox = false;
            this.Name = "SavingProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Saving_Progress";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Saving_Progress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Prb_Copier;
    }
}