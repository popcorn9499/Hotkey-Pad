using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Hotkey_Pad
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
        private TabItem tabPage;


        public Pad(TabItem tabPage)
        {
            this.buttonXPadding = 20;
            this.buttonYPadding = 10;

            this.rowButtonNum = 5;
            this.colButtonNum = 5;
            this.buttonWidth = (int)((tabPage.Width - buttonXPadding * rowButtonNum) / rowButtonNum);
            this.buttonHeight = (int)((tabPage.Height - buttonYPadding * colButtonNum) / colButtonNum);

            this.tabPage = tabPage;
            if ((tabPage.Content.GetType()) == typeof(Grid))
            {
                this.regenButtons((Grid)(tabPage.Content));
            }
            
        }

        public void regenButtons(Grid grid)
        {

            for (int i = 0; i < rowButtonNum; i++)
            {
                RowDefinition c1 = new RowDefinition();
                c1.Height = new GridLength(20, GridUnitType.Star);
                grid.RowDefinitions.Add(c1);
            }

            for (int i = 0; i < colButtonNum; i++)
            {
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(20, GridUnitType.Star);
                grid.ColumnDefinitions.Add(c1);
            }

            for (int rowNum = 0; rowNum < rowButtonNum; rowNum++)
            {
                
                buttonList.Add(new List<ButtonWrapper>());
                for (int colNum = 0; colNum < colButtonNum; colNum++)
                {
                    Button MyControl1 = new Button();
                    MyControl1.Content = "BUTTON";
                    MyControl1.Name = "Button";
                    MyControl1.Margin = new Thickness(2);
                    //MyControl1.Width = 90;
                    Grid.SetColumn(MyControl1, colNum);
                    Grid.SetRow(MyControl1, rowNum);
                    grid.Children.Add(MyControl1);

                }


                /*{
                    tabPa
                    int pointX = (buttonXPadding / 2) + (buttonWidth * rowNum) + buttonXPadding * rowNum;
                    int pointY = (buttonYPadding / 2) + (buttonHeight * colNum) + buttonYPadding * colNum;
                    ButtonWrapper buttonTemp = new ButtonWrapper(pointX, pointY, buttonHeight, buttonWidth, "TEST");
                    this.tabPage.Controls.Add(buttonTemp.thisButton);
                    buttonList[rowNum].Add(buttonTemp);
                }
                */


            }
        }





    }
}