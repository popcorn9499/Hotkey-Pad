using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotkey_Pad
{
    class KeyCodeData
    {
        public string Character { get; }
        public Key Keycode { get; }
        public int EvdevScanCodeData { get;}

        public KeyCodeData(string Character, int keyCode, int evdevKey)
        {
            this.Character = Character;
            this.Keycode = (Key)keyCode;
            this.EvdevScanCodeData = evdevKey;
        }
    }
}
