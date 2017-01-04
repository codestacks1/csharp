using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xiaowen.Office.Excel;

namespace Xiaowen.Web.Mvc.Controllers
{
    public class OfficeController : Controller
    {
        // GET: Office
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult Export()
        {
            MvcApplication mvc = new MvcApplication();
            string str1 = AppDomain.CurrentDomain.RelativeSearchPath;
            string str2 = AppDomain.CurrentDomain.BaseDirectory;

            string path = Environment.CurrentDirectory;

            ExcelExport excel = new ExcelExport();
            excel.Export(path);

            var model = "str";
            return Content(model);
        }
    }
}