namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class Leave_Apply
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
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Reason = new System.Windows.Forms.TextBox();
            this.Dtp_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Dtp_End_Date = new System.Windows.Forms.DateTimePicker();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Cmb_Leave_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 22);
            this.label2.TabIndex = 479;
            this.label2.Text = "Reason describe below.";
            // 
            // Txt_Reason
            // 
            this.Txt_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Reason.Location = new System.Drawing.Point(45, 125);
            this.Txt_Reason.Multiline = true;
            this.Txt_Reason.Name = "Txt_Reason";
            this.Txt_Reason.Size = new System.Drawing.Size(713, 160);
            this.Txt_Reason.TabIndex = 477;
            // 
            // Dtp_Start_Date
            // 
            this.Dtp_Start_Date.CustomFormat = "dd-MMM-yy";
            this.Dtp_Start_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Start_Date.Location = new System.Drawing.Point(567, 35);
            this.Dtp_Start_Date.Name = "Dtp_Start_Date";
            this.Dtp_Start_Date.Size = new System.Drawing.Size(190, 26);
            this.Dtp_Start_Date.TabIndex = 471;
            this.Dtp_Start_Date.Value = new System.DateTime(2020, 7, 30, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(445, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 22);
            this.label11.TabIndex = 472;
            this.label11.Text = "Start Time:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(445, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 22);
            this.label12.TabIndex = 473;
            this.label12.Text = "End Time :";
            // 
            // Dtp_End_Date
            // 
            this.Dtp_End_Date.CustomFormat = "dd-MMM-yy";
            this.Dtp_End_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_End_Date.Location = new System.Drawing.Point(567, 78);
            this.Dtp_End_Date.Name = "Dtp_End_Date";
            this.Dtp_End_Date.Size = new System.Drawing.Size(190, 26);
            this.Dtp_End_Date.TabIndex = 474;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Cancel.Location = new System.Drawing.Point(41, 303);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(169, 35);
            this.Btn_Cancel.TabIndex = 470;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Save.Location = new System.Drawing.Point(586, 303);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(172, 35);
            this.Btn_Save.TabIndex = 469;
            this.Btn_Save.Text = "Submit";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Cmb_Leave_Type
            // 
            this.Cmb_Leave_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Cmb_Leave_Type.FormattingEnabled = true;
            this.Cmb_Leave_Type.Items.AddRange(new object[] {
            "Casual",
            "Sick",
            "LWP",
            "ALT_Off"});
            this.Cmb_Leave_Type.Location = new System.Drawing.Point(166, 34);
            this.Cmb_Leave_Type.Name = "Cmb_Leave_Type";
            this.Cmb_Leave_Type.Size = new System.Drawing.Size(190, 28);
            this.Cmb_Leave_Type.TabIndex = 468;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 467;
            this.label1.Text = "Leave Type:";
            // 
            // Leave_Apply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Reason);
            this.Controls.Add(this.Dtp_Start_Date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Dtp_End_Date);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Cmb_Leave_Type);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Leave_Apply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave_Apply";
            this.Load += new System.EventHandler(this.Leave_Apply_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Reason;
        private System.Windows.Forms.DateTimePicker Dtp_Start_Date;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker Dtp_End_Date;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.ComboBox Cmb_Leave_Type;
        private System.Windows.Forms.Label label1;
    }
}