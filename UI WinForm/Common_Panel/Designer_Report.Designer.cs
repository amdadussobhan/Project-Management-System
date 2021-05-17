namespace Skill_PMS.UI_WinForm.Common_Panel
{
    partial class Designer_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dgv_Designer_Report = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Cmb_Name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Prb_Designer = new System.Windows.Forms.ProgressBar();
            this.label87 = new System.Windows.Forms.Label();
            this.Dtp_To = new System.Windows.Forms.DateTimePicker();
            this.label81 = new System.Windows.Forms.Label();
            this.Dtp_From = new System.Windows.Forms.DateTimePicker();
            this.Btn_Designer_Find = new System.Windows.Forms.Button();
            this.Cmb_Shift = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.Btn_Capacity = new System.Windows.Forms.Button();
            this.Btn_Target_Time = new System.Windows.Forms.Button();
            this.Btn_Pro_Time = new System.Windows.Forms.Button();
            this.Btn_Efficiency = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Designer_Report)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_Designer_Report
            // 
            this.Dgv_Designer_Report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Designer_Report.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.Dgv_Designer_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Designer_Report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Designer_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Designer_Report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn22,
            this.Column47,
            this.Column42});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Format = "g";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Designer_Report.DefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_Designer_Report.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Dgv_Designer_Report.Location = new System.Drawing.Point(43, 118);
            this.Dgv_Designer_Report.Name = "Dgv_Designer_Report";
            this.Dgv_Designer_Report.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Dgv_Designer_Report.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Designer_Report.Size = new System.Drawing.Size(1547, 705);
            this.Dgv_Designer_Report.TabIndex = 126;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel6.Controls.Add(this.Btn_Efficiency);
            this.panel6.Controls.Add(this.Btn_Pro_Time);
            this.panel6.Controls.Add(this.Btn_Target_Time);
            this.panel6.Controls.Add(this.Btn_Capacity);
            this.panel6.Controls.Add(this.Cmb_Name);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.Prb_Designer);
            this.panel6.Controls.Add(this.label87);
            this.panel6.Controls.Add(this.Dtp_To);
            this.panel6.Controls.Add(this.label81);
            this.panel6.Controls.Add(this.Dtp_From);
            this.panel6.Controls.Add(this.Btn_Designer_Find);
            this.panel6.Controls.Add(this.Cmb_Shift);
            this.panel6.Controls.Add(this.label89);
            this.panel6.Location = new System.Drawing.Point(169, 12);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1300, 100);
            this.panel6.TabIndex = 125;
            // 
            // Cmb_Name
            // 
            this.Cmb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Name.FormattingEnabled = true;
            this.Cmb_Name.Location = new System.Drawing.Point(939, 12);
            this.Cmb_Name.Name = "Cmb_Name";
            this.Cmb_Name.Size = new System.Drawing.Size(187, 26);
            this.Cmb_Name.TabIndex = 121;
            this.Cmb_Name.Text = "ALL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(863, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 22);
            this.label1.TabIndex = 122;
            this.label1.Text = "Name :";
            // 
            // Prb_Designer
            // 
            this.Prb_Designer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Prb_Designer.Location = new System.Drawing.Point(3, 87);
            this.Prb_Designer.Maximum = 0;
            this.Prb_Designer.Name = "Prb_Designer";
            this.Prb_Designer.Size = new System.Drawing.Size(1294, 10);
            this.Prb_Designer.TabIndex = 120;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Black;
            this.label87.Location = new System.Drawing.Point(15, 14);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(58, 22);
            this.label87.TabIndex = 109;
            this.label87.Text = "Date :";
            // 
            // Dtp_To
            // 
            this.Dtp_To.CustomFormat = "dd-MMM-yy hh:mm tt";
            this.Dtp_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_To.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_To.Location = new System.Drawing.Point(355, 12);
            this.Dtp_To.Name = "Dtp_To";
            this.Dtp_To.Size = new System.Drawing.Size(187, 26);
            this.Dtp_To.TabIndex = 111;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.Black;
            this.label81.Location = new System.Drawing.Point(302, 14);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(42, 22);
            this.label81.TabIndex = 110;
            this.label81.Text = "To :";
            // 
            // Dtp_From
            // 
            this.Dtp_From.CustomFormat = "dd-MMM-yy hh:mm tt";
            this.Dtp_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_From.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_From.Location = new System.Drawing.Point(86, 12);
            this.Dtp_From.Name = "Dtp_From";
            this.Dtp_From.Size = new System.Drawing.Size(187, 26);
            this.Dtp_From.TabIndex = 108;
            this.Dtp_From.Value = new System.DateTime(2020, 8, 7, 0, 0, 0, 0);
            // 
            // Btn_Designer_Find
            // 
            this.Btn_Designer_Find.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Designer_Find.Location = new System.Drawing.Point(1157, 9);
            this.Btn_Designer_Find.Name = "Btn_Designer_Find";
            this.Btn_Designer_Find.Size = new System.Drawing.Size(133, 32);
            this.Btn_Designer_Find.TabIndex = 95;
            this.Btn_Designer_Find.Text = "Find Data";
            this.Btn_Designer_Find.UseVisualStyleBackColor = true;
            // 
            // Cmb_Shift
            // 
            this.Cmb_Shift.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Shift.FormattingEnabled = true;
            this.Cmb_Shift.Items.AddRange(new object[] {
            "ALL",
            "Night",
            "Evening",
            "Morning"});
            this.Cmb_Shift.Location = new System.Drawing.Point(636, 12);
            this.Cmb_Shift.Name = "Cmb_Shift";
            this.Cmb_Shift.Size = new System.Drawing.Size(187, 26);
            this.Cmb_Shift.TabIndex = 97;
            this.Cmb_Shift.Text = "ALL";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.Black;
            this.label89.Location = new System.Drawing.Point(570, 14);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(56, 22);
            this.label89.TabIndex = 106;
            this.label89.Text = "Shift :";
            // 
            // Btn_Capacity
            // 
            this.Btn_Capacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Capacity.FlatAppearance.BorderSize = 0;
            this.Btn_Capacity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Capacity.Font = new System.Drawing.Font("Arial", 15F);
            this.Btn_Capacity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Capacity.Location = new System.Drawing.Point(86, 44);
            this.Btn_Capacity.Name = "Btn_Capacity";
            this.Btn_Capacity.Size = new System.Drawing.Size(187, 36);
            this.Btn_Capacity.TabIndex = 127;
            this.Btn_Capacity.Text = "Capacity";
            this.Btn_Capacity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Capacity.UseVisualStyleBackColor = true;
            this.Btn_Capacity.Click += new System.EventHandler(this.Btn_Capacity_Click);
            // 
            // Btn_Target_Time
            // 
            this.Btn_Target_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Target_Time.FlatAppearance.BorderSize = 0;
            this.Btn_Target_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Target_Time.Font = new System.Drawing.Font("Arial", 15F);
            this.Btn_Target_Time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Target_Time.Location = new System.Drawing.Point(355, 44);
            this.Btn_Target_Time.Name = "Btn_Target_Time";
            this.Btn_Target_Time.Size = new System.Drawing.Size(187, 36);
            this.Btn_Target_Time.TabIndex = 128;
            this.Btn_Target_Time.Text = "Target_Time";
            this.Btn_Target_Time.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Target_Time.UseVisualStyleBackColor = true;
            // 
            // Btn_Pro_Time
            // 
            this.Btn_Pro_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Pro_Time.FlatAppearance.BorderSize = 0;
            this.Btn_Pro_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Pro_Time.Font = new System.Drawing.Font("Arial", 15F);
            this.Btn_Pro_Time.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Pro_Time.Location = new System.Drawing.Point(636, 45);
            this.Btn_Pro_Time.Name = "Btn_Pro_Time";
            this.Btn_Pro_Time.Size = new System.Drawing.Size(187, 36);
            this.Btn_Pro_Time.TabIndex = 129;
            this.Btn_Pro_Time.Text = "Pro_Time";
            this.Btn_Pro_Time.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Pro_Time.UseVisualStyleBackColor = true;
            // 
            // Btn_Efficiency
            // 
            this.Btn_Efficiency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Efficiency.FlatAppearance.BorderSize = 0;
            this.Btn_Efficiency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Efficiency.Font = new System.Drawing.Font("Arial", 15F);
            this.Btn_Efficiency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btn_Efficiency.Location = new System.Drawing.Point(939, 45);
            this.Btn_Efficiency.Name = "Btn_Efficiency";
            this.Btn_Efficiency.Size = new System.Drawing.Size(187, 36);
            this.Btn_Efficiency.TabIndex = 130;
            this.Btn_Efficiency.Text = "Efficiency";
            this.Btn_Efficiency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Efficiency.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "SL";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 50;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Name";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 150;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Job_ID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 200;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.HeaderText = "Folder";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Service";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 250;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 130;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Est_Time";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Width = 130;
            // 
            // Column47
            // 
            this.Column47.HeaderText = "Pro_Time";
            this.Column47.Name = "Column47";
            this.Column47.Width = 130;
            // 
            // Column42
            // 
            this.Column42.HeaderText = "Efficiency";
            this.Column42.Name = "Column42";
            this.Column42.Width = 130;
            // 
            // Designer_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1630, 857);
            this.Controls.Add(this.Dgv_Designer_Report);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Designer_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Designer_Report";
            this.Load += new System.EventHandler(this.Designer_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Designer_Report)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_Designer_Report;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox Cmb_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar Prb_Designer;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.DateTimePicker Dtp_To;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.DateTimePicker Dtp_From;
        private System.Windows.Forms.Button Btn_Designer_Find;
        private System.Windows.Forms.ComboBox Cmb_Shift;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Button Btn_Efficiency;
        private System.Windows.Forms.Button Btn_Pro_Time;
        private System.Windows.Forms.Button Btn_Target_Time;
        private System.Windows.Forms.Button Btn_Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column47;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column42;
    }
}