using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DBService.Helper;
using ERP.DBUlitity.Helper;

namespace ERP.DBService.Service
{
    public abstract class BaseService<T> : EntityHelper<T>
    {
        IDataMgr _dataMgr = new DataMgrHelper();
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="entity"></param>
        public abstract void Add(T entity);

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool Del(T entity);

        /// <summary>
        /// 删除指定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract bool Del(int id);

        /// <summary>
        /// 更新指定数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract bool Update(T entity);

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public abstract bool Add(List<T> entities);

        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract T GetEntity(string condition);

        /// <summary>
        /// 根据条件获取多条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public abstract List<T> GetEntities(string condition);

        /// <summary>
        /// 对象转换
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public abstract T DoConvertToEntity(System.Data.DataRow row);

        public override T ConvertToEntity(System.Data.DataRow row)
        {
            return DoConvertToEntity(row);
        }
    }
}
