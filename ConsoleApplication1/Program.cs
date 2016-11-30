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
            data.Place = 1;
            data.Club = "NaVi";
            data.Assotiation = "LoL";
            data.Number = 51;
            data.Weight = 73.6;
            values.Add(data);

            values.ToExcel("Test");

            Engine.GetData("D:\\test.xlsx");
        }
    }
}
