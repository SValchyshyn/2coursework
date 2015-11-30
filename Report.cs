using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _2courOOP_KR
{
    public partial class Report : Form
    {

        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestSerializer.MakeReport(1,3,1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestSerializer.MakeReport(4, 6, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RequestSerializer.MakeReport(6, 9, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestSerializer.MakeReport(9, 12, 1);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            string[] paths = FilePaths.GetPath();
            var a = 0;
            var b = 0;
            var c = 0;
            var d = 0;
            for (int i = 0; i < FilePaths.GetPath().Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(paths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 0 && date.Month <= 3)
                    a++;                
                else if (date.Month > 3 && date.Month <= 6)
                    b++;               
                else if (date.Month > 6 && date.Month <= 9)
                    c++;               
                else if (date.Month > 9 && date.Month <= 12)
                    d++;
            }
            label3.Text = a.ToString();
            label5.Text = b.ToString();
            label7.Text = c.ToString();
            label9.Text = d.ToString();
        }
    }
}
