using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.Production.Designer
{
    public partial class SavingProgress : Form
    {
        private class UiProgress
        {
            public UiProgress(string name, long bytes, long maxbytes)
            {
                this.name = name; this.bytes = bytes; this.maxbytes = maxbytes;
            }
            public string name;
            public long bytes;
            public long maxbytes;
        }

        // Class to report exception {
        private class UIError
        {
            public UIError(Exception ex, string path_)
            {
                msg = ex.Message; path = path_; result = DialogResult.Cancel;
            }
            public string msg;
            public string path;
            public DialogResult result;
        }
        private BackgroundWorker mCopier;
        private delegate void ProgressChanged(UiProgress info);
        private delegate void CopyError(UIError err);
        private ProgressChanged OnChange;
        private CopyError OnError;

        public SavingProgress()
        {
            InitializeComponent();

            mCopier = new BackgroundWorker();
            mCopier.DoWork += Copier_DoWork;
            mCopier.RunWorkerCompleted += Copier_RunWorkerCompleted;
            mCopier.WorkerSupportsCancellation = true;
            OnChange += Copier_ProgressChanged;
            OnError += Copier_Error;
            ChangeUi(false);
        }

        public string Source, Destination, Backup, Raw_Source, Raw_Backup, Status;

        private void Copier_DoWork(object sender, DoWorkEventArgs e)
        {
            // Create list of files to copy
            long maxbytes = 0;
            maxbytes += Source.Length;
            // Copy files
            long bytes = 0;
            try
            {
                this.BeginInvoke(OnChange, new object[] { new UiProgress(Source, bytes, maxbytes) });
                File.Copy(Source, Destination, true);
            }
            catch (Exception ex)
            {
                UIError err = new UIError(ex, Source);
                this.Invoke(OnError, new object[] { err });
                if (err.result == DialogResult.Cancel)
                {

                }
            }
            bytes += Source.Length;
        }

        private void Copier_ProgressChanged(UiProgress info)
        {
            // Update progress
            Prb_Copier.Value = (int)(100.0 * info.bytes / info.maxbytes);
        }

        private void Copier_Error(UIError err)
        {
            // Error handler
            string msg = string.Format("Error copying file {0}\n{1}\nClick OK to continue copying files", err.path, err.msg);
            err.result = MessageBox.Show(msg, @"Copy error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        }

        private void Copier_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (!File.Exists(Backup))
            //    File.Delete(Backup);

            //File.Move(Source, Backup);

            //if (File.Exists(Source))
            //    File.Delete(Source);

            ////if (!File.Exists(Raw_Backup))
            ////    File.Move(Raw_Source, Raw_Backup);

            //if (File.Exists(Raw_Source))
            //    File.Delete(Raw_Source);

            // Operation completed, update UI
            if (!File.Exists(Destination))
                File.Copy(Source, Destination, true);

            Thread.Sleep(1000);
            ChangeUi(false);
            this.Close();
        }

        private void ChangeUi(bool docopy)
        {
            Prb_Copier.Visible = docopy;
            Prb_Copier.Value = 0;
        }

        private void Saving_Progress_Load(object sender, EventArgs e)
        {
            ChangeUi(true); 
            mCopier.RunWorkerAsync();
        }
    }
}
