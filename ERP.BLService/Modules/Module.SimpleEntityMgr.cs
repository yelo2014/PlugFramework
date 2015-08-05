using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.PL.Interface.BLService;

namespace ERP.BLService
{
    public partial class Module : ISimpleBlService
	{
        public void AddSimpleData(DataType.SimpeEntity simpleData)
        {
            throw new NotImplementedException();
        }

        public void AddSimpleDatas(IEnumerable<DataType.SimpeEntity> simpleDatas)
        {
            throw new NotImplementedException();
        }

        public void DeleteSimpleData(DataType.SimpeEntity simpleData)
        {
            throw new NotImplementedException();
        }

        public void EditSimpleData(DataType.SimpeEntity simpleData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataType.SimpeEntity> GetSimpleDatas()
        {
            throw new NotImplementedException();
        }
    }
}
