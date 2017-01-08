using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xiaowen.Windows.Video.Views;

namespace Xiaowen.Windows.Video.UserControls
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// 
    /// 启动动画
    /// </summary>
    public partial class Loading : UserControl
    {
        public Loading()
        {
            InitializeComponent();
        }

        public async void LanuchAnimation(object obj)
        {
            await this.LaodedStartAnimation();
            ((Window)obj).Close();
        }

        async Task LaodedStartAnimation()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            //MessageBox.Show("Loaded final");
            HomeWindow home = new HomeWindow();
            home.Show();
        }
    }
}
