using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Hotkey_Pad
{
    public class ButtonWrapper
    {

        public Button thisButton = new Button();


        public ButtonWrapper(int pointX, int pointY, int height, int width, string text, Color? backColor = null, Color? foreColor = null, string font = "Microsoft Sans Serif", float fontSize = 8.25f, string name = "DynamicButton")
        {
            /*
            if (backColor == null) backColor = Color.FromArgb(0,0,0,0);
            if (foreColor == null) foreColor = Color.FromRgb(255,255,255);
            this.thisButton.X
            this.thisButton.Location = new Point(pointX, pointY);
            this.thisButton.Height = height;
            this.thisButton.Width = width;
            this.thisButton.Text = text;
            this.thisButton.Name = name;
            this.thisButton.Font = new Font(font, fontSize);
            this.thisButton.BackColor = Color.Transparent;
            this.thisButton.ForeColor = Color.Black;
            */
        }



    }
}
