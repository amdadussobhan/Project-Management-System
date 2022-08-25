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
using System.Threading.Tasks;
using System.Threading;

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
        private ImageTime _imageTime;

        public User User { get; set; }
        public int _runningJobsId;
        private int _fileAmount;
        private bool _isOld;
        private string _myService, _file, _rawFile, _fileName, _filePath, _ext, _parentFolder;
        public double _proTime = 0, _myTime = 0, _support = 0;
        public static double TotalTime;
        public static bool Minimized;
        private string _instruction, _jobFolder, _readyFolder, _myFolder, _rawFolder;
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
            _job = _db.New_Jobs.FirstOrDefault(x => x.JobId == _job.JobId);
            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);

            if (_job != null)
            {
                this.Text = @"Processing - By - " + User.Short_Name + "_" + _job.JobId;

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

            _imageTime = _db.ImageTime.FirstOrDefault(x => x.Job_ID == _job.JobId);
            Check_Service();

            foreach (var designer in _common.Current_Designers())
                CMB_Share.Items.Add(designer.Name);

            _jobFolder = _job.WorkingLocation;
            if (Directory.Exists(_jobFolder))
                Process.Start(_jobFolder);
        }

        private void Check_Service()
        {
            if (_imageTime != null)
            {
                if (_imageTime.Clipping_Time > 0)
                    Chk_Clipping_Path.Enabled = true;

                if (_imageTime.Basic_Time > 0)
                    Chk_Basic_Process.Enabled = true;

                if (_imageTime.Pre_Process > 0)
                    Chk_Pre_Process.Enabled = true;

                if (_imageTime.Post_Process > 0)
                    Chk_Post_Process.Enabled = true;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Cancel_Job();

            Tmr_Count_Processing.Stop();
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
                if (File.Exists(_destination))
                    File.Delete(_destination);

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
        }

        private void Btn_My_Folder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_myFolder))
                Process.Start(_myFolder);
            else
                MessageBox.Show(@"Folder doesn't Exist. Please inform Your In-charge Or Manager about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Tmr_Count_Processing.Stop();
                Btn_Pause.Text = "Resume";
            }
            else
            {
                if (autoPause)
                {
                    Tmr_Count_Processing.Start();
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

        private void Rdb_PSD_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Rdb_JPG_CheckedChanged(object sender, EventArgs e)
        {
            Check_Format();
        }

        private void Chk_Clipping_Path_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_Basic_Process_CheckedChanged(object sender, EventArgs e)
        {
            Generate_Service();
        }

        private void Chk_Pre_Process_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Pre_Process.Checked)
                Chk_Post_Process.Enabled = false;
            else
                Check_Service();

            Generate_Service();
        }

        private void Chk_Post_Process_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Post_Process.Checked)
                Chk_Pre_Process.Enabled = false;
            else
                Check_Service();

            Generate_Service();
        }

        private void Generate_Service()
        {
            _myService = "";

            if (Chk_Clipping_Path.Checked)
                _myService += "CP+";

            if (Chk_Basic_Process.Checked)
                _myService += "B_RET+";

            if (Chk_Pre_Process.Checked)
                _myService += "Pre_Pro+";

            if (Chk_Post_Process.Checked)
                _myService += "Post_Pro+";

            _myService = _myService.TrimEnd('+');

            if (_myService != "")
            {
                Btn_Start.Text = @"Start Job";
                Btn_Start.Enabled = true;
            }
            else
                Btn_Start.Enabled = false;
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
                Tmr_Count_Processing.Stop();
                Btn_Pause.Text = @"Resume";
            }
            else
            {
                Tmr_Count_Processing.Start();
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

        private async void Btn_Save_Click(object sender, EventArgs e)
        {
            Tmr_Count_Processing.Stop();
            Tmr_Pause.Stop();
            Pnl_Start_Job.Visible = true;
            Pnl_Counter.Visible = false;
            Pnl_Format.Visible = false;
            Pnl_Drop.Visible = true;
            Pnl_Drop.Enabled = true;
            Btn_Label.Visible = true;
            Btn_Label.Text = "Please Wait File Saving...";

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

                //var savingProgress = new SavingProgress
                //{
                //    _job = _job,
                //    _user = User,
                //    _pause = true,
                //    _proTime = _proTime,
                //    _fileName = _fileName,
                //    _myService = _myService,
                //    _performance = _performance,
                //};
                //savingProgress.Show();
            }
            else
            {
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

                _readyFolder = _job.WorkingLocation+ @"\" + _myService + "_Done" + @"\" + root;

                if (_log.Remarks == "Share")
                    _readyFolder += @"\Share\" + User.Short_Name;

                Directory.CreateDirectory(_readyFolder);
                _destination = Path.Combine(_readyFolder, itemName);

                if (File.Exists(_source))
                    await Task.Run(() => File.Copy(_source, _destination, true));
                else
                    MessageBox.Show(@"Find done file & keep it to Done folder manually...", @"Done file doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //var savingProgress = new SavingProgress
                //{
                //    _job = _job,
                //    _user = User,
                //    _source = _source,
                //    _proTime = _proTime,
                //    _fileName = _fileName,
                //    _myService = _myService,
                //    _destination = _destination,
                //    _performance = _performance,
                //};
                ////Task.Run(() => 
                //savingProgress.Show();
                _file = "";
            }

            //update log Report in Log Table
            _proTime /= 60;
            _log.ProTime += _proTime;
            _log.OutputLocation = _destination;
            _log.EndTime = DateTime.Now;
            _log.Status = "Done";
            _log.Quality = 100;
            _log.Revenue =  _log.TargetTime / _job.TargetTime * _job.Taka;
            _log.Support = _support;
            _log.Up = 0;

            _db.SaveChanges();

            var efficiency = 0;

            if (_log.ProTime != 0)
                efficiency = (int)(_log.TargetTime / _log.ProTime * 100);

            _job.ProDone = _db.Logs.Where(x => x.JobId == _job.JobId & x.Status == "Done").Select(x => x.Image).Distinct().Count();

            if (_job.ProDone > 0)
                _job.ProTime = _db.Logs.Where(x => x.JobId == _job.JobId & x.Status == "Done").Distinct().Sum(x => x.ProTime) / _job.ProDone;

            if (efficiency > 400)
                _log.Efficiency = 100;
            else
                _log.Efficiency = efficiency;

            _proTime = 0;
            Btn_Label.Text = "Time Saved. Efficiency:"+ _log.Efficiency + "%";

            if (efficiency < 90)
                Btn_Label.BackColor = Color.Tomato;
            else if (efficiency < 100)
                Btn_Label.BackColor = Color.Orange;
            else
                Btn_Label.BackColor = Color.MediumSeaGreen;

            DateTime _currentTime = DateTime.Now;
            var myJob = _db.My_Jobs.FirstOrDefault(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService & x.Date == _currentTime.Date);

            if (myJob == null)
            {
                myJob = new MyJob
                {
                    JobId = _job.JobId,
                    Name = User.Short_Name,
                    Service = _myService,
                    Date = _currentTime.Date,
                    StartTime = _log.StartTime
                };
                _db.My_Jobs.Add(myJob);
            }

            var fileCount = myJob.Amount = _db.Logs
                .Count(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                    x.StartTime >= _performance.Login & x.StartTime <= _currentTime);

            double quality;
            if (fileCount != 0)
            {
                myJob.TotalJobTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Sum(x => x.TargetTime);

                myJob.JobTime = myJob.TotalJobTime / fileCount;

                myJob.TotalProTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Sum(x => x.ProTime);

                myJob.ProTime = myJob.TotalProTime / fileCount;

                if (myJob.ProTime != 0)
                    myJob.Efficiency = (int)(myJob.JobTime / myJob.ProTime * 100);

                quality = _db.Logs
                    .Where(x => x.JobId == _job.JobId & x.Name == User.Short_Name & x.Service == _myService &
                                x.StartTime >= _performance.Login & x.StartTime <= _currentTime).Average(x => x.Quality);

                myJob.Quality = (int)(quality);
            }

            myJob.EndTime = _currentTime;
            myJob.Up = 0;
            //---End Update My_Job Report in My_Job Table

            //---Update My_Job Performance in Performance Table
            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);

            _performance.File = fileCount = _db.Logs
                .Count(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime);

            if (fileCount != 0)
            {
                _performance.JobTime = _db.Logs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.TargetTime);

                _performance.ProTime = _db.Logs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.ProTime);

                if (_performance.ProTime != 0)
                    _performance.Efficiency = (int)(_performance.JobTime / _performance.ProTime * 100);

                quality = _db.Logs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Average(x => x.Quality);

                _performance.Quality = (int)(quality);

                _performance.Revenue = _db.Logs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.Revenue);

                _performance.Support = _db.Logs
                        .Where(x => x.Name == User.Short_Name & x.StartTime >= _performance.Login & x.StartTime <= _currentTime)
                        .Sum(x => x.Support);
            }

            _performance.Logout = _currentTime;
            _performance.WorkingTime = (int)(_currentTime - _performance.Login).TotalMinutes;
            _performance.Up = 0;

            if (Directory.Exists(_myFolder))
                Process.Start(_myFolder);

            _db.SaveChanges();
        }

        private void Pnl_Drop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Pnl_Drop_DragDrop(object sender, DragEventArgs e)
        {
            var logCount = _db.Logs.Where(x => x.Name == User.Short_Name & x.Status == "Running").Count();
            if (logCount != 0)
            {
                MessageBox.Show(@"You are already loged in. Please close that, then try again", @"Already Loged in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            _fileAmount = files.Count();

            if (_fileAmount > 1)
            {
                MessageBox.Show(@"Please select single file. Don't select multiple files...", @"Multiple files selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _proTime = 0;
            Tmr_Count_Processing.Start();
            Tmr_Pause.Start();
            _file = _rawFile = files[0];
            _fileName = Path.GetFileNameWithoutExtension(_file);

            var imageTime = _db.ImageTime.FirstOrDefault(x => x.Job_ID == _job.JobId & x.Image == _fileName);

            if (imageTime == null)
            {
                Btn_Label.Visible = true;
                Btn_Label.ForeColor = Color.Red;
                Btn_Label.Text = "Time empty";
                Tmr_Count_Processing.Stop();
                return;
            }

            _myTime = 0; _support = 0;

            if (Chk_Clipping_Path.Checked)
            {
                _myTime += imageTime.Clipping_Time;
                if((User.Team == "Clipper") | (User.Team == "Basic" & _job.Team != "Basic") | ((User.Team == "Advance" | User.Team == "Senior") & _job.Team != "Advance"))
                    _support += imageTime.Clipping_Time;
            }

            if (Chk_Basic_Process.Checked)
            {
                _myTime += imageTime.Basic_Time;
                if ((User.Team == "Basic" & _job.Team != "Basic") | ((User.Team == "Advance" | User.Team == "Senior") & _job.Team != "Advance"))
                    _support += imageTime.Clipping_Time;
            }

            if (Chk_Pre_Process.Checked)
                _myTime += imageTime.Pre_Process;

            if (Chk_Post_Process.Checked)
                _myTime += imageTime.Post_Process;

            //for check if file already production running.
            _log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & (x.Status == "Running" | x.Status == "InHand") & x.Name != User.Short_Name);

            if (_log != null)
            {
                var log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name == User.Short_Name & x.Remarks == "Share");

                if (log == null)
                {
                    MessageBox.Show(@"This file already production running. by " + _log.Name + @". Please select another file......", @"Running by " + _log.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Tmr_Count_Processing.Stop();
                    return;
                }
                _myTime = log.TargetTime;
            }

            this.WindowState = FormWindowState.Minimized;
            //Task.Run(()=>
            //LoadImage(imageTime);

            string Loc = _filePath = _myFolder = Path.GetDirectoryName(_file);
            string fileName = Path.GetFileName(_file);
            _parentFolder = new DirectoryInfo(_filePath ?? string.Empty).Name;
            //_doneFolder = _filePath + @"\Done_File";

            //move file to my folder
            if (_parentFolder != "Processing" & _parentFolder != "Done_File")
            {
                _rawFolder = _filePath + @"\Processing";
                Directory.CreateDirectory(_rawFolder);

                _filePath = Path.Combine(_rawFolder, fileName);

                if (File.Exists(_filePath))
                    File.Delete(_filePath);

                File.Move(_file ?? string.Empty, _filePath);
                _file = _filePath;

                _filePath = _rawFolder;
            }

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

            _log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId & x.Image == _fileName & x.Service == _myService & x.Name == User.Short_Name);

            if (_log == null)
            {
                _log = new Log
                {
                    JobId = _job.JobId,
                    Image = _fileName,
                    //ActualTime = _myTime,
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
            _log.Type = imageTime.Type;
            _log.InputLocation = _file;
            _log.WorkingLocation = _file;

            //Task.Run(() => SavePendingImage(Loc));
            
            Pnl_Counter.Visible = true;
            Pnl_Format.Visible = true;
            Pnl_Drop.Visible = false;
            Pnl_Service.Visible = false;
            Pnl_Start_Job.Visible = false;
            Btn_Label.Visible = false;
            Btn_Pause.Text = @"Pause";

            CMB_Share.Enabled = true;
            BTN_Share.Enabled = true;

            Txt_image.Text = _fileName;
            Lbl_Job_Time.Text = @"Job Time: " + _myTime;

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
                Pnl_Drop.Visible = true;

                Pnl_Service.Visible = false;
                Btn_Start.Visible = false;

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