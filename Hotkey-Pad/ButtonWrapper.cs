using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace Hotkey_Pad
{
    public class ButtonWrapper
    {

        public Button thisButton = new Button();

        public ButtonData buttonData;
        
        public delegate void buttonClickEventDelegate(object sender, RoutedEventArgs e, ButtonData buttonData);
        public buttonClickEventDelegate buttonClickEvent;


        public ButtonWrapper(ButtonData buttonData,string text, Thickness margin, Color? backColor = null, 
            Color? foreColor = null, string font = "Microsoft Sans Serif", float fontSize = 8.25f, string name = "DynamicButton")
        {
            this.buttonData = buttonData;

            TextBlock thisButtonText = new TextBlock();
            thisButtonText.Text = text;
            thisButtonText.TextWrapping = TextWrapping.Wrap;
            thisButtonText.Padding = new Thickness(5);
            this.thisButton.Content = thisButtonText;
            this.thisButton.Name = name;
            this.thisButton.Margin = margin;
            this.thisButton.Cursor = Cursors.Arrow;
            this.thisButton.Click += Button_Click;

            this.thisButton.Background = generateBrush(this.buttonData.ButtonBackgroundColor);
            this.thisButton.Foreground = generateBrush(this.buttonData.ButtonForegroundColor);
            /*
            if (backColor == null) backColor = Color.FromArgb(0,0,0,0);
            if (foreColor == null) foreColor = Color.FromRgb(255,255,255);
            this.thisButton.X
            this.thisButton.Location = new Point(pointX, pointY);
            this.thisButton.Height = height;
            this.thisButton.Width = width;
            this.thisButton.Content = text;
            this.thisButton.Name = name;
            this.thisButton.Font = new Font(font, fontSize);
            this.thisButton.BackColor = Color.Transparent;
            this.thisButton.ForeColor = Color.Black;
            */
        }

        private Brush generateBrush(string rgbString)
        {
            byte R=0, G=0, B=0;
            string[] rgbStringList = rgbString.Split(',');
            R = (byte)int.Parse(rgbStringList[0]);
            B = (byte)int.Parse(rgbStringList[1]);
            G = (byte)int.Parse(rgbStringList[2]);
            Brush payload = new SolidColorBrush(Color.FromRgb(R, G, B));
            return payload;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            buttonClickEvent.Invoke(sender, e, this.buttonData);
            //ButtonPadEditor x = new ButtonPadEditor(buttonData);
            //x.Show();
        }

    }
}
