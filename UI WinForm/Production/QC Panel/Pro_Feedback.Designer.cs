
namespace Skill_PMS.UI_WinForm.Production.QC_Panel
{
    partial class Pro_Feedback
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
            this.Txt_Location = new System.Windows.Forms.TextBox();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.Txt_Remarks = new System.Windows.Forms.TextBox();
            this.Btn_Open_Folder = new System.Windows.Forms.Button();
            this.Txt_Name = new System.Windows.Forms.TextBox();
            this.Txt_JobID = new System.Windows.Forms.TextBox();
            this.Txt_Image = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_Location
            // 
            this.Txt_Location.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Location.Location = new System.Drawing.Point(37, 339);
            this.Txt_Location.Name = "Txt_Location";
            this.Txt_Location.Size = new System.Drawing.Size(821, 27);
            this.Txt_Location.TabIndex = 224;
            this.Txt_Location.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Submit.Location = new System.Drawing.Point(738, 392);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(120, 35);
            this.Btn_Submit.TabIndex = 225;
            this.Btn_Submit.Text = "Submit";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // Txt_Remarks
            // 
            this.Txt_Remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Txt_Remarks.Location = new System.Drawing.Point(37, 135);
            this.Txt_Remarks.Multiline = true;
            this.Txt_Remarks.Name = "Txt_Remarks";
            this.Txt_Remarks.Size = new System.Drawing.Size(821, 181);
            this.Txt_Remarks.TabIndex = 438;
            // 
            // Btn_Open_Folder
            // 
            this.Btn_Open_Folder.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Open_Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Btn_Open_Folder.Location = new System.Drawing.Point(37, 392);
            this.Btn_Open_Folder.Name = "Btn_Open_Folder";
            this.Btn_Open_Folder.Size = new System.Drawing.Size(120, 35);
            this.Btn_Open_Folder.TabIndex = 440;
            this.Btn_Open_Folder.Text = "Open";
            this.Btn_Open_Folder.UseVisualStyleBackColor = false;
            this.Btn_Open_Folder.Click += new System.EventHandler(this.Btn_Open_Folder_Click);
            // 
            // Txt_Name
            // 
            this.Txt_Name.Enabled = false;
            this.Txt_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Name.Location = new System.Drawing.Point(37, 43);
            this.Txt_Name.Name = "Txt_Name";
            this.Txt_Name.Size = new System.Drawing.Size(220, 27);
            this.Txt_Name.TabIndex = 441;
            this.Txt_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_JobID
            // 
            this.Txt_JobID.Enabled = false;
            this.Txt_JobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_JobID.Location = new System.Drawing.Point(340, 43);
            this.Txt_JobID.Name = "Txt_JobID";
            this.Txt_JobID.Size = new System.Drawing.Size(220, 27);
            this.Txt_JobID.TabIndex = 442;
            this.Txt_JobID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Image
            // 
            this.Txt_Image.Enabled = false;
            this.Txt_Image.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Image.Location = new System.Drawing.Point(638, 43);
            this.Txt_Image.Name = "Txt_Image";
            this.Txt_Image.Size = new System.Drawing.Size(220, 27);
            this.Txt_Image.TabIndex = 443;
            this.Txt_Image.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(271, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(346, 26);
            this.label7.TabIndex = 444;
            this.label7.Text = "write down error message properly";
            // 
            // Pro_Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(897, 460);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_Image);
            this.Controls.Add(this.Txt_JobID);
            this.Controls.Add(this.Txt_Name);
            this.Controls.Add(this.Btn_Open_Folder);
            this.Controls.Add(this.Txt_Remarks);
            this.Controls.Add(this.Txt_Location);
            this.Controls.Add(this.Btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Pro_Feedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.Load += new System.EventHandler(this.Feedback_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Location;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.TextBox Txt_Remarks;
        private System.Windows.Forms.Button Btn_Open_Folder;
        private System.Windows.Forms.TextBox Txt_Name;
        private System.Windows.Forms.TextBox Txt_JobID;
        private System.Windows.Forms.TextBox Txt_Image;
        private System.Windows.Forms.Label label7;
    }
}