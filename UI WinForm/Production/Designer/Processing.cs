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
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class Processing : Form
    {
        private SkillContext _db = new SkillContext();
        private Common _common = new Common();

        public bool autoPause = false;
        public Point cursorPosition = new Point();
        private Log _log = new Log();
        private ImageTime _imageTime = new ImageTime();
        public NewJob _job = new NewJob();
        public Performance _performance = new Performance();

        public User User { get; set; }
        public int _runningJobsId, _fileCount;
        private bool _isOld = false;
        private string _myService, _file, _rawFile, _fileName, _filePath, _ext, _parentFolder;
        public double _proTime, _pauseTime, _support, _cp_factor, _ret_factor, _pre_factor, _post_factor;
        public static double TotalTime;
        public static bool Minimized;
        public List<string> _files;
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

                var service = "";

                if (_job.Service != null)
                {
                    if (_job.Service.Contains("LIQ2"))
                        service += "LIQ+";

                    if (_job.Service.Contains("MSK"))
                        service += "MSK+";

                    if (_job.Service.Contains("NJ"))
                        service += "NJ+";

                    if (_job.Service.Contains("SHA"))
                        service += "SHA+";
                }

                if (service != "")
                    Chk_Post_Process.Text = service.TrimEnd('+');
                else
                    Chk_Post_Process.Text = "Post Process";
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
            Check_Service();

            foreach (var designer in _common.Current_Designers())
                CMB_Share.Items.Add(designer.Name);

            _jobFolder = _job.WorkingLocation;
            if (Directory.Exists(_jobFolder))
                Process.Start(_jobFolder);
        }
        
        private void Check_Service()
        {
            if (_job.Service != null)
            {
                if (_job.Service.Contains("CP"))
                    Chk_Clipping_Path.Enabled = true;
                else
                    Chk_Clipping_Path.Enabled = false;

                if (_job.Service.Contains("RET"))
                    Chk_Basic_Process.Enabled = true;
                else
                    Chk_Basic_Process.Enabled = false;

                if (_job.Service.Contains("LIQ1"))
                    Chk_Pre_Process.Enabled = true;
                else
                    Chk_Pre_Process.Enabled = false;

                if (_job.Service.Contains("LIQ2") || _job.Service.Contains("MSK") || _job.Service.Contains("NJ") || _job.Service.Contains("SHA"))
                    Chk_Post_Process.Enabled = true;
                else
                    Chk_Post_Process.Enabled = false;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Cancel_Job();

            Tmr_Count.Stop();
            _proTime = 0;
            _pauseTime = 0;

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
                    dashboard._performance = _performance;
                    dashboard.Show();
                    break;
                }
            }
        }

        private void Cancel_Job()
        {
            _log = _db.Logs
                .FirstOrDefault(x => x.JobId == _job.JobId && x.Image == _fileName && x.Status == "Running" && x.Name == User.Short_Name && x.Image == _fileName);

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
            if (_shareName != User.Short_Name && !string.IsNullOrEmpty(_shareName))
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
                    .Where(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name != User.Short_Name && x.Remarks == "Share")
                    .FirstOrDefault();

                double totalTime = 0;
                if (find != null)
                {
                    totalTime = _db.Logs
                        .Where(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name != User.Short_Name && x.Remarks == "Share")
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
                _pauseTime += 10;
                autoPause = true;
                Tmr_Count.Stop();

                Btn_Play.Visible = true;
                Btn_Play.Enabled = true;

                Btn_Pause.Visible = false;
                Btn_Pause.Enabled = false;
            }
            else
            {
                if (autoPause)
                {
                    Tmr_Count.Start();
                    Btn_Pause.Visible = true;
                    Btn_Pause.Enabled = true;

                    Btn_Play.Visible = false;
                    Btn_Play.Enabled = false;
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
            if (Chk_Clipping_Path.Checked)
            {
                if (_job.ScriptAmount > 0)
                {
                    Chk_Basic_Process.Checked = false;
                    Chk_Pre_Process.Checked = false;
                    Chk_Post_Process.Checked = false;
                }
            }
            else
                Check_Service();

            Generate_Service();
        }

        private void Chk_Basic_Process_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Basic_Process.Checked)
            {
                if (_job.ScriptAmount > 0)
                    Chk_Clipping_Path.Checked = false;
            }
            else
                Check_Service();

            Generate_Service();
        }

        private void Chk_Pre_Process_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Pre_Process.Checked)
            {
                Chk_Post_Process.Checked = false;
                if (_job.ScriptAmount > 0)
                    Chk_Clipping_Path.Checked = false;
            }
            else
                Check_Service();

            Generate_Service();
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            Play_Pause();
        }

        private void Chk_Post_Process_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Post_Process.Checked)
            {
                Chk_Pre_Process.Checked = false;
                if (_job.ScriptAmount >0)
                    Chk_Clipping_Path.Checked = false;
            }
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
                _myService += "RET+";

            if (Chk_Pre_Process.Checked)
                _myService += "LIQ1+";

            if (Chk_Post_Process.Checked)
            {
                if (_job.Service.Contains("LIQ2"))
                    _myService += "LIQ2+";

                if (_job.Service.Contains("MSK"))
                    _myService += "MSK+";

                if (_job.Service.Contains("NJ"))
                    _myService += "NJ+";

                if (_job.Service.Contains("SHA"))
                    _myService += "SHA+";
            }

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
            var counter = Counter.GetInstance();
            if (this.WindowState == FormWindowState.Minimized && Btn_Pause.Text != "Resume")
            {
                counter.Show();
                Minimized = true;
            }
            else
            {
                Minimized = false;
            }

            Counter.Minimized = Minimized;
            //Counter.TotalTime = TotalTime;
        }

        private void Btn_Pause_Click(object sender, EventArgs e)
        {
            Play_Pause();
        }

        private void Play_Pause()
        {
            if (Btn_Pause.Visible)
            {
                autoPause = false;
                Tmr_Count.Stop();

                Btn_Play.Visible = true;
                Btn_Play.Enabled = true;

                Btn_Pause.Visible = false;
                Btn_Pause.Enabled = false;

            }
            else
            {
                Tmr_Count.Start();

                Btn_Pause.Visible = true;
                Btn_Pause.Enabled = true;

                Btn_Play.Visible = false;
                Btn_Play.Enabled = false;
            }
        }

        private void Tmr_Count_Tick(object sender, EventArgs e)
        {
            _proTime++;
            TimeSpan timeSpan = TimeSpan.FromSeconds(TotalTime--);
            Lbl_Job_Time.Text = @"Target: " + timeSpan.ToString(@"h\:mm\:ss");

            if (Btn_Pause.BackColor == Color.FromArgb(180, 180, 180))
                Btn_Pause.BackColor = Color.MediumOrchid;
            else
                Btn_Pause.BackColor = Color.FromArgb(180, 180, 180);
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Tmr_Pause.Stop();
            Tmr_Count.Stop();
            string file = "", /*filePath = "", */ fileName = "", parentFolder = "", rawFolder = "";
            
            if (_files.Count == 0)
            {
                Pnl_Start_Job.Visible = true;
                Pnl_Counter.Visible = false;
                Pnl_Format.Visible = false;
                Pnl_Drop.Visible = true;
                Pnl_Drop.Enabled = true;
                Btn_Save.Enabled = false;
                Tmr_Count.Stop();

                if (Directory.Exists(_myFolder))
                    Process.Start(_myFolder);
            }
            else
            {
                file = _files[0];
                this.WindowState = FormWindowState.Minimized;
                Tmr_Count.Start();
                Tmr_Pause.Start();
                Open_File(file);

                //filePath = Path.GetDirectoryName(file);
                //fileName = Path.GetFileName(file);
                //parentFolder = new DirectoryInfo(filePath ?? string.Empty).Name;

                //move file to my folder
                //if (parentFolder != "Processing")
                //{
                //rawFolder = filePath + @"\Processing";
                //    Directory.CreateDirectory(rawFolder);
                //    filePath = Path.Combine(rawFolder, fileName);

                //    if (File.Exists(filePath))
                //        File.Delete(filePath);

                //    File.Move(file ?? string.Empty, filePath);
                //    file = filePath;
                //    filePath = rawFolder;
                //}

                //try
                //{
                //    var open = new Process
                //    {
                //        StartInfo =
                //        {
                //            FileName = @"Photoshop",
                //            Arguments = file ?? string.Empty
                //        }
                //    };
                //    open.Start();
                //}
                //catch
                //{
                //    var open = new Process
                //    {
                //        StartInfo =
                //        {
                //            FileName = @"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\Photoshop.exe",
                //            Arguments = file ?? string.Empty
                //        }
                //    };
                //    open.Start();
                //}
            }

            var itemName = Path.GetFileNameWithoutExtension(_file) + _ext;
            var source = Path.Combine(_filePath, itemName);

            if (Btn_Pause.Enabled)
            {
                var root = "";
                var filePath = Path.GetDirectoryName(_file);
                _parentFolder = new DirectoryInfo(filePath ?? string.Empty).Name;
                while (_parentFolder != _myService)
                {
                    //if (_parentFolder != "Processing")
                    root = _parentFolder + @"\" + root;
                    filePath = Path.GetDirectoryName(filePath);
                    _parentFolder = new DirectoryInfo(filePath ?? string.Empty).Name;
                }

                var readyFolder = _job.WorkingLocation + @"\" + _myService + "_Done" + @"\" + root;

                if (_log.Remarks == "Share")
                    readyFolder += @"\Share\" + User.Short_Name;

                Directory.CreateDirectory(readyFolder);
                var destination = Path.Combine(readyFolder, itemName);

                if (File.Exists(source))
                    File.Copy(source, destination, true);
                else
                    MessageBox.Show(@"Find done file & keep it to Done folder manually...", @"Done file doesn't Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);

                _log.OutputLocation = destination;
                //_file = "";
            }
            //else
            //{
            //    if (File.Exists(source))
            //    {
            //        var path = Path.GetDirectoryName(_filePath);
            //        var destination = Path.Combine(path ?? string.Empty, itemName);

            //        if (File.Exists(destination))
            //            File.Delete(destination);

            //        File.Move(source, destination);
            //    }


            //    if (File.Exists(_file))
            //    {
            //        var path = Path.GetDirectoryName(_filePath);
            //        var pauseItemName = Path.GetFileName(_file);
            //        var destination = Path.Combine(path ?? string.Empty, pauseItemName);

            //        if (File.Exists(destination))
            //            File.Delete(destination);

            //        File.Move(_file, destination);
            //    }
            //}

            //update log Report in Log Table
            _log.ProTime += (Math.Round(_proTime/60, 1));

            if (_log.TargetTime == 0)
                _log.TargetTime = _log.ProTime;

            //var avg = 0.0;

            //var othersProductions = _db.Logs.Where(x => x.JobId == _job.JobId && x.Type == _log.Type && x.Service == _myService && x.Status == "Done").ToList();
            //if (othersProductions != null)
            //{
            //    var sum = 0.0;
            //    foreach (var othersProduction in othersProductions)
            //        sum += othersProduction.ProTime;

            //    var image = othersProductions.Select(x => x.Image).Distinct().Count();
            //    if (image >0)
            //        avg = sum / image;
            //}

            //var factor = 1.0;
            //if (_log.TargetTime != 0)
            //    factor = avg / _log.TargetTime;
            
            //double cp = 0, ret = 0, pre = 0, post = 0;

            //if (_imageTime != null)
            //{
            //    cp = Math.Round(avg * _cp_factor, 1);
            //    ret = Math.Round(avg * _ret_factor, 1);
            //    pre = Math.Round(avg * _pre_factor, 1);
            //    post = Math.Round(avg * _post_factor, 1);
            //}

            //var imageTime = _db.ImageTime.Where(x => x.Job_ID == _job.JobId && x.Type == _imageTime.Type);
            //foreach (var image in imageTime)
            //{
            //    if (_myService.Contains("CP"))
            //    {
            //        if (cp > 0)
            //            image.Clipping_Time = cp;
            //    }

            //    if (_myService.Contains("RET"))
            //    {
            //        if (ret > 0)
            //            image.Basic_Time = ret;
            //    }

            //    if (_myService.Contains("LIQ1"))
            //    {
            //        if (pre > 0)
            //            image.Pre_Process = pre;
            //    }

            //    if (_myService.Contains("LIQ2") || _myService.Contains("MSK") || _myService.Contains("NJ") || _myService.Contains("SHA"))
            //    {
            //        if (post > 0)
            //            image.Post_Process = post;
            //    }
            //}

            //_log.TargetTime = Math.Round((_log.TargetTime + _log.ProTime) / 2, 1);

            //_log.Support = _proTime / _log.TargetTime * _support;
            _log.EndTime = DateTime.Now;
            _log.Status = "Done";

            if (_pauseTime > 30)
                _log.PauseTime += _pauseTime/60;

            var efficiency = 0;
            efficiency = 0;
            if (_log.ProTime != 0)
                efficiency = (int)(_log.TargetTime / _log.ProTime * 100);

            if (efficiency > 400)
                _log.Efficiency = 100;
            else
                _log.Efficiency = efficiency;

            var job = _db.New_Jobs.FirstOrDefault(x => x.Id == _job.Id);
            job.ProDone = _db.Logs.Where(x => x.JobId == job.JobId && x.Status == "Done").Select(x => x.Image).Distinct().Count();

            if (job.ProDone > 0)
                job.ProTime = _db.Logs.Where(x => x.JobId == job.JobId && x.Status == "Done").Distinct().Sum(x => x.ProTime) / job.ProDone;

            if (job.ProTime != 0)
                efficiency = (int)(job.TargetTime / job.ProTime * 100);

            job.TargetEfficiency = efficiency;

            efficiency = 0;
            if (job.ProTime != 0)
                efficiency = (int)(job.ActualTime / job.ProTime * 100);

            job.ActualEfficiency = efficiency;

            _db.SaveChanges();

            DateTime currentTime = DateTime.Now;
            var myJob = _db.My_Jobs.FirstOrDefault(x => x.JobId == _job.JobId && x.Name == User.Short_Name && x.Service == _myService && x.Date == currentTime.Date);

            //Notification

            if (myJob == null)
            {
                myJob = new MyJob
                {
                    JobId = _job.JobId,
                    Name = User.Short_Name,
                    Service = _myService,
                    Date = currentTime.Date,
                    StartTime = _log.StartTime
                };
                _db.My_Jobs.Add(myJob);
            }

            var fileCount = myJob.Amount = _db.Logs
                .Count(x => x.JobId == _job.JobId && x.Name == User.Short_Name && x.Service == _myService &&
                    x.StartTime >= _performance.Login && x.StartTime <= currentTime);

            double quality;
            if (fileCount != 0)
            {
                myJob.TotalJobTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId && x.Name == User.Short_Name && x.Service == _myService &&
                                x.StartTime >= _performance.Login && x.StartTime <= currentTime).Sum(x => x.TargetTime);

                myJob.JobTime = Math.Round(myJob.TotalJobTime / fileCount, 1);

                myJob.TotalProTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId && x.Name == User.Short_Name && x.Service == _myService &&
                                x.StartTime >= _performance.Login && x.StartTime <= currentTime).Sum(x => x.ProTime);

                myJob.ProTime = Math.Round(myJob.TotalProTime / fileCount, 1);

                if (myJob.ProTime != 0)
                    myJob.Efficiency = (int)(myJob.JobTime / myJob.ProTime * 100);

                quality = _db.Logs
                    .Where(x => x.JobId == _job.JobId && x.Name == User.Short_Name && x.Service == _myService &&
                                x.StartTime >= _performance.Login && x.StartTime <= currentTime).Average(x => x.Quality);

                myJob.Quality = (int)(quality);
            }

            myJob.EndTime = currentTime;
            myJob.Up = 0;
            //---End Update My_Job Report in My_Job Table

            //---Update My_Job Performance in Performance Table
            _performance = _db.Performances.FirstOrDefault(x => x.Id == _performance.Id);

            _performance.File = fileCount = _db.Logs
                .Count(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime);

            if (fileCount != 0)
            {
                _performance.JobTime = Math.Round(_db.Logs
                        .Where(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime)
                        .Sum(x => x.TargetTime), 1);

                _performance.ProTime = Math.Round(_db.Logs
                        .Where(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime)
                        .Sum(x => x.ProTime), 1);

                if (_performance.ProTime != 0)
                    _performance.Efficiency = (int)(_performance.JobTime / _performance.ProTime * 100);

                quality = _db.Logs
                        .Where(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime)
                        .Average(x => x.Quality);

                _performance.Quality = (int)(quality);

                _performance.Revenue = _db.Logs
                        .Where(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime)
                        .Sum(x => x.Revenue);

                _performance.Support = _db.Logs
                        .Where(x => x.Name == User.Short_Name && x.StartTime >= _performance.Login && x.StartTime <= currentTime)
                        .Sum(x => x.Support);
            }

            _performance.Logout = currentTime;
            _performance.WorkingTime = (int)(currentTime - _performance.Login).TotalMinutes;
            _performance.Up = 0;

            _log.Up = 0;
            _db.SaveChanges();

            _file = _rawFile = file;
            //_filePath = filePath;
            //_fileName = fileName;
            //_parentFolder = parentFolder;
            //_rawFolder = rawFolder;

            if (_files.Count != 0)
                Start_File();
        }

        private void Pnl_Drop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Pnl_Drop_DragDrop(object sender, DragEventArgs e)
        {
            _files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
            _file = _rawFile = _files[0];
            _fileCount = _files.Count;

            this.WindowState = FormWindowState.Minimized;
            Tmr_Count.Start();
            Tmr_Pause.Start();

            _filePath = Path.GetDirectoryName(_file);
            _fileName = Path.GetFileName(_file);
            //_parentFolder = new DirectoryInfo(_filePath ?? string.Empty).Name;

            //move file to my folder
            //if (_parentFolder != "Processing")
            //{
            //    _rawFolder = _filePath + @"\Processing";
            //    Directory.CreateDirectory(_rawFolder);
            //    _filePath = Path.Combine(_rawFolder, _fileName);

            //    if (File.Exists(_filePath))
            //        File.Delete(_filePath);

            //    File.Move(_file ?? string.Empty, _filePath);
            //    _file = _filePath;
            //    _filePath = _rawFolder;
            //}

            //try
            //{
            //    var open = new Process
            //    {
            //        StartInfo =
            //        {
            //            FileName = @"Photoshop",
            //            Arguments = _file ?? string.Empty
            //        }
            //    };
            //    open.Start();
            //}
            //catch
            //{
            //    var open = new Process
            //    {
            //        StartInfo =
            //        {
            //            FileName = @"C:\Program Files (x86)\Adobe\Adobe Photoshop CS6\Photoshop.exe",
            //            Arguments = _file ?? string.Empty
            //        }
            //    };
            //    open.Start();
            //}

            Open_File(_file);
            Start_File();
        }

        private void Open_File(string file)
        {
            try
            {
                var open = new Process
                {
                    StartInfo =
                    {
                        FileName = @"Photoshop",
                        Arguments = file ?? string.Empty
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
                        Arguments = file ?? string.Empty
                    }
                };
                open.Start();
            }
        }

        private void Start_File()
        {
            _db = null;
            _db = new SkillContext();
            _proTime = 0;
            _pauseTime = 0;
            _fileName = Path.GetFileNameWithoutExtension(_file);
            _imageTime = _db.ImageTime.FirstOrDefault(x => x.Job_ID == _job.JobId && x.Image == _fileName);

            _support = 0;
            double myTime = 0;

            //_cp_factor = _ret_factor = _pre_factor = _post_factor = 0;

            if (_imageTime != null)
            {
                if (Chk_Clipping_Path.Checked)
                {
                    myTime += _imageTime.Clipping_Time;

                    if ((User.Team == "Clipper") || (User.Team == "Basic" && _job.Team == "Advance") || ((User.Team == "Advance" || User.Team == "Senior") && _job.Team == "Basic"))
                        _support += _imageTime.Clipping_Time;
                }

                if (Chk_Basic_Process.Checked)
                {
                    myTime += _imageTime.Basic_Time;

                    if ((User.Team == "Basic" && _job.Team == "Advance") || ((User.Team == "Advance" || User.Team == "Senior") && _job.Team == "Basic"))
                        _support += _imageTime.Clipping_Time;
                }

                if (Chk_Pre_Process.Checked)
                    myTime += _imageTime.Pre_Process;

                if (Chk_Post_Process.Checked)
                    myTime += _imageTime.Post_Process;

                //_cp_factor = _imageTime.Clipping_Time / myTime;
                //_ret_factor = _imageTime.Basic_Time / myTime;
                //_pre_factor = _imageTime.Pre_Process / myTime;
                //_post_factor = _imageTime.Post_Process / myTime;
            }

            _log = _db.Logs.FirstOrDefault(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name == User.Short_Name);

            if (_log == null)
            {
                _log = new Log
                {
                    JobId = _job.JobId,
                    Image = _fileName,
                    TargetTime = Math.Round(myTime,1),
                    Shift = _performance.Shift,
                    Service = _myService,
                    Date = _performance.Date,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    Name = User.Short_Name
                };
                _db.Logs.Add(_log);

                TotalTime = _log.TargetTime * 60;
            }
            else
            {
                TotalTime = (myTime * 60) - _proTime;
                _isOld = true;

                if (_log.Remarks == "Share")
                    myTime = _log.TargetTime;
            }

            if (_performance.IsOT == 1)
                _log.IsOT = 1;

            _log.Quality = 100;
            _log.Status = "Running";

            if (_imageTime != null)
                _log.Type = _imageTime.Type;

            _log.InputLocation = _file;
            //_log.WorkingLocation = _file;
            _log.ActualTime = Math.Round((_log.TargetTime / _job.TargetTime * _job.ActualTime), 1);
            _log.Revenue = Math.Round((_log.TargetTime / _job.TargetTime * _job.Taka), 1);

            Pnl_Counter.Visible = true;
            Pnl_Format.Visible = true;
            Pnl_Drop.Visible = false;
            Pnl_Service.Visible = false;
            Pnl_Start_Job.Visible = false;

            Btn_Play.Visible = false;
            Btn_Play.Enabled = false;

            Btn_Pause.Visible = true;
            Btn_Pause.Enabled = true;

            CMB_Share.Enabled = true;
            BTN_Share.Enabled = true;

            Btn_Cancel.Enabled = true;
            Btn_Save.Enabled = true;

            Txt_image.Text = _fileName;
            //Lbl_Job_Time.Text = @"Job Time: " + Math.Round(myTime, 1);

            _files.RemoveAt(0);
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
                .Where(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name != User.Short_Name && x.Remarks == "Share")
                .FirstOrDefault();

            double totalTime = 0;
            if (find != null)
            {
                totalTime = _db.Logs
                    .Where(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name != User.Short_Name && x.Remarks == "Share")
                    .Sum(x => x.TargetTime);
            }

            double shareTime = Convert.ToDouble(Txt_Mnt.Text);
            if (totalTime + shareTime > _log.TargetTime)
            {
                MessageBox.Show(@"Share time limit over. Please decrease share time...", @"Share time limit over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var log = _db.Logs
                .FirstOrDefault(x => x.JobId == _job.JobId && x.Image == _fileName && x.Service == _myService && x.Name == _shareName & x.Remarks == "Share");

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
                MessageBox.Show(@"Folder doesn't Exist. Please inform Your Shift in-charge Or ADMIN about this...", @"Folder Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);            
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