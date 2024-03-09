using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.UI_WinForm.CS_Panel
{
    public partial class Modify_200 : Form
    {
        public Modify_200()
        {
            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            //HtmlWeb web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument document = web.Load("http://example.com/");

            //var title = document.DocumentNode.SelectNodes("//div/h1").First().InnerText;
            //Console.WriteLine(title);
            string Loc = Txt_Location.Text; if (!string.IsNullOrEmpty(Loc) & Directory.Exists(Loc))
            {
                string[] files = Directory.GetFiles(Loc, "*", SearchOption.AllDirectories);
                Prb_Rename.Value = 0;
                Prb_Rename.Maximum = files.Count();

                foreach (string sourceFile in files)
                {
                    string name = Path.GetFileName(sourceFile);

                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument document = web.Load(sourceFile);

                    var title = document.DocumentNode. SelectNodes("//main/h1").First().InnerText;
                    Console.WriteLine(name);
                    Prb_Rename.Increment(1);
                }

                MessageBox.Show(@"Successfully modified. Please check this Folder ", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Folder Location maybe Empty. Please Enter correct folder Location", @"Invalid Folder Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
