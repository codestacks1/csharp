using System;
using System.Web.Mvc;
using Xiaowen.Personal.SqlDetach;
using Xiaowen.Personal.SqlDetach.Dbo;
using Xiaowen.Web.Mvc.SqlDetachService;

namespace Xiaowen.Web.Mvc.Utilities
{
    public class BaseController : Controller
    {
        private SqlDetachClient client;
        protected SqlDetachClient Client
        {
            get
            {
                if (client == null)
                {
                    client = new SqlDetachClient();
                }
                return client;
            }
            set { client = value; }
        }

        //private DboHandler sqlDetacher;
        //public DboHandler SqlDetacher
        //{
        //    get
        //    {
        //        if (sqlDetacher == null)
        //            sqlDetacher = new DboHandler();
        //        return sqlDetacher;
        //    }
        //    set
        //    {
        //        sqlDetacher = value;
        //    }
        //}
    }
}