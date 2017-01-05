using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xiaowen.Personal.SqlDetach.Dbo;
using Xiaowen.Personal.SqlDetach.Entity;

namespace Xiaowen.Personal.SqlDetach.BusinessCode
{
    public class Demo
    {
        private DboHandler sqlDetacher;
        public Demo(DboHandler sqlDetacher)
        {
            this.sqlDetacher = sqlDetacher;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xwDoWhileEvent">使用那个事件处理</param>
        /// <param name="sender">订阅者</param>
        /// <param name="whereParams">where条件及内容</param>
        public void QueryAutor(XwDoEnum xwDoWhileEvent, params XwWhereClauseSchema[] whereParams)
        {
            XwSqlDetachSimpleHandler sqlSentence = SQL.Sql01.DemoQueryFirst;
            this.sqlDetacher.QuerySimpleSql<Author>(XwDoEnum.XwDoMvcActionResult, dbName: null, sqlSentence: sqlSentence, whereParams: whereParams);
        }
    }
}
