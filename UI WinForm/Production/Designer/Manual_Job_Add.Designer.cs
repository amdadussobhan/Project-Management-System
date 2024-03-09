namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class Manual_Job_Add
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
            this.Cmb_JobID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Dtp_Start_Time = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Dtp_End_Time = new System.Windows.Forms.DateTimePicker();
            this.Txt_Target_Time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_Reason = new System.Windows.Forms.TextBox();
            this.Txt_File = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Chk_Clipping_Path = new System.Windows.Forms.CheckBox();
            this.Chk_Pre_Process = new System.Windows.Forms.CheckBox();
            this.Chk_Post_Process = new System.Windows.Forms.CheckBox();
            this.Chk_Basic_Process = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Cmb_JobID
            // 
            this.Cmb_JobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Cmb_JobID.FormattingEnabled = true;
            this.Cmb_JobID.Location = new System.Drawing.Point(152, 36);
            this.Cmb_JobID.Name = "Cmb_JobID";
            this.Cmb_JobID.Size = new System.Drawing.Size(190, 28);
            this.Cmb_JobID.TabIndex = 426;
            this.Cmb_JobID.SelectedValueChanged += new System.EventHandler(this.Cmb_JobID_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 425;
            this.label1.Text = "Job ID :";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Cancel.Location = new System.Drawing.Point(41, 303);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(169, 35);
            this.Btn_Cancel.TabIndex = 428;
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
            this.Btn_Save.TabIndex = 427;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Dtp_Start_Time
            // 
            this.Dtp_Start_Time.CustomFormat = "dd-MMM-yy hh:mm tt";
            this.Dtp_Start_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Start_Time.Location = new System.Drawing.Point(152, 80);
            this.Dtp_Start_Time.Name = "Dtp_Start_Time";
            this.Dtp_Start_Time.Size = new System.Drawing.Size(190, 26);
            this.Dtp_Start_Time.TabIndex = 429;
            this.Dtp_Start_Time.Value = new System.DateTime(2020, 7, 30, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(41, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 22);
            this.label11.TabIndex = 430;
            this.label11.Text = "Start Time :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(445, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 22);
            this.label12.TabIndex = 431;
            this.label12.Text = "End Time :";
            // 
            // Dtp_End_Time
            // 
            this.Dtp_End_Time.CustomFormat = "dd-MMM-yy hh:mm tt";
            this.Dtp_End_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_End_Time.Location = new System.Drawing.Point(567, 80);
            this.Dtp_End_Time.Name = "Dtp_End_Time";
            this.Dtp_End_Time.Size = new System.Drawing.Size(190, 26);
            this.Dtp_End_Time.TabIndex = 432;
            // 
            // Txt_Target_Time
            // 
            this.Txt_Target_Time.Enabled = false;
            this.Txt_Target_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Txt_Target_Time.Location = new System.Drawing.Point(567, 37);
            this.Txt_Target_Time.Name = "Txt_Target_Time";
            this.Txt_Target_Time.Size = new System.Drawing.Size(190, 26);
            this.Txt_Target_Time.TabIndex = 446;
            this.Txt_Target_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(445, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 22);
            this.label7.TabIndex = 447;
            this.label7.Text = "Target Time :";
            // 
            // Txt_Reason
            // 
            this.Txt_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Reason.Location = new System.Drawing.Point(45, 202);
            this.Txt_Reason.Multiline = true;
            this.Txt_Reason.Name = "Txt_Reason";
            this.Txt_Reason.Size = new System.Drawing.Size(713, 85);
            this.Txt_Reason.TabIndex = 448;
            // 
            // Txt_File
            // 
            this.Txt_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Txt_File.Location = new System.Drawing.Point(152, 160);
            this.Txt_File.Name = "Txt_File";
            this.Txt_File.Size = new System.Drawing.Size(606, 26);
            this.Txt_File.TabIndex = 449;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(41, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 450;
            this.label2.Text = "File Name :";
            // 
            // Chk_Clipping_Path
            // 
            this.Chk_Clipping_Path.AutoSize = true;
            this.Chk_Clipping_Path.Enabled = false;
            this.Chk_Clipping_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Clipping_Path.Location = new System.Drawing.Point(45, 120);
            this.Chk_Clipping_Path.Name = "Chk_Clipping_Path";
            this.Chk_Clipping_Path.Size = new System.Drawing.Size(136, 26);
            this.Chk_Clipping_Path.TabIndex = 463;
            this.Chk_Clipping_Path.Text = "Clipping Path";
            this.Chk_Clipping_Path.UseVisualStyleBackColor = true;
            this.Chk_Clipping_Path.CheckedChanged += new System.EventHandler(this.Chk_Clipping_Path_CheckedChanged);
            // 
            // Chk_Pre_Process
            // 
            this.Chk_Pre_Process.AutoSize = true;
            this.Chk_Pre_Process.Enabled = false;
            this.Chk_Pre_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Pre_Process.Location = new System.Drawing.Point(441, 120);
            this.Chk_Pre_Process.Name = "Chk_Pre_Process";
            this.Chk_Pre_Process.Size = new System.Drawing.Size(132, 26);
            this.Chk_Pre_Process.TabIndex = 464;
            this.Chk_Pre_Process.Text = "Pre_Process";
            this.Chk_Pre_Process.UseVisualStyleBackColor = true;
            this.Chk_Pre_Process.CheckedChanged += new System.EventHandler(this.Chk_Pre_Process_CheckedChanged);
            // 
            // Chk_Post_Process
            // 
            this.Chk_Post_Process.AutoSize = true;
            this.Chk_Post_Process.Enabled = false;
            this.Chk_Post_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Post_Process.Location = new System.Drawing.Point(625, 120);
            this.Chk_Post_Process.Name = "Chk_Post_Process";
            this.Chk_Post_Process.Size = new System.Drawing.Size(140, 26);
            this.Chk_Post_Process.TabIndex = 465;
            this.Chk_Post_Process.Text = "Post_Process";
            this.Chk_Post_Process.UseVisualStyleBackColor = true;
            this.Chk_Post_Process.CheckedChanged += new System.EventHandler(this.Chk_Post_Process_CheckedChanged);
            // 
            // Chk_Basic_Process
            // 
            this.Chk_Basic_Process.AutoSize = true;
            this.Chk_Basic_Process.Enabled = false;
            this.Chk_Basic_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Basic_Process.Location = new System.Drawing.Point(233, 120);
            this.Chk_Basic_Process.Name = "Chk_Basic_Process";
            this.Chk_Basic_Process.Size = new System.Drawing.Size(156, 26);
            this.Chk_Basic_Process.TabIndex = 466;
            this.Chk_Basic_Process.Text = "Basic_Retourch";
            this.Chk_Basic_Process.UseVisualStyleBackColor = true;
            this.Chk_Basic_Process.CheckedChanged += new System.EventHandler(this.Chk_Basic_Process_CheckedChanged);
            // 
            // Manual_Job_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.Chk_Basic_Process);
            this.Controls.Add(this.Chk_Post_Process);
            this.Controls.Add(this.Chk_Pre_Process);
            this.Controls.Add(this.Chk_Clipping_Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_File);
            this.Controls.Add(this.Txt_Reason);
            this.Controls.Add(this.Txt_Target_Time);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Dtp_Start_Time);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Dtp_End_Time);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Cmb_JobID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Manual_Job_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual_Job_Add";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Manual_Job_Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_JobID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.DateTimePicker Dtp_Start_Time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker Dtp_End_Time;
        private System.Windows.Forms.TextBox Txt_Target_Time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_Reason;
        private System.Windows.Forms.TextBox Txt_File;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Chk_Clipping_Path;
        private System.Windows.Forms.CheckBox Chk_Pre_Process;
        private System.Windows.Forms.CheckBox Chk_Post_Process;
        private System.Windows.Forms.CheckBox Chk_Basic_Process;
    }
}