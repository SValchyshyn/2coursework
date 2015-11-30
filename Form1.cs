using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace _2courOOP_KR
{
    public partial class Form1 : Form
    {
        List<string> pathesWithoutExt = new List<string>();
        List<string> goods = new List<string>();
        string[] paths = FilePaths.GetRepPath();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRequest createRequest=new CreateRequest();
            createRequest.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report=new Report();
            report.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var path in paths)
            {
                pathesWithoutExt.Add(Path.GetFileNameWithoutExtension(path));
            }
            FillListBox1();

        }

        private void FillListBox1()
        {
            listBox1.DataSource = pathesWithoutExt;
            listBox2.DataSource = goods;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLixtBox2();
        }

        private void FillLixtBox2()
        {
            var selected = listBox1.SelectedIndex;
            var CurRep = RequestSerializer.DeserializeRep(paths[selected]);
            listBox2.DataSource = null;
            goods.Clear();
            foreach (Goods VARIABLE in CurRep.GoodsList)
            {
                goods.Add(VARIABLE.GetGoods());
            }
            listBox2.DataSource = goods;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedRep = listBox1.SelectedIndex;
            var selectedGoods = listBox2.SelectedIndex;
            var path = paths[listBox1.SelectedIndex];
            ReportClass report = RequestSerializer.DeserializeRep(paths[selectedRep]);
            report.GoodsList.RemoveAt(selectedGoods);
            File.Delete(paths[selectedRep]);
            RequestSerializer.ReplaceReportFile(path,report);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FillListBox1();
            FillLixtBox2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.Delete(paths[listBox1.SelectedIndex]);
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
