using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ERP.DBService
{
    public interface IDataMgr
    {
        /// <summary>
        /// 执行SQL查询
        /// </summary>
        /// <param name="strCmd"></param>
        DataTable Query(string strCmd);
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="strCmd"></param>
        bool Execute(string strCmd);
        /// <summary>
        /// 执行S多条QL事务
        /// </summary>
        /// <param name="strCmd"></param>
        bool Execute(List<string> strCmd);

        /// <summary>
        /// 开启数据库连接
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        void CloseConnection();
    }
}
