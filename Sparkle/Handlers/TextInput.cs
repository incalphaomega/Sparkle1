using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using static Sparkle.Handlers.KeysStroke;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Sparkle.Handlers
{
    class TextInput
    {
        Vector2 position;

        public enum Layout
        {
            ruRU = 1049,
            enUS = 1033
        }

        Layout currentLayout;

        public string text { get; set; }

        public TextInput(Vector2 position)
        {
            this.position = position;
            text = "";
        }

        public void Update()
        {
            currentLayout = (Layout)InputLanguage.CurrentInputLanguage.Culture.KeyboardLayoutId;

            if (keyPressed(Keys.Space))
            {
                text += " ";
            }
            else if (keyPressed(Keys.Back) && text.Length > 0)
            {
                text = text.Remove(text.Length - 1);
            }
            else if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
            {
                //альтернативные символы
                foreach (Keys key in KState.GetPressedKeys())
                {
                    if (keyPressed(key))
                    {
                        if (KState.CapsLock)
                        {
                            text += getAlterSymbol(key).ToLower();
                        }
                        else
                        {
                            text += getAlterSymbol(key);
                        }
                    }
                }
            }
            else
            {
                //основные
                foreach (Keys key in KState.GetPressedKeys())
                {
                    if (keyPressed(key))
                    {
                        if (KState.CapsLock)
                        {
                            text += getSymbol(key).ToUpper();
                        }
                        else
                        {
                            text += getSymbol(key);
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch s)
        {
            s.DrawString(Main.consoleFont, text, position, Color.Black);
        }

        public string getSymbol(Keys key)
        {
            switch (key)
            {
                case Keys.OemTilde:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ё";
                        default:
                            return "`";
                    }
                case Keys.D1:
                case Keys.NumPad1:
                    return "1";
                case Keys.D2:
                case Keys.NumPad2:
                    return "2";
                case Keys.D3:
                case Keys.NumPad3:
                    return "3";
                case Keys.D4:
                case Keys.NumPad4:
                    return "4";
                case Keys.D5:
                case Keys.NumPad5:
                    return "5";
                case Keys.D6:
                case Keys.NumPad6:
                    return "6";
                case Keys.D7:
                case Keys.NumPad7:
                    return "7";
                case Keys.D8:
                case Keys.NumPad8:
                    return "8";
                case Keys.D9:
                case Keys.NumPad9:
                    return "9";
                case Keys.D0:
                case Keys.NumPad0:
                    return "0";
                case Keys.OemMinus:
                    return "-";
                case Keys.OemPlus:
                    return "=";
                case Keys.Divide:
                    return "/";
                case Keys.Multiply:
                    return "*";
                case Keys.Subtract:
                    return "-";
                case Keys.Q:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "й";
                        default:
                            return "q";
                    }
                case Keys.W:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ц";
                        default:
                            return "w";
                    }
                case Keys.E:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "у";
                        default:
                            return "e";
                    }
                case Keys.R:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "к";
                        default:
                            return "r";
                    }
                case Keys.T:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "е";
                        default:
                            return "t";
                    }
                case Keys.Y:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "н";
                        default:
                            return "y";
                    }
                case Keys.U:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "г";
                        default:
                            return "u";
                    }
                case Keys.I:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ш";
                        default:
                            return "i";
                    }
                case Keys.O:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "щ";
                        default:
                            return "o";
                    }
                case Keys.P:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "з";
                        default:
                            return "p";
                    }
                case Keys.OemOpenBrackets:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "х";
                        default:
                            return "[";
                    }
                case Keys.OemCloseBrackets:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ъ";
                        default:
                            return "]";
                    }
                case Keys.OemPipe:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "\\";
                        default:
                            return "\\";
                    }
                case Keys.Add:
                    return "+";
                case Keys.A:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ф";
                        default:
                            return "a";
                    }
                case Keys.S:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ы";
                        default:
                            return "s";
                    }
                case Keys.D:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "в";
                        default:
                            return "d";
                    }
                case Keys.F:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "а";
                        default:
                            return "f";
                    }
                case Keys.G:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "п";
                        default:
                            return "g";
                    }
                case Keys.H:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "р";
                        default:
                            return "h";
                    }
                case Keys.J:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "о";
                        default:
                            return "j";
                    }
                case Keys.K:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "л";
                        default:
                            return "k";
                    }
                case Keys.L:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "д";
                        default:
                            return "l";
                    }
                case Keys.OemSemicolon:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ж";
                        default:
                            return ";";
                    }
                case Keys.OemQuotes:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "э";
                        default:
                            return "'";
                    }
                case Keys.Z:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "я";
                        default:
                            return "z";
                    }
                case Keys.X:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ч";
                        default:
                            return "x";
                    }
                case Keys.C:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "с";
                        default:
                            return "c";
                    }
                case Keys.V:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "м";
                        default:
                            return "v";
                    }
                case Keys.B:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "и";
                        default:
                            return "b";
                    }
                case Keys.N:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "т";
                        default:
                            return "n";
                    }
                case Keys.M:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ь";
                        default:
                            return "m";
                    }
                case Keys.OemComma:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "б";
                        default:
                            return ",";
                    }
                case Keys.OemPeriod:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "ю";
                        default:
                            return ".";
                    }
                case Keys.OemQuestion:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ".";
                        default:
                            return "/";
                    }
                case Keys.Decimal:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ",";
                        default:
                            return ".";
                    }
                default:
                    return "";
            }
        }

        public string getAlterSymbol(Keys key)
        {
            switch (key)
            {
                case Keys.OemTilde:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ё";
                        default:
                            return "~";
                    }
                case Keys.D1:
                    return "!";
                case Keys.NumPad1:
                    return "1";
                case Keys.D2:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "\"";
                        default:
                            return "@";
                    }
                case Keys.NumPad2:
                    return "2";
                case Keys.D3:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "#";
                        default:
                            return "#";
                    }
                case Keys.NumPad3:
                    return "3";
                case Keys.D4:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ";";
                        default:
                            return "$";
                    }
                case Keys.NumPad4:
                    return "4";
                case Keys.D5:
                    return "%";
                case Keys.NumPad5:
                    return "5";
                case Keys.D6:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ":";
                        default:
                            return "^";
                    }
                case Keys.NumPad6:
                    return "6";
                case Keys.D7:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "?";
                        default:
                            return "&";
                    }
                case Keys.NumPad7:
                    return "7";
                case Keys.D8:
                    return "*";
                case Keys.NumPad8:
                    return "8";
                case Keys.D9:
                    return "(";
                case Keys.NumPad9:
                    return "9";
                case Keys.D0:
                    return ")";
                case Keys.NumPad0:
                    return "0";
                case Keys.OemMinus:
                    return "_";
                case Keys.OemPlus:
                    return "+";
                case Keys.Divide:
                    return "/";
                case Keys.Multiply:
                    return "*";
                case Keys.Subtract:
                    return "-";
                case Keys.Q:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Й";
                        default:
                            return "Q";
                    }
                case Keys.W:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ц";
                        default:
                            return "W";
                    }
                case Keys.E:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "У";
                        default:
                            return "E";
                    }
                case Keys.R:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "К";
                        default:
                            return "R";
                    }
                case Keys.T:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Е";
                        default:
                            return "T";
                    }
                case Keys.Y:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Н";
                        default:
                            return "Y";
                    }
                case Keys.U:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Г";
                        default:
                            return "U";
                    }
                case Keys.I:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ш";
                        default:
                            return "I";
                    }
                case Keys.O:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Щ";
                        default:
                            return "O";
                    }
                case Keys.P:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "З";
                        default:
                            return "P";
                    }
                case Keys.OemOpenBrackets:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Х";
                        default:
                            return "{";
                    }
                case Keys.OemCloseBrackets:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ъ";
                        default:
                            return "}";
                    }
                case Keys.OemPipe:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "/";
                        default:
                            return "|";
                    }
                case Keys.Add:
                    return "+";
                case Keys.A:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ф";
                        default:
                            return "A";
                    }
                case Keys.S:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ы";
                        default:
                            return "S";
                    }
                case Keys.D:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "В";
                        default:
                            return "D";
                    }
                case Keys.F:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "А";
                        default:
                            return "F";
                    }
                case Keys.G:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "П";
                        default:
                            return "G";
                    }
                case Keys.H:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Р";
                        default:
                            return "H";
                    }
                case Keys.J:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "О";
                        default:
                            return "J";
                    }
                case Keys.K:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Л";
                        default:
                            return "K";
                    }
                case Keys.L:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Д";
                        default:
                            return "L";
                    }
                case Keys.OemSemicolon:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ж";
                        default:
                            return ":";
                    }
                case Keys.OemQuotes:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Э";
                        default:
                            return "\"";
                    }
                case Keys.Z:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Я";
                        default:
                            return "Z";
                    }
                case Keys.X:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ч";
                        default:
                            return "X";
                    }
                case Keys.C:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "С";
                        default:
                            return "C";
                    }
                case Keys.V:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "М";
                        default:
                            return "V";
                    }
                case Keys.B:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "И";
                        default:
                            return "B";
                    }
                case Keys.N:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Т";
                        default:
                            return "N";
                    }
                case Keys.M:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ь";
                        default:
                            return "M";
                    }
                case Keys.OemComma:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Б";
                        default:
                            return "<";
                    }
                case Keys.OemPeriod:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return "Ю";
                        default:
                            return ">";
                    }
                case Keys.OemQuestion:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ",";
                        default:
                            return "?";
                    }
                case Keys.Decimal:
                    switch (currentLayout)
                    {
                        case Layout.ruRU:
                            return ",";
                        default:
                            return ".";
                    }
                default:
                    return "";
            }
        }
    }
}