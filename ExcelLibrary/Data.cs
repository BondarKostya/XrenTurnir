using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public class Data
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Level { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string Assotiation { get; set; }
        public string Club { get; set; }
        public double Weight { get; set; }
        public double kWilis { get; set; }

        public double Prised { get; set; }
        public double Jym { get; set; }
        public string Alpha { get; set; }   //WHAT THE FUCK??
        public double Taga { get; set; }

        public double Summ { get; set; }
        public int Place { get; set; }
        public bool NormFlag { get; set; }
        public double SummKU { get; set; }
        public double Points { get; set; }
        public string Trainers { get; set; }

        public Data()
        {
            Number = 0;
            Name = string.Empty;
            Birthday = string.Empty;
            Level = string.Empty;
            State = string.Empty;
            Sity = string.Empty;
            Assotiation = string.Empty;
            Club = string.Empty;
            Weight = 0;
            kWilis = 0;
            Prised = 0;
            Jym = 0;
            Alpha = string.Empty;
            Taga = 0;
            Summ = 0;
            Place = 0;
            NormFlag = false;
            Points = 0;
            Trainers = string.Empty;
        }

        public List<string> ToStringList()
        {
            List<string> result = new List<string>(20);

            result.Add(Number.ToString());
            result.Add(Name);
            result.Add(Birthday);
            result.Add(Level);
            result.Add(State);
            result.Add(Sity);
            result.Add(Assotiation);
            result.Add(Club);
            result.Add(Weight.ToString());
            result.Add(kWilis.ToString());
            result.Add(Prised.ToString());
            result.Add(Jym.ToString());
            result.Add(Alpha);
            result.Add(Taga.ToString());
            result.Add(Summ.ToString());
            result.Add(Place.ToString());
            result.Add(NormFlag.ToString());
            result.Add(Points.ToString());
            result.Add(Trainers);

            return result;
        }
    }
}
