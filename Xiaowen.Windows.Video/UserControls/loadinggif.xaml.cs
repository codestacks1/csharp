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
    /// Interaction logic for loadinggif.xaml
    /// </summary>
    public partial class LoadingGif : UserControl
    {
        private BitmapImage image;
        public LoadingGif()
        {
            InitializeComponent();
            image = new BitmapImage(new Uri("/Xiaowen.Windows.Video;component/img/launch.gif", UriKind.Relative));
        }

        public async void LanuchAnimation(object obj)
        {
            await this.InitAsyncData();
            ((Window)obj).Close();
        }

        private async Task InitAsyncData()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            //等待3秒gif动画播放完，加载主页面
            HomeWindow home = new HomeWindow();
            home.Show();
        }
    }
}
