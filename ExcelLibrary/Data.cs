using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public class Data
    {
        public const int Low = 60;
        public const int Medium = 80;
        public const int Hard = 100;
        public const int TryHard = 150;

        private double _p1;
        private double _p2;
        private double _p3;

        private double _j1;
        private double _j2;
        private double _j3;

        private double _t1;
        private double _t2;
        private double _t3;

        private void Compile(char c)
        {
            switch (c)
            {
                case 'p':
                    {
                        Prised = string.Format("{0}/{1}/{2}", _p1, _p2, _p3);
                        break;
                    }
                case 'j':
                    {
                        Jym = string.Format("{0}/{1}/{2}", _j1, _j2, _j3);
                        break;
                    }
                case 't':
                    {
                        Taga = string.Format("{0}/{1}/{2}", _t1, _t2, _t3);
                        break;
                    }
            }
                
        }

        private void Decompile(char c)
        {
            switch (c)
            {
                case 'p':
                    {
                        if (!string.IsNullOrEmpty(Prised))
                        {
                            string[] mass = Prised.Split('/');

                            _p1 = double.Parse(mass[0]);
                            _p2 = double.Parse(mass[1]);
                            _p3 = double.Parse(mass[2]);
                        }

                        break;
                    }
                case 'j':
                    {
                        if (!string.IsNullOrEmpty(Jym))
                        {
                            string[] mass = Jym.Split('/');

                            _j1 = double.Parse(mass[0]);
                            _j2 = double.Parse(mass[1]);
                            _j3 = double.Parse(mass[2]);

                        }
                        break;
                    }
                case 't':
                    {
                        if (!string.IsNullOrEmpty(Taga))
                        {
                            string[] mass = Taga.Split('/');

                            _t1 = double.Parse(mass[0]);
                            _t2 = double.Parse(mass[1]);
                            _t3 = double.Parse(mass[2]);

                        }
                        break;
                    }
            }
        }

        public double p1 { get { return _p1; } set { _p1 = value; Compile('p'); } }
        public double p2 { get { return _p2; } set { _p2 = value; Compile('p'); } }
        public double p3 { get { return _p3; } set { _p3 = value; Compile('p'); } }

        public double j1 { get { return _j1; } set { _j1 = value; Compile('j'); } }
        public double j2 { get { return _j2; } set { _j2 = value; Compile('j'); } }
        public double j3 { get { return _j3; } set { _j3 = value; Compile('j'); } }

        public double t1 { get { return _t1; } set { _t1 = value; Compile('t'); } }
        public double t2 { get { return _t2; } set { _t2 = value; Compile('t'); } }
        public double t3 { get { return _t3; } set { _t3 = value; Compile('t'); } }


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

        public string Prised { get; set; }
        public string Jym { get; set; }
        public string Alpha { get; set; }   //WHAT THE FUCK??
        public string Taga { get; set; }

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
            Prised = string.Empty;
            Jym = string.Empty;
            Alpha = string.Empty;
            Taga = string.Empty;
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
            result.Add(Trainers);
            //result.Add(Prised);
            result.Add(p1.ToString());
            result.Add(p2.ToString());
            result.Add(p3.ToString());
            result.Add(j1.ToString());
            result.Add(j2.ToString());
            result.Add(j3.ToString());
            result.Add(t1.ToString());
            result.Add(t2.ToString());
            result.Add(t3.ToString());
            //result.Add(Jym);
            //result.Add(Taga);
            result.Add(Alpha);
            result.Add(Summ.ToString());
            result.Add(Place.ToString());
            result.Add(NormFlag.ToString());
            result.Add(Points.ToString());

            return result;
        }

        public void InitEnd()
        {
            Decompile('p');
            Decompile('j');
            Decompile('t');
        }
    }
}
