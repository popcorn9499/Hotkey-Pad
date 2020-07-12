using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotkey_Pad
{
    /// <summary>
    /// Interaction logic for ButtonPadEditor.xaml
    /// </summary>
    public partial class ButtonPadEditor : Window
    {
        private ButtonData buttonData;
        private Pad pad;

        public ButtonPadEditor(ButtonData buttonData, Pad pad)
        {
            this.buttonData = buttonData;
            this.pad = pad;

            InitializeComponent();

            tbBtnName.Text = this.buttonData.BtnText;
            cbHotkeyEnable.IsChecked = this.buttonData.HotkeyEnable;
            tbHotkey.Text = this.buttonData.HotkeyCombo.ToString();
            cbCmdEnable.IsChecked = this.buttonData.CmdExeEnable;
            tbCmd.Text = this.buttonData.CmdExeCommand;

            cbCurrentConnection.Items.Add(""); //adds a blank item so you can reset the button to blankness

            foreach (ConnectionManager item in ConnectionManager.Connection_List)
            {
                lvServerListItem lvItem = item.lvItem;
                String data = lvItem.IP_Address + ":" + lvItem.Port;
                cbCurrentConnection.Items.Add(data);
            }
            cbCurrentConnection.Text = this.buttonData.Connection;
        }


        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            Hotkey hotkey;
            // Don't let the event pass further
            // because we don't want standard textbox shortcuts working
            e.Handled = true;

            // Get modifiers and key data
            var modifiers = Keyboard.Modifiers;
            var key = e.Key;

            // When Alt is pressed, SystemKey is used instead
            if (key == Key.System)
            {
                key = e.SystemKey;
            }

            // Pressing delete, backspace or escape without modifiers clears the current value
            if (modifiers == ModifierKeys.None &&
                (key == Key.Delete || key == Key.Back || key == Key.Escape))
            {
                hotkey = null;
                return;
            }

            // If no actual key was pressed - return
            if (key == Key.LeftCtrl ||
                key == Key.RightCtrl ||
                key == Key.LeftAlt ||
                key == Key.RightAlt ||
                key == Key.LeftShift ||
                key == Key.RightShift ||
                key == Key.LWin ||
                key == Key.RWin ||
                key == Key.Clear ||
                key == Key.OemClear ||
                key == Key.Apps)
            {
                return;
            }

            // Update the value
            hotkey = new Hotkey(key, modifiers);

            TextBox tb = (TextBox)sender;
            tb.Text = hotkey.ToString();
            this.buttonData.HotkeyCombo = hotkey;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.buttonData.BtnText = tbBtnName.Text.ToString();
            this.buttonData.HotkeyEnable = (bool)cbHotkeyEnable.IsChecked;
            this.buttonData.CmdExeEnable = (bool)cbCmdEnable.IsChecked;
            this.buttonData.CmdExeCommand = tbCmd.Text;
            this.buttonData.Connection = cbCurrentConnection.Text;
            this.pad.regenButtons();
        }
    }
}
