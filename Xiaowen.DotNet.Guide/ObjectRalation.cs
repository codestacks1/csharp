using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 对象之间的关系
    /// 1、包含关系
    /// </summary>
    public class ObjectRalation
    {
        private KelvinJanuary kJanuary;
        protected KelvinJanuary Kjanuary
        {
            get
            {
                if (kJanuary == null)
                    kJanuary = new KelvinJanuary();
                return Kjanuary;
            }
        }
        //集合关系
        protected KelvinJanuary[] kJanuarys
        {
            get { return new KelvinJanuary[10]; }
        }
    }
    public class KelvinJanuary { }

}
