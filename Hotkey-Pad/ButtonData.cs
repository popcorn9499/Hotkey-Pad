﻿using System;
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
        public string cmdExeEnable { get; set; } = "false";
        public string cmdExeCommand { get; set; } = "";
        public string hotkeyEnable { get; set; } = "true";
        public string hotkeyCombo { get; set; } = "";
    }
}