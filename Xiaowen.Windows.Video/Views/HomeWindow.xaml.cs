using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xiaowen.Windows.Video.UserControls;
using Xiaowen.Windows.Video.ViewModels;

namespace Xiaowen.Windows.Video.Views
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window, IView
    {
        public HomeWindow()
        {
            InitializeComponent();

            int? i = Task.CurrentId;

            Thread thr = Thread.CurrentThread;

            //thr.Abort();

           // Task.Run(() =>
           //{
           //    TabMap mapComponent = new TabMap();
           //    TabMapViewModel map = new TabMapViewModel();
           //});
        }


    }
}
