
namespace Skill_PMS
{
    partial class Rename
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
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.Btn_Backup = new System.Windows.Forms.Button();
            this.Btn_Restore = new System.Windows.Forms.Button();
            this.Cmb_Job_ID = new System.Windows.Forms.ComboBox();
            this.Lbl_Job_ID = new System.Windows.Forms.Label();
            this.Prb_Rename = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Txt_Location.Location = new System.Drawing.Point(75, 88);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(634, 29);
            this.Txt_Location.TabIndex = 0;
            // 
            // Btn_Backup
            // 
            this.Btn_Backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Backup.Location = new System.Drawing.Point(75, 138);
            this.Btn_Backup.Name = "Btn_Backup";
            this.Btn_Backup.Size = new System.Drawing.Size(150, 35);
            this.Btn_Backup.TabIndex = 1;
            this.Btn_Backup.Text = "Backup";
            this.Btn_Backup.UseVisualStyleBackColor = true;
            this.Btn_Backup.Click += new System.EventHandler(this.Btn_Backup_Click);
            // 
            // Btn_Restore
            // 
            this.Btn_Restore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Restore.Location = new System.Drawing.Point(559, 138);
            this.Btn_Restore.Name = "Btn_Restore";
            this.Btn_Restore.Size = new System.Drawing.Size(150, 35);
            this.Btn_Restore.TabIndex = 2;
            this.Btn_Restore.Text = "Restore";
            this.Btn_Restore.UseVisualStyleBackColor = true;
            this.Btn_Restore.Click += new System.EventHandler(this.Btn_Restore_Click);
            // 
            // Cmb_Job_ID
            // 
            this.Cmb_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Cmb_Job_ID.FormattingEnabled = true;
            this.Cmb_Job_ID.Location = new System.Drawing.Point(342, 30);
            this.Cmb_Job_ID.Name = "Cmb_Job_ID";
            this.Cmb_Job_ID.Size = new System.Drawing.Size(195, 32);
            this.Cmb_Job_ID.TabIndex = 3;
            // 
            // Lbl_Job_ID
            // 
            this.Lbl_Job_ID.AutoSize = true;
            this.Lbl_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Lbl_Job_ID.Location = new System.Drawing.Point(249, 34);
            this.Lbl_Job_ID.Name = "Lbl_Job_ID";
            this.Lbl_Job_ID.Size = new System.Drawing.Size(73, 24);
            this.Lbl_Job_ID.TabIndex = 4;
            this.Lbl_Job_ID.Text = "Job_ID:";
            // 
            // Prb_Rename
            // 
            this.Prb_Rename.Location = new System.Drawing.Point(0, 198);
            this.Prb_Rename.Maximum = 0;
            this.Prb_Rename.Name = "Prb_Rename";
            this.Prb_Rename.Size = new System.Drawing.Size(780, 10);
            this.Prb_Rename.TabIndex = 144;
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(780, 207);
            this.Controls.Add(this.Prb_Rename);
            this.Controls.Add(this.Lbl_Job_ID);
            this.Controls.Add(this.Cmb_Job_ID);
            this.Controls.Add(this.Btn_Restore);
            this.Controls.Add(this.Btn_Backup);
            this.Controls.Add(this.Txt_Location);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(600, 100);
            this.Name = "Rename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Rename";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Rename_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Button Btn_Backup;
        private System.Windows.Forms.Button Btn_Restore;
        private System.Windows.Forms.ComboBox Cmb_Job_ID;
        private System.Windows.Forms.Label Lbl_Job_ID;
        private System.Windows.Forms.ProgressBar Prb_Rename;
    }
}