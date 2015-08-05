using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.DBService.Helper
{
    public abstract class EntityHelper<T>
    {
        /// <summary>
        /// 将从数据库中取到的数据转成实体
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public abstract T ConvertToEntity(DataRow row);
    }
}
