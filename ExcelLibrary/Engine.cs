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

        public static void ToExcel(this List<Data> values, string fileName, string worksheetTitle)
        {
            var wb = new XLWorkbook(); //create workbook
            var ws = wb.Worksheets.Add(worksheetTitle); //add worksheet to workbook

            //ws.Cell(1, 1).InsertData(titles); //insert titles to first row
            int i = 1;
            List<string> titles = new List<string>();
            titles.Add("№ жереба");
            titles.Add("Прізвище/Ім'я");
            titles.Add("Дата народження");
            titles.Add("Розряд");
            titles.Add("Область");
            titles.Add("Місто");
            titles.Add("Сп това-во");
            titles.Add("Клуб");
            titles.Add("Власна вага");
            titles.Add("Коефіцієнт Віліса");
            titles.Add("Тренер (и)");
            titles.Add("Присідання");
            titles.Add("Жим");
            titles.Add("а 2-х вправ");
            titles.Add("Тяга");
            titles.Add("Сума");
            titles.Add("Місце");
            titles.Add("Викон. розряд");
            titles.Add("Сума КУ");
            titles.Add("Очки");

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
                int c = 3;

                var lowValues = values.Where(x => x.Weight <= Data.Low).ToList();
                var mediumValues = values.Where(x => x.Weight > Data.Low && x.Weight <= Data.Medium).ToList();
                var hardValues = values.Where(x => x.Weight > Data.Medium && x.Weight <= Data.Hard).ToList();
                var tryHardValues = values.Where(x => x.Weight > Data.Hard && x.Weight < Data.TryHard).ToList();

                ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Low);
                foreach (var value in lowValues)
                {
                    int j = 1;
                    //ws.Cell(c, 1).Value = c - 1;
                    foreach (var property in value.ToStringList())
                    {
                        ws.Cell(c, j++).Value = property;
                    }
                    c++;
                }
                c++;

                ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Medium);
                foreach (var value in mediumValues)
                {
                    int j = 1;
                    //ws.Cell(c, 1).Value = c - 1;
                    foreach (var property in value.ToStringList())
                    {
                        ws.Cell(c, j++).Value = property;
                    }
                    c++;
                }
                c++;

                ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Hard);
                foreach (var value in hardValues)
                {
                    int j = 1;
                    //ws.Cell(c, 1).Value = c - 1;
                    foreach (var property in value.ToStringList())
                    {
                        ws.Cell(c, j++).Value = property;
                    }
                    c++;
                }
                c++;

                ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.TryHard);
                foreach (var value in tryHardValues)
                {
                    int j = 1;
                    //ws.Cell(c, 1).Value = c - 1;
                    foreach (var property in value.ToStringList())
                    {
                        ws.Cell(c, j++).Value = property;
                    }
                    c++;
                }
                c++;

                //foreach (var value in values)
                //{
                //    int j = 1;
                //    //ws.Cell(c, 1).Value = c - 1;
                //    foreach (var property in value.ToStringList())
                //    {
                //        ws.Cell(c, j++).Value = property;
                //    }
                //    c++;
                //}
            }

            //save file to memory stream and return it as byte array
            using (var ms = new System.IO.MemoryStream())
            {
                wb.SaveAs(fileName);
            }
        }

        public static List<Data> GetData(string path, string worksheet)
        {
            List<Data> result = new List<Data>();

            try
            {
                XLWorkbook workbook = new XLWorkbook(path);
                var ws = workbook.Worksheet(worksheet);

                var cellName = ws.CellsUsed().Where(c => c.Value.ToString() == "Прізвище/Ім'я").First();

                List<IXLCell> cells = new List<IXLCell>();
                while (!cellName.IsEmpty() || cellName.Address.RowNumber < 200)
                {
                    cellName = cellName.CellBelow();
                    cells.Add(cellName);
                }

                IXLCell tempCell;
                foreach (var cell in cells)
                {
                    if (!cell.IsEmpty())
                    {
                        var human = new Data();
                        human.Name = cell.Value.ToString();

                        tempCell = cell.CellRight();
                        human.Birthday = tempCell.Value.ToString().Replace("0:00:00", string.Empty);

                        tempCell = tempCell.CellRight();
                        human.Level = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.State = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Sity = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Assotiation = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Club = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        double temp;
                        double.TryParse(tempCell.Value.ToString(), out temp);
                        human.Weight = temp;

                        tempCell = tempCell.CellRight();
                        double.TryParse(tempCell.Value.ToString(), out temp);
                        human.kWilis = temp;

                        tempCell = tempCell.CellRight();
                        human.Trainers = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Prised = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Jym = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Alpha = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Taga = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        double.TryParse(tempCell.Value.ToString(), out temp);
                        human.Summ = temp;

                        tempCell = tempCell.CellRight();
                        int tempInt;
                        int.TryParse(tempCell.Value.ToString(), out tempInt);
                        human.Place = tempInt;

                        tempCell = tempCell.CellRight();
                        bool tempBool;
                        bool.TryParse(tempCell.Value.ToString(), out tempBool);
                        human.NormFlag = tempBool;

                        tempCell = tempCell.CellRight();
                        double.TryParse(tempCell.Value.ToString(), out temp);
                        human.Points = temp;

                        human.InitEnd();
                        if (human.Name != string.Empty)
                            result.Add(human);
                    }
                }

                foreach (var cell in result)
                {
                    foreach (var prop in cell.ToStringList())
                    {
                        System.Diagnostics.Debug.WriteLine(prop);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
