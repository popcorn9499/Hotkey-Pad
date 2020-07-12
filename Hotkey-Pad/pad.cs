using Hotkey_Pad.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Henooh.DeviceEmulator;
using Henooh.DeviceEmulator.Native;
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

        private KeyboardController kb = new KeyboardController();

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
                }
            }
        }

        public virtual async void ButtonEditor_Click(object sender, RoutedEventArgs e, ButtonData buttonData)
        {
            //MessageBox.Show("HELLO)O");
            if (buttonData.CmdExeEnable)
            {

            }
            if (buttonData.HotkeyEnable)
            {
                if (buttonData.Connection.Equals(""))
                { //local connection management
                    VirtualKeyCode key = buttonData.HotkeyCombo.KeyToVirtualKey();
                    ModifierKeys modifier = buttonData.HotkeyCombo.modifiers;

                    if (modifier.HasFlag(ModifierKeys.Control))
                    {
                        this.kb.Control(key);
                    }
                    else if (modifier.HasFlag(ModifierKeys.Shift))
                    {
                        this.kb.Shift(key);
                    }
                    else if (modifier.HasFlag(ModifierKeys.Alt))
                    {
                        this.kb.Alt(key);
                    }
                    else if (modifier.HasFlag(ModifierKeys.Windows))
                    {
                        this.kb.Window(key);
                    }
                    else
                    {
                        this.kb.Type(key);
                    }
                } else
                {

                }

            }

        }
    }
}