
namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    partial class QC_Progress
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
            this.components = new System.ComponentModel.Container();
            this.Prb_Copier = new System.Windows.Forms.ProgressBar();
            this.Tmr_Count = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Prb_Copier
            // 
            this.Prb_Copier.Location = new System.Drawing.Point(7, 11);
            this.Prb_Copier.Name = "Prb_Copier";
            this.Prb_Copier.Size = new System.Drawing.Size(400, 15);
            this.Prb_Copier.TabIndex = 6;
            // 
            // Tmr_Count
            // 
            this.Tmr_Count.Enabled = true;
            this.Tmr_Count.Interval = 3000;
            this.Tmr_Count.Tick += new System.EventHandler(this.Tmr_Count_Tick);
            // 
            // QC_Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(415, 37);
            this.Controls.Add(this.Prb_Copier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(1490, 950);
            this.MaximizeBox = false;
            this.Name = "QC_Progress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "QC_Progress";
            this.Load += new System.EventHandler(this.QC_Progress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Prb_Copier;
        private System.Windows.Forms.Timer Tmr_Count;
    }
}