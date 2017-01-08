using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 公开类型，所有类型均可访问到该类
    /// </summary>
    public class Modifier
    {
        /// <summary>
        /// 私有的类型
        /// </summary>
        private class X { }

        /// <summary>
        /// 受保护的类型
        /// </summary>
        protected class Y { }

        /// <summary>
        /// 程序集内可访问的类
        /// </summary>
        internal class Z
        {
            M m = new M();
            M.ZZ zz = new M.ZZ();
            string str = new M.ZZ().Attr;
        }

        /// <summary>
        /// 不能被继承的类型
        /// </summary>
       public sealed class M
        {
            public class ZZ
            {
                public string Attr { get; set; }
            }
        }
    }
}
