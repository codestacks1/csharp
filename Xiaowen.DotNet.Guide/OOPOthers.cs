using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    using NyNameSpaceAlias = MyRootNameSpace.MyNodeBNameSpace;

    public class OOPOthers
    {
        public int Func(NyNameSpaceAlias.MyFirstClasss sf)
        {
            global::Xiaowen.DotNet.Guide.MyRootNameSpace.MyNodeANameSpace.MyFirstClass s = new MyRootNameSpace.MyNodeANameSpace.MyFirstClass();

            NyNameSpaceAlias.MyFirstClasss mf = new NyNameSpaceAlias.MyFirstClasss();

            NyNameSpaceAlias::MyFirstClasss ss = new NyNameSpaceAlias.MyFirstClasss();


            try
            {
                return 1;
            }
            catch (Exception)
            {
                return 2;
                throw;
            }
            finally
            {
                int i = 3;
                //return i;//error 不可以使用return
            }
        }
    }

    namespace MyRootNameSpace
    {
        namespace MyNodeANameSpace
        {
            public class MyFirstClass
            {

            }
        }

        namespace MyNodeBNameSpace
        {
            public class MyFirstClasss
            {
                public void FuncB()
                {
                    try
                    {

                    }
                    catch (MyException myex)
                    {
                        string msg = myex.Message;
                        throw;
                    }
                }
            }
        }
    }

    public class MyException : Exception
    {
        private NyNameSpaceAlias.MyFirstClasss mf;

        public NyNameSpaceAlias.MyFirstClasss Mf
        {
            get
            {
                return mf;
            }
        }

        public MyException(NyNameSpaceAlias.MyFirstClasss source) :
            base("There are only 52 cards in the desk.")
        {
            mf = source;
        }
    }


    #region Event

    public delegate void AddNumber(object sender, MyEventArgs e);

    public class MyEvent
    {
        //事件
        /*
         首先需要订阅事件,即订阅事件需要提供代码
         */

        public event AddNumber AddNumEvent;




        public void UsedEvent()
        {
            AddNumEvent += MyEvent_AddNumEvent;
        }

        private void MyEvent_AddNumEvent(object sender, MyEventArgs e)
        {
            Console.Write("actived event");
            Console.Read();
        }
    }



    public class MyEventArgs
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public List<string> DataSet { get; set; }
    }

    #endregion
}
