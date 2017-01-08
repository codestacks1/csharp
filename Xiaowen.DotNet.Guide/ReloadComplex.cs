using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class ReloadComplex
    {
        public ReloadComplex()
        {
        }
        public ReloadComplex(ReloadComplex c1, ReloadComplex c2)
        {
            this.C1 = c1;
            this.C2 = c2;
        }

        private ReloadComplex C1 { get; set; }
        private ReloadComplex C2 { get; set; }

        public ReloadComplex Res
        {
            get
            {
                return C1;
            }
        }

        /// <summary>
        /// 重载“+”二元运算符
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static ReloadComplex operator +(ReloadComplex c1, ReloadComplex c2)
        {
            return new ReloadComplex();
        }
        public static ReloadComplex operator -(ReloadComplex c1, ReloadComplex c2)
        {
            return new ReloadComplex();
        }

        public override string ToString()
        {
            return (string.Format("这两个类型的数据我没有处理，请耐心等待后续处理..."));
        }
    }

    public class S : ReloadComplex
    {
        public int Weight { get; set; }
    }
    public class H : ReloadComplex
    {
        public int Weight { get; set; }
    }

    public class OperatorClass
    {
        public void Sum()
        {
            S s = new S();
            H h = new H();
            ReloadComplex r = s + h;//运算符重载
            ReloadComplex rc = s - h;
        }
    }
}
