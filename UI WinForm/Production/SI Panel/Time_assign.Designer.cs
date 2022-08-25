
namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    partial class Time_assign
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
            this.Prb_Assign = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Prb_Assign
            // 
            this.Prb_Assign.Location = new System.Drawing.Point(10, 15);
            this.Prb_Assign.Name = "Prb_Assign";
            this.Prb_Assign.Size = new System.Drawing.Size(400, 15);
            this.Prb_Assign.TabIndex = 6;
            // 
            // Time_assign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(420, 42);
            this.Controls.Add(this.Prb_Assign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(1490, 950);
            this.MaximizeBox = false;
            this.Name = "Time_assign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Time_assign";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Time_assign_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Prb_Assign;
    }
}