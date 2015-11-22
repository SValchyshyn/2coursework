using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2courOOP_KR
{
    public partial class Report : Form
    {
        private string[] filePaths =
            Directory.GetFiles(
                @"C:\Users\Bodiver\Documents\Visual Studio 2015\Projects\2courOOP KR\2courOOP KR\bin\Debug", "*.osl");
        BinaryFormatter bformatter = new BinaryFormatter();

        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request report=new Request();
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 0 && date.Month <= 3)
                {
                    Console.WriteLine(filePaths[i]);
                    Request req = null;
                    Stream stream = File.Open(filePaths[i], FileMode.Open);
                   // bformatter = new BinaryFormatter();
                    req = (Request)bformatter.Deserialize(stream);
                    stream.Close();
                    report.Name.AddRange(req.Name);
                    report.Ammount.AddRange(req.Ammount);
                    report.Date.AddRange(req.Date);
                }
            }
            foreach (var VARIABLE in report.Name)
            {
                Console.WriteLine(VARIABLE);
            }
            foreach (var VARIABLE in report.Ammount)
            {
                Console.WriteLine(VARIABLE);
            }

            foreach (var VARIABLE in report.Date)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 3 && date.Month <= 6)
                {
                    Console.WriteLine(filePaths[i]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 6 && date.Month <= 9)
                {
                    Console.WriteLine(filePaths[i]);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 9 && date.Month <= 12)
                {
                    Console.WriteLine(filePaths[i]);
                }
            }
        }
    }
}
