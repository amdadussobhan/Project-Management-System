
namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    partial class Add_Feedback
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
            this.Cmb_Client = new System.Windows.Forms.ComboBox();
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_Job_ID = new System.Windows.Forms.TextBox();
            this.Txt_Folder = new System.Windows.Forms.TextBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Txt_Loc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_Amount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_Job_Time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cmb_Client
            // 
            this.Cmb_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Cmb_Client.FormattingEnabled = true;
            this.Cmb_Client.Location = new System.Drawing.Point(146, 122);
            this.Cmb_Client.Name = "Cmb_Client";
            this.Cmb_Client.Size = new System.Drawing.Size(151, 28);
            this.Cmb_Client.TabIndex = 236;
            this.Cmb_Client.SelectedValueChanged += new System.EventHandler(this.Cmb_Client_SelectedValueChanged);
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Location.Location = new System.Drawing.Point(165, 266);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(231, 27);
            this.Txt_Location.TabIndex = 238;
            this.Txt_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(37, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 26);
            this.label9.TabIndex = 240;
            this.label9.Text = "Location :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 26);
            this.label11.TabIndex = 239;
            this.label11.Text = "Client :";
            // 
            // Txt_Job_ID
            // 
            this.Txt_Job_ID.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Txt_Job_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Job_ID.Enabled = false;
            this.Txt_Job_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.Txt_Job_ID.Location = new System.Drawing.Point(62, 37);
            this.Txt_Job_ID.Multiline = true;
            this.Txt_Job_ID.Name = "Txt_Job_ID";
            this.Txt_Job_ID.Size = new System.Drawing.Size(718, 54);
            this.Txt_Job_ID.TabIndex = 242;
            this.Txt_Job_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Folder
            // 
            this.Txt_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Folder.Location = new System.Drawing.Point(146, 191);
            this.Txt_Folder.Name = "Txt_Folder";
            this.Txt_Folder.Size = new System.Drawing.Size(649, 30);
            this.Txt_Folder.TabIndex = 435;
            this.Txt_Folder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Cancel.Enabled = false;
            this.Btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Cancel.Location = new System.Drawing.Point(42, 336);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(169, 35);
            this.Btn_Cancel.TabIndex = 421;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Btn_Save.Location = new System.Drawing.Point(625, 336);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(172, 35);
            this.Btn_Save.TabIndex = 417;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Txt_Loc
            // 
            this.Txt_Loc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Loc.Location = new System.Drawing.Point(146, 264);
            this.Txt_Loc.Name = "Txt_Loc";
            this.Txt_Loc.Size = new System.Drawing.Size(649, 30);
            this.Txt_Loc.TabIndex = 415;
            this.Txt_Loc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Loc.TextChanged += new System.EventHandler(this.Txt_Loc_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(37, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 26);
            this.label17.TabIndex = 419;
            this.label17.Text = "Location :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 26);
            this.label5.TabIndex = 416;
            this.label5.Text = "Folder :";
            // 
            // Txt_Amount
            // 
            this.Txt_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Amount.Location = new System.Drawing.Point(405, 121);
            this.Txt_Amount.Name = "Txt_Amount";
            this.Txt_Amount.Size = new System.Drawing.Size(151, 30);
            this.Txt_Amount.TabIndex = 442;
            this.Txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(301, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 443;
            this.label8.Text = "Amount :";
            // 
            // Txt_Job_Time
            // 
            this.Txt_Job_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Job_Time.Location = new System.Drawing.Point(644, 121);
            this.Txt_Job_Time.Name = "Txt_Job_Time";
            this.Txt_Job_Time.Size = new System.Drawing.Size(151, 30);
            this.Txt_Job_Time.TabIndex = 444;
            this.Txt_Job_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(565, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 26);
            this.label7.TabIndex = 445;
            this.label7.Text = "Time :";
            // 
            // Add_Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(838, 411);
            this.Controls.Add(this.Txt_Job_Time);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_Amount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Txt_Folder);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Txt_Loc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_Job_ID);
            this.Controls.Add(this.Cmb_Client);
            this.Controls.Add(this.Txt_Location);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Add_Feedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Feedback";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Add_Feedback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox Cmb_Client;
        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_Job_ID;
        private System.Windows.Forms.TextBox Txt_Folder;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox Txt_Loc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Amount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_Job_Time;
        private System.Windows.Forms.Label label7;
    }
}