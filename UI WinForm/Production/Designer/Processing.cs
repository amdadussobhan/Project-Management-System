using Skill_PMS.Data;
using Skill_PMS.Models;
using Skill_PMS.UI_WinForm.Production.QC_Panel;
using Skill_PMS.UI_WinForm.Production.SI_Panel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Skill_PMS.Controller;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Processing : Form
    {
        private readonly SkillContext _db = new SkillContext();
        private readonly Common _common = new Common();

        public bool autoPause = false;
        public Point cursorPosition = new Point();
        private Log _log = new Log();
        public NewJob _job = new NewJob();
        public Performance _performance = new Performance();

        public User User { get; set; }

        private int _fileAmount;
        private bool _isOld;
        private string _myService, _file, _rawFile, _fileName, _filePath, _ext, _parentFolder;
        private double _myTime;
        public double _proTime = 0;
        public static double TotalTime;
        public static bool Minimized;
        private string _instruction, _jobFolder, _readyFolder, _myFolder, _rawFolder, _doneFolder;
        private string _source, _destination, _shareName;

        public Processing()
        {
            InitializeComponent();
        }

        private static Processing _instance;
        public static Processing GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new Processing();
            else
                _instance.BringToFront();
            return _instance;
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            _job = _db.New_Jobs
                .FirstOrDefault(x => x.JobId == _job.JobId);

            _performance = _db.Performances
                .Where(x => x.Id == _performance.Id)
                .FirstOrDefault<Performance>();

            if (_job != null)
            {
                this.Text = @"Processing - By - " + User.Short_Name + "_" + _job.JobId;

                Lbl_Format.Text = @"Format- " + _job.Format;
                _jobFolder = _job.WorkingLocation;
                _instruction = _job.InputLocation + @"\ins";
                _instruction = Path.Combine(_instruction, @"ins.txt");

                _ext = _job.Format;
            }

            switch (_ext)
            {
                case ".jpg":
                    Rdb_JPG.Checked = true;
                    break;
                case ".psd":
                    Rdb_PSD.Checked = true;
                    break;
                case ".png":
                    Rdb_PNG.Checked = true;
                    break;
                case ".tif":
                    Rdb_TIF.Checked = true;
                    break;
            }

            if (_job.Service.Contains("CP"))
                Chk_CP.Enabled = true;

            if (_job.Service.Contains("RET"))
                Chk_RET.Enabled = true;

            if (_job.Service.Contains("MSK"))
                Chk_MSK.Enabled = true;

            if (_job.Service.Contains("SHA"))
                Chk_SHA.Enabled = true;

            if (_job.Service.Contains("NJ"))
                Chk_NJ.Enabled = true;

            if (_job.Service.Contains("CC"))
                Chk_CC.Enabled = true;

            if (_job.Service.Contains("LIQ"))
                Chk_LIQ.Enabled = true;

            if (_job.Service.Contains("AI"))
                Chk_AI.Enabled = true;

            //if (User.Role == "QC")
            //{
            //    Btn_Start.Enabled = true;
            //    Btn_Start.Text = @"Start QC";
            //}

            foreach (var designer in _common.Current_Designers())
                CMB_Share.Items.Add(designer.Name);

            if (Directory.Exists(_jobFolder))
                Process.Start(_jobFolder);
            else
                MessageBox.Show(@"Job Folder doesn't Exist. Please inform Your in-charge Or Manager about this...", @"Job Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Generate_Service()
        {
            _myService = "";

            if (Chk_CP.Checked)
                _myService += "CP+";

            if (Chk_RET.Checked)
                _myService += "RET+";

            if (Chk_MSK.Checked)
                _myService += "MSK+";

            if (Chk_SHA.Checked)
                _myService += "SHA+";

            if (Chk_LIQ.Checked)
                _myService += "LIQ+";

            if (Chk_NJ.Checked)
                _myService += "NJ+";

            if (Chk_CC.Checked)
                _myService += "CC+";

            if (Chk_AI.Checked)
                _myService += "AI+";

            _myService = _myService.TrimEnd('+');
            Lbl_My_Service.Text = @"Service: " + _myService;
            //Lbl_Job_Time_1.Text = @"Job Time: " + _myTime;

            if (_myService != "")
            {
                Btn_Start.Text = @"Start Job";
                Btn_Start.Enabled = true;
            }
            else
                Btn_Start.Enabled = false;
        }

        private void Chk_CP_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_RET_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_MSK_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_NJ_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_CC_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_LIQ_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_SHA_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_AI_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }        

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Cancel_Job();

            Tmr_Count.Stop();
            _proTime = 0;

            var timespan = TimeSpan.FromSeconds(0);
            Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");

            Pnl_Format.Visible = false;
            Pnl_Counter.Visible = false;
            Pnl_Drop.Visible = true;
            Pnl_Start_Job.Visible = true;
        }

        private void Processing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cancel_Job();
            Minimized = false;
            switch (User.Role)
            {
                case "SI":
                {
                    var siDashboard = SiDashboard.GetInstance();
                    siDashboard.Show();
                    break;
                }
                case "QC":
                {
                    var qcDashboard = QcDashboard.GetInstance();
                    qcDashboard.Show();
                    break;
                }
                default:
                {
                    var dashboard = Dashboard.GetInstance();
                    dashboard.Performance = _performance;
                    dashboard.Show();
                    break;
                }
            }
        }

        private void Cancel_Job()
        {
            _log = _db.Logs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Status == "Running" & x.Name == User.Short_Name & x.Service == _myService);

            if (_log != null)
            {
                if (_isOld)
                    _log.Status = "Done";
                else
                    _db.Logs.Remove(_log);
            }

            _db.SaveChanges();

            if (File.Exists(_file))
            {
                var path = Path.GetDirectoryName(_filePath);
                var itemName = Path.GetFileName(_file);
                _destination = Path.Combine(path ?? string.Empty, itemName);

                //move back file to my folder
                File.Move(_file ?? string.Empty, _destination);
            }
        }

        private void Check_Format()
        {
            if (Rdb_PSD.Checked)
                _ext = ".psd";
            else if (Rdb_TIF.Checked)
                _ext = ".tif";
            else if (Rdb_JPG.Checked)
                _ext = ".jpg";
            else
                _ext = ".png";
            Lbl_Format.Text = @"Format- " + _ext;
        }

        private void Rdb_PSD_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Rdb_JPG_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Pnl_Drop.Visible = false;
            Pnl_Service.Visible = true;
            Chk_Select_All.Visible = true;
            Btn_Clear.Visible = false;
            Btn_Start.Visible = true;
            Lbl_Success.Visible = false;
            Btn_Start.Enabled = false;
        }

        private void Btn_My_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_myFolder))
                Process.Start(_myFolder);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please inform Your In-charge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Chk_Select_All_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Select_All.Checked)
            {
                if (_job.Service.Contains("CP"))
                {
                    Chk_CP.Enabled = true;
                    Chk_CP.Checked = true;
                }

                if (_job.Service.Contains("RET"))
                {
                    Chk_RET.Enabled = true;
                    Chk_RET.Checked = true;
                }

                if (_job.Service.Contains("MSK"))
                {
                    Chk_MSK.Enabled = true;
                    Chk_MSK.Checked = true;
                }

                if (_job.Service.Contains("SHA"))
                {
                    Chk_SHA.Enabled = true;
                    Chk_SHA.Checked = true;
                }

                if (_job.Service.Contains("NJ"))
                {
                    Chk_NJ.Enabled = true;
                    Chk_NJ.Checked = true;
                }

                if (_job.Service.Contains("CC"))
                {
                    Chk_CC.Enabled = true;
                    Chk_CC.Checked = true;
                }

                if (_job.Service.Contains("LIQ"))
                {
                    Chk_LIQ.Enabled = true;
                    Chk_LIQ.Checked = true;
                }

                if (_job.Service.Contains("AI"))
                {
                    Chk_AI.Enabled = true;
                    Chk_AI.Checked = true;
                }
            }
            else
            {
                Chk_CP.Checked = false;
                Chk_RET.Checked = false;
                Chk_MSK.Checked = false;
                Chk_SHA.Checked = false;
                Chk_NJ.Checked = false;
                Chk_CC.Checked = false;
                Chk_LIQ.Checked = false;
                Chk_AI.Checked = false;
            }
        }

        private void CMB_Share_TextChanged(object sender, EventArgs e)
        {
            _shareName = CMB_Share.Text;
            if (_shareName != User.Short_Name & !string.IsNullOrEmpty(_shareName))
            {
                BTN_Share.Enabled = true;
                Txt_Mnt.Enabled = true;
            }
            else
            {
                BTN_Share.Enabled = false;
                Txt_Mnt.Enabled = false;
            }
        }

        private void Txt_Mnt_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_Mnt.Text))
            {
                var find = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name != User.Short_Name & x.Remarks == "Share")
                    .FirstOrDefault();

                double totalTime = 0;
                if (find != null)
                {
                    totalTime = _db.Logs
                        .Where(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name != User.Short_Name & x.Remarks == "Share")
                        .Sum(x => x.TargetTime);
                }

                double shareTime = Convert.ToDouble(Txt_Mnt.Text);
                if (totalTime + shareTime > _log.TargetTime)
                    Txt_Mnt.BackColor = Color.FromArgb(255, 100, 100);
                else
                    Txt_Mnt.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void Btn_Instruction_Click(object sender, EventArgs e)
        {
            if (File.Exists(_instruction))
            {
                Process.Start(_instruction);
            }
            else
                MessageBox.Show(@"Instruction doesn't Exist. Please inform Your in-charge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Tmr_Pause_Tick(object sender, EventArgs e)
        {
            if (cursorPosition == Cursor.Position)
            {
                autoPause = true;
                Tmr_Count.Stop();
                Btn_Pause.Text = "Resume";
            }
            else
            {
                if (autoPause)
                {
                    Tmr_Count.Start();
                    Btn_Pause.Text = "Pause";
                }
            }
            cursorPosition = Cursor.Position;
        }

        private void Rdb_PNG_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Rdb_TIF_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Processing_Resize(object sender, EventArgs e)
        {
            //var counter = new Counter();
            //if (this.WindowState == FormWindowState.Minimized & TotalTime != 0 & Btn_Pause.Text != "Resume")
            //{
            //    //counter.Show();
            //    Minimized = true;
            //}
            //else
            //{
            //    Minimized = false;
            //}

            //Counter.Minimized = Minimized;
            //Counter.TotalTime = TotalTime;
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            if (Btn_Pause.Text == @"Pause")
            {
                autoPause = false;
                Tmr_Count.Stop();
                Btn_Pause.Text = @"Resume";
            }
            else
            {
                Tmr_Count.Start();
                Btn_Pause.Text = @"Pause";
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _proTime++; TotalTime--;
            if (Pnl_Counter.BackColor == Color.FromArgb(180, 180, 180))
                Pnl_Counter.BackColor = Color.MediumOrchid;
            else
                Pnl_Counter.BackColor = Color.FromArgb(180, 180, 180);

            //var timespan = TimeSpan.FromSeconds(TotalTime);
            //Lbl_Count.Text = timespan.ToString(@"h\:mm\:ss");
            //if ((TotalTime < 0))
            //{
            //if (Pnl_Counter.BackColor == Color.FromArgb(255, 100, 100))
            //    Pnl_Counter.BackColor = Color.FromArgb(255, 195, 195);
            //else
            //    Pnl_Counter.BackColor = Color.FromArgb(255, 100, 100);
            //}
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Tmr_Count.Stop();
            Tmr_Pause.Stop();
            _proTime /= 60;

            Pnl_Counter.Visible = false;
            Pnl_Format.Visible = false;
            Pnl_Start_Job.Visible = true;
            Pnl_Drop.Visible = true;
            Pnl_Drop.Enabled = true;
            Lbl_Success.Visible = true;

            var itemName = Path.GetFileNameWithoutExtension(_file) + _ext;
            _source = Path.Combine(_filePath, itemName);

            if (Btn_Pause.Text == @"Resume")
            {
                var path = Path.GetDirectoryName(_filePath);
                _destination = Path.Combine(path ?? string.Empty, itemName);

                if (File.Exists(_source))
                    File.Move(_source, _destination);
                else
                    File.Move(_rawFile, _destination);

                var savingProgress = new SavingProgress
                {
                    _job = _job,
                    _user = User,
                    _pause = true,
                    _proTime = _proTime,
                    _fileName = _fileName,
                    _myService = _myService,
                    _performance = _performance,
                };
                savingProgress.Show();
            }
            else
            {
                //Directory.CreateDirectory(_doneFolder);
                //_destination = Path.Combine(_doneFolder, itemName);                    

                //if (File.Exists(_destination))
                //    File.Delete(_destination);

                //move done file to done folder
                //File.Move(_source, _destination);
                //_source = _destination;

                //create ready folder with check if exist subfolder
                var root = "";
                _filePath = Path.GetDirectoryName(_filePath);
                _parentFolder = new DirectoryInfo(_filePath ?? string.Empty).Name;
                while (_parentFolder != _myService)
                {
                    if (_parentFolder != "Processing")
                        root = _parentFolder + @"\" + root;

                    _filePath = Path.GetDirectoryName(_filePath);
                    _parentFolder = new DirectoryInfo(_filePath ?? string.Empty).Name;
                }

                _readyFolder = _job.WorkingLocation + @"\" + _myService + "_Done" + @"\" + root;

                if (_log.Remarks == "Share")
                    _readyFolder += @"\Share\" + User.Short_Name;

                Directory.CreateDirectory(_readyFolder);
                _destination = Path.Combine(_readyFolder, itemName);

                var savingProgress = new SavingProgress
                {
                    _job = _job,
                    _user = User,
                    _source = _source,
                    _proTime = _proTime,
                    _fileName = _fileName,
                    _myService = _myService,
                    _destination = _destination,
                    _performance = _performance,
                };
                savingProgress.Show();
                _file = "";
            }
            _proTime = 0;
        }

        private void Pnl_Drop_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            _fileAmount = files.Count();
            _file = _rawFile = files[0];
            string Loc = Path.GetDirectoryName(_file); ;

            if (_fileAmount == 1)
            {
                _proTime = 0;
                Tmr_Count.Start();
                Tmr_Pause.Start();
                string file = Path.GetFileName(_file);
                _fileName = Path.GetFileNameWithoutExtension(_file);

                var imageTime = _db.ImageTime
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName);

                if (imageTime == null)
                {
                    MessageBox.Show(@"This file have not assign target time. Please inform to Shift Incharge", @"Target Time empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tmr_Count.Stop();
                    return;
                }

                _myTime = 0;

                if (Chk_CP.Checked)
                    _myTime += imageTime.CP_Time;

                if (Chk_RET.Checked)
                    _myTime += imageTime.RET_Time;

                if (Chk_MSK.Checked)
                    _myTime += imageTime.MSK_Time;

                if (Chk_SHA.Checked)
                    _myTime += imageTime.SHA_Time;

                if (Chk_LIQ.Checked)
                    _myTime += imageTime.LIQ_Time;

                if (Chk_NJ.Checked)
                    _myTime += imageTime.NJ_Time;

                if (Chk_CC.Checked)
                    _myTime += imageTime.CC_Time;

                if (Chk_AI.Checked)
                    _myTime += imageTime.AI_Time;


                //for check if file already production running.
                _log = _db.Logs
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & (x.Status == "Running" | x.Status == "InHand") & x.Name != User.Short_Name);

                if (_log != null)
                {
                    var log = _db.Logs
                        .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name == User.Short_Name & x.Remarks == "Share");

                    if (log == null)
                    {
                        MessageBox.Show(@"This file already production running. by " + _log.Name + @". Please select another file......", @"Running by " + _log.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Tmr_Count.Stop();
                        return;
                    }
                    _myTime = log.TargetTime;
                }

                this.WindowState = FormWindowState.Minimized;

                _filePath = Loc;
                _parentFolder = new DirectoryInfo(_filePath ?? string.Empty).Name;
                //_doneFolder = _filePath + @"\Done_File";

                //move file to my folder
                if (_parentFolder != "Processing" & _parentFolder != "Done_File")
                {
                    _rawFolder = _filePath + @"\Processing";
                    Directory.CreateDirectory(_rawFolder);

                    _filePath = Path.Combine(_rawFolder, file);

                    if (File.Exists(_filePath))
                        File.Delete(_filePath);

                    File.Move(_file ?? string.Empty, _filePath);
                    _file = _filePath;

                    _filePath = _rawFolder;
                }
                //else
                //{
                //    var subfolder = Path.GetDirectoryName(_filePath);
                //    _doneFolder = subfolder + @"\Done_File";
                //}

                //Directory.CreateDirectory(_doneFolder);

                try
                {
                    var open = new Process 
                    { 
                        StartInfo = 
                        { 
                            FileName = @"Photoshop",
                            Arguments = _file ?? string.Empty 
                        } 
                    };
                    open.Start();
                }
                catch
                {
                    var open = new Process
                    {
                        StartInfo =
                        {
                            FileName = @"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\Photoshop.exe",
                            Arguments = _file ?? string.Empty
                        }
                    };
                    open.Start();
                }

                _log = _db.Logs
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name == User.Short_Name);

                if (_log == null)
                {
                    _log = new Log
                    {
                        JobId = _job.JobId,
                        Image = _fileName,
                        ActualTime = _myTime,
                        TargetTime = _myTime,
                        Shift = _performance.Shift,
                        Service = _myService,
                        Date = DateTime.Now.Date,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        Name = User.Short_Name
                    };
                    _db.Logs.Add(_log);

                    TotalTime = _log.TargetTime * 60;
                }
                else
                {
                    //_proTime = _log.ProTime * 60;
                    TotalTime = (_myTime * 60) - _proTime;
                    _isOld = true;
                }

                _log.Status = "Running";
                _log.Category = imageTime.Category;
                _log.InputLocation = _file;
                _log.WorkingLocation = _file;
                _db.SaveChanges();

                Pnl_Counter.Visible = true;
                Pnl_Format.Visible = true;
                Pnl_Drop.Visible = false;
                Pnl_Service.Visible = false;
                Pnl_Start_Job.Visible = false;
                Lbl_Success.Visible = false;
                Btn_Pause.Text = @"Pause";

                CMB_Share.Enabled = true;
                BTN_Share.Enabled = true;

                Txt_image.Text = _fileName;
                Lbl_Job_Time.Text = @"Job Time: " + _myTime;
                Lbl_Job_Time_1.Text = @"Job Time: " + _myTime;
            }
            else
                MessageBox.Show(@"Please select single file. Don't select multiple files...", @"Multiple files selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

            files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                var pendingImage = _db.PendingImage
                    .FirstOrDefault(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Image == fileName);

                if (pendingImage == null)
                {
                    pendingImage = new PendingImage
                    {
                        JobId = _job.JobId,
                        Name = User.Short_Name,
                        Image = fileName,
                        Time = DateTime.Now
                    };
                    _db.PendingImage.Add(pendingImage);
                }
            }

            _db.SaveChanges();
        }
        
        private void BTN_Share_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Mnt.Text))
            {
                MessageBox.Show(@"Share time is empty. Please Enter share time...", @"Share time is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var find = _db.Logs
                .Where(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name != User.Short_Name & x.Remarks == "Share")
                .FirstOrDefault();

            double totalTime = 0;
            if (find != null)
            {
                totalTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name != User.Short_Name & x.Remarks == "Share")
                    .Sum(x => x.TargetTime);
            }            

            double shareTime = Convert.ToDouble(Txt_Mnt.Text);
            if (totalTime + shareTime > _log.TargetTime)
            {
                MessageBox.Show(@"Share time limit over. Please decrease share time...", @"Share time limit over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var log = _db.Logs
                .FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name == _shareName & x.Remarks == "Share");

            if (log == null)
            {
                log = new Log
                {
                    JobId = _job.JobId,
                    Image = _fileName,
                    Service = _myService,
                    Name = _shareName,
                    Date = DateTime.Now.Date,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now
                };
                _db.Logs.Add(log);
            }

            log.ActualTime = log.TargetTime = shareTime;
            Lbl_Job_Time_1.Text = log.TargetTime + "";
            log.Status = "InHand";
            log.Remarks = "Share";

            _log.ActualTime = _log.TargetTime -= shareTime;
            _log.Remarks = "Share";
            _db.SaveChanges();
            MessageBox.Show(@"This file shared successfully with " + _shareName + @". Please inform him to start immediate......", @"Successfully shared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TotalTime -= (shareTime * 60);
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (Btn_Start.Text == @"Start Job")
            {
                Pnl_Service.Visible = false;
                Pnl_Drop.Visible = true;
                Btn_Start.Visible = false;
                Chk_Select_All.Visible = false;
                Btn_Clear.Visible = true;

                ////Create my folder in job folder
                //_myFolder = Job.WorkingLocation + "\\" + User.Short_Name;
                //Directory.CreateDirectory(_myFolder);

                //Create my folder to local drive
                var localDrive = @"C:\";

                if (Directory.Exists(@"D:\"))
                    localDrive = @"D:\";
                else if (Directory.Exists(@"E:\"))
                    localDrive = @"E:\";
                else if (Directory.Exists(@"F:\"))
                    localDrive = @"F:\";
                else if (Directory.Exists(@"G:\"))
                    localDrive = @"G:\";

                _myFolder = localDrive + @"Workfile\" + DateTime.Now.ToString("dd_MMM_yy") + "\\" + _job.JobId + "\\" + User.Short_Name + "\\" + _myService;
                Directory.CreateDirectory(_myFolder);
                Process.Start(_myFolder);

                //create done folder in job folder
                _readyFolder = _job.WorkingLocation + @"\" + _myService + "_Done";
                Directory.CreateDirectory(_readyFolder);

                Btn_Ready_Folder.Enabled = true;
                Btn_My_Folder.Enabled = true;
            }
            else if (Btn_Start.Text == @"Start QC")
            {
                var qcProcess = QC_Process.getInstance();
                qcProcess._job.JobId = _job.JobId;
                QC_Process._user = User;
                qcProcess.Show();
                this.Hide();
            }
        }

        private void Pnl_Drop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Btn_Job_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_jobFolder))
                Process.Start(_jobFolder);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please inform Your in-charge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        private void Btn_Ready_Folder_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(_readyFolder))
                Process.Start(_readyFolder);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please Start Job First then try again...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}