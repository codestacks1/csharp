using System;

namespace Xiaowen.DotNet.Guide
{
    /// <summary>
    /// class 前面的关键字被称为访问修饰符
    /// 1、public 公共的
    /// 2、protected 受保护的类，只有子类可访问
    /// 3、private 私有的
    /// 4、internal 程序集内可访问
    /// 5、sealed 不允许被继承
    /// </summary>
    public class Program
    {
        //Main方法是整个软件程序的入口
        static void Main(string[] args)
        {
            Variance.A a = new Variance.A();
            a.NumA = 1;

            Variance.B b = new Variance.B();
            b.NumA = 2;
            b.NumB = 3;

            Variance.A aa = new Variance.A();
            aa.NumA = 4;

            a = b;
            int _a = a.NumA;

            b = aa as Variance.B;// b = nulls
            int _b = b.NumA;//这里b为空
        }

        public static void TestMain()
        {
            //激活并触发事件
            new SystemEvent().EventTrigger();
            return;

            EventIntroduction e = new EventIntroduction();
            RegistedEvent r = new RegistedEvent(e);
            e.TrigEvent(e);

            //值类型
            int x = 42;
            //引用类型
            string str = "hello world";
            Console.WriteLine("值类型：{0} \n\t 引用类型：{1}",
                x, str);
        }

        private static void E_EventSelf(object send, EventArgs args)
        {
            if (send is Program)
            {
                //DataColumn dc = new DataColumn("id");
                //DataTable dt = new DataTable();
                //dt.Rows;

                //dt.BeginLoadData();
                //foreach (DataRow item in dt.Rows)
                //{
                //    string s = item[dc].ToString();
                //    item[dc] = "";
                //}

                //DataRow dr = DataRow[dc];


                StringGetter<int> sg = new StringGetter<int>();
                sg.GetString<Program>(1);
            }
        }
    }

    public class Instantiator<T> where T : new()
    {
        public T instance;
        public Instantiator()
        {
            instance = new T();
        }
    }


    public class StringGetter<T>
    {
        public B GetString<B>(T item) where B : new()
        {
            return new B();
        }
    }


    public interface IMethaneProducer<out T>
    {
        T MyProperty { get; }
        T Func();

        //void BelchAt(T target);//error 
    }


}
