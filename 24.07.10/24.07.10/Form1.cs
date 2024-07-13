using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._07._10
{
    public partial class Form1 : Form
    {
        public static int cert = 0;
        string id = "";
        string name = "";

        public bool test = false;
        TextBox[] txtList;
        const string IdPlaceholder = "아이디를 입력해주세요";

        public Form1()
        {
            InitializeComponent();

            txtList = new TextBox[] { textBox1 };
            foreach (var txt in txtList)
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == textBox1) txt.Text = IdPlaceholder;
                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == IdPlaceholder)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == textBox1) txt.Text = IdPlaceholder;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string con = "server = .\\SQLEXPRESS; database = news; uid=sa; pwd = 1234";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            string query = "select * from [user] where id = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (textBox1.Text.Equals(""))
            {
                msg.err("빈칸이 있습니다");
            }
            else
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        id = rdr.GetString(1);
                    }

                    if (id != textBox1.Text)
                    {
                        msg.err("아이디를 확인해주세요");
                    }
                    else
                    {
                        msg.info("본인인증을 시작하겠습니다");
                        this.Hide();
                        certified certified = new certified();
                        certified.Show();
                    }

                }
                else
                {
                    msg.err("존재하는 회원이 없습니다");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string con = "server = .\\SQLEXPRESS; database = news; uid = sa; pwd = 1234 ";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();

            string query = "select * from [user] where u_name = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                name = rdr.GetString(0);
            }

            if (cert == 0)
            {
                msg.err("본인인증 완료 후 로그인 해주세요");
            }
            else
            {
                msg.err(name + "님 환영합니다");
            }

        }
    }
}
