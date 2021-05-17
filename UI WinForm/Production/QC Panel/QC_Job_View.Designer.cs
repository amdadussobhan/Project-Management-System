namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    partial class QC_Job_View
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
            this.label10 = new System.Windows.Forms.Label();
            this.Cmb_Type = new System.Windows.Forms.ComboBox();
            this.Lbl_Incoming = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Lbl_Total_Time = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Lbl_Service = new System.Windows.Forms.Label();
            this.Lbl_Actual_Time = new System.Windows.Forms.Label();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.Lbl_Target_Time = new System.Windows.Forms.Label();
            this.Lbl_Delivery = new System.Windows.Forms.Label();
            this.Lbl_Job_ID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Open = new System.Windows.Forms.Button();
            this.Txt_Remarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(235, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 26);
            this.label10.TabIndex = 435;
            this.label10.Text = "Type :";
            // 
            // Cmb_Type
            // 
            this.Cmb_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Type.FormattingEnabled = true;
            this.Cmb_Type.Items.AddRange(new object[] {
            "Redo",
            "Modify"});
            this.Cmb_Type.Location = new System.Drawing.Point(307, 340);
            this.Cmb_Type.Name = "Cmb_Type";
            this.Cmb_Type.Size = new System.Drawing.Size(204, 28);
            this.Cmb_Type.TabIndex = 434;
            // 
            // Lbl_Incoming
            // 
            this.Lbl_Incoming.AutoSize = true;
            this.Lbl_Incoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Incoming.Location = new System.Drawing.Point(176, 65);
            this.Lbl_Incoming.Name = "Lbl_Incoming";
            this.Lbl_Incoming.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Incoming.TabIndex = 430;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(49, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 26);
            this.label9.TabIndex = 429;
            this.label9.Text = "Incoming :";
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Save.Location = new System.Drawing.Point(578, 341);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(150, 35);
            this.Btn_Save.TabIndex = 412;
            this.Btn_Save.Text = "Update Job";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Lbl_Total_Time
            // 
            this.Lbl_Total_Time.AutoSize = true;
            this.Lbl_Total_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total_Time.Location = new System.Drawing.Point(670, 141);
            this.Lbl_Total_Time.Name = "Lbl_Total_Time";
            this.Lbl_Total_Time.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Total_Time.TabIndex = 426;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(530, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 26);
            this.label21.TabIndex = 425;
            this.label21.Text = "Total Time :";
            // 
            // Lbl_Service
            // 
            this.Lbl_Service.AutoSize = true;
            this.Lbl_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Service.Location = new System.Drawing.Point(176, 141);
            this.Lbl_Service.Name = "Lbl_Service";
            this.Lbl_Service.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Service.TabIndex = 422;
            // 
            // Lbl_Actual_Time
            // 
            this.Lbl_Actual_Time.AutoSize = true;
            this.Lbl_Actual_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Actual_Time.Location = new System.Drawing.Point(670, 67);
            this.Lbl_Actual_Time.Name = "Lbl_Actual_Time";
            this.Lbl_Actual_Time.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Actual_Time.TabIndex = 421;
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.AutoSize = true;
            this.Lbl_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Amount.Location = new System.Drawing.Point(670, 29);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Amount.TabIndex = 420;
            // 
            // Lbl_Target_Time
            // 
            this.Lbl_Target_Time.AutoSize = true;
            this.Lbl_Target_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Target_Time.Location = new System.Drawing.Point(670, 103);
            this.Lbl_Target_Time.Name = "Lbl_Target_Time";
            this.Lbl_Target_Time.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Target_Time.TabIndex = 419;
            // 
            // Lbl_Delivery
            // 
            this.Lbl_Delivery.AutoSize = true;
            this.Lbl_Delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Delivery.Location = new System.Drawing.Point(176, 103);
            this.Lbl_Delivery.Name = "Lbl_Delivery";
            this.Lbl_Delivery.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Delivery.TabIndex = 418;
            // 
            // Lbl_Job_ID
            // 
            this.Lbl_Job_ID.AutoSize = true;
            this.Lbl_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Job_ID.Location = new System.Drawing.Point(176, 29);
            this.Lbl_Job_ID.Name = "Lbl_Job_ID";
            this.Lbl_Job_ID.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Job_ID.TabIndex = 417;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 26);
            this.label3.TabIndex = 416;
            this.label3.Text = "Service :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 26);
            this.label5.TabIndex = 414;
            this.label5.Text = "Delivery :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(516, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 26);
            this.label6.TabIndex = 413;
            this.label6.Text = "Target Time :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(516, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 26);
            this.label7.TabIndex = 411;
            this.label7.Text = "Actual Time :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(555, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 410;
            this.label8.Text = "Amount :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 408;
            this.label1.Text = "Job ID :";
            // 
            // Btn_Open
            // 
            this.Btn_Open.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Open.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Open.Location = new System.Drawing.Point(25, 337);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(150, 35);
            this.Btn_Open.TabIndex = 431;
            this.Btn_Open.Text = "Open Folder";
            this.Btn_Open.UseVisualStyleBackColor = false;
            this.Btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // Txt_Remarks
            // 
            this.Txt_Remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Remarks.Location = new System.Drawing.Point(27, 242);
            this.Txt_Remarks.Multiline = true;
            this.Txt_Remarks.Name = "Txt_Remarks";
            this.Txt_Remarks.Size = new System.Drawing.Size(701, 85);
            this.Txt_Remarks.TabIndex = 436;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 26);
            this.label4.TabIndex = 437;
            this.label4.Text = "Remarks :";
            // 
            // QC_Job_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(756, 396);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_Remarks);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Cmb_Type);
            this.Controls.Add(this.Btn_Open);
            this.Controls.Add(this.Lbl_Incoming);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Lbl_Total_Time);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.Lbl_Service);
            this.Controls.Add(this.Lbl_Actual_Time);
            this.Controls.Add(this.Lbl_Amount);
            this.Controls.Add(this.Lbl_Target_Time);
            this.Controls.Add(this.Lbl_Delivery);
            this.Controls.Add(this.Lbl_Job_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "QC_Job_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QC_Job_View";
            this.Load += new System.EventHandler(this.QC_Job_Viewcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cmb_Type;
        private System.Windows.Forms.Label Lbl_Incoming;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Label Lbl_Total_Time;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label Lbl_Service;
        private System.Windows.Forms.Label Lbl_Actual_Time;
        private System.Windows.Forms.Label Lbl_Amount;
        private System.Windows.Forms.Label Lbl_Target_Time;
        private System.Windows.Forms.Label Lbl_Delivery;
        private System.Windows.Forms.Label Lbl_Job_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.TextBox Txt_Remarks;
        private System.Windows.Forms.Label label4;
    }
}