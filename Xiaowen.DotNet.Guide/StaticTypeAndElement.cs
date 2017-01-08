using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 注意静态类中 其成员也必须是静态的
    /// </summary>
    public static class StaticTypeAndElement
    {
        private static string tag;
        public static string Tag { get; set; }
        public static void FuncA() { }
        public delegate void DelFunc();
        public static event DelFunc EventFunc;
        public class StaticA { }
        public interface StaticInfA { }
    }
}
