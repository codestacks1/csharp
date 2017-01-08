using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xiaowen.DotNet.Guide.OOP;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 创建对象
    /// </summary>
    public class InstantiationClass
    {
        //使用电脑前，需要先将电脑实例化，及创建一个电脑对象
        //这样才能让电脑具有不同的配置和性能
        public void GetComputer()
        {
            Computer thinkPadT640s = new Computer();
            thinkPadT640s.Cpu = 8;//8核
            thinkPadT640s.memory = 8;//8G
            thinkPadT640s.Disk = 256;//256G
            thinkPadT640s.DisplayDevice(123456);//键盘录入123456，显示器显示123456，这是电脑所具有的功能
        }
    }
    

    //面向对象解释
    public class OOP
    {
        //电脑
        public class Computer
        {
            //CPU
            public int Cpu { get; set; }
            //内存
            public int memory { get; set; }
            //磁盘
            public int Disk { get; set; }
            /// <summary>
            /// 电脑有显示的功能
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public int DisplayDevice(int i)
            {
                return i;
            }
        }
    }
}
