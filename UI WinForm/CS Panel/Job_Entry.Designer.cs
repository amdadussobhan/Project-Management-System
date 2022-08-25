namespace Skill_PMS.UI_WinForm.CS_Panel
{
    partial class JobEntry
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
            this.Lbl_Total_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Open_Folder = new System.Windows.Forms.Button();
            this.Txt_Folder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_Currency = new System.Windows.Forms.ComboBox();
            this.Txt_Price = new System.Windows.Forms.TextBox();
            this.Cmb_Catagory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cmb_Client = new System.Windows.Forms.ComboBox();
            this.Cmb_Job_Type = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.Btn_Submit_Job = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Dtp_Delivery = new System.Windows.Forms.DateTimePicker();
            this.Txt_Job_Time = new System.Windows.Forms.TextBox();
            this.Txt_Amount = new System.Windows.Forms.TextBox();
            this.Txt_Job_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Chk_Remember = new System.Windows.Forms.CheckBox();
            this.Cmb_Service = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lbl_Total_Time
            // 
            this.Lbl_Total_Time.AutoSize = true;
            this.Lbl_Total_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Lbl_Total_Time.Location = new System.Drawing.Point(536, 414);
            this.Lbl_Total_Time.Name = "Lbl_Total_Time";
            this.Lbl_Total_Time.Size = new System.Drawing.Size(23, 25);
            this.Lbl_Total_Time.TabIndex = 244;
            this.Lbl_Total_Time.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 243;
            this.label1.Text = "Total Time :";
            // 
            // Btn_Open_Folder
            // 
            this.Btn_Open_Folder.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Open_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Open_Folder.Location = new System.Drawing.Point(740, 342);
            this.Btn_Open_Folder.Name = "Btn_Open_Folder";
            this.Btn_Open_Folder.Size = new System.Drawing.Size(117, 35);
            this.Btn_Open_Folder.TabIndex = 10;
            this.Btn_Open_Folder.Text = "Open";
            this.Btn_Open_Folder.UseVisualStyleBackColor = false;
            this.Btn_Open_Folder.Click += new System.EventHandler(this.Btn_Open_Folder_Click);
            // 
            // Txt_Folder
            // 
            this.Txt_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Folder.Location = new System.Drawing.Point(168, 288);
            this.Txt_Folder.Name = "Txt_Folder";
            this.Txt_Folder.Size = new System.Drawing.Size(232, 27);
            this.Txt_Folder.TabIndex = 6;
            this.Txt_Folder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 26);
            this.label3.TabIndex = 235;
            this.label3.Text = "Folder :";
            // 
            // Cmb_Currency
            // 
            this.Cmb_Currency.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F);
            this.Cmb_Currency.FormattingEnabled = true;
            this.Cmb_Currency.Location = new System.Drawing.Point(289, 410);
            this.Cmb_Currency.Name = "Cmb_Currency";
            this.Cmb_Currency.Size = new System.Drawing.Size(111, 30);
            this.Cmb_Currency.TabIndex = 9;
            this.Cmb_Currency.TextChanged += new System.EventHandler(this.Cmb_Currency_TextChanged);
            // 
            // Txt_Price
            // 
            this.Txt_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Price.Location = new System.Drawing.Point(167, 410);
            this.Txt_Price.Name = "Txt_Price";
            this.Txt_Price.Size = new System.Drawing.Size(116, 30);
            this.Txt_Price.TabIndex = 8;
            this.Txt_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Price.TextChanged += new System.EventHandler(this.Txt_Price_TextChanged);
            // 
            // Cmb_Catagory
            // 
            this.Cmb_Catagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Cmb_Catagory.FormattingEnabled = true;
            this.Cmb_Catagory.Location = new System.Drawing.Point(168, 168);
            this.Cmb_Catagory.Name = "Cmb_Catagory";
            this.Cmb_Catagory.Size = new System.Drawing.Size(232, 28);
            this.Cmb_Catagory.TabIndex = 1;
            this.Cmb_Catagory.TextChanged += new System.EventHandler(this.Cmb_Category_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 26);
            this.label4.TabIndex = 225;
            this.label4.Text = "Catagory :";
            // 
            // Cmb_Client
            // 
            this.Cmb_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Cmb_Client.FormattingEnabled = true;
            this.Cmb_Client.Location = new System.Drawing.Point(167, 108);
            this.Cmb_Client.Name = "Cmb_Client";
            this.Cmb_Client.Size = new System.Drawing.Size(232, 28);
            this.Cmb_Client.TabIndex = 0;
            this.Cmb_Client.TextChanged += new System.EventHandler(this.Cmb_Client_TextChanged);
            // 
            // Cmb_Job_Type
            // 
            this.Cmb_Job_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Cmb_Job_Type.FormattingEnabled = true;
            this.Cmb_Job_Type.Items.AddRange(new object[] {
            "Test",
            "Regular",
            "Feedback"});
            this.Cmb_Job_Type.Location = new System.Drawing.Point(168, 228);
            this.Cmb_Job_Type.Name = "Cmb_Job_Type";
            this.Cmb_Job_Type.Size = new System.Drawing.Size(231, 28);
            this.Cmb_Job_Type.TabIndex = 2;
            this.Cmb_Job_Type.Text = "Regular";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(41, 225);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 26);
            this.label24.TabIndex = 224;
            this.label24.Text = "Job Type :";
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Location.Location = new System.Drawing.Point(169, 347);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(565, 27);
            this.Txt_Location.TabIndex = 7;
            this.Txt_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Location.TextChanged += new System.EventHandler(this.Txt_Job_Location_TextChanged);
            // 
            // Btn_Submit_Job
            // 
            this.Btn_Submit_Job.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Submit_Job.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Submit_Job.Location = new System.Drawing.Point(740, 408);
            this.Btn_Submit_Job.Name = "Btn_Submit_Job";
            this.Btn_Submit_Job.Size = new System.Drawing.Size(117, 35);
            this.Btn_Submit_Job.TabIndex = 11;
            this.Btn_Submit_Job.Text = "Submit";
            this.Btn_Submit_Job.UseVisualStyleBackColor = false;
            this.Btn_Submit_Job.Click += new System.EventHandler(this.Btn_Submit_Job_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(48, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 26);
            this.label9.TabIndex = 223;
            this.label9.Text = "Location :";
            // 
            // Dtp_Delivery
            // 
            this.Dtp_Delivery.CustomFormat = "dd-MMM-yy   hh:mm tt";
            this.Dtp_Delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Delivery.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Delivery.Location = new System.Drawing.Point(625, 288);
            this.Dtp_Delivery.Name = "Dtp_Delivery";
            this.Dtp_Delivery.Size = new System.Drawing.Size(232, 30);
            this.Dtp_Delivery.TabIndex = 5;
            this.Dtp_Delivery.Value = new System.DateTime(2020, 7, 23, 13, 50, 57, 0);
            // 
            // Txt_Job_Time
            // 
            this.Txt_Job_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Job_Time.Location = new System.Drawing.Point(625, 107);
            this.Txt_Job_Time.Name = "Txt_Job_Time";
            this.Txt_Job_Time.Size = new System.Drawing.Size(232, 30);
            this.Txt_Job_Time.TabIndex = 3;
            this.Txt_Job_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Job_Time.TextChanged += new System.EventHandler(this.Txt_Job_Time_TextChanged);
            // 
            // Txt_Amount
            // 
            this.Txt_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Amount.Location = new System.Drawing.Point(625, 167);
            this.Txt_Amount.Name = "Txt_Amount";
            this.Txt_Amount.Size = new System.Drawing.Size(232, 30);
            this.Txt_Amount.TabIndex = 4;
            this.Txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Amount.TextChanged += new System.EventHandler(this.Txt_Amount_TextChanged);
            // 
            // Txt_Job_ID
            // 
            this.Txt_Job_ID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Txt_Job_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Job_ID.Enabled = false;
            this.Txt_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Txt_Job_ID.Location = new System.Drawing.Point(48, 40);
            this.Txt_Job_ID.Multiline = true;
            this.Txt_Job_ID.Name = "Txt_Job_ID";
            this.Txt_Job_ID.Size = new System.Drawing.Size(816, 54);
            this.Txt_Job_ID.TabIndex = 204;
            this.Txt_Job_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(513, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 26);
            this.label5.TabIndex = 222;
            this.label5.Text = "Delivery :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(544, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 26);
            this.label7.TabIndex = 220;
            this.label7.Text = "Time :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(516, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 219;
            this.label8.Text = "Amount :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(73, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 26);
            this.label11.TabIndex = 218;
            this.label11.Text = "Client :";
            // 
            // Chk_Remember
            // 
            this.Chk_Remember.AutoSize = true;
            this.Chk_Remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Chk_Remember.Location = new System.Drawing.Point(635, 413);
            this.Chk_Remember.Name = "Chk_Remember";
            this.Chk_Remember.Size = new System.Drawing.Size(107, 24);
            this.Chk_Remember.TabIndex = 346;
            this.Chk_Remember.Text = "Remember";
            this.Chk_Remember.UseVisualStyleBackColor = true;
            // 
            // Cmb_Service
            // 
            this.Cmb_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Cmb_Service.FormattingEnabled = true;
            this.Cmb_Service.Items.AddRange(new object[] {
            "Basic",
            "Advance"});
            this.Cmb_Service.Location = new System.Drawing.Point(626, 228);
            this.Cmb_Service.Name = "Cmb_Service";
            this.Cmb_Service.Size = new System.Drawing.Size(231, 28);
            this.Cmb_Service.TabIndex = 348;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(518, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 349;
            this.label2.Text = "Service :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(79, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 26);
            this.label6.TabIndex = 350;
            this.label6.Text = "Price :";
            // 
            // JobEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(905, 482);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cmb_Service);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Chk_Remember);
            this.Controls.Add(this.Lbl_Total_Time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Open_Folder);
            this.Controls.Add(this.Txt_Folder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cmb_Currency);
            this.Controls.Add(this.Txt_Price);
            this.Controls.Add(this.Cmb_Catagory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cmb_Client);
            this.Controls.Add(this.Cmb_Job_Type);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.Txt_Location);
            this.Controls.Add(this.Btn_Submit_Job);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Dtp_Delivery);
            this.Controls.Add(this.Txt_Job_Time);
            this.Controls.Add(this.Txt_Amount);
            this.Controls.Add(this.Txt_Job_ID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "JobEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Job";
            this.Load += new System.EventHandler(this.Add_Job_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_Total_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Open_Folder;
        private System.Windows.Forms.TextBox Txt_Folder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cmb_Currency;
        private System.Windows.Forms.TextBox Txt_Price;
        private System.Windows.Forms.ComboBox Cmb_Catagory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cmb_Client;
        private System.Windows.Forms.ComboBox Cmb_Job_Type;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Button Btn_Submit_Job;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker Dtp_Delivery;
        private System.Windows.Forms.TextBox Txt_Job_Time;
        private System.Windows.Forms.TextBox Txt_Amount;
        private System.Windows.Forms.TextBox Txt_Job_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox Chk_Remember;
        private System.Windows.Forms.ComboBox Cmb_Service;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}