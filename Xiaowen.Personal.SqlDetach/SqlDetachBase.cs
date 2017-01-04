using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Xiaowen.Personal.SqlDetach
{
    /// <summary>
    /// author:xiaowen
    /// </summary>
    public class SqlDetachBase
    {
        /// <summary>
        /// for ActionResult
        /// </summary>
        public event XwMvcActionHandler<ActionResult> XwMvcActionEvent;

        /// <summary>
        /// for ContentResult
        /// </summary>
        public event XwMvcContentHandler<ContentResult> XwMvcContentEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void XwDoMvcActionResult(object sender, XwEventArgs e)
        {
            XwMvcActionEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void XwDoMvcActionResult(XwEventArgs e)
        {
            XwMvcActionEvent?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void XwDoMvcContentResult(object sender, XwEventArgs e)
        {
            XwMvcContentEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void XwDoMvcContentResult(XwEventArgs e)
        {
            XwMvcContentEvent?.Invoke(this, e);
        }
    }
}
