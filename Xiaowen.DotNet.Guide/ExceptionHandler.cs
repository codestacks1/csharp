using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class ExceptionHandler
    {
        /// <summary>
        /// 该方法演示使用try...catch处理异常代码块
        /// </summary>
        public void ResolveException()
        {
            string str = "exception";
            try
            {
                //非数字字符串在转换成int类型时会发生异常，
                //因此使用try...catch抓取该异常
                //这样不会导致程序中断或退出（死掉）
                int i = Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ResolveException函数发生异常：{0}", ex.Message);
            }
        }


        /// <summary>
        /// 增加了finally的错误处理方式
        /// </summary>
        /// <returns></returns>
        public int ResolveException(int i)
        {
            string str = "exception";
            try
            {
                //非数字字符串在转换成int类型时会发生异常，
                //因此使用try...catch抓取该异常
                //这样不会导致程序中断或退出（死掉）
                i = Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ResolveException函数发生异常：{0}", ex.Message);
            }
            finally
            {
                i = 100;//finally中的代码始终会被执行
            }
            return i;
        }
    }
}
