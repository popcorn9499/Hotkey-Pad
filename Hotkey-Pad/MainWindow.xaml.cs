using Hotkey_Pad;
using Hotkey_Pad.Properties;
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
        public Pad padEditor, pad;


        public MainWindow()
        {

            int buttonPadding = Settings.Default.buttonPadding;
            int rowButtonNum = Settings.Default.rowButtonNum;
            int colButtonNum = Settings.Default.colButtonNum;

            InitializeComponent();
            tb_buttonPadding.Text = buttonPadding.ToString();
            tb_rowButtonNum.Text = rowButtonNum.ToString();
            tb_colButtonNum.Text = colButtonNum.ToString();
            

            foreach (TabItem tabItem in tabControl1.Items)
            {
                if (tabItem.Header.ToString().Equals("Pad")){
                    /* MessageBox.Show(tabItem.Content.ToString());
                     MessageBox.Show(((tabItem.Content.GetType()) == typeof(Grid)).ToString());*/
                    this.pad = new Pad(tabItem, buttonPadding, rowButtonNum, colButtonNum);
                } else if (tabItem.Header.ToString().Equals("Pad Editor"))
                {
                    /* MessageBox.Show(tabItem.Content.ToString());
                     MessageBox.Show(((tabItem.Content.GetType()) == typeof(Grid)).ToString());*/
                    this.padEditor = new Pad(tabItem, buttonPadding, rowButtonNum, colButtonNum);
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
            if (prevWindowHeight == 0) prevWindowHeight = 450.0;
            if (prevWindowWidth == 0) prevWindowWidth = 800.0;
            tabControl1.Height = newWindowHeight*(tabControl1.Height/prevWindowHeight);
            tabControl1.Width = newWindowWidth*(tabControl1.Width/prevWindowWidth);
        }

        private void tb_colButtonNum_TextChanged(object sender, TextChangedEventArgs e)
        {

            int colButtonNum;
            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out colButtonNum))
            {
                Settings.Default.colButtonNum = colButtonNum;
                if (padEditor != null && pad != null)
                {
                    this.padEditor.colButtonNum = colButtonNum;
                    this.pad.colButtonNum = colButtonNum;
                }
            }
            else
            {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }

        private void tb_buttonPadding_TextChanged(object sender, TextChangedEventArgs e)
        {
            int buttonPadding;
  
            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out buttonPadding))
            {
                Settings.Default.buttonPadding = buttonPadding;
                if (padEditor != null && pad != null)
                {
                    this.padEditor.buttonPadding = buttonPadding;
                    this.pad.buttonPadding = buttonPadding;
                }
                
            }
            else
            {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pad.regenButtons();
            padEditor.regenButtons();
        }

        private void tb_rowButtonNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            int rowButtonNum;
            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out rowButtonNum))
            {
                Settings.Default.rowButtonNum = rowButtonNum;
                if (padEditor != null && pad != null)
                {
                    this.padEditor.rowButtonNum = rowButtonNum;
                    this.pad.rowButtonNum = rowButtonNum;
                }
            } else {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }
    }
}
