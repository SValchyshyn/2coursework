using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _2courOOP_KR
{
    [Serializable()]
    public class Request:ISerializable
    {
        public List<string> Name { get; set; }

        public List<int> Ammount { get; set; }

        public List<DateTime> Date { get; set; }


        public Request()
        {
            Name = new List<string>();
            Ammount = new List<int>();
            Date = new List<DateTime>();

        }

        public Request(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            Name = (List<string>) info.GetValue("Name", typeof(List<string>));
            Ammount = (List<int>) info.GetValue("Ammount", typeof(List<int>));
            Date = (List<DateTime>) info.GetValue("Date", typeof(List<DateTime>));
        }

        public Request(List<string> name, List<int> ammount, List<DateTime> date)
        {
            Name = name;
            Ammount = ammount;
            Date = date;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("Name", Name);
            info.AddValue("Ammount", Ammount);
            info.AddValue("Date", Date);
        }
    }
}