using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace hotkey_pad
{
    public class pad
    {

        public int buttonXPadding;
        public int buttonYPadding;
        public int rowButtonNum;
        public int colButtonNum;
        public int buttonWidth;
        public int buttonHeight;

        public pad(TabPage tabPageVR)
        {
            this.buttonXPadding = 20;
            this.buttonYPadding = 10;

            this.rowButtonNum = 5;
            this.colButtonNum = 5;

            this.buttonWidth = (tabPageVR.Width - buttonXPadding * rowButtonNum) / rowButtonNum;
            this.buttonHeight = (tabPageVR.Height - buttonYPadding * colButtonNum) / colButtonNum;
            for (int rowNum = 0; rowNum < rowButtonNum; rowNum++)
            {
                for (int colNum = 0; colNum < colButtonNum; colNum++)
                {
                    Button testButton = new Button();
                    testButton.Location = new Point((buttonXPadding / 2) + (buttonWidth * rowNum) + buttonXPadding * rowNum, (buttonYPadding / 2) + (buttonHeight * colNum) + buttonYPadding * colNum);
                    testButton.Height = buttonHeight;
                    testButton.Width = buttonWidth;
                    // Set background and foreground
                    //testButton.BackColor = Color.Red;
                    //testButton.ForeColor = Color.Blue;

                    testButton.Text = "I am Dynamic Button";
                    testButton.Name = "DynamicButton";
                    //testButton.Font = new Font("Georgia", 16);
                    tabPageVR.Controls.Add(testButton);
                }
            }
        }




     
    }
}
