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
        public bool CmdExeEnable { get; set; } = false;
        public string CmdExeCommand { get; set; } = "";
        public bool HotkeyEnable { get; set; } = false;
        public Hotkey HotkeyCombo { get; set; } = new Hotkey();
        public string ButtonBackgroundColor { get; set; } = "123,37,209,255";
        public string ButtonForegroundColor { get; set; } = "255,255,255,255";


        public bool CompareTo(ButtonData buttonData2)
        {
            if (!this.Connection.Equals(buttonData2.Connection)) return false;
            if (!this.BtnText.Equals(buttonData2.BtnText)) return false;
            if (this.CmdExeEnable != buttonData2.CmdExeEnable) return false;
            if (!this.CmdExeCommand.Equals(buttonData2.CmdExeCommand)) return false;
            if (this.HotkeyEnable != buttonData2.HotkeyEnable) return false;
            if (!this.HotkeyCombo.Equals(buttonData2.HotkeyCombo)) return false;
            if (!this.ButtonBackgroundColor.Equals(buttonData2.ButtonBackgroundColor)) return false;
            if (!this.ButtonForegroundColor.Equals(buttonData2.ButtonForegroundColor)) return false;
            return true;
        }

        public void Reset()
        {
            this.Connection = "";
            this.BtnText = "Button Name";
            this.CmdExeCommand = "";
            this.CmdExeEnable = false;
            this.HotkeyEnable = false;
            this.HotkeyCombo = new Hotkey();
            this.ButtonBackgroundColor = "123,37,209,255";
            this.ButtonForegroundColor = "255,255,255,255";
        }
    }
}

