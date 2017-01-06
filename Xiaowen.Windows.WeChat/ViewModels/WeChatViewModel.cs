using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wechat = Xiaowen.Windows.WeChat.Model;

namespace Xiaowen.Windows.WeChat.ViewModels
{
    public class WeChatViewModel : BindableBase
    {
        private Wechat.Message message;
        public Wechat.Message Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public ICommand SendCommand { get; private set; }

        public WeChatViewModel()
        {
            this.Message = new Wechat.Message();

            this.SendCommand = new DelegateCommand<object>(OnSendCommand);
        }

        private void OnSendCommand(object obj)
        {
            MessageBox.Show(Message.Content);
        }
    }
}
