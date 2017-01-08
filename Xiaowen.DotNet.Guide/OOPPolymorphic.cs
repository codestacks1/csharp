using System;
using System.IO;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// 面向对象的特性之一：多态
    /// </summary>
    public class OOPPolymorphic
    {
        public virtual void FuncA() { }

        public virtual void FuncB() { }
    }


    public class A : OOPPolymorphic
    {
        public override void FuncA()
        {
            base.FuncA();
        }

        public override void FuncB()
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine("对象的多态性");
        }
    }

    public class B : A
    {
        public override void FuncB()
        {
            base.FuncB();
        }
    }


    //=======================================

    public class BaseType
    {
        private string tag;
        public string Tag { get; set; }

        public void FuncA() { }
    }

    public class InheritBaseType : BaseType { }

    public class InheritBaseType2 : BaseType { }

    public class CommonType
    {
        public void FuncA()
        {
            InheritBaseType inheritObj = new InheritBaseType();
            InheritBaseType2 inheritObj2 = new InheritBaseType2();
            BaseType bt = inheritObj;//不需要强制转换 多态性
            bt = inheritObj2;//多态
        }
    }

    //=========================================

    //接口的多态性
    public interface IKelvinInterface
    {
        void FuncA();
    }

    public class KelvinImpl : IKelvinInterface
    {
        public void FuncA()
        {
            throw new NotImplementedException();
        }
    }

    public class Kelvin
    {
        public void FuncA()
        {
            IKelvinInterface iKelvin = null;
            KelvinImpl kelvin = new KelvinImpl();
            iKelvin = kelvin;//多态  kelvin被赋予了接口类型的变量
            iKelvin.FuncA();
        }
    }

}
