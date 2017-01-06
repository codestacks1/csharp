
using Microsoft.Practices.Prism.Mvvm;
using System.Windows;

namespace Xiaowen.Windows.WeChat.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// 要在前段使用.AutoWireViewModel="True"必须在codebehind中继承IView Interface
    /// IView Interface from Prism.Wpf.Prism.Mvvm
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
