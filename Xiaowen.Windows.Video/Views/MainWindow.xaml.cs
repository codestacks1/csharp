using System.Windows;

namespace Xiaowen.Windows.Video.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void launchAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            launchAnimation.LanuchAnimation(this);
        }
    }
}
