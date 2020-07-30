using Skill_PMS.Controller;
using Skill_PMS.Data;
using Skill_PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Processing : Form
    {
        SkillContext DB = new SkillContext();

        public Job job = new Job();
        Log log = new Log();
        Common common = new Common();
        public User user { get; set; }

        string My_Service = "";
        double My_Time = 0, Total_Time = 0, Pro_Time = 0;

        int File_Amount;
        string[] files, files_name = new string[99];

        string Instruction, Job_Folder, My_Folder, Ready_Folder;

        public Processing()
        {
            InitializeComponent();
        }

        private static Processing instance;
        public static Processing getInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new Processing();
            else
                instance.BringToFront();
            return instance;
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            this.Text = "Processing - " + user.Full_Name;

            job = DB.Jobs
                .Where(x => x.JobID == job.JobID)
                .FirstOrDefault<Job>();

            Lbl_Job_ID.Text = job.JobID;
            Lbl_Job_Time.Text = job.Target_Time + "";
            Lbl_My_Time.Text = "0";
            Lbl_Job_Service.Text = job.Service;
            Lbl_My_Service.Text = "";

            Job_Folder = job.WorkingLocation;
            Instruction = job.InputLocation + @"\ins.txt";
            My_Folder = job.WorkingLocation + @"\" + user.Short_Name;

            Check_Service();
        }

        void Check_Service()
        {
            if (job.Service.Contains("CP"))
                Chk_CP.Enabled = true;

            if (job.Service.Contains("RET"))
                Chk_RET.Enabled = true;

            if (job.Service.Contains("MSK"))
                Chk_MSK.Enabled = true;

            if (job.Service.Contains("SHA"))
                Chk_SHA.Enabled = true;

            if (job.Service.Contains("NJ"))
                Chk_NJ.Enabled = true;

            if (job.Service.Contains("CC"))
                Chk_CC.Enabled = true;

            if (job.Service.Contains("LIQ"))
                Chk_LIQ.Enabled = true;

            if (job.Service.Contains("AI"))
                Chk_AI.Enabled = true;
        }

        private void DGV_Files_DragDrop(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int SL = 1;
            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();
            common.Dgv_Size(DGV_Files, 11);

            File_Amount = files.Count();

            if (File_Amount > 0 & File_Amount < 16)
            {
                int i = 0;
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    files_name[i++] = name;
                    DGV_Files.Rows.Add(SL++, name, "X");

                    log = new Log();
                    log.Job_ID = job.ID;
                    log.Image = name;
                    log.Job_Time = My_Time;
                    log.Service = My_Service;
                    log.Start_Job = DateTime.Now;
                    log.Finish_Job = DateTime.Now;
                    log.User_ID = user.ID;
                    log.Status = "Running";
                    DB.Logs.AddOrUpdate(log);
                }

                foreach (string file in files)
                {
                    try
                    {
                        Process Open = new Process();
                        Open.StartInfo.FileName = @"Photoshop";
                        Open.StartInfo.Arguments = file;
                        Open.Start();
                    }
                    catch
                    {
                        Process Open = new Process();
                        Open.StartInfo.FileName = @"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\Photoshop.exe";
                        Open.StartInfo.Arguments = file;
                        Open.Start();
                    }

                    Thread.Sleep(500);
                }

                DB.SaveChanges();

                DGV_Files.AllowDrop = false;
                Btn_Start.Enabled = false;
                Btn_Save.Enabled = true;
                Btn_Cancel.Enabled = true;
                Btn_Pause.Enabled = true;

                Total_Time = My_Time * File_Amount * 60;
                Tmr_Count.Start();
            }
            else
                MessageBox.Show("Maximum file amount selected. Please don't select more than 15 files...", "File amount exceeded the limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DGV_Files_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if(My_Time > 0)
            {
                Ready_Folder = job.WorkingLocation + @"\" + My_Service + "_Done";
                Directory.CreateDirectory(My_Folder);
                Directory.CreateDirectory(Ready_Folder);
                Process.Start(My_Folder);

                DGV_Files.AllowDrop = true;
                Btn_My_Folder.Enabled = true;
                Btn_Ready_Folder.Enabled = true;

                Chk_CP.Enabled = false;
                Chk_RET.Enabled = false;
                Chk_MSK.Enabled = false;
                Chk_SHA.Enabled = false;
                Chk_NJ.Enabled = false;
                Chk_CC.Enabled = false;
                Chk_LIQ.Enabled = false;
                Chk_AI.Enabled = false;

                Chk_Select_all.Enabled = false;
            }
        }

        void Check_Time_Service()
        {
            My_Time = 0;
            My_Service = "";

            if (Chk_CP.Checked)
            {
                My_Time += job.CP_Time;
                My_Service += "CP+";
            }

            if (Chk_RET.Checked)
            {
                My_Time += job.RET_Time;
                My_Service += "RET+";
            }

            if (Chk_MSK.Checked)
            {
                My_Time += job.MSK_Time;
                My_Service += "MSK+";
            }

            if (Chk_SHA.Checked)
            {
                My_Time += job.SHA_Time;
                My_Service += "SHA+";
            }

            if (Chk_LIQ.Checked)
            {
                My_Time += job.LIQ_Time;
                My_Service += "LIQ+";
            }

            if (Chk_NJ.Checked)
            {
                My_Time += job.NJ_Time;
                My_Service += "NJ+";
            }

            if (Chk_CC.Checked)
            {
                My_Time += job.CC_Time;
                My_Service += "CC+";
            }

            if (Chk_AI.Checked)
            {
                My_Time += job.AI_Time;
                My_Service += "AI+";
            }

            Chk_Select_all.Enabled = true;

            Lbl_My_Time.Text = My_Time + "";
            My_Service = My_Service.TrimEnd('+');
            Lbl_My_Service.Text = My_Service; 
            
            if (My_Time > 0)
                Btn_Start.Enabled = true;
            else
                Btn_Start.Enabled = false;
        }

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_AI_CheckedChanged(object sender, EventArgs e)
        {
            Check_Time_Service();
        }

        private void Chk_Select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Select_all.Checked)
            {
                if (job.Service.Contains("CP"))
                    Chk_CP.Checked = true;

                if (job.Service.Contains("RET"))
                    Chk_RET.Checked = true;

                if (job.Service.Contains("MSK"))
                    Chk_MSK.Checked = true;

                if (job.Service.Contains("SHA"))
                    Chk_SHA.Checked = true;

                if (job.Service.Contains("NJ"))
                    Chk_NJ.Checked = true;

                if (job.Service.Contains("CC"))
                    Chk_CC.Checked = true;

                if (job.Service.Contains("LIQ"))
                    Chk_LIQ.Checked = true;

                if (job.Service.Contains("AI"))
                    Chk_AI.Checked = true;
            }
            else
            {
                if (job.Service.Contains("CP"))
                    Chk_CP.Checked = false;

                if (job.Service.Contains("RET"))
                    Chk_RET.Checked = false;

                if (job.Service.Contains("MSK"))
                    Chk_MSK.Checked = false;

                if (job.Service.Contains("SHA"))
                    Chk_SHA.Checked = false;

                if (job.Service.Contains("NJ"))
                    Chk_NJ.Checked = false;

                if (job.Service.Contains("CC"))
                    Chk_CC.Checked = false;

                if (job.Service.Contains("LIQ"))
                    Chk_LIQ.Checked = false;

                if (job.Service.Contains("AI"))
                    Chk_AI.Checked = false;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Reset_Process();
            Clear_Job();
        }

        void Reset_Process()
        {
            DGV_Files.DataSource = null;
            DGV_Files.Rows.Clear();
            DGV_Files.AllowDrop = true;
            Check_Service();
            Tmr_Count.Stop();

            var timespan = TimeSpan.FromSeconds(0);
            Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");

            Btn_Pause.Enabled = false;
            Btn_Save.Enabled = false;
        }

        void Clear_Job()
        {
            foreach (string file in files_name)
            {
                Remove_File(file);
                if (File_Amount == 0)
                    break;
            }
            DB.SaveChanges();
        }

        void Remove_File(string file)
        {
            log = DB.Logs
                .Where(x => x.Job_ID == job.ID & x.Image == file & x.Status == "Running" & x.User_ID == user.ID & x.Service == My_Service)
                .FirstOrDefault<Log>();

            if (log != null)
                DB.Logs.Remove(log);

            if (--File_Amount == 0)
                Reset_Process();
        }

        private void Btn_My_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(My_Folder))
                Process.Start(My_Folder);
            else
                MessageBox.Show("My Folder doesn't Exist. Please Start Job First then try again...", "My Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Processing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear_Job();
            Dashboard dashboard = Dashboard.getInstance();
            dashboard.Show();
        }

        private void DGV_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string file_name = "";
            if (DGV_Files.Columns[DGV_Files.CurrentCell.ColumnIndex].HeaderText.Contains("X"))
            {
                if (DGV_Files.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    file_name = DGV_Files.Rows[e.RowIndex].Cells[1].Value.ToString();
                }

                if (!String.IsNullOrWhiteSpace(DGV_Files.CurrentCell.EditedFormattedValue.ToString()))
                {
                    if (!string.IsNullOrEmpty(file_name))
                    {
                        DGV_Files.Rows.RemoveAt(e.RowIndex);
                        Remove_File(file_name);
                        DB.SaveChanges();
                    }
                }
            }
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (Btn_Pause.Text == "Pause")
            {
                Tmr_Count.Stop();
                Btn_Pause.Text = "Resume";
            }
            else
            {
                Tmr_Count.Start();
                Btn_Pause.Text = "Pause";
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            Pro_Time++; Total_Time--;
            var timespan = TimeSpan.FromSeconds(Total_Time);
            Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            if (Total_Time < 0)
            {
                if (Panel.BackColor == Color.FromArgb(255, 90, 100))
                {
                    //Btn_Reject.BackColor = Color.FromArgb(255, 195, 195);
                    //Txt_image.BackColor = Color.FromArgb(255, 195, 195);
                    //Txt_Job_ID.BackColor = Color.FromArgb(255, 195, 195);
                    Panel.BackColor = Color.FromArgb(255, 195, 195);
                }
                else
                {
                    //Btn_Reject.BackColor = Color.FromArgb(255, 90, 100);
                    //Txt_image.BackColor = Color.FromArgb(255, 90, 100);
                    //Txt_Job_ID.BackColor = Color.FromArgb(255, 90, 100);
                    Panel.BackColor = Color.FromArgb(255, 90, 100);
                }
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Tmr_Count.Stop();

            Pro_Time = Math.Round(Pro_Time / File_Amount / 60, 2);

            foreach(string file in files_name)
            {
                log = DB.Logs
                    .Where(x => x.Job_ID == job.ID & x.Image == file & x.Status == "Running" & x.User_ID == user.ID & x.Service == My_Service)
                    .FirstOrDefault<Log>();

                if (log != null)
                {
                    log.Pro_Time = Pro_Time;
                    log.Efficiency = Convert.ToInt32(My_Time / Pro_Time * 100);
                    log.Finish_Job = DateTime.Now;
                    log.Status = "Done";
                    DB.Logs.AddOrUpdate(log);
                }

                if (--File_Amount == 0)
                    break;
            }
            job.Pro_Done += File_Amount;
            job.Pro_Time += Pro_Time / 2;
            DB.Jobs.AddOrUpdate(job);
            DB.SaveChanges();
            Reset_Process();            
        }

        private void Btn_Instruction_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Instruction))
            {
                Process.Start(Instruction);
                if (My_Time > 0)
                    Btn_Start.Enabled = true;                
            }                
            else
                MessageBox.Show("Instruction doesn't Exist. Please inform Your Incharge Or Manager about this...", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            
        }

        private void Btn_Job_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Job_Folder))
                Process.Start(Job_Folder);
            else
                MessageBox.Show("Folder doesn't Exist. Please inform Your Incharge Or Manager about this...", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        private void Btn_Ready_Folder_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(Ready_Folder))
                Process.Start(Ready_Folder);
            else
                MessageBox.Show("Folder doesn't Exist. Please Start Job First then try again...", "Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
