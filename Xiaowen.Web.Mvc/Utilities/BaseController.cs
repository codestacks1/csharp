using System;
using System.Web.Mvc;
using Xiaowen.Personal.SqlDetach;
using Xiaowen.Personal.SqlDetach.Dbo;

namespace Xiaowen.Web.Mvc.Utilities
{
    public class BaseController : Controller
    {
        private DboHandler sqlDetacher;
        public DboHandler SqlDetacher
        {
            get
            {
                if (sqlDetacher == null)
                    sqlDetacher = new DboHandler();
                return sqlDetacher;
            }
            set
            {
                sqlDetacher = value;
            }
        }
    }
}