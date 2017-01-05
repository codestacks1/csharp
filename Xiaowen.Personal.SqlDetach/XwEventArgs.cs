using System;
using System.Collections;
using System.Text;

namespace Xiaowen.Personal.SqlDetach
{
    /// <summary>
    /// author: xiaowen
    /// </summary>
    /// <typeparam name="ActionResult"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate ActionResult XwMvcActionHandler<out ActionResult>(object sender, XwEventArgs e);

    /// <summary>
    /// author: xiaowen
    /// </summary>
    /// <typeparam name="ContentResult"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate ContentResult XwMvcContentHandler<out ContentResult>(object sender, XwEventArgs e);

    /// <summary>
    /// author: xiaowen
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="dataParameter"></param>
    /// <param name="where"></param>
    /// <returns></returns>
    public delegate StringBuilder XwSqlDetachSimpleHandler(ref XwSqlSimpleSchema sql, ref ArrayList dataParameter, params XwWhereClauseSchema[] where);

    /// <summary>
    /// author: xiaowen
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="dataParameter"></param>
    /// <param name="where"></param>
    /// <returns></returns>
    public delegate StringBuilder XwSqlDetachComplexHandler(ref XwSqlComplexSchema sql, ref ArrayList dataParameter, params XwWhereClauseSchema[] where);

    /// <summary>
    /// author: xiaowen
    /// </summary>
    public class XwEventArgs : EventArgs
    {
        private bool isSuccess = true;
        private bool isError = false;
        public bool IsSuccess { get { return isSuccess; } set { isSuccess = value; } }

        public bool IsError { get { return isError; } set { isError = value; } }

        public string ErrorMsg { get; set; }

        public object Result { get; set; }
    }
}
