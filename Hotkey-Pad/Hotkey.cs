using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Henooh.DeviceEmulator;
using Henooh.DeviceEmulator.Native;

namespace Hotkey_Pad
{
    public class Hotkey
    {
        public Key key { get; set; }

        public ModifierKeys modifiers { get; set; }

        public Hotkey() {}

        public Hotkey(string keyStr, string modifierStr)
        {
            int keyNum, modifierNum;

            keyNum = int.Parse(keyStr);
            modifierNum = int.Parse(modifierStr);
            this.key = (Key)keyNum;
            this.modifiers = (ModifierKeys)modifierNum;

        }

        public Hotkey(Key key, ModifierKeys modifiers)
        {
            this.key = key;
            this.modifiers = modifiers;
        }

        public VirtualKeyCode KeyToVirtualKey() {
            VirtualKeyCode data = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(this.key);
            return data;
        }

        public VirtualKeyCode ModifierKeyToVirtualKey()
        {

            if (modifiers.HasFlag(ModifierKeys.Control))
                return VirtualKeyCode.CONTROL;
            if (modifiers.HasFlag(ModifierKeys.Shift))
                return VirtualKeyCode.SHIFT;
            if (modifiers.HasFlag(ModifierKeys.Alt))
                return VirtualKeyCode.MENU;
            if (modifiers.HasFlag(ModifierKeys.Windows))
                return VirtualKeyCode.RWIN;
            throw new NoModifier();
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            if (modifiers.HasFlag(ModifierKeys.Control))
                str.Append("Ctrl + ");
            if (modifiers.HasFlag(ModifierKeys.Shift))
                str.Append("Shift + ");
            if (modifiers.HasFlag(ModifierKeys.Alt))
                str.Append("Alt + ");
            if (modifiers.HasFlag(ModifierKeys.Windows))
                str.Append("Win + ");

            str.Append(key);
            if (str != null) //cleans it up so that we dont just have a (None) String
                return str.ToString();
            return "";
        }
    }

    public class NoModifier : Exception
    {
        public NoModifier() : base() { }
    }
}
