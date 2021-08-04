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
            this.components = new System.ComponentModel.Container();
            this.Prb_Copier = new System.Windows.Forms.ProgressBar();
            this.Lbl_Success = new System.Windows.Forms.Label();
            this.Tmr_Close = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Copy = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Prb_Copier
            // 
            this.Prb_Copier.Location = new System.Drawing.Point(10, 15);
            this.Prb_Copier.Name = "Prb_Copier";
            this.Prb_Copier.Size = new System.Drawing.Size(400, 15);
            this.Prb_Copier.TabIndex = 5;
            // 
            // Lbl_Success
            // 
            this.Lbl_Success.AutoSize = true;
            this.Lbl_Success.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Lbl_Success.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Lbl_Success.ForeColor = System.Drawing.Color.Green;
            this.Lbl_Success.Location = new System.Drawing.Point(120, 10);
            this.Lbl_Success.Name = "Lbl_Success";
            this.Lbl_Success.Size = new System.Drawing.Size(176, 24);
            this.Lbl_Success.TabIndex = 396;
            this.Lbl_Success.Text = "File Saved Success";
            this.Lbl_Success.Visible = false;
            // 
            // Tmr_Close
            // 
            this.Tmr_Close.Interval = 3333;
            this.Tmr_Close.Tick += new System.EventHandler(this.Tmr_Close_Tick);
            // 
            // Tmr_Copy
            // 
            this.Tmr_Copy.Interval = 33333;
            this.Tmr_Copy.Tick += new System.EventHandler(this.Tmr_Copy_Tick);
            // 
            // SavingProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(420, 42);
            this.Controls.Add(this.Lbl_Success);
            this.Controls.Add(this.Prb_Copier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(1490, 950);
            this.MaximizeBox = false;
            this.Name = "SavingProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Saving_Progress";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Saving_Progress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar Prb_Copier;
        private System.Windows.Forms.Label Lbl_Success;
        private System.Windows.Forms.Timer Tmr_Close;
        private System.Windows.Forms.Timer Tmr_Copy;
    }
}