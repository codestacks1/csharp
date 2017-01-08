using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xiaowen.DotNet.Guide
{
    public class SystemEvent
    {
        //索引器
        //get,set访问器
        public SystemEvent this[int i]
        {
            get
            {
                return new SystemEvent();
            }
            set
            {

            }
        }
        public event EventHandler myEvent;
        public SystemEvent()
        {
            myEvent += SystemEvent_myEvent;
        }

        public void EventTrigger()
        {
            this.SystemEvent_myEvent(this, EventArgs.Empty);
        }

        private void SystemEvent_myEvent(object sender, EventArgs e)
        {
            Console.WriteLine("你触发了事件哦！嘻嘻");
            Console.Read();
        }
    }
}
