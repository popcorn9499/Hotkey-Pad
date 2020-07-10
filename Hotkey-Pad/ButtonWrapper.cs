using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hotkey_pad
{
    public class ButtonWrapper
    {

        public Button thisButton = new Button();


        public ButtonWrapper(int pointX, int pointY, int height, int width, string text, Color? backColor = null, Color? foreColor = null, string name="DynamicButton")
        {
            if (backColor == null) backColor = Color.Transparent;
            if (foreColor == null) foreColor = Color.Black;
            
            thisButton.Location = new Point(pointX,pointY);
            thisButton.Height = height;
            thisButton.Width = width;
            thisButton.Text = text;
            thisButton.Name = name;
            this.thisButton.BackColor = Color.Transparent;
            this.thisButton.ForeColor = Color.Black ;

            
        }


    }
}
