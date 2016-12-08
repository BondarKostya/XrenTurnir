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
        private static XLWorkbook Wilks;
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

        private static void CalculatePlace(this List<Data> values)
        {
            values.Sort((x, y) =>
            {
                if (x.SummKU > y.SummKU)
                    return -1;
                else if (x.SummKU < y.SummKU)
                    return 1;
                else
                    return 0;
            });

            int i = 1;
            foreach (var value in values)
                value.Place = i++;
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
            //titles.Add("Присідання");
            //titles.Add("Жим");
            //titles.Add("а 2-х вправ");
            //titles.Add("Тяга");
            //titles.Add("Сума");
            //titles.Add("Місце");
            //titles.Add("Викон. розряд");
            //titles.Add("Сума КУ");
            //titles.Add("Очки");

            ws.Range("L1:N1").Merge();
            ws.Range("O1:Q1").Merge();
            ws.Range("R1:T1").Merge();

            foreach (var title in titles)
            {
                ws.Cell(1, i).Value = title;
                i++;
            }

            ws.Cell(1, 12).Value = "Присідання";
            ws.Cell(2, 12).Value = "1";
            ws.Cell(2, 13).Value = "2";
            ws.Cell(2, 14).Value = "3";
            ws.Cell(1, 15).Value = "Жим";
            ws.Cell(2, 15).Value = "1";
            ws.Cell(2, 16).Value = "2";
            ws.Cell(2, 17).Value = "3";
            ws.Cell(1, 18).Value = "Тяга";
            ws.Cell(2, 18).Value = "1";
            ws.Cell(2, 19).Value = "2";
            ws.Cell(2, 20).Value = "3";
            ws.Cell(1, 21).Value = "а 2-х вправ";
            ws.Cell(1, 22).Value = "Сума";
            ws.Cell(1, 23).Value = "Місце";
            ws.Cell(1, 24).Value = "Викон. розряд";
            ws.Cell(1, 25).Value = "Сума КУ";
            ws.Cell(1, 26).Value = "Очки";

            //var headers = ws.Range("A1:T1");
            ws.Columns(1, 20).AdjustToContents();

            if (values != null && values.Count() > 0)
            {
                ////insert data to from second row on
                //ws.Cell(2, 1).InsertData(values);
                int c = 3;

                if (worksheetTitle == "Male")
                {
                    var lowValues = values.Where(x => double.Parse(x.Weight) <= Data.c59).ToList();
                    var lowMediumValues = values.Where(x => double.Parse(x.Weight) > Data.c59 && double.Parse(x.Weight) <= Data.c66).ToList();
                    var mediumValues = values.Where(x => double.Parse(x.Weight) > Data.c66 && double.Parse(x.Weight) <= Data.c74).ToList();
                    var lowHardValues = values.Where(x => double.Parse(x.Weight) > Data.c74 && double.Parse(x.Weight) < Data.c83).ToList();
                    var hardValues = values.Where(x => double.Parse(x.Weight) > Data.c83 && double.Parse(x.Weight) < Data.c93).ToList();
                    var lowTryHardValues = values.Where(x => double.Parse(x.Weight) > Data.c93 && double.Parse(x.Weight) < Data.c105).ToList();
                    var tryHardValues = values.Where(x => double.Parse(x.Weight) > Data.c105).ToList();

                    lowValues.CalculatePlace();
                    lowMediumValues.CalculatePlace();
                    mediumValues.CalculatePlace();
                    lowHardValues.CalculatePlace();
                    hardValues.CalculatePlace();
                    lowTryHardValues.CalculatePlace();
                    tryHardValues.CalculatePlace();

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c59);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c66);
                    foreach (var value in lowMediumValues)
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c74);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c83);
                    foreach (var value in lowHardValues)
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c93);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c105);
                    foreach (var value in lowTryHardValues)
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія від {0} кг", Data.c105);
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
                }
                else if (worksheetTitle == "Female")
                {
                    var lowValues = values.Where(x => double.Parse(x.Weight) <= Data.c47).ToList();
                    var lowMediumValues = values.Where(x => double.Parse(x.Weight) > Data.c47 && double.Parse(x.Weight) <= Data.c52).ToList();
                    var mediumValues = values.Where(x => double.Parse(x.Weight) > Data.c52 && double.Parse(x.Weight) <= Data.c57).ToList();
                    var lowHardValues = values.Where(x => double.Parse(x.Weight) > Data.c57 && double.Parse(x.Weight) < Data.c63).ToList();
                    var hardValues = values.Where(x => double.Parse(x.Weight) > Data.c63 && double.Parse(x.Weight) < Data.c72).ToList();
                    var tryHardValues = values.Where(x => double.Parse(x.Weight) > Data.c72).ToList();

                    lowValues.CalculatePlace();
                    lowMediumValues.CalculatePlace();
                    mediumValues.CalculatePlace();
                    lowHardValues.CalculatePlace();
                    hardValues.CalculatePlace();
                    tryHardValues.CalculatePlace();

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c47);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c52);
                    foreach (var value in lowMediumValues)
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c57);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c63);
                    foreach (var value in lowHardValues)
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.c72);
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

                    ws.Cell(c++, 1).Value = string.Format("Вагова категорія від {0} кг", Data.c72);
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
                }

                //ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Low);
                //foreach (var value in lowValues)
                //{
                //    int j = 1;
                //    //ws.Cell(c, 1).Value = c - 1;
                //    foreach (var property in value.ToStringList())
                //    {
                //        ws.Cell(c, j++).Value = property;
                //    }
                //    c++;
                //}
                //c++;

                //ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Medium);
                //foreach (var value in mediumValues)
                //{
                //    int j = 1;
                //    //ws.Cell(c, 1).Value = c - 1;
                //    foreach (var property in value.ToStringList())
                //    {
                //        ws.Cell(c, j++).Value = property;
                //    }
                //    c++;
                //}
                //c++;

                //ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.Hard);
                //foreach (var value in hardValues)
                //{
                //    int j = 1;
                //    //ws.Cell(c, 1).Value = c - 1;
                //    foreach (var property in value.ToStringList())
                //    {
                //        ws.Cell(c, j++).Value = property;
                //    }
                //    c++;
                //}
                //c++;

                //ws.Cell(c++, 1).Value = string.Format("Вагова категорія до {0} кг", Data.TryHard);
                //foreach (var value in tryHardValues)
                //{
                //    int j = 1;
                //    //ws.Cell(c, 1).Value = c - 1;
                //    foreach (var property in value.ToStringList())
                //    {
                //        ws.Cell(c, j++).Value = property;
                //    }
                //    c++;
                //}
                //c++;

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

                var cellName = ws.CellsUsed().Where(c => c.Value.ToString() == "Прізвище та ім'я").First();

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

                        //tempCell = cell.CellRight();
                        //human.Level = tempCell.Value.ToString();

                        tempCell = cell.CellRight();
                        //double temp;
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        human.Weight = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Birthday = tempCell.Value.ToString().Replace("0:00:00", string.Empty);



                        //tempCell = tempCell.CellRight();
                        //human.State = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Sity = tempCell.Value.ToString();

                        //tempCell = tempCell.CellRight();
                        //human.Assotiation = tempCell.Value.ToString();

                        tempCell = tempCell.CellRight();
                        human.Club = tempCell.Value.ToString();

                        //tempCell = tempCell.CellRight();
                        //double temp;
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.Weight = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.kWilis = temp;

                        tempCell = tempCell.CellRight();
                        human.Trainers = tempCell.Value.ToString();

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.p1 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.p2 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.p3 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.j1 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.j2 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.j3 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.t1 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.t2 = temp;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.t3 = temp;

                        //tempCell = tempCell.CellRight();
                        //human.Alpha = tempCell.Value.ToString();

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.Summ = temp;

                        //tempCell = tempCell.CellRight();
                        //int tempInt;
                        //int.TryParse(tempCell.Value.ToString(), out tempInt);
                        //human.Place = tempInt;

                        //tempCell = tempCell.CellRight();
                        //bool tempBool;
                        //bool.TryParse(tempCell.Value.ToString(), out tempBool);
                        //human.NormFlag = tempBool;

                        //tempCell = tempCell.CellRight();
                        //double.TryParse(tempCell.Value.ToString(), out temp);
                        //human.Points = temp;

                        //human.InitEnd();
                        if (human.Name != string.Empty && !human.Name.Contains(" кг"))
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

        public static double GetPoint(double summ, string weight, bool isMale)
        {
            return GetKWilks(weight, isMale) * summ;
        }

        public static double GetKWilks(string weight, bool isMale)
        {
            if (Wilks == null)
            {
                Wilks = new XLWorkbook("Wilks.xlsx");
            }

            double result = 0;
            try
            {
                IXLWorksheet ws;
                if (isMale)
                    ws = Wilks.Worksheet("Male");
                else
                    ws = Wilks.Worksheet("Female");

                string[] w = weight.Split(',');


                string res = ws.Cell(int.Parse(w[0]), int.Parse(w[1]) + 1).Value.ToString();

                double.TryParse(res, out result);

                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
