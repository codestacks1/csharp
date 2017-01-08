using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class TypeAndElement//类
    {
        //类成员

        private string tag;//字段
        public string Tag//属性
        {
            get { return tag; }
            set { tag = value; }
        }
        public void FuncA() { }//方法
        public delegate void DelFunc();//委托
        public event DelFunc EventFunc;//事件
        public void FuncB()
        {
            EventFunc += FuncA;
        }
    }
}
