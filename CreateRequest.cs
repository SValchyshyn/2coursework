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
    public partial class CreateRequest : Form
    {
        List<string> name = new List<string>();
        List<int> ammount = new List<int>();
        List<DateTime> date = new List<DateTime>();
        public CreateRequest()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _name = name_txt.Text.ToString();
            var _ammount = int.Parse(ammount_txt.Text.ToString());
            var _date= DateTime.Parse(date_txt.Text.ToString());
            name.Add(_name);
            ammount.Add(_ammount);
            date.Add(_date);
            name_txt.Clear();
            ammount_txt.Clear();
            date_txt.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream stream = CreateRequestFile();
            foreach (var VARIABLE in name)
            {
                Console.WriteLine(VARIABLE);
            }
            foreach (var VARIABLE in ammount)
            {
                Console.WriteLine(VARIABLE);
            }
            foreach (var VARIABLE in date)
            {
                Console.WriteLine(VARIABLE);
            }
            name.Clear();
            ammount.Clear();
            date.Clear();
            stream.Close();
        }

        private Stream CreateRequestFile()
        {
            Request req = new Request(name, ammount, date);
            date.Sort((x, y) => y.CompareTo(x));
            Stream stream = File.Open($"Request({date[0]:yyyy-MM-dd}).osl", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, req);
            return stream;
        }
    }
}
