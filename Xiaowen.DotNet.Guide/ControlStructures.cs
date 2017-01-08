using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 流程控制演示类
    /// ControlStructures是类名
    /// </summary>
    public class ControlStructures
    {
        /// <summary>
        /// if else 语句
        /// </summary>
        public void IfControl(int inputNumber)
        {
            int i = 10;
            if (i == inputNumber)
            {
                Console.WriteLine(i);
            }
            else if (i < inputNumber)
            {
                Console.WriteLine(inputNumber);
            }
            else
            {
                Console.WriteLine("i>inputNumber");
            }
        }

        /// <summary>
        /// switch语句
        /// 注意返回值不可写在case块里,否则break将失效
        /// </summary>
        /// <param name="value"></param>
        public int SwitchControl(int value)
        {
            int res = -1;
            switch (value)
            {
                case 1:
                    res = 1;
                    break;
                case 2:
                    res = 2;
                    break;
                case 3:
                    res = 3;
                    break;
                default:
                    break;
            }
            return res;
        }

        /// <summary>
        /// for循环
        /// </summary>
        public void ForLoopControl()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i);
            }
        }


        /// <summary>
        /// do循环
        /// </summary>
        public void DoLoopControl()
        {
            int i = 0;
            do
            {
                ++i;
            } while (i > 10);//当i>10的时候跳出循环
        }


        /// <summary>
        /// while循环
        /// </summary>
        public void WhileLoopControl()
        {
            int i = 10;
            while (i >= 10)
            {
                if (i == 10)
                    ++i;    //在这里会继续执行循环
                else
                    i = i - 2;//在这里不再执行循环
            }
        }

        /// <summary>
        /// foreach循环
        /// </summary>
        public void ForeachLoopControl()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add("one");
            arrayList.Add("two");

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
