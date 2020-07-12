using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hotkey_Pad
{
    public class EditorPad : Pad
    {
        public EditorPad(TabItem tabPage, int buttonPadding, int rowButtonNum, int colButtonNum)
            : base (tabPage, buttonPadding,rowButtonNum,colButtonNum)
        {
            
        }

        public override void ButtonEditor_Click(object sender, RoutedEventArgs e, ButtonData buttonData)
        {
            ButtonPadEditor x = new ButtonPadEditor(buttonData);
            x.Show();
        }
    }
}
