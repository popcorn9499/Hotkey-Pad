﻿using Hotkey_Pad;
using Hotkey_Pad.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotkey_Pad_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Pad padEditor, pad;

        

        public MainWindow()
        {

            int buttonPadding = Settings.Default.buttonPadding;
            int rowButtonNum = Settings.Default.rowButtonNum;
            int colButtonNum = Settings.Default.colButtonNum;



            //populate buttonData
            if (Settings.Default.buttonData.Equals(""))
            { //populate us with some basic data
                for (int i = 0; i < rowButtonNum; i++)
                {
                    Pad.buttonDataList.Add(new List<ButtonData>());
                    for (int j = 0; j < colButtonNum; j++)
                    {
                        Pad.buttonDataList[i].Add(new ButtonData());
                    }
                }
            }
            else
            { //populate with saved data
                Pad.buttonDataList = JsonConvert.DeserializeObject<List<List<ButtonData>>>(Settings.Default.buttonData);
            }

            InitializeComponent();
            tb_buttonPadding.Text = buttonPadding.ToString();
            tb_rowButtonNum.Text = rowButtonNum.ToString();
            tb_colButtonNum.Text = colButtonNum.ToString();

            if (Settings.Default.connectData == null)
            {
                Settings.Default.connectData = new StringCollection();
            }

            try
            {
                foreach (String item in Settings.Default.connectData)
                {
                    String ipAddress = item.Split(':')[0]; //gets the hostname and port from the config
                    Int32 port = Int32.Parse(item.Split(':')[1]);

                    addConnection(ipAddress, port);
                }
            }
            catch { }

            


            foreach (TabItem tabItem in tabControl1.Items)
            {
                if (tabItem.Header.ToString().Equals("Pad")) {
                    this.pad = new Pad(tabItem, buttonPadding, rowButtonNum, colButtonNum);
                } else if (tabItem.Header.ToString().Equals("Pad Editor"))
                {
                    this.padEditor = new EditorPad(tabItem, buttonPadding, rowButtonNum, colButtonNum);
                }
            }


            //recolor the window
            mainWindow.Background = ColorHandler.generateBrush(Settings.Default.winBackground);
            mainWindow.Foreground = ColorHandler.generateBrush(Settings.Default.winForeground);
            tabItemPad.Background = ColorHandler.generateBrush(Settings.Default.padTabBackground);
            tabItemPad.Foreground = ColorHandler.generateBrush(Settings.Default.padTabForeground);
            tabItemPadEditor.Background = ColorHandler.generateBrush(Settings.Default.padEditTabBackground);
            tabItemPadEditor.Foreground = ColorHandler.generateBrush(Settings.Default.padEditorTabForeground);
            tabItemSettings.Background = ColorHandler.generateBrush(Settings.Default.settingsTabBackground);
            tabItemSettings.Foreground = ColorHandler.generateBrush(Settings.Default.settingsTabForeground);

            tb_windowBackground.Text = Settings.Default.winBackground;
            tb_windowForeground.Text = Settings.Default.winForeground;
            tb_padTabBackground.Text = Settings.Default.padTabBackground;
            tb_padTabForeground.Text = Settings.Default.padTabForeground;
            tb_padEditorTabBackground.Text = Settings.Default.padEditTabBackground;
            tb_padEditorTabForeground.Text = Settings.Default.padEditorTabForeground;
            tb_settingsTabBackground.Text = Settings.Default.settingsTabBackground;
            tb_settingsTabForeground.Text = Settings.Default.settingsTabForeground;

        }



        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button x = (Button)sender;
            MessageBox.Show(x.Margin.ToString());
        }

        private void window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowHeight = e.NewSize.Height;
            double newWindowWidth = e.NewSize.Width;
            double prevWindowHeight = e.PreviousSize.Height;
            double prevWindowWidth = e.PreviousSize.Width;
            if (prevWindowHeight == 0) prevWindowHeight = 450.0;
            if (prevWindowWidth == 0) prevWindowWidth = 800.0;
            tabControl1.Height = newWindowHeight * (tabControl1.Height / prevWindowHeight);
            tabControl1.Width = newWindowWidth * (tabControl1.Width / prevWindowWidth);
        }

        private void tb_colButtonNum_TextChanged(object sender, TextChangedEventArgs e)
        { //saves the setting change and adds it to the pad

            int colButtonNum;
            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out colButtonNum))
            {
                Settings.Default.colButtonNum = colButtonNum;

                foreach (List<ButtonData> data in Pad.buttonDataList)
                {
                    if (colButtonNum > data.Count)
                    { //increase number of columns
                        for (int i = data.Count; i < colButtonNum; i++)
                        {
                            data.Add(new ButtonData());
                        }
                    }
                    else if (colButtonNum < data.Count)
                    { //decrease number of columns

                        for (int i = data.Count - 1; i > colButtonNum; i--)
                        {
                            if (data[i].CompareTo(new ButtonData())) data.RemoveAt(i);
                        }
                    }
                }
               
                if (padEditor != null && pad != null)
                {
                    this.padEditor.colButtonNum = colButtonNum;
                    this.pad.colButtonNum = colButtonNum;
                }
            }
            else
            {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }

        private void tb_buttonPadding_TextChanged(object sender, TextChangedEventArgs e)
        { //saves the setting change and adds it to the pad
            int buttonPadding;

            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out buttonPadding))
            {
                Settings.Default.buttonPadding = buttonPadding;
                if (padEditor != null && pad != null)
                {
                    this.padEditor.buttonPadding = buttonPadding;
                    this.pad.buttonPadding = buttonPadding;
                }

            }
            else
            {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //redraws stuff needing redrawing on tab change
            pad.regenButtons();
            padEditor.regenButtons();
        }

        private void btnAddConnection_Click(object sender, RoutedEventArgs e)
        {
            String ipAddress = tbAddConnectionIP.Text;
            Int32 port;

            if (!int.TryParse(tbAddConnectionPort.Text, out port))
            {
                MessageBox.Show("The port must be a integer!");
                return;
            }

            addConnection(ipAddress, port);
        }

        private void addConnection(string ipAddress, Int32 port)
        {
            lvServerListItem lvItem = new lvServerListItem { IP_Address = ipAddress, Port = port.ToString(), Connection_Status = "WHY" };
            lvServerList.Items.Add(lvItem);

            ConnectionManager.Connection_List.Add(new ConnectionManager(ipAddress, port, lvItem));
        }

        private void btnRemoveCheckedConnections_Click(object sender, RoutedEventArgs e)
        { //removes items selected in the server list.
            var selected = lvServerList.SelectedItems.Cast<Object>().ToArray();
            foreach (var eachItem in selected)
            {
                lvServerList.Items.Remove(eachItem);
                ConnectionManager deadConnection = ConnectionManager.findConnection((lvServerListItem)eachItem);
                deadConnection.close();
            }
        }

        private void window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StringCollection servers = new StringCollection();
            foreach (ConnectionManager item in ConnectionManager.Connection_List)
            {
                lvServerListItem lvItem = item.lvItem;
                String ipAddress = lvItem.IP_Address; //gathers all the item information and creates a serverName
                String port = lvItem.Port;
                String serverName = ipAddress + ":" + port;
                servers.Add(serverName); //adds the connection info to the config
            }
            Settings.Default.connectData = servers;

            Settings.Default.buttonData = JsonConvert.SerializeObject(Pad.buttonDataList);

            Settings.Default.Save();
        }

        private void window1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowHeight = e.NewSize.Height;
            double newWindowWidth = e.NewSize.Width;
            double prevWindowHeight = e.PreviousSize.Height;
            double prevWindowWidth = e.PreviousSize.Width;
            if (prevWindowHeight == 0) return;
            if (prevWindowWidth == 0) return;
            gridPad.Height = newWindowHeight * (gridPad.Height / prevWindowHeight);
            gridPad.Width = newWindowWidth * (gridPad.Width / prevWindowWidth);

            if (prevWindowHeight == 0) return;
            if (prevWindowWidth == 0) return;
            gridPadEditor.Height = newWindowHeight * (gridPadEditor.Height / prevWindowHeight);
            gridPadEditor.Width = newWindowWidth * (gridPadEditor.Width / prevWindowWidth);

        }

        private void tb_rowButtonNum_TextChanged(object sender, TextChangedEventArgs e)
        { //saves the setting change and adds it to the pad
            int rowButtonNum;
            TextBox tb = (TextBox)sender;
            if (int.TryParse(tb.Text, out rowButtonNum))
            {
                Settings.Default.rowButtonNum = rowButtonNum;
                if (this.pad != null) {
                    if (rowButtonNum > Pad.buttonDataList.Count)
                    {   // growing the list.
                        // increase the row by some number of increased rows.
                        for (int i = Pad.buttonDataList.Count; i < rowButtonNum; i++)
                        {
                            Pad.buttonDataList.Add(new List<ButtonData>());
                            for (int j = 0; j < rowButtonNum; j++)
                            {
                                Pad.buttonDataList[i].Add(new ButtonData());
                            }
                        }
                    }
                    else if (rowButtonNum < Pad.buttonDataList.Count)
                    {
                        for (int i = Pad.buttonDataList.Count-1; i > rowButtonNum; i--)
                        {   // shrinking the list.
                            // if the entire column is empty delete the entire row. if not dont. 
                            bool isEmpty = true;
                            foreach (ButtonData data in Pad.buttonDataList[i])
                            {
                                if (!data.CompareTo(new ButtonData())) isEmpty = false;
                            }
                            if (isEmpty)
                            {
                                Pad.buttonDataList.RemoveAt(i);
                            } 
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (padEditor != null && pad != null)
                {
                    this.padEditor.rowButtonNum = rowButtonNum;
                    this.pad.rowButtonNum = rowButtonNum;
                }
            } else {
                MessageBox.Show("Please Make this an Integer!!!");
            }
        }

        private void tb_windowBackground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            mainWindow.Background = ColorHandler.generateBrush(rgb);
            Settings.Default.winBackground = rgb;
        }

        private void tb_windowForeground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            mainWindow.Foreground = ColorHandler.generateBrush(rgb);
            Settings.Default.winForeground = rgb;
        }

        private void tb_padTabBackground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemPad.Background = ColorHandler.generateBrush(rgb);
            Settings.Default.padTabBackground = rgb;
        }

        private void tb_padTabForeground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemPad.Foreground = ColorHandler.generateBrush(rgb);
            Settings.Default.padTabForeground = rgb;
        }

        private void tb_padEditorTabBackground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemPadEditor.Background = ColorHandler.generateBrush(rgb);
            Settings.Default.padEditTabBackground = rgb;
        }

        private void tb_padEditorTabForeground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemPadEditor.Foreground = ColorHandler.generateBrush(rgb);
            Settings.Default.padEditorTabForeground = rgb;
        }

        private void tb_settingsTabBackground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemSettings.Background = ColorHandler.generateBrush(rgb);
            Settings.Default.settingsTabBackground = rgb;
        }

        private void tb_settingsTabForeground_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string rgb = tb.Text;
            rgb = ColorHandler.CheckRGBA(rgb);
            tabItemSettings.Foreground = ColorHandler.generateBrush(rgb);
            Settings.Default.settingsTabForeground = rgb;
        }
    }
}
