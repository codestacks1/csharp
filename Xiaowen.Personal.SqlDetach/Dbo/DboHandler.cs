using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.Personal.SqlDetach.Dbo
{
    public class DboHandler : SqlDetachBase
    {

        /// <summary>
        /// 执行简单查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="dbName"></param>
        /// <param name="sqlSentence"></param>
        /// <param name="whereParams"></param>
        internal virtual void QuerySimpleSql<T>(XwDoEnum eventFlag, object dbName, XwSqlDetachSimpleHandler sqlSentence, params XwWhereClauseSchema[] whereParams) where T : class, new()
        {
            //承载数据库操作结果
            XwEventArgs e = new XwEventArgs();

            try
            {
                //执行数据库操作Code

                e.Result = null;
            }
            catch (Exception ex)
            {
                e.IsSuccess = false;
                e.IsError = true;
                e.ErrorMsg = ex.Message;
            }
            ExecXwDoWhileEvent(eventFlag, e);
        }

        /// <summary>
        /// 执行哪一个事件
        /// </summary>
        /// <param name="eventFlag"></param>
        private void ExecXwDoWhileEvent(XwDoEnum eventFlag, XwEventArgs e)
        {
            switch (eventFlag)
            {
                case XwDoEnum.XwDoMvcActionResult:
                    this.XwDoMvcActionResult(e);
                    break;
                case XwDoEnum.XwDoMvcContentResult:
                    this.XwDoMvcContentResult(e);
                    break;
                default:
                    break;
            }
        }

    }
}
