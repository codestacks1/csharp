using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class FunctionForCSharp
    {
        /// <summary>
        /// 无参数 无返回值的函数/方法
        /// </summary>
        public void FuncNoValue()
        {
            //功能代码块
        }

        /// <summary>
        /// 有参数 无返回值的函数/方法
        /// </summary>
        /// <param name="i"></param>
        public void FuncHasParameter(int i)
        {
            //方法实现
        }

        /// <summary>
        /// 有多个参数 无返回值的函数/方法
        /// 因与上面的方法重名，故也被称为方法的重载
        /// </summary>
        /// <param name="i"></param>
        /// <param name="str"></param>
        public void FuncHasParameter(int i, string str)
        {
            //code
        }

        /// <summary>
        /// 无参数 有返回值的函数/方法
        /// </summary>
        /// <returns>返回值类型为 int 类型</returns>
        public int FuncHasReturnValue()
        {
            return 100;
        }

        /// <summary>
        /// 有参数 有返回值的函数/方法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string FuncHasParamAndReValue(int i)
        {
            return i.ToString();
        }

        //委托 委托无参返回int类型数据的方法
        public delegate int FuncDel();

        /// <summary>
        /// 被委托的方法 返回int类型数据的无参函数
        /// </summary>
        /// <returns></returns>
        public int FuncForDelegate()
        {
            return 1;
        }

        /// <summary>
        /// 使用委托的无返回值的函数
        /// </summary>
        /// <param name="del">委托类型参数</param>
        public void FuncFromDelegate(FuncDel del)
        {

        }
    }
}
