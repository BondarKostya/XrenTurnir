using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLiblary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface ISportService
    {
        [OperationContract]
        void SetData(Data value);
        
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfLiblary.ContractType".
    [DataContract]
    public class Data
    {        
        private double _p1;
        private double _p2;
        private double _p3;

        private double _j1;
        private double _j2;
        private double _j3;

        private double _t1;
        private double _t2;
        private double _t3;
        
        [DataMember]
        public double p1 { get { return _p1; } set { _p1 = value; } }
        [DataMember]
        public double p2 { get { return _p2; } set { _p2 = value; } }
        [DataMember]
        public double p3 { get { return _p3; } set { _p3 = value; } }

        [DataMember]
        public double j1 { get { return _j1; } set { _j1 = value; } }
        [DataMember]
        public double j2 { get { return _j2; } set { _j2 = value; } }
        [DataMember]
        public double j3 { get { return _j3; } set { _j3 = value; } }

        [DataMember]
        public double t1 { get { return _t1; } set { _t1 = value; } }
        [DataMember]
        public double t2 { get { return _t2; } set { _t2 = value; } }
        [DataMember]
        public double t3 { get { return _t3; } set { _t3 = value; } }

        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Birthday { get; set; }
        [DataMember]
        public string Level { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Sity { get; set; }
        [DataMember]
        public string Assotiation { get; set; }
        [DataMember]
        public string Club { get; set; }
        [DataMember]
        public string Weight { get; set; }
        
        [DataMember]
        public string Trainers { get; set; }
    }
}
