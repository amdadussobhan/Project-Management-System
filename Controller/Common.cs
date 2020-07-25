using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skill_PMS.Controller
{
    class Common
    {
        public void Dgv_Size(DataGridView Dgv, int Font_Size)
        {
            Dgv.RowTemplate.Height = 30;
            DataGridViewCellStyle Dgv_Cell_Style = new DataGridViewCellStyle();
            Dgv_Cell_Style.Font = new Font("Arial", Font_Size, FontStyle.Regular);
            Dgv_Cell_Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Cell_Style.SelectionBackColor = Color.Purple;
            Dgv.DefaultCellStyle = Dgv_Cell_Style;
            //Dgv_Cell_Style.BackColor = Color.Beige;
            //Dgv.ColumnHeadersDefaultCellStyle = Dgv_Cell_Style;
        }

        public void Row_Color_By_Delivery(DataGridView Dgv, string Delivery)
        {
            foreach (DataGridViewRow Row in Dgv.Rows)
            {
                DateTime now = DateTime.Now, delivery = Convert.ToDateTime(Row.Cells[Delivery].Value);

                if (Convert.ToString(delivery) != "" & Convert.ToString(delivery) != " " & Convert.ToString(delivery) != null)
                {
                    int Remain_Hour = (int)(delivery - now).TotalHours;

                    if (Remain_Hour < 0)
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Red;
                        //Row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (Remain_Hour <= 0)
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Orange;
                        //Row.DefaultCellStyle.BackColor = Color.Orange;
                    }
                    else
                    {
                        Row.DefaultCellStyle.ForeColor = Color.Green;
                        //Row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }
    }
}
