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
            new KeyCodeData("LCTRL", Key.LeftCtrl, 29),
            new KeyCodeData("RCTRL", Key.RightCtrl, 97),
            new KeyCodeData("LALT", Key.LeftAlt, 56),
            new KeyCodeData("RALT", Key.RightAlt, 100),
            new KeyCodeData("LSHIFT", Key.LeftShift, 42),
            new KeyCodeData("RSHIFT", Key.RightShift, 54),
            new KeyCodeData("LMETA", Key.LWin, 125),
            new KeyCodeData("RMETA", Key.RWin, 126),
            new KeyCodeData("CAPSLOCK", Key.CapsLock, 58),
            new KeyCodeData("TAB", Key.Tab, 15),
            new KeyCodeData("ENTER", Key.Return, 28),
            new KeyCodeData("BACKSLASH", Key.OemBackslash, 43),
            new KeyCodeData("BACKSPACE", Key.OemBackslash, 14),
            new KeyCodeData("ESC", Key.Escape, 1),
            new KeyCodeData("F1", Key.F1, 59),
            new KeyCodeData("F2", Key.F2, 60),
            new KeyCodeData("F3", Key.F3, 61),
            new KeyCodeData("F4", Key.F4, 62),
            new KeyCodeData("F5", Key.F5, 63),
            new KeyCodeData("F6", Key.F6, 64),
            new KeyCodeData("F7", Key.F7, 65),
            new KeyCodeData("F8", Key.F8, 66),
            new KeyCodeData("F9", Key.F9, 67),
            new KeyCodeData("F10", Key.F10, 68),
            new KeyCodeData("F11", Key.F11, 87),
            new KeyCodeData("F12", Key.F12, 88),
            new KeyCodeData("F13", Key.F13, 183),
            new KeyCodeData("F14", Key.F14, 184),
            new KeyCodeData("F15", Key.F15, 185),
            new KeyCodeData("F16", Key.F16, 186),
            new KeyCodeData("F17", Key.F17, 187),
            new KeyCodeData("F18", Key.F18, 188),
            new KeyCodeData("F19", Key.F19, 189),
            new KeyCodeData("F20", Key.F20, 190),
            new KeyCodeData("F21", Key.F21, 191),
            new KeyCodeData("F22", Key.F22, 192),
            new KeyCodeData("F23", Key.F23, 193),
            new KeyCodeData("F24", Key.F24, 194),
            new KeyCodeData("A", Key.A, 30),
            new KeyCodeData("B", Key.B, 48),
            new KeyCodeData("C", Key.C, 46),
            new KeyCodeData("D", Key.D, 32),
            new KeyCodeData("E", Key.E, 18),
            new KeyCodeData("F", Key.F, 33),
            new KeyCodeData("G", Key.G, 34),
            new KeyCodeData("H", Key.H, 35),
            new KeyCodeData("I", Key.I, 23),
            new KeyCodeData("J", Key.J, 36),
            new KeyCodeData("K", Key.K, 37),
            new KeyCodeData("L", Key.L, 38),
            new KeyCodeData("M", Key.M, 50),
            new KeyCodeData("N", Key.N, 49),
            new KeyCodeData("O", Key.O, 24),
            new KeyCodeData("P", Key.P, 25),
            new KeyCodeData("Q", Key.Q, 16),
            new KeyCodeData("R", Key.R, 19),
            new KeyCodeData("S", Key.S, 31),
            new KeyCodeData("T", Key.T, 20),
            new KeyCodeData("U", Key.U, 22),
            new KeyCodeData("V", Key.V, 47),
            new KeyCodeData("W", Key.W, 17),
            new KeyCodeData("X", Key.X, 45),
            new KeyCodeData("Y", Key.Y, 21),
            new KeyCodeData("Z", Key.Z, 44),
            new KeyCodeData("COMA", Key.OemComma, 57),
            new KeyCodeData("DOT", Key.OemPeriod, 52),
            new KeyCodeData("SEMICOLON", Key.OemSemicolon, 39),
            new KeyCodeData("APOSTROPHE", Key.OemQuotes, 40),
            new KeyCodeData("LEFTBRACE", Key.OemOpenBrackets, 26),
            new KeyCodeData("RIGHTBRACE", Key.OemCloseBrackets, 27),
            new KeyCodeData("GRAVE", Key.OemTilde, 41),
            new KeyCodeData("1", Key.D1, 2),
            new KeyCodeData("2", Key.D2, 3),
            new KeyCodeData("3", Key.D3, 4),
            new KeyCodeData("4", Key.D4, 5),
            new KeyCodeData("5", Key.D5, 6),
            new KeyCodeData("6", Key.D6, 7),
            new KeyCodeData("7", Key.D7, 8),
            new KeyCodeData("8", Key.D8, 9),
            new KeyCodeData("9", Key.D9, 10),
            new KeyCodeData("0", Key.D0, 11),
            new KeyCodeData("MINUS", Key.OemMinus, 12),
            new KeyCodeData("EQUAL", Key.OemPlus, 13),
            new KeyCodeData("KP1", Key.NumPad1, 79),
            new KeyCodeData("KP2", Key.NumPad2, 80),
            new KeyCodeData("KP3", Key.NumPad3, 81),
            new KeyCodeData("KP4", Key.NumPad4, 75),
            new KeyCodeData("KP5", Key.NumPad5, 76),
            new KeyCodeData("KP6", Key.NumPad6, 77),
            new KeyCodeData("KP7", Key.NumPad7, 71),
            new KeyCodeData("KP8", Key.NumPad8, 72),
            new KeyCodeData("KP9", Key.NumPad9, 73),
            new KeyCodeData("KP0", Key.NumPad0, 82),
            new KeyCodeData("KPDOT", Key.Decimal, 83),
            new KeyCodeData("KPENTER", Key.Enter, 96),
            new KeyCodeData("KPPLUS", Key.Add, 78),
            new KeyCodeData("KPMINUS", Key.Subtract, 74),
            new KeyCodeData("KPASTERISK", Key.Multiply, 55),
            new KeyCodeData("KPSLASH", Key.Divide, 98)
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
