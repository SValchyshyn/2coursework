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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRequest createRequest=new CreateRequest();
            createRequest.Show();
            //string[] name=new string[] {"sad","ball", "hong"};
            //int[] ammount = new[] {10, 25, 36};
            //DateTime[] date=new DateTime[] {new DateTime(2015,12,16), new DateTime(2015, 12, 18), new DateTime(2015, 12, 19) };
            //Request req = new Request(name,ammount,date );
            //Stream stream = File.Open("RequestInfo.osl", FileMode.Create);
            //BinaryFormatter bformatter = new BinaryFormatter();

            //Console.WriteLine("Writing Employee Information");
            //Console.WriteLine(req.Ammount.GetValue(1));
            //Console.WriteLine(req.Date.GetValue(1));
            //Console.WriteLine(req.Name.GetValue(1));

            //bformatter.Serialize(stream, req);
            //stream.Close();
            //Request req = null;

            //Stream stream = File.Open("RequestInfo.osl", FileMode.Open);
            //bformatter = new BinaryFormatter();

            //Console.WriteLine("Reading Employee Information");
            //req = (Request)bformatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine("Employee Id: {0}", req.Ammount.ToString());
            //Console.WriteLine("Employee Name: {0}", req.Name);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report=new Report();
            report.Show();
        }
    }
}
