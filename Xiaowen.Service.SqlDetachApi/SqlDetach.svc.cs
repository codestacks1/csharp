using System;
using System.Collections;
using Xiaowen.Personal.SqlDetach;
using Xiaowen.Personal.SqlDetach.Dbo;
using Xiaowen.Service.SqlDetachApi.Basic;

namespace Xiaowen.Service.SqlDetachApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SqlDetach : ISqlDetach, ISqlDetachBase
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetSqlDetachBase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xwDoWhileEvent"></param>
        /// <param name="sender"></param>
        /// <param name="whereParams"></param>
        public void QueryAuthor(XwDoEnum xwDoWhileEvent, DboHandler sender, params XwWhereClauseSchema[] whereParams)
        {
            Personal.SqlDetach.BusinessCode.Demo bll = new Personal.SqlDetach.BusinessCode.Demo(sender);
            bll.QueryAutor(xwDoWhileEvent, whereParams);
        }
    }
}
