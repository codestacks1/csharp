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

namespace Xiaowen.Windows.Video.Views
{
    /// <summary>
    /// Interaction logic for VideoView.xaml
    /// </summary>
    public partial class VideoView : UserControl
    {
        public VideoView()
        {
            InitializeComponent();
            ////string path = AppDomain.CurrentDomain.BaseDirectory;
            ////string path1 = Application.ResourceAssembly.Location;
            ////string path2 = Environment.CurrentDirectory;
            ////path2 += "\\midea\\Robotica_720.wmv";
            ////MyMidea.Source = new Uri(path, UriKind.Relative);
        }

        private void MyMidea_MediaOpened(object sender, RoutedEventArgs e)
        {
            //TimelineSlider.Maximum = MyMidea.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void MyMidea_MediaEnded(object sender, RoutedEventArgs e)
        {
            MyMidea.Stop();
        }


        private void PlayMidea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("/img/pause.png", UriKind.Relative);
            bi.EndInit();
            PlayMidea.Source = bi;

            MyMidea.Play();
            InitPropertyValues();
        }

        private void PauseMidea_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void StopMidea_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ReplayMidea_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void InitPropertyValues()
        {
            MyMidea.Volume = (double)VolumnSilder.Value;
            MyMidea.SpeedRatio = (double)SpeedRatioSlider.Value;
        }

        private void VolumnSilder_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SpeedRatioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
