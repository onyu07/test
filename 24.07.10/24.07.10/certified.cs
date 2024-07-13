using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._07._10
{
    public partial class certified : Form
    {
        

        public certified()
        {
            InitializeComponent();
        }

        int c = -1;
        private void certified_Load(object sender, EventArgs e)
        {
            PictureBox[] pic = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].SizeMode = PictureBoxSizeMode.StretchImage;

                pic[i].Click += click;
            }
            CheckBox[] ckb = { checkBox2, checkBox3, checkBox4, checkBox5 };
            for (int i = 0; i < ckb.Length; i++)
            {
                ckb[i].ForeColor = Color.LightGray;
                ckb[i].Font = new Font(ckb[i].Font.FontFamily, 12, FontStyle.Underline);

               // ckb[i].Click += cc;
            }
        }
        void click(object s, EventArgs e)
        {
            c = -1;
            PictureBox[] pic = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

            foreach (PictureBox p in pic)
            {
                if (s.Equals(p))
                {
                    if (p.Name.Equals("1"))
                    {
                        p.Name = "";
                    }
                    else
                    {
                        p.Name = "1";
                        c = Array.IndexOf(pic, p) + 1;
                    }
                }
                else
                {
                    p.Name = "";
                }
            }
            set();
        }


        void set()
        {
            PictureBox[] pic = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Refresh();
                if (pic[i].Name.Equals("1"))
                {
                    Graphics g = pic[i].CreateGraphics();
                    int d = Math.Min(pic[i].Width , pic[i].Height);
                    int x = (pic[i].Width - d) / 2;
                    int y = (pic[i].Height - d) / 2;
                    g.DrawEllipse(new Pen(Color.Red,1), x, y, d-1, d-1);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox[] ckb = { checkBox2, checkBox3, checkBox4, checkBox5 };
            for (int i = 0; i < ckb.Length; i++)
            {
                ckb[i].Checked = true;
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            CheckBox[] ckb = { checkBox2, checkBox3, checkBox4, checkBox5 };
            if (checkBox4.Checked = true)
            {
                checkBox1.Checked = false;
                checkBox4.Checked = false;
            }
            else
            {
                checkBox4.Checked = true;
                for (global::System.Int32 i = 0; i < ckb.Length; i++)
                {
                    if (ckb[i].Checked = true)
                    {

                    }
                }


            }
        }
    }
}
