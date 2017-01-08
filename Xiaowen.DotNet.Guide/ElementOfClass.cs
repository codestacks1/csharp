using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class ElementOfClass
    {
        public string tag;
        private ElementOfClass() : this("") { }

        public ElementOfClass(string str) { }

        public void Func()
        {
            ElementOfClass s = new ElementOfClass();
            //实际使用的是第二个构造函数
        }
    }
    
    public class MyClass
    {
        ElementOfClass cl = new ElementOfClass("wer");
    }
}
