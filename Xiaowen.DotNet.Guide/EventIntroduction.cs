using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public delegate void EventDel(object send, ChangeArgs args);
    public class ChangeArgs
    {
        public static readonly ChangeArgs Empty = new ChangeArgs();
        public ChangeArgs() { }
        public static ChangeArgs WriteLine
        {
            get { return new ChangeArgs(); }
        }
        public int Count { get; set; }
    }

    public class EventIntroduction
    {
        public event EventDel changed;//事件必须在类里定义
        protected virtual void OnChanged(ChangeArgs args)
        {
            changed?.Invoke(this, args);//这个表达式可以下称下面的形式
            //if (changed != null)
            //{
            //    changed(this, args);//当前类的对象触发了事件
            //}
        }
        public void TrigEvent(object o)
        {
            Console.WriteLine("触发事件");
            ChangeArgs arg = new ChangeArgs();
            arg.Count = 100;
            OnChanged(arg);
        }
    }


    public class RegistedEvent
    {
        public RegistedEvent(EventIntroduction ei)
        {
            ei.changed += E_change;
        }
        private void E_change(object send, ChangeArgs args)
        {
            Console.WriteLine("Hello World");
            Console.Read();
        }
    }
}
