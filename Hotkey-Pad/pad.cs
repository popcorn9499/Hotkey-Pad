using Hotkey_Pad.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotkey_Pad
{
    public class Pad
    {

        public int buttonPadding;
        public int rowButtonNum;
        public int colButtonNum;
        public int buttonWidth;
        public int buttonHeight;
        public static List<List<ButtonData>> buttonDataList = new List<List<ButtonData>>();
        private TabItem tabPage;
        private Grid grid;


        public Pad(TabItem tabPage, int buttonPadding, int rowButtonNum, int colButtonNum)
        {
            this.buttonPadding = buttonPadding;


            this.rowButtonNum = rowButtonNum;
            this.colButtonNum = colButtonNum;

            this.grid = (Grid)(tabPage.Content);

            this.tabPage = tabPage;
            if ((tabPage.Content.GetType()) == typeof(Grid))
            {
                this.regenButtons();
            }
            
        }

        public void regenButtons()
        {
            this.grid.Children.Clear();
            this.grid.RowDefinitions.Clear();
            this.grid.ColumnDefinitions.Clear();

            for (int i = 0; i < rowButtonNum; i++)
            {
                RowDefinition c1 = new RowDefinition();
                c1.Height = new GridLength(20, GridUnitType.Star);
                this.grid.RowDefinitions.Add(c1);
            }

            for (int i = 0; i < colButtonNum; i++)
            {
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(20, GridUnitType.Star);
                this.grid.ColumnDefinitions.Add(c1);
            }

            for (int rowNum = 0; rowNum < rowButtonNum; rowNum++)
            {
                
                for (int colNum = 0; colNum < colButtonNum; colNum++)
                {
                    ButtonData dataItem = Pad.buttonDataList[rowNum][colNum];
                    ButtonWrapper buttonWrapper = new ButtonWrapper(dataItem, dataItem.BtnText, new Thickness(this.buttonPadding));
                    Grid.SetColumn(buttonWrapper.thisButton, colNum);
                    Grid.SetRow(buttonWrapper.thisButton, rowNum);
                    this.grid.Children.Add(buttonWrapper.thisButton);
                    buttonWrapper.buttonClickEvent += ButtonEditor_Click;
                    //Button MyControl1 = new Button();
                    /*MyControl1.Content = ;
                    MyControl1.Name = "Button";
                    MyControl1.Margin = new Thickness(this.buttonPadding);
                    MyControl1.Cursor = Cursors.Arrow;
                    MyControl1.Click += Button_Click;
                    //MyControl1.Width = 90;
                    Grid.SetColumn(MyControl1, colNum);
                    Grid.SetRow(MyControl1, rowNum);*/
                    //this.grid.Children.Add(MyControl1);
                }
            }


        }
        private void ButtonEditor_Click(object sender, RoutedEventArgs e, ButtonData buttonData)
        {
            ButtonPadEditor x = new ButtonPadEditor(buttonData);
            x.Show();
        }





    }
}