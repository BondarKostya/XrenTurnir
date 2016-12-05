using ExcelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> titles = new List<string>();
            ////string[] t = { "Name", "Age", "Other" };
            //titles.Add("Name");
            //titles.Add("Age");
            //titles.Add("Other");

            //List<Tuple<string, string, string>> values = new List<Tuple<string, string, string>>();

            //values.Add(new Tuple<string, string, string>("User", "20", "Insider"));
            //values.Add(new Tuple<string, string, string>("Admin", "22", "Windows"));
            //values.Add(new Tuple<string, string, string>("Developer", "21", ".NET"));

            //ExcelLibrary.Engine.ExportToExcel(values, "MyTitle", titles);

            List<ExcelLibrary.Data> values = new List<ExcelLibrary.Data>();
            ExcelLibrary.Data data = new ExcelLibrary.Data();
            data.Name = "Test Morjoviy";
            data.Level = "Medium";
            data.Place = 4;
            data.Club = "NaVi";
            data.Assotiation = "LoL";
            data.Number = 51;
            data.Weight = 73.6;
            data.Trainers = "Faker";
            values.Add(data);

            ExcelLibrary.Data data1 = new ExcelLibrary.Data();
            data1.Name = "User Morjoviy";
            data1.Level = "Low";
            data1.Place = 3;
            data1.Club = "Unranked";
            data1.Assotiation = "LoL";
            data1.Number = 6;
            data1.Weight = 58.2;
            data1.Trainers = "Solo";
            values.Add(data1);

            ExcelLibrary.Data data2 = new ExcelLibrary.Data();
            data2.Name = "Test User";
            data2.Level = "Low";
            data2.Place = 5;
            data2.Club = "Unranked";
            data2.Assotiation = "LoL";
            data2.Number = 106;
            data2.Weight = 62.1;
            data2.Trainers = "Dou";
            values.Add(data2);

            ExcelLibrary.Data data3 = new ExcelLibrary.Data();
            data3.Name = "Chelenger";
            data3.Level = "Hard";
            data3.Place = 1;
            data3.Club = "SKT T1";
            data3.Assotiation = "LoL";
            data3.Number = 38;
            data3.Weight = 85.7;
            data3.Trainers = "Dendy";
            values.Add(data3);

            ExcelLibrary.Data data4 = new ExcelLibrary.Data();
            data4.Name = "Odmen";
            data4.Level = "TryHard";
            data4.Place = 0;
            data4.Club = "Servernaya";
            data4.Assotiation = "LoL";
            data4.Number = 13;
            data4.Weight = 111;
            data4.Trainers = "St. Odmen";
            values.Add(data4);

            ExcelLibrary.Data data5 = new ExcelLibrary.Data();
            data5.Name = "Newby";
            data5.Level = "Bronze V";
            data5.Place = 6;
            data5.Club = "Ranked";
            data5.Assotiation = "LoL";
            data5.Number = 1;
            data5.Weight = 43.6;
            data5.Trainers = "User J";
            values.Add(data5);

            values.ToExcel("D:\\test.xlsx", "Man");

            Engine.GetData("D:\\test.xlsx", "Man");
        }
    }
}
