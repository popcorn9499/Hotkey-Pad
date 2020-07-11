using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotkey_Pad
{
    public class ButtonData
    {
        public string Connection { get; set; } = "";
        public string BtnText { get; set; } = "Button Name";
        public bool cmdExeEnable { get; set; } = false;
        public string cmdExeCommand { get; set; } = "";
        public bool hotkeyEnable { get; set; } = false;
        public string hotkeyCombo { get; set; } = "";
    }
}
