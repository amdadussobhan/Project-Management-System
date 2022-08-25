namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class Processing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Processing));
            this.Chk_Basic_Process = new System.Windows.Forms.CheckBox();
            this.Chk_Post_Process = new System.Windows.Forms.CheckBox();
            this.Chk_Pre_Process = new System.Windows.Forms.CheckBox();
            this.Chk_Clipping_Path = new System.Windows.Forms.CheckBox();
            this.Btn_Job_Folder = new System.Windows.Forms.Button();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Ready_Folder = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Pause = new System.Windows.Forms.Button();
            this.Lbl_Count = new System.Windows.Forms.Label();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Tmr_Count_Processing = new System.Windows.Forms.Timer(this.components);
            this.Pnl_Counter = new System.Windows.Forms.Panel();
            this.Lbl_Job_Time = new System.Windows.Forms.Label();
            this.Pnl_Service = new System.Windows.Forms.Panel();
            this.Pnl_Format = new System.Windows.Forms.Panel();
            this.Rdb_PSD = new System.Windows.Forms.RadioButton();
            this.Rdb_JPG = new System.Windows.Forms.RadioButton();
            this.Rdb_PNG = new System.Windows.Forms.RadioButton();
            this.Txt_image = new System.Windows.Forms.TextBox();
            this.Rdb_TIF = new System.Windows.Forms.RadioButton();
            this.Pnl_Drop = new System.Windows.Forms.Panel();
            this.Pnl_Start_Job = new System.Windows.Forms.Panel();
            this.Btn_My_Folder = new System.Windows.Forms.Button();
            this.CMB_Share = new System.Windows.Forms.ComboBox();
            this.BTN_Share = new System.Windows.Forms.Button();
            this.Btn_Instruction = new System.Windows.Forms.Button();
            this.Txt_Mnt = new System.Windows.Forms.TextBox();
            this.Tmr_Pause = new System.Windows.Forms.Timer(this.components);
            this.Btn_Label = new System.Windows.Forms.Button();
            this.Pnl_Counter.SuspendLayout();
            this.Pnl_Service.SuspendLayout();
            this.Pnl_Format.SuspendLayout();
            this.Pnl_Start_Job.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chk_Basic_Process
            // 
            this.Chk_Basic_Process.AutoSize = true;
            this.Chk_Basic_Process.Enabled = false;
            this.Chk_Basic_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Basic_Process.Location = new System.Drawing.Point(15, 34);
            this.Chk_Basic_Process.Name = "Chk_Basic_Process";
            this.Chk_Basic_Process.Size = new System.Drawing.Size(143, 26);
            this.Chk_Basic_Process.TabIndex = 346;
            this.Chk_Basic_Process.Text = "Basic Process";
            this.Chk_Basic_Process.UseVisualStyleBackColor = true;
            this.Chk_Basic_Process.CheckedChanged += new System.EventHandler(this.Chk_Basic_Process_CheckedChanged);
            // 
            // Chk_Post_Process
            // 
            this.Chk_Post_Process.AutoSize = true;
            this.Chk_Post_Process.Enabled = false;
            this.Chk_Post_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Post_Process.Location = new System.Drawing.Point(308, 34);
            this.Chk_Post_Process.Name = "Chk_Post_Process";
            this.Chk_Post_Process.Size = new System.Drawing.Size(135, 26);
            this.Chk_Post_Process.TabIndex = 349;
            this.Chk_Post_Process.Text = "Post Process";
            this.Chk_Post_Process.UseVisualStyleBackColor = true;
            this.Chk_Post_Process.CheckedChanged += new System.EventHandler(this.Chk_Post_Process_CheckedChanged);
            // 
            // Chk_Pre_Process
            // 
            this.Chk_Pre_Process.AutoSize = true;
            this.Chk_Pre_Process.Enabled = false;
            this.Chk_Pre_Process.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Pre_Process.Location = new System.Drawing.Point(308, 5);
            this.Chk_Pre_Process.Name = "Chk_Pre_Process";
            this.Chk_Pre_Process.Size = new System.Drawing.Size(127, 26);
            this.Chk_Pre_Process.TabIndex = 350;
            this.Chk_Pre_Process.Text = "Pre Process";
            this.Chk_Pre_Process.UseVisualStyleBackColor = true;
            this.Chk_Pre_Process.CheckedChanged += new System.EventHandler(this.Chk_Pre_Process_CheckedChanged);
            // 
            // Chk_Clipping_Path
            // 
            this.Chk_Clipping_Path.AutoSize = true;
            this.Chk_Clipping_Path.Enabled = false;
            this.Chk_Clipping_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Chk_Clipping_Path.Location = new System.Drawing.Point(15, 5);
            this.Chk_Clipping_Path.Name = "Chk_Clipping_Path";
            this.Chk_Clipping_Path.Size = new System.Drawing.Size(136, 26);
            this.Chk_Clipping_Path.TabIndex = 366;
            this.Chk_Clipping_Path.Text = "Clipping Path";
            this.Chk_Clipping_Path.UseVisualStyleBackColor = true;
            this.Chk_Clipping_Path.CheckedChanged += new System.EventHandler(this.Chk_Clipping_Path_CheckedChanged);
            // 
            // Btn_Job_Folder
            // 
            this.Btn_Job_Folder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btn_Job_Folder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Job_Folder.BackgroundImage")));
            this.Btn_Job_Folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_Job_Folder.FlatAppearance.BorderSize = 0;
            this.Btn_Job_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Job_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Job_Folder.Location = new System.Drawing.Point(53, 0);
            this.Btn_Job_Folder.Name = "Btn_Job_Folder";
            this.Btn_Job_Folder.Size = new System.Drawing.Size(44, 37);
            this.Btn_Job_Folder.TabIndex = 0;
            this.Btn_Job_Folder.UseVisualStyleBackColor = false;
            this.Btn_Job_Folder.Click += new System.EventHandler(this.Btn_Job_Folder_Click);
            // 
            // Btn_Start
            // 
            this.Btn_Start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Start.Enabled = false;
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Start.Location = new System.Drawing.Point(7, 120);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(444, 35);
            this.Btn_Start.TabIndex = 391;
            this.Btn_Start.Text = "Start Job";
            this.Btn_Start.UseVisualStyleBackColor = false;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Ready_Folder
            // 
            this.Btn_Ready_Folder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Ready_Folder.BackgroundImage")));
            this.Btn_Ready_Folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_Ready_Folder.FlatAppearance.BorderSize = 0;
            this.Btn_Ready_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Ready_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Ready_Folder.Location = new System.Drawing.Point(148, -2);
            this.Btn_Ready_Folder.Name = "Btn_Ready_Folder";
            this.Btn_Ready_Folder.Size = new System.Drawing.Size(49, 39);
            this.Btn_Ready_Folder.TabIndex = 394;
            this.Btn_Ready_Folder.UseVisualStyleBackColor = true;
            this.Btn_Ready_Folder.Click += new System.EventHandler(this.Btn_Ready_Folder_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.Location = new System.Drawing.Point(352, 3);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(100, 35);
            this.Btn_Save.TabIndex = 395;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Pause
            // 
            this.Btn_Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pause.Location = new System.Drawing.Point(251, 3);
            this.Btn_Pause.Name = "Btn_Pause";
            this.Btn_Pause.Size = new System.Drawing.Size(100, 35);
            this.Btn_Pause.TabIndex = 396;
            this.Btn_Pause.Text = "Pause";
            this.Btn_Pause.UseVisualStyleBackColor = true;
            this.Btn_Pause.Click += new System.EventHandler(this.Btn_Pause_Click);
            // 
            // Lbl_Count
            // 
            this.Lbl_Count.AutoSize = true;
            this.Lbl_Count.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Count.ForeColor = System.Drawing.Color.Purple;
            this.Lbl_Count.Location = new System.Drawing.Point(12, 40);
            this.Lbl_Count.Name = "Lbl_Count";
            this.Lbl_Count.Size = new System.Drawing.Size(130, 39);
            this.Lbl_Count.TabIndex = 397;
            this.Lbl_Count.Text = "0:00:00";
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.LightCoral;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.Location = new System.Drawing.Point(150, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(100, 35);
            this.Btn_Cancel.TabIndex = 398;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Tmr_Count_Processing
            // 
            this.Tmr_Count_Processing.Interval = 1000;
            this.Tmr_Count_Processing.Tick += new System.EventHandler(this.Tmr_Count_Tick);
            // 
            // Pnl_Counter
            // 
            this.Pnl_Counter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Pnl_Counter.Controls.Add(this.Lbl_Job_Time);
            this.Pnl_Counter.Controls.Add(this.Btn_Cancel);
            this.Pnl_Counter.Controls.Add(this.Btn_Save);
            this.Pnl_Counter.Controls.Add(this.Btn_Pause);
            this.Pnl_Counter.Controls.Add(this.Lbl_Count);
            this.Pnl_Counter.Location = new System.Drawing.Point(1, 119);
            this.Pnl_Counter.Name = "Pnl_Counter";
            this.Pnl_Counter.Size = new System.Drawing.Size(455, 40);
            this.Pnl_Counter.TabIndex = 399;
            this.Pnl_Counter.Visible = false;
            // 
            // Lbl_Job_Time
            // 
            this.Lbl_Job_Time.AutoSize = true;
            this.Lbl_Job_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Lbl_Job_Time.Location = new System.Drawing.Point(15, 7);
            this.Lbl_Job_Time.Name = "Lbl_Job_Time";
            this.Lbl_Job_Time.Size = new System.Drawing.Size(89, 24);
            this.Lbl_Job_Time.TabIndex = 399;
            this.Lbl_Job_Time.Text = "Job Time";
            // 
            // Pnl_Service
            // 
            this.Pnl_Service.Controls.Add(this.Chk_Clipping_Path);
            this.Pnl_Service.Controls.Add(this.Chk_Pre_Process);
            this.Pnl_Service.Controls.Add(this.Chk_Post_Process);
            this.Pnl_Service.Controls.Add(this.Chk_Basic_Process);
            this.Pnl_Service.Location = new System.Drawing.Point(0, 42);
            this.Pnl_Service.Name = "Pnl_Service";
            this.Pnl_Service.Size = new System.Drawing.Size(455, 65);
            this.Pnl_Service.TabIndex = 400;
            // 
            // Pnl_Format
            // 
            this.Pnl_Format.Controls.Add(this.Rdb_PSD);
            this.Pnl_Format.Controls.Add(this.Rdb_JPG);
            this.Pnl_Format.Controls.Add(this.Rdb_PNG);
            this.Pnl_Format.Controls.Add(this.Txt_image);
            this.Pnl_Format.Controls.Add(this.Rdb_TIF);
            this.Pnl_Format.Location = new System.Drawing.Point(1, 41);
            this.Pnl_Format.Name = "Pnl_Format";
            this.Pnl_Format.Size = new System.Drawing.Size(455, 67);
            this.Pnl_Format.TabIndex = 401;
            this.Pnl_Format.Visible = false;
            // 
            // Rdb_PSD
            // 
            this.Rdb_PSD.AutoSize = true;
            this.Rdb_PSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_PSD.Location = new System.Drawing.Point(15, 42);
            this.Rdb_PSD.Name = "Rdb_PSD";
            this.Rdb_PSD.Size = new System.Drawing.Size(63, 24);
            this.Rdb_PSD.TabIndex = 384;
            this.Rdb_PSD.TabStop = true;
            this.Rdb_PSD.Text = "PSD";
            this.Rdb_PSD.UseVisualStyleBackColor = true;
            this.Rdb_PSD.CheckedChanged += new System.EventHandler(this.Rdb_PSD_CheckedChanged);
            // 
            // Rdb_JPG
            // 
            this.Rdb_JPG.AutoSize = true;
            this.Rdb_JPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_JPG.Location = new System.Drawing.Point(139, 42);
            this.Rdb_JPG.Name = "Rdb_JPG";
            this.Rdb_JPG.Size = new System.Drawing.Size(61, 24);
            this.Rdb_JPG.TabIndex = 385;
            this.Rdb_JPG.TabStop = true;
            this.Rdb_JPG.Text = "JPG";
            this.Rdb_JPG.UseVisualStyleBackColor = true;
            this.Rdb_JPG.CheckedChanged += new System.EventHandler(this.Rdb_JPG_CheckedChanged);
            // 
            // Rdb_PNG
            // 
            this.Rdb_PNG.AutoSize = true;
            this.Rdb_PNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_PNG.Location = new System.Drawing.Point(261, 42);
            this.Rdb_PNG.Name = "Rdb_PNG";
            this.Rdb_PNG.Size = new System.Drawing.Size(64, 24);
            this.Rdb_PNG.TabIndex = 386;
            this.Rdb_PNG.TabStop = true;
            this.Rdb_PNG.Text = "PNG";
            this.Rdb_PNG.UseVisualStyleBackColor = true;
            this.Rdb_PNG.CheckedChanged += new System.EventHandler(this.Rdb_PNG_CheckedChanged);
            // 
            // Txt_image
            // 
            this.Txt_image.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Txt_image.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Txt_image.Location = new System.Drawing.Point(5, 10);
            this.Txt_image.Margin = new System.Windows.Forms.Padding(20);
            this.Txt_image.Multiline = true;
            this.Txt_image.Name = "Txt_image";
            this.Txt_image.Size = new System.Drawing.Size(444, 30);
            this.Txt_image.TabIndex = 404;
            this.Txt_image.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Rdb_TIF
            // 
            this.Rdb_TIF.AutoSize = true;
            this.Rdb_TIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rdb_TIF.Location = new System.Drawing.Point(386, 42);
            this.Rdb_TIF.Name = "Rdb_TIF";
            this.Rdb_TIF.Size = new System.Drawing.Size(54, 24);
            this.Rdb_TIF.TabIndex = 387;
            this.Rdb_TIF.TabStop = true;
            this.Rdb_TIF.Text = "TIF";
            this.Rdb_TIF.UseVisualStyleBackColor = true;
            this.Rdb_TIF.CheckedChanged += new System.EventHandler(this.Rdb_TIF_CheckedChanged);
            // 
            // Pnl_Drop
            // 
            this.Pnl_Drop.AllowDrop = true;
            this.Pnl_Drop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pnl_Drop.Location = new System.Drawing.Point(0, 38);
            this.Pnl_Drop.Name = "Pnl_Drop";
            this.Pnl_Drop.Size = new System.Drawing.Size(455, 75);
            this.Pnl_Drop.TabIndex = 403;
            this.Pnl_Drop.Visible = false;
            this.Pnl_Drop.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pnl_Drop_DragDrop);
            this.Pnl_Drop.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pnl_Drop_DragEnter);
            // 
            // Pnl_Start_Job
            // 
            this.Pnl_Start_Job.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Pnl_Start_Job.Controls.Add(this.Btn_Label);
            this.Pnl_Start_Job.Location = new System.Drawing.Point(0, 118);
            this.Pnl_Start_Job.Name = "Pnl_Start_Job";
            this.Pnl_Start_Job.Size = new System.Drawing.Size(455, 40);
            this.Pnl_Start_Job.TabIndex = 400;
            // 
            // Btn_My_Folder
            // 
            this.Btn_My_Folder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btn_My_Folder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_My_Folder.BackgroundImage")));
            this.Btn_My_Folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_My_Folder.Enabled = false;
            this.Btn_My_Folder.FlatAppearance.BorderSize = 0;
            this.Btn_My_Folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_My_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_My_Folder.Location = new System.Drawing.Point(100, -4);
            this.Btn_My_Folder.Name = "Btn_My_Folder";
            this.Btn_My_Folder.Size = new System.Drawing.Size(45, 41);
            this.Btn_My_Folder.TabIndex = 404;
            this.Btn_My_Folder.UseVisualStyleBackColor = false;
            this.Btn_My_Folder.Click += new System.EventHandler(this.Btn_My_Folder_Click);
            // 
            // CMB_Share
            // 
            this.CMB_Share.Enabled = false;
            this.CMB_Share.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CMB_Share.FormattingEnabled = true;
            this.CMB_Share.Location = new System.Drawing.Point(201, 5);
            this.CMB_Share.Name = "CMB_Share";
            this.CMB_Share.Size = new System.Drawing.Size(121, 28);
            this.CMB_Share.TabIndex = 405;
            this.CMB_Share.TextChanged += new System.EventHandler(this.CMB_Share_TextChanged);
            // 
            // BTN_Share
            // 
            this.BTN_Share.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_Share.Enabled = false;
            this.BTN_Share.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Share.Location = new System.Drawing.Point(377, 2);
            this.BTN_Share.Name = "BTN_Share";
            this.BTN_Share.Size = new System.Drawing.Size(74, 33);
            this.BTN_Share.TabIndex = 406;
            this.BTN_Share.Text = "Share";
            this.BTN_Share.UseVisualStyleBackColor = true;
            this.BTN_Share.Click += new System.EventHandler(this.BTN_Share_Click);
            // 
            // Btn_Instruction
            // 
            this.Btn_Instruction.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btn_Instruction.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Instruction.BackgroundImage")));
            this.Btn_Instruction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Btn_Instruction.FlatAppearance.BorderSize = 0;
            this.Btn_Instruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Instruction.Location = new System.Drawing.Point(6, 0);
            this.Btn_Instruction.Name = "Btn_Instruction";
            this.Btn_Instruction.Size = new System.Drawing.Size(44, 37);
            this.Btn_Instruction.TabIndex = 407;
            this.Btn_Instruction.UseVisualStyleBackColor = false;
            this.Btn_Instruction.Click += new System.EventHandler(this.Btn_Instruction_Click);
            // 
            // Txt_Mnt
            // 
            this.Txt_Mnt.Enabled = false;
            this.Txt_Mnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Mnt.Location = new System.Drawing.Point(328, 5);
            this.Txt_Mnt.Name = "Txt_Mnt";
            this.Txt_Mnt.Size = new System.Drawing.Size(43, 29);
            this.Txt_Mnt.TabIndex = 408;
            this.Txt_Mnt.TextChanged += new System.EventHandler(this.Txt_Mnt_TextChanged);
            // 
            // Tmr_Pause
            // 
            this.Tmr_Pause.Interval = 30000;
            this.Tmr_Pause.Tick += new System.EventHandler(this.Tmr_Pause_Tick);
            // 
            // Btn_Label
            // 
            this.Btn_Label.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Btn_Label.Enabled = false;
            this.Btn_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Label.Location = new System.Drawing.Point(6, 2);
            this.Btn_Label.Name = "Btn_Label";
            this.Btn_Label.Size = new System.Drawing.Size(444, 35);
            this.Btn_Label.TabIndex = 409;
            this.Btn_Label.UseVisualStyleBackColor = false;
            // 
            // Processing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(455, 161);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Pnl_Service);
            this.Controls.Add(this.Pnl_Start_Job);
            this.Controls.Add(this.Txt_Mnt);
            this.Controls.Add(this.Btn_Instruction);
            this.Controls.Add(this.BTN_Share);
            this.Controls.Add(this.CMB_Share);
            this.Controls.Add(this.Btn_My_Folder);
            this.Controls.Add(this.Btn_Ready_Folder);
            this.Controls.Add(this.Btn_Job_Folder);
            this.Controls.Add(this.Pnl_Drop);
            this.Controls.Add(this.Pnl_Format);
            this.Controls.Add(this.Pnl_Counter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(50, 777);
            this.MaximizeBox = false;
            this.Name = "Processing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Processing";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Processing_FormClosed);
            this.Load += new System.EventHandler(this.Processing_Load);
            this.Resize += new System.EventHandler(this.Processing_Resize);
            this.Pnl_Counter.ResumeLayout(false);
            this.Pnl_Counter.PerformLayout();
            this.Pnl_Service.ResumeLayout(false);
            this.Pnl_Service.PerformLayout();
            this.Pnl_Format.ResumeLayout(false);
            this.Pnl_Format.PerformLayout();
            this.Pnl_Start_Job.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox Chk_Basic_Process;
        private System.Windows.Forms.CheckBox Chk_Post_Process;
        private System.Windows.Forms.CheckBox Chk_Pre_Process;
        private System.Windows.Forms.CheckBox Chk_Clipping_Path;
        private System.Windows.Forms.Button Btn_Job_Folder;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Ready_Folder;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Pause;
        private System.Windows.Forms.Label Lbl_Count;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Timer Tmr_Count_Processing;
        private System.Windows.Forms.Panel Pnl_Counter;
        private System.Windows.Forms.Panel Pnl_Service;
        private System.Windows.Forms.Panel Pnl_Format;
        private System.Windows.Forms.RadioButton Rdb_TIF;
        private System.Windows.Forms.RadioButton Rdb_PSD;
        private System.Windows.Forms.RadioButton Rdb_JPG;
        private System.Windows.Forms.RadioButton Rdb_PNG;
        private System.Windows.Forms.TextBox Txt_image;
        private System.Windows.Forms.Panel Pnl_Drop;
        private System.Windows.Forms.Panel Pnl_Start_Job;
        private System.Windows.Forms.Button Btn_My_Folder;
        private System.Windows.Forms.ComboBox CMB_Share;
        private System.Windows.Forms.Button BTN_Share;
        private System.Windows.Forms.Button Btn_Instruction;
        private System.Windows.Forms.TextBox Txt_Mnt;
        private System.Windows.Forms.Label Lbl_Job_Time;
        private System.Windows.Forms.Timer Tmr_Pause;
        private System.Windows.Forms.Button Btn_Label;
    }
}