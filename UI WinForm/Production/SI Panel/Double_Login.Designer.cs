
namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    partial class Double_Login
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
            this.Txt_Reason = new System.Windows.Forms.TextBox();
            this.Btn_allow = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Reason
            // 
            this.Txt_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Reason.Location = new System.Drawing.Point(48, 40);
            this.Txt_Reason.Multiline = true;
            this.Txt_Reason.Name = "Txt_Reason";
            this.Txt_Reason.Size = new System.Drawing.Size(585, 142);
            this.Txt_Reason.TabIndex = 0;
            // 
            // Btn_allow
            // 
            this.Btn_allow.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_allow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Btn_allow.Location = new System.Drawing.Point(500, 194);
            this.Btn_allow.Name = "Btn_allow";
            this.Btn_allow.Size = new System.Drawing.Size(133, 35);
            this.Btn_allow.TabIndex = 1;
            this.Btn_allow.Text = "Allow Login";
            this.Btn_allow.UseVisualStyleBackColor = false;
            this.Btn_allow.Click += new System.EventHandler(this.Btn_allow_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Btn_Cancel.Location = new System.Drawing.Point(48, 194);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(133, 35);
            this.Btn_Cancel.TabIndex = 2;
            this.Btn_Cancel.Text = "Cancel Login";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Double_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(680, 257);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_allow);
            this.Controls.Add(this.Txt_Reason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Double_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Double_Login";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Reason;
        private System.Windows.Forms.Button Btn_allow;
        private System.Windows.Forms.Button Btn_Cancel;
    }
}