using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DataType;

namespace Plugin.PL.Interface.BLService
{
    public interface ISimpleBlService
    {
        void AddSimpleData(SimpeEntity simpleData);
        void AddSimpleDatas(IEnumerable<SimpeEntity> simpleDatas);
        void DeleteSimpleData(SimpeEntity simpleData);
        void EditSimpleData(SimpeEntity simpleData);
        IEnumerable<SimpeEntity> GetSimpleDatas();
    }
}
