using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace _2courOOP_KR
{
    public class RequestSerializer
    {
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

        public static void CreateRequestFile(Request req)
        {

                Stream stream = File.Open($"Request({req.GetDate():yyyy-MM-dd}).osl", FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, req);
                stream.Close();  
        }
        public static void CreateReportFile(ReportClass rep, int quarterNum)
        {
            Stream stream = File.Open($"Report {quarterNum}-st quarter({rep.GetDate():yyyy}).rep", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, rep);
            stream.Close();
            foreach (var VARIABLE in rep.GoodsList)
            {
                Console.WriteLine(VARIABLE.Name + '\n' + VARIABLE.Ammount + '\n' + VARIABLE.Date);
            }

        }

        public static void ReplaceReportFile(string path, ReportClass rep)
        {
            Stream stream = File.Open(path, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, rep);
            stream.Close();
            
        }


        public static Request Deserialize(string FileWay)
        {
            using (Stream stream = File.Open(FileWay, FileMode.Open))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                return (Request)bformatter.Deserialize(stream);
            }
        }

        public static ReportClass DeserializeRep(string FileWay)
        {
            using (Stream stream = File.Open(FileWay, FileMode.Open))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                return (ReportClass)bformatter.Deserialize(stream);
            }
        }

        public static void MakeReport(int a, int b, int q)
        {
            string[] paths = FilePaths.GetPath();
            var quarterFiles = new List<Tuple<string, DateTime>>();
            ReportClass report = new ReportClass();
            Request request = new Request();
            for (int i = 0; i < paths.Length; i++)
            {
                var date = DateTime.Parse(Regex.Match(paths[i], @"\(([^)]*)\)").Groups[1].Value);
                if (date.Month >= a && date.Month <= b)
                {
                    quarterFiles.Add(new Tuple<string, DateTime>(paths[i], date));
                }
            }
            quarterFiles.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            DateTime compareTime = quarterFiles[0].Item2;
            request = RequestSerializer.Deserialize(quarterFiles[0].Item1);
            report.AddRange(request.GoodsList);
            for (int i = 1; i < quarterFiles.Count; i++)
            {
                if (compareTime.Year == quarterFiles[i].Item2.Year)
                {
                    request = null;
                    request = RequestSerializer.Deserialize(quarterFiles[i].Item1);
                    report.AddRange(request.GoodsList);
                }
                else
                {
                    RequestSerializer.CreateReportFile(report, q);
                    report.GoodsList.Clear();
                    compareTime = quarterFiles[i].Item2;
                    request = RequestSerializer.Deserialize(quarterFiles[i].Item1);
                    report.AddRange(request.GoodsList);
                }
            }
            RequestSerializer.CreateReportFile(report, q);
            for (int i = 0; i < quarterFiles.Count; i++)
            {
                File.Delete(quarterFiles[i].Item1);
            }
        }
    }
}