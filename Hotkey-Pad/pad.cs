using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace hotkey_pad
{
    public class Pad
    {

        public int buttonXPadding;
        public int buttonYPadding;
        public int rowButtonNum;
        public int colButtonNum;
        public int buttonWidth;
        public int buttonHeight;
        private TabPage tabPage;

        public Pad(TabPage tabPage)
        {
            this.buttonXPadding = 20;
            this.buttonYPadding = 10;

            this.rowButtonNum = 5;
            this.colButtonNum = 5;

            this.buttonWidth = (tabPage.Width - buttonXPadding * rowButtonNum) / rowButtonNum;
            this.buttonHeight = (tabPage.Height - buttonYPadding * colButtonNum) / colButtonNum;

            this.tabPage = tabPage;
            this.regenButtons();
        }

        public void regenButtons()
        {
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
                    this.tabPage.Controls.Add(testButton);
                }
            }
        }




     
    }
}
