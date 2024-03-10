namespace Skill_PMS.UI_WinForm.Production.SI_Panel
{
    partial class Job_assign
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
            this.Txt_Post_Pro = new System.Windows.Forms.TextBox();
            this.Txt_Pre_Pro = new System.Windows.Forms.TextBox();
            this.Txt_Retouch = new System.Windows.Forms.TextBox();
            this.Txt_Clipping = new System.Windows.Forms.TextBox();
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Btn_Subfolder = new System.Windows.Forms.Button();
            this.Lbl_Actual_Time = new System.Windows.Forms.Label();
            this.Lbl_Amount = new System.Windows.Forms.Label();
            this.Lbl_Target_Time = new System.Windows.Forms.Label();
            this.Lbl_Delivery = new System.Windows.Forms.Label();
            this.Lbl_Job_ID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Cmb_Type = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Btn_Open_Folder = new System.Windows.Forms.Button();
            this.Rdb_TIF = new System.Windows.Forms.RadioButton();
            this.Rdb_PSD = new System.Windows.Forms.RadioButton();
            this.Rdb_JPG = new System.Windows.Forms.RadioButton();
            this.Rdb_PNG = new System.Windows.Forms.RadioButton();
            this.Btn_assign = new System.Windows.Forms.Button();
            this.Prb_FolderTime = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Team = new System.Windows.Forms.ComboBox();
            this.Txt_File = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_Folder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.Lbl_Basic = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Lbl_Incoming = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_QC = new System.Windows.Forms.TextBox();
            this.Chk_MSK = new System.Windows.Forms.CheckBox();
            this.Chk_SHA = new System.Windows.Forms.CheckBox();
            this.Chk_NJ = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Chk_CC = new System.Windows.Forms.CheckBox();
            this.Chk_RES = new System.Windows.Forms.CheckBox();
            this.jobBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Save.Location = new System.Drawing.Point(807, 411);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(134, 35);
            this.Btn_Save.TabIndex = 317;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Txt_Post_Pro
            // 
            this.Txt_Post_Pro.Enabled = false;
            this.Txt_Post_Pro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Post_Pro.Location = new System.Drawing.Point(126, 45);
            this.Txt_Post_Pro.Name = "Txt_Post_Pro";
            this.Txt_Post_Pro.Size = new System.Drawing.Size(121, 26);
            this.Txt_Post_Pro.TabIndex = 307;
            this.Txt_Post_Pro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Post_Pro.TextChanged += new System.EventHandler(this.Txt_Post_Process_TextChanged);
            // 
            // Txt_Pre_Pro
            // 
            this.Txt_Pre_Pro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Pre_Pro.Location = new System.Drawing.Point(5, 45);
            this.Txt_Pre_Pro.Name = "Txt_Pre_Pro";
            this.Txt_Pre_Pro.Size = new System.Drawing.Size(121, 26);
            this.Txt_Pre_Pro.TabIndex = 306;
            this.Txt_Pre_Pro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Pre_Pro.TextChanged += new System.EventHandler(this.Txt_Pre_Process_TextChanged);
            // 
            // Txt_Retouch
            // 
            this.Txt_Retouch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Retouch.Location = new System.Drawing.Point(5, 44);
            this.Txt_Retouch.Name = "Txt_Retouch";
            this.Txt_Retouch.Size = new System.Drawing.Size(121, 26);
            this.Txt_Retouch.TabIndex = 303;
            this.Txt_Retouch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Retouch.TextChanged += new System.EventHandler(this.Txt_Basics_TextChanged);
            // 
            // Txt_Clipping
            // 
            this.Txt_Clipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Clipping.Location = new System.Drawing.Point(5, 45);
            this.Txt_Clipping.Name = "Txt_Clipping";
            this.Txt_Clipping.Size = new System.Drawing.Size(121, 26);
            this.Txt_Clipping.TabIndex = 336;
            this.Txt_Clipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Clipping.TextChanged += new System.EventHandler(this.Txt_Clipping_TextChanged);
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Location.Location = new System.Drawing.Point(147, 217);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(525, 30);
            this.Txt_Location.TabIndex = 312;
            this.Txt_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(39, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 26);
            this.label17.TabIndex = 329;
            this.label17.Text = "Location :";
            // 
            // Btn_Subfolder
            // 
            this.Btn_Subfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Subfolder.Location = new System.Drawing.Point(814, 160);
            this.Btn_Subfolder.Name = "Btn_Subfolder";
            this.Btn_Subfolder.Size = new System.Drawing.Size(123, 35);
            this.Btn_Subfolder.TabIndex = 328;
            this.Btn_Subfolder.Text = "Merge Folder";
            this.Btn_Subfolder.UseVisualStyleBackColor = true;
            this.Btn_Subfolder.Click += new System.EventHandler(this.Btn_Subfolder_Click);
            // 
            // Lbl_Actual_Time
            // 
            this.Lbl_Actual_Time.AutoSize = true;
            this.Lbl_Actual_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Actual_Time.Location = new System.Drawing.Point(830, 78);
            this.Lbl_Actual_Time.Name = "Lbl_Actual_Time";
            this.Lbl_Actual_Time.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Actual_Time.TabIndex = 326;
            // 
            // Lbl_Amount
            // 
            this.Lbl_Amount.AutoSize = true;
            this.Lbl_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Amount.Location = new System.Drawing.Point(830, 39);
            this.Lbl_Amount.Name = "Lbl_Amount";
            this.Lbl_Amount.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Amount.TabIndex = 325;
            // 
            // Lbl_Target_Time
            // 
            this.Lbl_Target_Time.AutoSize = true;
            this.Lbl_Target_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Target_Time.Location = new System.Drawing.Point(830, 114);
            this.Lbl_Target_Time.Name = "Lbl_Target_Time";
            this.Lbl_Target_Time.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Target_Time.TabIndex = 324;
            // 
            // Lbl_Delivery
            // 
            this.Lbl_Delivery.AutoSize = true;
            this.Lbl_Delivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Delivery.Location = new System.Drawing.Point(155, 119);
            this.Lbl_Delivery.Name = "Lbl_Delivery";
            this.Lbl_Delivery.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Delivery.TabIndex = 323;
            // 
            // Lbl_Job_ID
            // 
            this.Lbl_Job_ID.AutoSize = true;
            this.Lbl_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Job_ID.Location = new System.Drawing.Point(155, 41);
            this.Lbl_Job_ID.Name = "Lbl_Job_ID";
            this.Lbl_Job_ID.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Job_ID.TabIndex = 322;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 26);
            this.label5.TabIndex = 319;
            this.label5.Text = "Delivery :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(681, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 26);
            this.label6.TabIndex = 318;
            this.label6.Text = "Target Time :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(696, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 26);
            this.label7.TabIndex = 316;
            this.label7.Text = "Lock Time :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(708, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 26);
            this.label8.TabIndex = 315;
            this.label8.Text = "Total File :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 26);
            this.label4.TabIndex = 314;
            this.label4.Text = "Folder :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 313;
            this.label1.Text = "Job ID :";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Cancel.Location = new System.Drawing.Point(48, 411);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(133, 35);
            this.Btn_Cancel.TabIndex = 339;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Cmb_Type
            // 
            this.Cmb_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Type.FormattingEnabled = true;
            this.Cmb_Type.Items.AddRange(new object[] {
            "Simple",
            "Medium",
            "Complex"});
            this.Cmb_Type.Location = new System.Drawing.Point(551, 269);
            this.Cmb_Type.Name = "Cmb_Type";
            this.Cmb_Type.Size = new System.Drawing.Size(121, 28);
            this.Cmb_Type.TabIndex = 342;
            this.Cmb_Type.SelectedIndexChanged += new System.EventHandler(this.Cmb_Type_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label10.Location = new System.Drawing.Point(444, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 25);
            this.label10.TabIndex = 343;
            this.label10.Text = "Category :";
            // 
            // Btn_Open_Folder
            // 
            this.Btn_Open_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Open_Folder.Location = new System.Drawing.Point(682, 160);
            this.Btn_Open_Folder.Name = "Btn_Open_Folder";
            this.Btn_Open_Folder.Size = new System.Drawing.Size(123, 35);
            this.Btn_Open_Folder.TabIndex = 344;
            this.Btn_Open_Folder.Text = "Open Folder";
            this.Btn_Open_Folder.UseVisualStyleBackColor = true;
            this.Btn_Open_Folder.Click += new System.EventHandler(this.Btn_Open_Folder_Click);
            // 
            // Rdb_TIF
            // 
            this.Rdb_TIF.AutoSize = true;
            this.Rdb_TIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_TIF.Location = new System.Drawing.Point(658, 416);
            this.Rdb_TIF.Name = "Rdb_TIF";
            this.Rdb_TIF.Size = new System.Drawing.Size(54, 24);
            this.Rdb_TIF.TabIndex = 391;
            this.Rdb_TIF.TabStop = true;
            this.Rdb_TIF.Text = "TIF";
            this.Rdb_TIF.UseVisualStyleBackColor = true;
            this.Rdb_TIF.CheckedChanged += new System.EventHandler(this.Rdb_TIF_CheckedChanged);
            // 
            // Rdb_PSD
            // 
            this.Rdb_PSD.AutoSize = true;
            this.Rdb_PSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_PSD.Location = new System.Drawing.Point(286, 416);
            this.Rdb_PSD.Name = "Rdb_PSD";
            this.Rdb_PSD.Size = new System.Drawing.Size(63, 24);
            this.Rdb_PSD.TabIndex = 388;
            this.Rdb_PSD.TabStop = true;
            this.Rdb_PSD.Text = "PSD";
            this.Rdb_PSD.UseVisualStyleBackColor = true;
            this.Rdb_PSD.CheckedChanged += new System.EventHandler(this.Rdb_PSD_CheckedChanged);
            // 
            // Rdb_JPG
            // 
            this.Rdb_JPG.AutoSize = true;
            this.Rdb_JPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_JPG.Location = new System.Drawing.Point(405, 416);
            this.Rdb_JPG.Name = "Rdb_JPG";
            this.Rdb_JPG.Size = new System.Drawing.Size(61, 24);
            this.Rdb_JPG.TabIndex = 389;
            this.Rdb_JPG.TabStop = true;
            this.Rdb_JPG.Text = "JPG";
            this.Rdb_JPG.UseVisualStyleBackColor = true;
            this.Rdb_JPG.CheckedChanged += new System.EventHandler(this.Rdb_JPG_CheckedChanged);
            // 
            // Rdb_PNG
            // 
            this.Rdb_PNG.AutoSize = true;
            this.Rdb_PNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_PNG.Location = new System.Drawing.Point(530, 416);
            this.Rdb_PNG.Name = "Rdb_PNG";
            this.Rdb_PNG.Size = new System.Drawing.Size(64, 24);
            this.Rdb_PNG.TabIndex = 390;
            this.Rdb_PNG.TabStop = true;
            this.Rdb_PNG.Text = "PNG";
            this.Rdb_PNG.UseVisualStyleBackColor = true;
            this.Rdb_PNG.CheckedChanged += new System.EventHandler(this.Rdb_PNG_CheckedChanged);
            // 
            // Btn_assign
            // 
            this.Btn_assign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_assign.Location = new System.Drawing.Point(683, 214);
            this.Btn_assign.Name = "Btn_assign";
            this.Btn_assign.Size = new System.Drawing.Size(123, 35);
            this.Btn_assign.TabIndex = 394;
            this.Btn_assign.Text = "Assign Time";
            this.Btn_assign.UseVisualStyleBackColor = true;
            this.Btn_assign.Click += new System.EventHandler(this.Btn_assign_Click);
            // 
            // Prb_FolderTime
            // 
            this.Prb_FolderTime.Location = new System.Drawing.Point(9, 464);
            this.Prb_FolderTime.Maximum = 0;
            this.Prb_FolderTime.Name = "Prb_FolderTime";
            this.Prb_FolderTime.Size = new System.Drawing.Size(960, 10);
            this.Prb_FolderTime.TabIndex = 395;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 26);
            this.label2.TabIndex = 397;
            this.label2.Text = "Job Type :";
            // 
            // Cmb_Team
            // 
            this.Cmb_Team.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Team.FormattingEnabled = true;
            this.Cmb_Team.Items.AddRange(new object[] {
            "Basic",
            "Advance"});
            this.Cmb_Team.Location = new System.Drawing.Point(146, 271);
            this.Cmb_Team.Name = "Cmb_Team";
            this.Cmb_Team.Size = new System.Drawing.Size(121, 28);
            this.Cmb_Team.TabIndex = 396;
            // 
            // Txt_File
            // 
            this.Txt_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_File.Location = new System.Drawing.Point(816, 272);
            this.Txt_File.Name = "Txt_File";
            this.Txt_File.Size = new System.Drawing.Size(121, 26);
            this.Txt_File.TabIndex = 398;
            this.Txt_File.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(706, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 26);
            this.label11.TabIndex = 399;
            this.label11.Text = "Quantity :";
            // 
            // Txt_Folder
            // 
            this.Txt_Folder.Enabled = false;
            this.Txt_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Folder.Location = new System.Drawing.Point(147, 163);
            this.Txt_Folder.Name = "Txt_Folder";
            this.Txt_Folder.Size = new System.Drawing.Size(525, 30);
            this.Txt_Folder.TabIndex = 401;
            this.Txt_Folder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(814, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 35);
            this.button1.TabIndex = 403;
            this.button1.Text = "Rename File";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label12.Location = new System.Drawing.Point(26, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 25);
            this.label12.TabIndex = 404;
            this.label12.Text = "Clipping";
            // 
            // Lbl_Basic
            // 
            this.Lbl_Basic.AutoSize = true;
            this.Lbl_Basic.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Lbl_Basic.Location = new System.Drawing.Point(25, 12);
            this.Lbl_Basic.Name = "Lbl_Basic";
            this.Lbl_Basic.Size = new System.Drawing.Size(84, 25);
            this.Lbl_Basic.TabIndex = 405;
            this.Lbl_Basic.Text = "Retouch";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label14.Location = new System.Drawing.Point(1, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 25);
            this.label14.TabIndex = 406;
            this.label14.Text = "Post Process";
            // 
            // Lbl_Incoming
            // 
            this.Lbl_Incoming.AutoSize = true;
            this.Lbl_Incoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Incoming.Location = new System.Drawing.Point(155, 81);
            this.Lbl_Incoming.Name = "Lbl_Incoming";
            this.Lbl_Incoming.Size = new System.Drawing.Size(0, 26);
            this.Lbl_Incoming.TabIndex = 409;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 26);
            this.label9.TabIndex = 408;
            this.label9.Text = "Incoming :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(74, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 411;
            this.label3.Text = "+ QC";
            // 
            // Txt_QC
            // 
            this.Txt_QC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_QC.Location = new System.Drawing.Point(5, 45);
            this.Txt_QC.Name = "Txt_QC";
            this.Txt_QC.Size = new System.Drawing.Size(121, 26);
            this.Txt_QC.TabIndex = 410;
            this.Txt_QC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Chk_MSK
            // 
            this.Chk_MSK.AutoSize = true;
            this.Chk_MSK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Chk_MSK.Location = new System.Drawing.Point(7, 15);
            this.Chk_MSK.Name = "Chk_MSK";
            this.Chk_MSK.Size = new System.Drawing.Size(63, 22);
            this.Chk_MSK.TabIndex = 4;
            this.Chk_MSK.Text = "MSK";
            this.Chk_MSK.UseVisualStyleBackColor = true;
            this.Chk_MSK.CheckedChanged += new System.EventHandler(this.Chk_MSK_CheckedChanged);
            // 
            // Chk_SHA
            // 
            this.Chk_SHA.AutoSize = true;
            this.Chk_SHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Chk_SHA.Location = new System.Drawing.Point(130, 15);
            this.Chk_SHA.Name = "Chk_SHA";
            this.Chk_SHA.Size = new System.Drawing.Size(60, 22);
            this.Chk_SHA.TabIndex = 3;
            this.Chk_SHA.Text = "SHA";
            this.Chk_SHA.UseVisualStyleBackColor = true;
            this.Chk_SHA.CheckedChanged += new System.EventHandler(this.Chk_SHA_CheckedChanged);
            // 
            // Chk_NJ
            // 
            this.Chk_NJ.AutoSize = true;
            this.Chk_NJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Chk_NJ.Location = new System.Drawing.Point(76, 15);
            this.Chk_NJ.Name = "Chk_NJ";
            this.Chk_NJ.Size = new System.Drawing.Size(48, 22);
            this.Chk_NJ.TabIndex = 407;
            this.Chk_NJ.Text = "NJ";
            this.Chk_NJ.UseVisualStyleBackColor = true;
            this.Chk_NJ.CheckedChanged += new System.EventHandler(this.Chk_NJ_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label13.Location = new System.Drawing.Point(2, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 25);
            this.label13.TabIndex = 406;
            this.label13.Text = "Pre Pro (LIQ)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Txt_Clipping);
            this.groupBox1.Location = new System.Drawing.Point(50, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 77);
            this.groupBox1.TabIndex = 418;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Txt_Retouch);
            this.groupBox2.Controls.Add(this.Lbl_Basic);
            this.groupBox2.Location = new System.Drawing.Point(209, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 77);
            this.groupBox2.TabIndex = 419;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.Txt_Pre_Pro);
            this.groupBox3.Location = new System.Drawing.Point(368, 318);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 77);
            this.groupBox3.TabIndex = 419;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Chk_CC);
            this.groupBox4.Controls.Add(this.Chk_MSK);
            this.groupBox4.Controls.Add(this.Chk_NJ);
            this.groupBox4.Controls.Add(this.Txt_Post_Pro);
            this.groupBox4.Controls.Add(this.Chk_SHA);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(527, 318);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 77);
            this.groupBox4.TabIndex = 420;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Chk_RES);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.Txt_QC);
            this.groupBox5.Location = new System.Drawing.Point(807, 318);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 77);
            this.groupBox5.TabIndex = 420;
            this.groupBox5.TabStop = false;
            // 
            // Chk_CC
            // 
            this.Chk_CC.AutoSize = true;
            this.Chk_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Chk_CC.Location = new System.Drawing.Point(196, 15);
            this.Chk_CC.Name = "Chk_CC";
            this.Chk_CC.Size = new System.Drawing.Size(51, 22);
            this.Chk_CC.TabIndex = 408;
            this.Chk_CC.Text = "CC";
            this.Chk_CC.UseVisualStyleBackColor = true;
            this.Chk_CC.CheckedChanged += new System.EventHandler(this.Chk_CC_CheckedChanged);
            // 
            // Chk_RES
            // 
            this.Chk_RES.AutoSize = true;
            this.Chk_RES.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Chk_RES.Location = new System.Drawing.Point(6, 15);
            this.Chk_RES.Name = "Chk_RES";
            this.Chk_RES.Size = new System.Drawing.Size(61, 22);
            this.Chk_RES.TabIndex = 409;
            this.Chk_RES.Text = "RES";
            this.Chk_RES.UseVisualStyleBackColor = true;
            // 
            // jobBindingSource
            // 
            this.jobBindingSource.DataSource = typeof(Skill_PMS.Models.NewJob);
            // 
            // Job_assign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(979, 482);
            this.Controls.Add(this.Txt_File);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Lbl_Incoming);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Txt_Folder);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cmb_Team);
            this.Controls.Add(this.Prb_FolderTime);
            this.Controls.Add(this.Btn_assign);
            this.Controls.Add(this.Rdb_TIF);
            this.Controls.Add(this.Rdb_PSD);
            this.Controls.Add(this.Rdb_JPG);
            this.Controls.Add(this.Rdb_PNG);
            this.Controls.Add(this.Btn_Open_Folder);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Cmb_Type);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Txt_Location);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Btn_Subfolder);
            this.Controls.Add(this.Lbl_Actual_Time);
            this.Controls.Add(this.Lbl_Amount);
            this.Controls.Add(this.Lbl_Target_Time);
            this.Controls.Add(this.Lbl_Delivery);
            this.Controls.Add(this.Lbl_Job_ID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Job_assign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job_assign";
            this.Load += new System.EventHandler(this.Job_assign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox Txt_Post_Pro;
        private System.Windows.Forms.TextBox Txt_Pre_Pro;
        private System.Windows.Forms.TextBox Txt_Retouch;
        private System.Windows.Forms.TextBox Txt_Clipping;
        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button Btn_Subfolder;
        private System.Windows.Forms.Label Lbl_Actual_Time;
        private System.Windows.Forms.Label Lbl_Amount;
        private System.Windows.Forms.Label Lbl_Target_Time;
        private System.Windows.Forms.Label Lbl_Delivery;
        private System.Windows.Forms.Label Lbl_Job_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.ComboBox Cmb_Type;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Btn_Open_Folder;
        private System.Windows.Forms.BindingSource jobBindingSource;
        private System.Windows.Forms.RadioButton Rdb_TIF;
        private System.Windows.Forms.RadioButton Rdb_PSD;
        private System.Windows.Forms.RadioButton Rdb_JPG;
        private System.Windows.Forms.RadioButton Rdb_PNG;
        private System.Windows.Forms.Button Btn_assign;
        private System.Windows.Forms.ProgressBar Prb_FolderTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_Team;
        private System.Windows.Forms.TextBox Txt_File;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_Folder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Lbl_Basic;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Lbl_Incoming;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_QC;
        private System.Windows.Forms.CheckBox Chk_SHA;
        private System.Windows.Forms.CheckBox Chk_MSK;
        private System.Windows.Forms.CheckBox Chk_NJ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox Chk_CC;
        private System.Windows.Forms.CheckBox Chk_RES;
    }
}