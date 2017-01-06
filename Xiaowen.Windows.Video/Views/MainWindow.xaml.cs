using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Xiaowen.Windows.Video.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Loading_Loaded(object sender, RoutedEventArgs e)
        {
            Task task = AnimationLoaded();
        }

        async Task AnimationLoaded()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            //MessageBox.Show("Loaded final");
            HomeWindow home = new HomeWindow();
            this.Close();
            home.Show();
        }
    }
}
