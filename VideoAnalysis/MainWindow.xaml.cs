﻿using System;
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

namespace VideoAnalysis
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

        private void Loading_Loaded(object sender, RoutedEventArgs e)
        {
            Task task = AnimationLoaded();
        }

        async Task AnimationLoaded()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            //MessageBox.Show("Loaded final");
            HomeWindow home = new HomeWindow();
            this.Close();
            home.Show();
        }
    }
}