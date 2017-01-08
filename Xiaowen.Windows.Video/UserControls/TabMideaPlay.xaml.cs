using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Xiaowen.Windows.Video.UserControls
{
    /// <summary>
    /// Interaction logic for MideaPlayTab.xaml
    /// </summary>
    public partial class TabMideaPlay : UserControl
    {
        public TabMideaPlay()
        {
            InitializeComponent();
        }

        private void myMideaElement_MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                timelineSlider.Maximum = myMideaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
            catch (Exception)
            {

            }
        }

        private void myMideaElement_MediaEnded(object sender, System.Windows.RoutedEventArgs e)
        {
            myMideaElement.Stop();

            replayBtn.Visibility = System.Windows.Visibility.Visible;
        }

        private void playBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myMideaElement.Play();

            this.ChangeMideaBtnImage(sender, "/Xiaowen.Windows.Video;component/img/01mediapause.png");

            playBtn.MouseDown -= playBtn_MouseDown;
            playBtn.MouseDown += pauseBtn_MouseDown;

            this.InitPropertyValues();

        }

        private void replayBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            replayBtn.Visibility = System.Windows.Visibility.Collapsed;
            myMideaElement.Play();
        }

        private void pauseBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myMideaElement.Pause();

            this.ChangeMideaBtnImage(sender, "/Xiaowen.Windows.Video;component/img/01mediaplay.png");

            playBtn.MouseDown -= pauseBtn_MouseDown;
            playBtn.MouseDown += playBtn_MouseDown;
        }

        private void stopBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myMideaElement.Stop();
        }

        private void ChangeMediaVolume(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            myMideaElement.Volume = (double)volumeSlider.Value;
        }

        private void ChangeMediaSpeedRatio(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            myMideaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void SeekToMediaPosition(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValue = (int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMideaElement.Position = ts;
        }

        /// <summary>
        /// 初始化播放属性 
        /// </summary>
        void InitPropertyValues()
        {
            myMideaElement.Volume = (double)volumeSlider.Value;
            myMideaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }


        void ChangeMideaBtnImage(object btn, string uri)
        {
            var imgSource = new BitmapImage();
            imgSource.BeginInit();
            imgSource.UriSource = new Uri(uri, UriKind.Relative);
            imgSource.EndInit();
            ((Image)btn).Source = imgSource;
        }


    }
}
