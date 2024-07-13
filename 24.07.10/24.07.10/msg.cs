using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._07._10
{
    internal class msg
    {
        public static void info(string a)
        {
            MessageBox.Show(null,a,"정보",0,MessageBoxIcon.Information);
        }
        public static void err(string a)
        {
            MessageBox.Show(null,a,"경고",0,MessageBoxIcon.Error);
        }
    }
}
