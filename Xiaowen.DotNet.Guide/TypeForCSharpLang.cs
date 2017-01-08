using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// C#中的常用基本类型
    /// </summary>
    public class TypeForCSharpLang
    {
        public void DataTypeForCSharp()
        {
            //C#基本值类型
            int i = 1000000001;
            long _long = 1000000000000000001;
            bool _bool = true;//true或false
            short _short = 1;
            double _double = 1.0101;//或1.0101
            float _float = 1.0f;
            byte _byte = 255;//0-255
            decimal myMoney = 9.999m;//金钱类型

            //C#引用类型
            string str = "引用类型";
            int[] _array = new int[] { 1, 2, 3, 4, 5, 6 };
            ControlStructures obj = new ControlStructures();
            Console.WriteLine(
                "int:{0}" + "long:{1}" + "bool:{2}"
                + "short:{3}" + "double:{4}" + "float:{5}"
                + "byte:{6}" + "decimal:{7}" + "str:{8}"
                + "int[]:{9}",
                i, _long, _bool, _short, _double, _float, _byte, myMoney, str, _array);
        }


        /// <summary>
        /// 数据类型转换
        /// </summary>
        public void ConvertToDataType()
        {
            int i = 1;
            string str = i.ToString();
            string str2 = Convert.ToString(i);
            byte by = Convert.ToByte(i);

            double num1 = 1.0001;
            int num2 = (int)num1;//强制转换
            string num3 = num1.ToString();

            //隐式转换
            int x = 42;
            double y = x;

            //显示转换
            double _y = 1.111;
            int _x = (int)_y;
        }
    }

}
