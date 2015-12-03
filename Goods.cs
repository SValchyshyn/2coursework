using System;

namespace _2courOOP_KR
{
    [Serializable()]
    public class Goods
    {
        public string Name { get; set; }

        public int Ammount { get; set; }

        public DateTime Date { get; set; }

        public Request Request
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public ReportClass ReportClass
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Goods()
        {
            Name = "";
            Ammount = 0;
            Date = DateTime.Parse("0000.00.00");
        }

        public Goods(string name, int ammount, DateTime date)
        {
            Name = name;
            Ammount = ammount;
            Date = date;
        }

        public string GetGoods()
        {
            string goods = $"Name: {Name}, Ammount: {Ammount}, Date: {Date}";
            return goods;
        }
    }
}