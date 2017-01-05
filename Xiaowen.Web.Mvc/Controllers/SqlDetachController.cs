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
        //private SqlDetachBaseClient sqlDetachBaseClient;
        private SqlDetachClient client;
        static RequestContext request = null;

        /// <summary>
        /// http 不能使用异步，只能通过ajax来实现
        /// </summary>
        //public async void General()
        //{
        //    sqlDetachBaseClient = new SqlDetachBaseClient();
        //    await Task.Run(() => sqlDetachBaseClient.GetSqlDetachBaseAsync());

        //    sqlDetachBaseClient.GetSqlDetachBaseCompleted += SqlDetachBaseClient_GetSqlDetachBaseCompleted;
        //}

        //private void SqlDetachBaseClient_GetSqlDetachBaseCompleted(object sender, GetSqlDetachBaseCompletedEventArgs e)
        //{
        //}

        // GET: SqlDetach
        public ActionResult Index(Nullable<int> id)
        {
            Nullable<bool> b = null;
            if (b == true)
            {
                string s = "";
            }

            if (b==false)
            {

            }

            return View();

            client = new SqlDetachClient();

            SqlDetacher.XwMvcActionEvent += SqlDetachBase_Index;

            ArrayList whereParams = new ArrayList();
            whereParams.Add(new XwWhereClauseSchema("id", 1));

            try
            {
                Task.Run(() => client.QueryAuthorAsync(XwDoEnum.XwDoMvcActionResult, SqlDetacher, whereParams.Cast<XwWhereClauseSchema>().ToArray()));

                //client.QueryAuthor(XwDoEnum.XwDoMvcActionResult, SqlDetacher, whereParams.Cast<XwWhereClauseSchema>().ToArray());//activeevent
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            return View();
        }

        private ActionResult SqlDetachBase_Index(object sender, XwEventArgs e)
        {
            SqlDetacher.XwMvcActionEvent -= SqlDetachBase_Index;
            object model = null;
            if (e.IsSuccess)
            {
                if (e.Result != null)
                {
                    model = e.Result;
                }
                else
                    model = new ArrayList { 1, 2, 3, 4590, 345, 6, 7, 9, 8, "axing" };
            }
            else if (e.IsError)
            {
                string err = e.ErrorMsg;
            }
            return View(model);
        }
    }
}