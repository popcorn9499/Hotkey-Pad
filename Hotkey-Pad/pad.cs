using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<List<ButtonWrapper>> buttonList = new List<List<ButtonWrapper>>();
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
                buttonList.Add(new List<ButtonWrapper>());
                for (int colNum = 0; colNum < colButtonNum; colNum++)
                {
                    
                    int pointX = (buttonXPadding / 2) + (buttonWidth * rowNum) + buttonXPadding * rowNum;
                    int pointY = (buttonYPadding / 2) + (buttonHeight * colNum) + buttonYPadding * colNum;
                    ButtonWrapper buttonTemp = new ButtonWrapper(pointX,pointY,buttonHeight,buttonWidth,"TEST");
                    this.tabPage.Controls.Add(buttonTemp.thisButton);
                    buttonList[rowNum].Add(buttonTemp);
                }

            }
        }




     
    }
}
