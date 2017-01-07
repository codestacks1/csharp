using Microsoft.Practices.Prism.Mvvm;
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
using System.Windows.Shapes;

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
        }

        private void ViewMap_Click(object sender, RoutedEventArgs e)
        {
            MapWindow map = new MapWindow();
            map.Show();
        }

        private void PlayMidea_Click(object sender, RoutedEventArgs e)
        {
            MideaWindow midea = new MideaWindow();
            midea.Show();
        }

        private void RabbitMq_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
