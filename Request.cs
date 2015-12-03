using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _2courOOP_KR
{
    [Serializable()]
    public class Request:ISerializable
    {
        public List<Goods> GoodsList { get; set; }

        public Request()
        {
            GoodsList=new List<Goods>();

        }

        public Request(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            GoodsList = (List<Goods>) info.GetValue("GoodsList", typeof(List<Goods>));
        }

        public Request(List<Goods> goodsList)
        {
            GoodsList=goodsList;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("GoodsList", GoodsList);
        }

        public void Add(string name, int ammount, DateTime date)
        {
            GoodsList.Add(new Goods(name,  ammount, date));
        }

        public DateTime GetDate()
        {
            GoodsList.Sort((x, y) => y.Date.CompareTo(x.Date));
            return GoodsList[0].Date;
        }
    }
}