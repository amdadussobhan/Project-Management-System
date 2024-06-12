namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class Misc_Task_Add
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
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Txt_Reason = new System.Windows.Forms.TextBox();
            this.Rdb_Training = new System.Windows.Forms.RadioButton();
            this.Rdb_Meeting = new System.Windows.Forms.RadioButton();
            this.Rdb_Prayer = new System.Windows.Forms.RadioButton();
            this.Rdb_Lunch = new System.Windows.Forms.RadioButton();
            this.Rdb_Others = new System.Windows.Forms.RadioButton();
            this.Rdb_Snacks = new System.Windows.Forms.RadioButton();
            this.Rdb_Instruction_Brief = new System.Windows.Forms.RadioButton();
            this.Tmr_Count = new System.Windows.Forms.Timer(this.components);
            this.Lbl_Time_Count = new System.Windows.Forms.Label();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.Tomato;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Save.Location = new System.Drawing.Point(522, 228);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(152, 35);
            this.Btn_Save.TabIndex = 469;
            this.Btn_Save.Text = "End";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Cancel.Location = new System.Drawing.Point(41, 228);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(152, 35);
            this.Btn_Cancel.TabIndex = 470;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Txt_Reason
            // 
            this.Txt_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Reason.Location = new System.Drawing.Point(522, 145);
            this.Txt_Reason.Name = "Txt_Reason";
            this.Txt_Reason.Size = new System.Drawing.Size(152, 26);
            this.Txt_Reason.TabIndex = 477;
            // 
            // Rdb_Training
            // 
            this.Rdb_Training.AutoSize = true;
            this.Rdb_Training.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Training.Location = new System.Drawing.Point(47, 59);
            this.Rdb_Training.Name = "Rdb_Training";
            this.Rdb_Training.Size = new System.Drawing.Size(101, 29);
            this.Rdb_Training.TabIndex = 478;
            this.Rdb_Training.TabStop = true;
            this.Rdb_Training.Text = "Training";
            this.Rdb_Training.UseVisualStyleBackColor = true;
            this.Rdb_Training.CheckedChanged += new System.EventHandler(this.Rdb_Training_CheckedChanged);
            // 
            // Rdb_Meeting
            // 
            this.Rdb_Meeting.AutoSize = true;
            this.Rdb_Meeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Meeting.Location = new System.Drawing.Point(370, 59);
            this.Rdb_Meeting.Name = "Rdb_Meeting";
            this.Rdb_Meeting.Size = new System.Drawing.Size(100, 29);
            this.Rdb_Meeting.TabIndex = 479;
            this.Rdb_Meeting.TabStop = true;
            this.Rdb_Meeting.Text = "Meeting";
            this.Rdb_Meeting.UseVisualStyleBackColor = true;
            this.Rdb_Meeting.CheckedChanged += new System.EventHandler(this.Rdb_Meeting_CheckedChanged);
            // 
            // Rdb_Prayer
            // 
            this.Rdb_Prayer.AutoSize = true;
            this.Rdb_Prayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Prayer.Location = new System.Drawing.Point(214, 59);
            this.Rdb_Prayer.Name = "Rdb_Prayer";
            this.Rdb_Prayer.Size = new System.Drawing.Size(87, 29);
            this.Rdb_Prayer.TabIndex = 480;
            this.Rdb_Prayer.TabStop = true;
            this.Rdb_Prayer.Text = "Prayer";
            this.Rdb_Prayer.UseVisualStyleBackColor = true;
            this.Rdb_Prayer.CheckedChanged += new System.EventHandler(this.Rdb_Prayer_CheckedChanged);
            // 
            // Rdb_Lunch
            // 
            this.Rdb_Lunch.AutoSize = true;
            this.Rdb_Lunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Lunch.Location = new System.Drawing.Point(46, 142);
            this.Rdb_Lunch.Name = "Rdb_Lunch";
            this.Rdb_Lunch.Size = new System.Drawing.Size(84, 29);
            this.Rdb_Lunch.TabIndex = 481;
            this.Rdb_Lunch.TabStop = true;
            this.Rdb_Lunch.Text = "Lunch";
            this.Rdb_Lunch.UseVisualStyleBackColor = true;
            this.Rdb_Lunch.CheckedChanged += new System.EventHandler(this.Rdb_Lunch_CheckedChanged);
            // 
            // Rdb_Others
            // 
            this.Rdb_Others.AutoSize = true;
            this.Rdb_Others.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Others.Location = new System.Drawing.Point(371, 142);
            this.Rdb_Others.Name = "Rdb_Others";
            this.Rdb_Others.Size = new System.Drawing.Size(89, 29);
            this.Rdb_Others.TabIndex = 483;
            this.Rdb_Others.TabStop = true;
            this.Rdb_Others.Text = "Others";
            this.Rdb_Others.UseVisualStyleBackColor = true;
            this.Rdb_Others.CheckedChanged += new System.EventHandler(this.Rdb_Others_CheckedChanged);
            // 
            // Rdb_Snacks
            // 
            this.Rdb_Snacks.AutoSize = true;
            this.Rdb_Snacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Snacks.Location = new System.Drawing.Point(214, 142);
            this.Rdb_Snacks.Name = "Rdb_Snacks";
            this.Rdb_Snacks.Size = new System.Drawing.Size(96, 29);
            this.Rdb_Snacks.TabIndex = 482;
            this.Rdb_Snacks.TabStop = true;
            this.Rdb_Snacks.Text = "Snacks";
            this.Rdb_Snacks.UseVisualStyleBackColor = true;
            this.Rdb_Snacks.CheckedChanged += new System.EventHandler(this.Rdb_Snacks_CheckedChanged);
            // 
            // Rdb_Instruction_Brief
            // 
            this.Rdb_Instruction_Brief.AutoSize = true;
            this.Rdb_Instruction_Brief.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_Instruction_Brief.Location = new System.Drawing.Point(516, 59);
            this.Rdb_Instruction_Brief.Name = "Rdb_Instruction_Brief";
            this.Rdb_Instruction_Brief.Size = new System.Drawing.Size(163, 29);
            this.Rdb_Instruction_Brief.TabIndex = 484;
            this.Rdb_Instruction_Brief.TabStop = true;
            this.Rdb_Instruction_Brief.Text = "Instruction Brief";
            this.Rdb_Instruction_Brief.UseVisualStyleBackColor = true;
            this.Rdb_Instruction_Brief.CheckedChanged += new System.EventHandler(this.Rdb_Instruction_Brief_CheckedChanged);
            // 
            // Tmr_Count
            // 
            this.Tmr_Count.Interval = 1000;
            this.Tmr_Count.Tick += new System.EventHandler(this.Tmr_Count_Tick);
            // 
            // Lbl_Time_Count
            // 
            this.Lbl_Time_Count.AutoSize = true;
            this.Lbl_Time_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.Lbl_Time_Count.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Time_Count.Location = new System.Drawing.Point(319, 226);
            this.Lbl_Time_Count.Name = "Lbl_Time_Count";
            this.Lbl_Time_Count.Size = new System.Drawing.Size(0, 36);
            this.Lbl_Time_Count.TabIndex = 485;
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Start.Location = new System.Drawing.Point(522, 228);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(152, 35);
            this.Btn_Start.TabIndex = 486;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Misc_Task_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(731, 304);
            this.Controls.Add(this.Lbl_Time_Count);
            this.Controls.Add(this.Rdb_Instruction_Brief);
            this.Controls.Add(this.Rdb_Others);
            this.Controls.Add(this.Rdb_Snacks);
            this.Controls.Add(this.Rdb_Lunch);
            this.Controls.Add(this.Rdb_Prayer);
            this.Controls.Add(this.Rdb_Meeting);
            this.Controls.Add(this.Rdb_Training);
            this.Controls.Add(this.Txt_Reason);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Misc_Task_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Misc_Task";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Misc_Task_Add_FormClosed);
            this.Load += new System.EventHandler(this.Misc_Task_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.TextBox Txt_Reason;
        private System.Windows.Forms.RadioButton Rdb_Training;
        private System.Windows.Forms.RadioButton Rdb_Meeting;
        private System.Windows.Forms.RadioButton Rdb_Prayer;
        private System.Windows.Forms.RadioButton Rdb_Lunch;
        private System.Windows.Forms.RadioButton Rdb_Others;
        private System.Windows.Forms.RadioButton Rdb_Snacks;
        private System.Windows.Forms.RadioButton Rdb_Instruction_Brief;
        private System.Windows.Forms.Timer Tmr_Count;
        private System.Windows.Forms.Label Lbl_Time_Count;
        private System.Windows.Forms.Button Btn_Start;
    }
}