using System.Windows;

namespace Xiaowen.Windows.Video.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private void launchAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowAnimation();
        }

        async void ShowAnimation()
        {
            await launchAnimation.LanuchAnimation(this);
        }
    }
}
