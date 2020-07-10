﻿using Hotkey_Pad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Hotkey_Pad_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            foreach (TabItem tabItem in tabControl1.Items)
            {
                if (tabItem.Header.ToString().Equals("Pad")){
                    /* MessageBox.Show(tabItem.Content.ToString());
                     MessageBox.Show(((tabItem.Content.GetType()) == typeof(Grid)).ToString());*/
                    Pad x = new Pad(tabItem);
                } else if (tabItem.Header.ToString().Equals("Pad Editor"))
                {
                    /* MessageBox.Show(tabItem.Content.ToString());
                     MessageBox.Show(((tabItem.Content.GetType()) == typeof(Grid)).ToString());*/
                    Pad x = new Pad(tabItem);
                }


            }

                
            } 
        

        
        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button x = (Button)sender;
            MessageBox.Show(x.Margin.ToString());
        }

        private void window1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var relativePosition = e.GetPosition(this);
            var point = PointToScreen(relativePosition);
            MessageBox.Show(point.ToString());
        }

        private void window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowHeight = e.NewSize.Height;
            double newWindowWidth = e.NewSize.Width;
            double prevWindowHeight = e.PreviousSize.Height;
            double prevWindowWidth = e.PreviousSize.Width;
            tabControl1.Height = newWindowHeight ;
            tabControl1.Width = newWindowWidth;
        }
        
    }
}