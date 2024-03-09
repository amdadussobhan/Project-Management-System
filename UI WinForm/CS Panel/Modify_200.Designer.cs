
namespace Skill_PMS.UI_WinForm.CS_Panel
{
    partial class Modify_200
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
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.Prb_Rename = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Start.Location = new System.Drawing.Point(558, 75);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(150, 35);
            this.Btn_Start.TabIndex = 7;
            this.Btn_Start.Text = "Start Action";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Txt_Location.Location = new System.Drawing.Point(72, 78);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(477, 29);
            this.Txt_Location.TabIndex = 5;
            // 
            // Prb_Rename
            // 
            this.Prb_Rename.Location = new System.Drawing.Point(0, 169);
            this.Prb_Rename.Maximum = 0;
            this.Prb_Rename.Name = "Prb_Rename";
            this.Prb_Rename.Size = new System.Drawing.Size(780, 10);
            this.Prb_Rename.TabIndex = 145;
            // 
            // Modify_200
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(780, 179);
            this.Controls.Add(this.Prb_Rename);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Txt_Location);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Modify_200";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify_200";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.ProgressBar Prb_Rename;
    }
}