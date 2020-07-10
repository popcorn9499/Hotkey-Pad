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


        public ButtonWrapper(int pointX, int pointY, int height, int width, string text, Color? backColor = null, Color? foreColor = null,string font = "Microsoft Sans Serif", float fontSize = 8.25f, string name="DynamicButton")
        {
            if (backColor == null) backColor = Color.Transparent;
            if (foreColor == null) foreColor = Color.Black;
            
            this.thisButton.Location = new Point(pointX,pointY);
            this.thisButton.Height = height;
            this.thisButton.Width = width;
            this.thisButton.Text = text;
            this.thisButton.Name = name;
            this.thisButton.Font = new Font(font, fontSize);
            this.thisButton.BackColor = Color.Transparent;
            this.thisButton.ForeColor = Color.Black;

        }

        

    }
}
