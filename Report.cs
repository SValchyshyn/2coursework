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

        private BinaryFormatter bformatter = new BinaryFormatter();

        public Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Tuple<string,DateTime>> quarterFiles=new List<Tuple<string, DateTime>>();
            Request report = new Request();
            Request request =new Request();
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month > 0 && date.Month <= 3)
                {
                    quarterFiles.Add(new Tuple<string, DateTime>(filePaths[i],date));
                    //Console.WriteLine(filePaths[i]);
                    //Request req = null;
                    //Stream stream = File.Open(filePaths[i], FileMode.Open);
                    ////bformatter = new BinaryFormatter();
                    //req = (Request)bformatter.Deserialize(stream);
                    //stream.Close();
                    //report.Name.AddRange(req.Name);
                    //report.Ammount.AddRange(req.Ammount);
                    //report.Date.AddRange(req.Date);
                }
            }
            quarterFiles.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            Request req = new Request();
            req.Date.Add(quarterFiles[0].Item2);
            Stream stream = File.Open(quarterFiles[0].Item1, FileMode.Open);
            request = (Request)bformatter.Deserialize(stream);
            stream.Close();
            report.Name.AddRange(request.Name);
            report.Ammount.AddRange(request.Ammount);
            report.Date.AddRange(request.Date);
            for (int i = 1; i < quarterFiles.Count; i++)
            {
                if (req.Date[0].Year == quarterFiles[i].Item2.Year)
                {
                    request = null;
                    stream = File.Open(quarterFiles[i].Item1, FileMode.Open);
                    request = (Request) bformatter.Deserialize(stream);
                    stream.Close();
                    report.Name.AddRange(request.Name);
                    report.Ammount.AddRange(request.Ammount);
                    report.Date.AddRange(request.Date);
                }
                else
                {
                    CreateRequestFile(report, 1);
                 
                    report.Name.Clear();
                    report.Ammount.Clear();
                    report.Date.Clear();
                    req.Date.Clear();
            
                    req.Date.Add(quarterFiles[i].Item2);        
                    stream = File.Open(quarterFiles[i].Item1, FileMode.Open);
                    request = (Request)bformatter.Deserialize(stream);
                    stream.Close();
                    report.Name.AddRange(request.Name);
                    report.Ammount.AddRange(request.Ammount);
                    report.Date.AddRange(request.Date);
                }
            }
            CreateRequestFile(report, 1);


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

        private void Report_Load(object sender, EventArgs e)
        {
            var a = 0;
            var b = 0;
            var c = 0;
            var d = 0;
            for (int i = 0; i < filePaths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(filePaths[i], @"\(([^)]*)\)").Groups[1].Value);
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

        private Stream CreateRequestFile(Request req, int quarterNum)
        {
            req.Date.Sort((x, y) => y.CompareTo(x)); ;
            Stream stream = File.Open($"Report {quarterNum}-st quarter({req.Date[0]:yyyy}).rep", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, req);
            return stream;
        }
    }
}
