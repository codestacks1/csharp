using System.Windows;
using System.Windows.Controls;
using pages = Xiaowen.Windows.Video.Pages;
using Xiaowen.Windows.Video.Views;

namespace Xiaowen.Windows.Video.UserControls
{
    /// <summary>
    /// Interaction logic for HomeTab.xaml
    /// </summary>
    public partial class TabHome : UserControl
    {
        public TabHome()
        {
            InitializeComponent();
        }

        private void ViewMap_Click(object sender, RoutedEventArgs e)
        {
            MapWindow map = new MapWindow();
            map.Show();
        }

        private void PlayMidea_Click(object sender, RoutedEventArgs e)
        {
            pages.MideaPage media = new Pages.MideaPage();
            

        }

        private void RabbitMq_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
