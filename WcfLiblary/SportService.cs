using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfLiblary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class SportService : ISportService
    {
        public static event Action<Data> OnNewChampion;
        public static event Action<List<Data>> OnNewQuery;

        public void SetData(Data value)
        {
            OnNewChampion?.Invoke(value);
        }

        public void SetDatas(List<Data> values)
        {
            OnNewQuery?.Invoke(values);
        }
    }
}
