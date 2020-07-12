using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotkey_Pad
{
    class KeyCodeTranslation
    { //A translation table which might be a bad idea having it hard coded not sure how it will work with different keyboards we shall see tho. Anyways 
        // this means we can easily translate between the evdev keycodes and windows based keycodes
        public static List<KeyCodeData> KeyTranslationList = new List<KeyCodeData> {
            new KeyCodeData("LCTRL", 44, 29),
            new KeyCodeData("RCTRL", 44, 97),
            new KeyCodeData("LALT", 44, 56),
            new KeyCodeData("RALT", 44, 100),
            new KeyCodeData("LSHIFT", 44, 42),
            new KeyCodeData("RSHIFT", 44, 54),
            new KeyCodeData("LMETA", 44, 125),
            new KeyCodeData("RMETA", 44, 126),
            new KeyCodeData("CAPSLOCK", 44, 58),
            new KeyCodeData("TAB", 44, 15),
            new KeyCodeData("ENTER", 44, 28),
            new KeyCodeData("BACKSPACE", 44, 14),
            new KeyCodeData("ESC", 44, 1),
            new KeyCodeData("A", 44, 30),
            new KeyCodeData("B", 45, 48),
            new KeyCodeData("C", 46, 46),
            new KeyCodeData("D", 47, 32)
        };

        public static List<int> findEvdevModifierKeys(ModifierKeys modifiers)
        {
            List<int> data = new List<int>();

            if (modifiers.HasFlag(ModifierKeys.Control)) data.Add(findEvdevKey(Key.LeftCtrl));
            if (modifiers.HasFlag(ModifierKeys.Alt)) data.Add(findEvdevKey(Key.LeftAlt));
            if (modifiers.HasFlag(ModifierKeys.Shift)) data.Add(findEvdevKey(Key.LeftShift));
            if (modifiers.HasFlag(ModifierKeys.Windows)) data.Add(findEvdevKey(Key.LWin));
            
            return data;
        }
        

        public static int findEvdevKey(Key keycode)
        {
            int evdevKey = 0; 
            foreach (KeyCodeData data in KeyTranslationList)
            {
                if (data.Keycode.Equals(keycode))
                {
                    evdevKey = data.EvdevScanCodeData;
                    break;
                }
            }
            return evdevKey;
        }
    }
}
