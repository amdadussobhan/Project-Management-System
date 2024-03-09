
namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    partial class MissingFiles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Dgv_Missing_Files = new System.Windows.Forms.DataGridView();
            this.Prb_Rename = new System.Windows.Forms.ProgressBar();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_JobID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Missing_Files)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv_Missing_Files
            // 
            this.Dgv_Missing_Files.AllowUserToAddRows = false;
            this.Dgv_Missing_Files.AllowUserToDeleteRows = false;
            this.Dgv_Missing_Files.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.Dgv_Missing_Files.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Missing_Files.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Missing_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Missing_Files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewTextBoxColumn51,
            this.Column1,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Missing_Files.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Missing_Files.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.Dgv_Missing_Files.Location = new System.Drawing.Point(41, 55);
            this.Dgv_Missing_Files.Name = "Dgv_Missing_Files";
            this.Dgv_Missing_Files.ReadOnly = true;
            this.Dgv_Missing_Files.RowTemplate.Height = 30;
            this.Dgv_Missing_Files.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Missing_Files.Size = new System.Drawing.Size(1121, 555);
            this.Dgv_Missing_Files.TabIndex = 419;
            // 
            // Prb_Rename
            // 
            this.Prb_Rename.Location = new System.Drawing.Point(7, 630);
            this.Prb_Rename.Maximum = 0;
            this.Prb_Rename.Name = "Prb_Rename";
            this.Prb_Rename.Size = new System.Drawing.Size(1188, 10);
            this.Prb_Rename.TabIndex = 422;
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Start.Location = new System.Drawing.Point(1012, 11);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(150, 35);
            this.Btn_Start.TabIndex = 421;
            this.Btn_Start.Text = "Find Missing";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Txt_Location.Location = new System.Drawing.Point(436, 14);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(567, 29);
            this.Txt_Location.TabIndex = 420;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 410;
            this.label1.Text = "Job ID :";
            // 
            // Cmb_JobID
            // 
            this.Cmb_JobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_JobID.FormattingEnabled = true;
            this.Cmb_JobID.Location = new System.Drawing.Point(120, 12);
            this.Cmb_JobID.Name = "Cmb_JobID";
            this.Cmb_JobID.Size = new System.Drawing.Size(201, 32);
            this.Cmb_JobID.TabIndex = 424;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 425;
            this.label2.Text = "Location :";
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "SL";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            this.dataGridViewTextBoxColumn50.Width = 50;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn51.HeaderText = "Image Name";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Designer Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Start_Time";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Service";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // MissingFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1201, 645);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cmb_JobID);
            this.Controls.Add(this.Prb_Rename);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Txt_Location);
            this.Controls.Add(this.Dgv_Missing_Files);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MissingFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MissingFiles";
            this.Load += new System.EventHandler(this.MissingFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Missing_Files)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Dgv_Missing_Files;
        private System.Windows.Forms.ProgressBar Prb_Rename;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_JobID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}