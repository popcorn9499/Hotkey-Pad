using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotkey_Pad
{
    public class Hotkey
    {
        public Key key { get; }

        public ModifierKeys modifiers { get; }

        public Hotkey() {}

        public Hotkey(string keyStr, string modifierStr)
        {
            int keyNum,modifierNum;

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
            if (str == null) //cleans it up so that we dont just have a (None) String
                return str.ToString();
            return "";
        }
    }
}
