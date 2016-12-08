using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelLibrary
{
    public class Data
    {
        public const int c59 = 59;
        public const int c66 = 66;
        public const int c74 = 74;
        public const int c83 = 83;
        public const int c93 = 93;
        public const int c105 = 105;

        public const int c47 = 47;
        public const int c52 = 52;
        public const int c57 = 57;
        public const int c63 = 63;
        public const int c72 = 72;

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

        public void CalculateSumm()
        {
            double max1;
            double max2;
            double max3;

            max1 = (_p1 > _p2) ? _p1 : _p2;
            max1 = (max1 > _p3) ? max1 : _p3;

            max2 = (_j1 > _j2) ? _j1 : _j2;
            max2 = (max2 > _j3) ? max2 : _j3;

            max3 = (_t1 > _t2) ? _t1 : _t2;
            max3 = (max3 > _t3) ? max3 : _t3;

            this.Summ = max1 + max2 + max3;
        }

        public double p1 { get { return _p1; } set { _p1 = value; CurrentTry = value; } }
        public double p2 { get { return _p2; } set { _p2 = value; CurrentTry = value; } }
        public double p3 { get { return _p3; } set { _p3 = value; CurrentTry = value; } }

        public double j1 { get { return _j1; } set { _j1 = value; CurrentTry = value; } }
        public double j2 { get { return _j2; } set { _j2 = value; CurrentTry = value; } }
        public double j3 { get { return _j3; } set { _j3 = value; CurrentTry = value; } }

        public double t1 { get { return _t1; } set { _t1 = value; CurrentTry = value; } }
        public double t2 { get { return _t2; } set { _t2 = value; CurrentTry = value; } }
        public double t3 { get { return _t3; } set { _t3 = value; CurrentTry = value; } }


        public int Number { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Level { get; set; }
        public string State { get; set; }
        public string Sity { get; set; }
        public string Assotiation { get; set; }
        public string Club { get; set; }
        public string Weight { get; set; }
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

        public double CurrentTry { get; set; }

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
            Weight = string.Empty;
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

        public Data(WcfLiblary.Data data)
        {

            this.Assotiation = data.Assotiation;
            this.Birthday = data.Birthday;
            this.Club = data.Club;
            this.j1 = data.j1;
            this.j2 = data.j2;
            this.j3 = data.j3;
            this.Level = data.Level;
            this.Name = data.Name;
            this.Number = data.Number;
            this.p1 = data.p1;
            this.p2 = data.p2;
            this.p3 = data.p3;
            this.Sity = data.Sity;
            this.State = data.State;
            this.t1 = data.t1;
            this.t2 = data.t2;
            this.t3 = data.t3;
            this.Trainers = data.Trainers;
            this.Weight = data.Weight;

            kWilis = 0;
            Prised = string.Empty;
            Jym = string.Empty;
            Alpha = string.Empty;
            Taga = string.Empty;
            Summ = 0;
            Place = 0;
            NormFlag = false;
            Points = 0;
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
            result.Add(SummKU.ToString());
            result.Add(Points.ToString());

            return result;
        }

        public WcfLiblary.Data ToData()
        {
            WcfLiblary.Data result = new WcfLiblary.Data();

            result.Assotiation = Assotiation;
            result.Birthday = Birthday;
            result.Club = Club;
            result.j1 = j1;
            result.j2 = j2;
            result.j3 = j3;
            result.Level = Level;
            result.Name = Name;
            result.Number = Number;
            result.p1 = p1;
            result.p2 = p2;
            result.p3 = p3;
            result.Sity = Sity;
            result.State = State;
            result.t1 = t1;
            result.t2 = t2;
            result.t3 = t3;
            result.Trainers = Trainers;
            result.Weight = Weight;
            result.CurrentTry = CurrentTry;

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
