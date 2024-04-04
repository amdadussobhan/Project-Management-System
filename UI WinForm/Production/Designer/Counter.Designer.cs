namespace Skill_PMS.UI_WinForm.Production.Designer
{
    partial class Counter
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
            this.Lbl_Count = new System.Windows.Forms.Label();
            this.Tmr_Count_m = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Lbl_Count
            // 
            this.Lbl_Count.AutoSize = true;
            this.Lbl_Count.Font = new System.Drawing.Font("Arial", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Count.Location = new System.Drawing.Point(6, 9);
            this.Lbl_Count.Name = "Lbl_Count";
            this.Lbl_Count.Size = new System.Drawing.Size(179, 53);
            this.Lbl_Count.TabIndex = 26;
            this.Lbl_Count.Text = "0:00:00";
            // 
            // Tmr_Count_m
            // 
            this.Tmr_Count_m.Interval = 1000;
            this.Tmr_Count_m.Tick += new System.EventHandler(this.Tmr_Count_m_Tick);
            // 
            // Counter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(185, 70);
            this.ControlBox = false;
            this.Controls.Add(this.Lbl_Count);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(50, 930);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Counter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Counter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Counter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Count;
        private System.Windows.Forms.Timer Tmr_Count_m;
    }
}