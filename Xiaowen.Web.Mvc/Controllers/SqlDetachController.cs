using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Xiaowen.Personal.SqlDetach;
using Xiaowen.Service.SqlDetachApi;
using Xiaowen.Web.Mvc.SqlDetachService;
using Xiaowen.Web.Mvc.Utilities;

namespace Xiaowen.Web.Mvc.Controllers
{
    public class SqlDetachController : BaseController
    {
        // GET: SqlDetach
        public ActionResult Index(Nullable<int> id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return View();
        }
    }
}