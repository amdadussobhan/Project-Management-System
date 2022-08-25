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
            this.Txt_Designation = new System.Windows.Forms.TextBox();
            this.Txt_Name = new System.Windows.Forms.TextBox();
            this.Lnk_Change_Pass = new System.Windows.Forms.LinkLabel();
            this.Txt_Pss = new System.Windows.Forms.TextBox();
            this.Txt_Usr = new System.Windows.Forms.TextBox();
            this.lblusr = new System.Windows.Forms.Label();
            this.lblpss = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Lnk_Sync = new System.Windows.Forms.LinkLabel();
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
            this.Cmb_Shift.Location = new System.Drawing.Point(279, 91);
            this.Cmb_Shift.Name = "Cmb_Shift";
            this.Cmb_Shift.Size = new System.Drawing.Size(214, 30);
            this.Cmb_Shift.TabIndex = 3;
            // 
            // Txt_Designation
            // 
            this.Txt_Designation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Designation.Location = new System.Drawing.Point(279, 54);
            this.Txt_Designation.Name = "Txt_Designation";
            this.Txt_Designation.Size = new System.Drawing.Size(214, 29);
            this.Txt_Designation.TabIndex = 20;
            this.Txt_Designation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Name
            // 
            this.Txt_Name.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Name.Location = new System.Drawing.Point(12, 13);
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
            this.Lnk_Change_Pass.Location = new System.Drawing.Point(367, 131);
            this.Lnk_Change_Pass.Name = "Lnk_Change_Pass";
            this.Lnk_Change_Pass.Size = new System.Drawing.Size(130, 18);
            this.Lnk_Change_Pass.TabIndex = 4;
            this.Lnk_Change_Pass.TabStop = true;
            this.Lnk_Change_Pass.Text = "Change Password";
            // 
            // Txt_Pss
            // 
            this.Txt_Pss.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Pss.Location = new System.Drawing.Point(94, 91);
            this.Txt_Pss.Name = "Txt_Pss";
            this.Txt_Pss.PasswordChar = '*';
            this.Txt_Pss.Size = new System.Drawing.Size(172, 29);
            this.Txt_Pss.TabIndex = 1;
            this.Txt_Pss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Usr
            // 
            this.Txt_Usr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Usr.Location = new System.Drawing.Point(94, 54);
            this.Txt_Usr.Name = "Txt_Usr";
            this.Txt_Usr.Size = new System.Drawing.Size(172, 29);
            this.Txt_Usr.TabIndex = 0;
            this.Txt_Usr.Text = "20000";
            this.Txt_Usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Usr.TextChanged += new System.EventHandler(this.Txt_Usr_TextChanged);
            // 
            // lblusr
            // 
            this.lblusr.AutoSize = true;
            this.lblusr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusr.Location = new System.Drawing.Point(8, 56);
            this.lblusr.Name = "lblusr";
            this.lblusr.Size = new System.Drawing.Size(72, 20);
            this.lblusr.TabIndex = 18;
            this.lblusr.Text = "User ID :";
            // 
            // lblpss
            // 
            this.lblpss.AutoSize = true;
            this.lblpss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpss.Location = new System.Drawing.Point(8, 94);
            this.lblpss.Name = "lblpss";
            this.lblpss.Size = new System.Drawing.Size(86, 20);
            this.lblpss.TabIndex = 17;
            this.lblpss.Text = "Password :";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Btn_Clear.Location = new System.Drawing.Point(10, 154);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(125, 35);
            this.Btn_Clear.TabIndex = 5;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = false;
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Location = new System.Drawing.Point(369, 154);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(125, 35);
            this.Btn_Login.TabIndex = 2;
            this.Btn_Login.Text = "Log-In";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Lnk_Sync
            // 
            this.Lnk_Sync.AutoSize = true;
            this.Lnk_Sync.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lnk_Sync.LinkColor = System.Drawing.Color.RoyalBlue;
            this.Lnk_Sync.Location = new System.Drawing.Point(15, 131);
            this.Lnk_Sync.Name = "Lnk_Sync";
            this.Lnk_Sync.Size = new System.Drawing.Size(118, 18);
            this.Lnk_Sync.TabIndex = 21;
            this.Lnk_Sync.TabStop = true;
            this.Lnk_Sync.Text = "Generate Report";
            this.Lnk_Sync.Click += new System.EventHandler(this.Lnk_Sync_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 201);
            this.Controls.Add(this.Lnk_Sync);
            this.Controls.Add(this.Cmb_Shift);
            this.Controls.Add(this.Txt_Designation);
            this.Controls.Add(this.Txt_Name);
            this.Controls.Add(this.Lnk_Change_Pass);
            this.Controls.Add(this.Txt_Pss);
            this.Controls.Add(this.Txt_Usr);
            this.Controls.Add(this.lblusr);
            this.Controls.Add(this.lblpss);
            this.Controls.Add(this.Btn_Clear);
            this.Controls.Add(this.Btn_Login);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skill_PMS Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Shift;
        private System.Windows.Forms.TextBox Txt_Designation;
        private System.Windows.Forms.TextBox Txt_Name;
        private System.Windows.Forms.LinkLabel Lnk_Change_Pass;
        private System.Windows.Forms.TextBox Txt_Pss;
        private System.Windows.Forms.TextBox Txt_Usr;
        private System.Windows.Forms.Label lblusr;
        private System.Windows.Forms.Label lblpss;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.LinkLabel Lnk_Sync;
    }
}

