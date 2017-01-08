using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public delegate void DelFunc();
    //创建接口
    public interface IDefineInterface
    {
        //接口不包含字段、委托、
        string Tag { get; set; }
        //接口方法无实现无访问修饰符
        void FuncA();
        event DelFunc evetFunc;
    }

    //隐式 实现
    //继承接口的类，必须实现接口成员
    public class InheriteInterface : IDefineInterface
    {
        public string Tag
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public event DelFunc evetFunc;
        public void FuncA()
        {
            throw new NotImplementedException();
        }
    }

    //显式 实现接口成员
    public class IExplicit : IDefineInterface
    {
        string IDefineInterface.Tag
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }

        event DelFunc IDefineInterface.evetFunc
        {
            add { throw new NotImplementedException(); }

            remove { throw new NotImplementedException(); }
        }

        void IDefineInterface.FuncA()
        {
            throw new NotImplementedException();
        }
    }
}
