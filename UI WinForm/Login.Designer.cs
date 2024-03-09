namespace Skill_PMS.UI_WinForm
{
    partial class Login
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
            this.Cmb_Shift = new System.Windows.Forms.ComboBox();
            this.Txt_Name = new System.Windows.Forms.TextBox();
            this.Lnk_Change_Pass = new System.Windows.Forms.LinkLabel();
            this.Txt_Pss = new System.Windows.Forms.TextBox();
            this.Txt_Usr = new System.Windows.Forms.TextBox();
            this.lblusr = new System.Windows.Forms.Label();
            this.lblpss = new System.Windows.Forms.Label();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Lnk_Sync = new System.Windows.Forms.LinkLabel();
            this.CMB_OT = new System.Windows.Forms.ComboBox();
            this.Txt_Designation = new System.Windows.Forms.TextBox();
            this.Txt_Server = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cmb_Shift
            // 
            this.Cmb_Shift.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Shift.FormattingEnabled = true;
            this.Cmb_Shift.Items.AddRange(new object[] {
            "Morning",
            "Evening",
            "Night"});
            this.Cmb_Shift.Location = new System.Drawing.Point(279, 116);
            this.Cmb_Shift.Name = "Cmb_Shift";
            this.Cmb_Shift.Size = new System.Drawing.Size(214, 30);
            this.Cmb_Shift.TabIndex = 2;
            // 
            // Txt_Name
            // 
            this.Txt_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Name.Location = new System.Drawing.Point(13, 6);
            this.Txt_Name.Name = "Txt_Name";
            this.Txt_Name.ReadOnly = true;
            this.Txt_Name.Size = new System.Drawing.Size(481, 31);
            this.Txt_Name.TabIndex = 19;
            this.Txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Lnk_Change_Pass
            // 
            this.Lnk_Change_Pass.AutoSize = true;
            this.Lnk_Change_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnk_Change_Pass.LinkColor = System.Drawing.Color.RoyalBlue;
            this.Lnk_Change_Pass.Location = new System.Drawing.Point(9, 169);
            this.Lnk_Change_Pass.Name = "Lnk_Change_Pass";
            this.Lnk_Change_Pass.Size = new System.Drawing.Size(130, 18);
            this.Lnk_Change_Pass.TabIndex = 5;
            this.Lnk_Change_Pass.TabStop = true;
            this.Lnk_Change_Pass.Text = "Change Password";
            // 
            // Txt_Pss
            // 
            this.Txt_Pss.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Pss.Location = new System.Drawing.Point(66, 116);
            this.Txt_Pss.Name = "Txt_Pss";
            this.Txt_Pss.PasswordChar = '*';
            this.Txt_Pss.Size = new System.Drawing.Size(200, 29);
            this.Txt_Pss.TabIndex = 1;
            this.Txt_Pss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Usr
            // 
            this.Txt_Usr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Usr.Location = new System.Drawing.Point(65, 79);
            this.Txt_Usr.Name = "Txt_Usr";
            this.Txt_Usr.Size = new System.Drawing.Size(201, 29);
            this.Txt_Usr.TabIndex = 0;
            this.Txt_Usr.Text = "20000";
            this.Txt_Usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Usr.TextChanged += new System.EventHandler(this.Txt_Usr_TextChanged);
            // 
            // lblusr
            // 
            this.lblusr.AutoSize = true;
            this.lblusr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusr.Location = new System.Drawing.Point(8, 81);
            this.lblusr.Name = "lblusr";
            this.lblusr.Size = new System.Drawing.Size(51, 20);
            this.lblusr.TabIndex = 18;
            this.lblusr.Text = "User :";
            // 
            // lblpss
            // 
            this.lblpss.AutoSize = true;
            this.lblpss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpss.Location = new System.Drawing.Point(8, 119);
            this.lblpss.Name = "lblpss";
            this.lblpss.Size = new System.Drawing.Size(52, 20);
            this.lblpss.TabIndex = 17;
            this.lblpss.Text = "Pass :";
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Location = new System.Drawing.Point(371, 156);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(125, 35);
            this.Btn_Login.TabIndex = 3;
            this.Btn_Login.Text = "Log-In";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Lnk_Sync
            // 
            this.Lnk_Sync.AutoSize = true;
            this.Lnk_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnk_Sync.LinkColor = System.Drawing.Color.RoyalBlue;
            this.Lnk_Sync.Location = new System.Drawing.Point(9, 151);
            this.Lnk_Sync.Name = "Lnk_Sync";
            this.Lnk_Sync.Size = new System.Drawing.Size(118, 18);
            this.Lnk_Sync.TabIndex = 21;
            this.Lnk_Sync.TabStop = true;
            this.Lnk_Sync.Text = "Generate Report";
            this.Lnk_Sync.Click += new System.EventHandler(this.Lnk_Sync_Click);
            // 
            // CMB_OT
            // 
            this.CMB_OT.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMB_OT.FormattingEnabled = true;
            this.CMB_OT.Items.AddRange(new object[] {
            "Regular",
            "OT Work"});
            this.CMB_OT.Location = new System.Drawing.Point(279, 78);
            this.CMB_OT.Name = "CMB_OT";
            this.CMB_OT.Size = new System.Drawing.Size(214, 30);
            this.CMB_OT.TabIndex = 4;
            this.CMB_OT.Text = "Regular";
            // 
            // Txt_Designation
            // 
            this.Txt_Designation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_Designation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Designation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.Txt_Designation.Location = new System.Drawing.Point(13, 42);
            this.Txt_Designation.Name = "Txt_Designation";
            this.Txt_Designation.ReadOnly = true;
            this.Txt_Designation.Size = new System.Drawing.Size(481, 25);
            this.Txt_Designation.TabIndex = 23;
            this.Txt_Designation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Server
            // 
            this.Txt_Server.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_Server.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Txt_Server.ForeColor = System.Drawing.Color.Red;
            this.Txt_Server.Location = new System.Drawing.Point(151, 162);
            this.Txt_Server.Name = "Txt_Server";
            this.Txt_Server.ReadOnly = true;
            this.Txt_Server.Size = new System.Drawing.Size(203, 17);
            this.Txt_Server.TabIndex = 24;
            this.Txt_Server.Text = "Server Disconnected";
            this.Txt_Server.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Server.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 201);
            this.Controls.Add(this.Txt_Server);
            this.Controls.Add(this.Txt_Designation);
            this.Controls.Add(this.CMB_OT);
            this.Controls.Add(this.Lnk_Sync);
            this.Controls.Add(this.Cmb_Shift);
            this.Controls.Add(this.Txt_Name);
            this.Controls.Add(this.Lnk_Change_Pass);
            this.Controls.Add(this.Txt_Pss);
            this.Controls.Add(this.Txt_Usr);
            this.Controls.Add(this.lblusr);
            this.Controls.Add(this.lblpss);
            this.Controls.Add(this.Btn_Login);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skill_PMS Login_V1.2.7.9";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Shift;
        private System.Windows.Forms.TextBox Txt_Name;
        private System.Windows.Forms.LinkLabel Lnk_Change_Pass;
        private System.Windows.Forms.TextBox Txt_Pss;
        private System.Windows.Forms.TextBox Txt_Usr;
        private System.Windows.Forms.Label lblusr;
        private System.Windows.Forms.Label lblpss;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.LinkLabel Lnk_Sync;
        private System.Windows.Forms.ComboBox CMB_OT;
        private System.Windows.Forms.TextBox Txt_Designation;
        private System.Windows.Forms.TextBox Txt_Server;
    }
}

