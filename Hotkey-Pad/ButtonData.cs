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
        public bool CmdExeEnable { get; set; } = false;
        public string CmdExeCommand { get; set; } = "";
        public bool HotkeyEnable { get; set; } = false;
        public string HotkeyCombo { get; set; } = "";
    }
}
