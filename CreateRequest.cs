using System;
using System.Windows.Forms;

namespace _2courOOP_KR
{
    public partial class CreateRequest : Form
    {
        Request req=new Request();
        public CreateRequest()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            req.Add(name_txt.Text,int.Parse((ammount_txt.Text)),DateTime.Parse(date_txt.Text));
            name_txt.Clear();
            ammount_txt.Clear();
            date_txt.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var VARIABLE in req.GoodsList)
            {
                Console.WriteLine(VARIABLE.Name+'\n'+VARIABLE.Ammount+'\n'+VARIABLE.Date);
            }
            RequestSerializer.CreateRequestFile(req);
        }

        private void CreateRequest_Load(object sender, EventArgs e)
        {

        }
    }
}
