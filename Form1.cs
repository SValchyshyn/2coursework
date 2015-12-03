using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace _2courOOP_KR
{
    public partial class Form1 : Form
    {
        private List<string> pathesWithoutExt = new List<string>();
        private ReportClass currRep = new ReportClass();
        private ReportClass deleted=new ReportClass();
        private string[] paths = {};

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateRequest createRequest = new CreateRequest();
            createRequest.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FillListBox1();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.DataSource != null)
            {
                currRep = RequestSerializer.DeserializeRep(paths[listBox1.SelectedIndex]);
                dataGridView1.Rows.Clear();
                FillDataGrid(currRep);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedGoods = dataGridView1.CurrentCell.RowIndex;
            ReportClass report = RequestSerializer.DeserializeRep(paths[listBox1.SelectedIndex]);
            deleted.Add(report.GoodsList[selectedGoods].Name, report.GoodsList[selectedGoods].Ammount, report.GoodsList[selectedGoods].Date);
            report.GoodsList.RemoveAt(selectedGoods);
            File.Delete(paths[listBox1.SelectedIndex]);
            RequestSerializer.ReplaceReportFile(paths[listBox1.SelectedIndex], report);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FillListBox1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.Delete(paths[listBox1.SelectedIndex]);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FillListBox1()
        {
            pathesWithoutExt.Clear();
            paths = null;
            paths = FilePaths.GetRepPath();
            foreach (var path in paths)
            {
                pathesWithoutExt.Add(Path.GetFileNameWithoutExtension(path));
            }
            listBox1.DataSource = null;
            listBox1.DataSource = pathesWithoutExt;
        }

        private void FillDataGrid(ReportClass report)
        {
            for (int i = 0; i < report.GoodsList.Count; i++)
            {
                dataGridView1.Rows.Add(report.GoodsList[i].Name, report.GoodsList[i].Ammount, report.GoodsList[i].Date);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var deletedString = "";
            for (int i = 0; i < deleted.GoodsList.Count; i++)
            {
                deletedString += $"Назва: {deleted.GoodsList[i].Name} Кількість: {deleted.GoodsList[i].Ammount} Дата:{deleted.GoodsList[i].Date}"+'\n';
            }
            MessageBox.Show(deletedString);
        }
    }
}
