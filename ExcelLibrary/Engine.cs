using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace ExcelLibrary
{
    public static class Engine
    {
        public static void ExportToExcel<T>(IEnumerable<T> data, string worksheetTitle, List<string> titles)
        {
            var wb = new XLWorkbook(); //create workbook
            var ws = wb.Worksheets.Add(worksheetTitle); //add worksheet to workbook

            //ws.Cell(1, 1).InsertData(titles); //insert titles to first row
            int i = 1;
            if (titles != null && titles.Count > 0)
                foreach (var title in titles)
                {
                    ws.Cell(1, i).Value = title;
                    i++;
                }

            if (data != null && data.Count() > 0)
            {
                //insert data to from second row on
                ws.Cell(2, 1).InsertData(data);
            }

            //save file to memory stream and return it as byte array
            using (var ms = new System.IO.MemoryStream())
            {
                wb.SaveAs("D:\\test.xlsx");
            }
        }

        public static void ToExcel(this List<Data> values, string worksheetTitle)
        {
            var wb = new XLWorkbook(); //create workbook
            var ws = wb.Worksheets.Add(worksheetTitle); //add worksheet to workbook

            //ws.Cell(1, 1).InsertData(titles); //insert titles to first row
            int i = 1;
            List<string> titles = new List<string>();
            titles.Add("№ жереба");
            titles.Add("Прізвіще/Ім'я");
            titles.Add("Дата народження");
            titles.Add("Розряд");
            titles.Add("Область");
            titles.Add("Місто");
            titles.Add("Сп това-во");
            titles.Add("Клуб");
            titles.Add("Власна вага");
            titles.Add("Коефіцієнт Віліса");
            titles.Add("Присідання");
            titles.Add("Жим");
            titles.Add("а 2-х вправ");
            titles.Add("Тяга");
            titles.Add("Сума");
            titles.Add("Місце");
            titles.Add("Викон. розряд");
            titles.Add("Сума КУ");
            titles.Add("Очки");
            titles.Add("Тренер (и)");
            
            foreach (var title in titles)
            {
                ws.Cell(1, i).Value = title;
                i++;
            }

            //var headers = ws.Range("A1:T1");
            ws.Columns(1, 20).AdjustToContents();

            if (values != null && values.Count() > 0)
            {
                ////insert data to from second row on
                //ws.Cell(2, 1).InsertData(values);
                int c = 2;
                foreach(var value in values)
                {
                    int j = 2;
                    ws.Cell(c, 1).Value = c - 1;
                    foreach(var property in value.ToStringList())
                    {
                        ws.Cell(c, j++).Value = property;
                    }
                    c++;
                }
            }

            //save file to memory stream and return it as byte array
            using (var ms = new System.IO.MemoryStream())
            {
                wb.SaveAs("D:\\test.xlsx");
            }
        }
    }
}
