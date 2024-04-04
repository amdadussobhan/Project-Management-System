namespace Skill_PMS.UI_WinForm.admin_Panel
{
    partial class AdminPanel
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
            this.Tmr_Count = new System.Windows.Forms.Timer(this.components);
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Tmr_Count
            // 
            this.Tmr_Count.Enabled = true;
            this.Tmr_Count.Interval = 22222;
            this.Tmr_Count.Tick += new System.EventHandler(this.Tmr_Count_Tick);
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.AutoSize = true;
            this.Lbl_Title.Font = new System.Drawing.Font("Comic Sans MS", 18.25F);
            this.Lbl_Title.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Title.Location = new System.Drawing.Point(22, 17);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(306, 34);
            this.Lbl_Title.TabIndex = 1;
            this.Lbl_Title.Text = "Report Generating Now...";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(340, 71);
            this.Controls.Add(this.Lbl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Sync";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanel_FormClosed);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Tmr_Count;
        private System.Windows.Forms.Label Lbl_Title;
    }
}