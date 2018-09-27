using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

using static Sparkle.Handlers.Input;

namespace Sparkle.GUI
{
    class TextBox
    {
        Vector2 position;
        Vector2 caretVPos;
        static Texture2D caretTex;
        Rectangle textRect;

        StringBuilder text;

        public enum Layout { ruRU = 1049, enUS = 1033 }
        Layout currentLayout;

        int caretPos;
        bool isActive;
        bool isMultiline;

        public TextBox(Vector2 position)
        {
            this.position = position;
            caretVPos = position;
            text = new StringBuilder();
            isActive = true;
            textRect = new Rectangle();
        }

        public static void LoadContent()
        {
            caretTex = Handlers.ContentLoader.Load<Texture2D>("Textures/GUI/textCursor");
        }

        public void Update()
        {
            currentLayout = (Layout)InputLanguage.CurrentInputLanguage.Culture.KeyboardLayoutId;

            textRect = new Rectangle((int)position.X, (int)position.Y, (int)Main.consoleFont.MeasureString(text).X,(int)Main.consoleFont.MeasureString(text).Y);
            if (buttonPressed(Buttons.Left))
            {
                if (textRect.Contains(new Point(MState.X, MState.Y)))
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }
            }

            if (isActive)
            {
                textEdit();
                if (isKeyUp(Keys.LeftControl))
                {
                    textInput();
                }

                if (text.Length > 0)
                {
                    caretVPos.X = position.X + Main.consoleFont.MeasureString(text.ToString().Substring(0, caretPos)).X;
                }
                else
                {
                    caretVPos.X = position.X;
                }
            }
        }

        public void Draw(SpriteBatch s, GameTime time)
        {
            s.DrawString(Main.consoleFont, text, position, Color.Black);
            if (isActive)
            {
                if (isSelect)
                {
                    s.DrawString(Main.consoleFont, selectedText, new Vector2(position.X + Main.consoleFont.MeasureString(text.ToString().Substring(0, firstChar)).X, position.Y), Color.White);
                }
                animateCaret(s, time);
            }
        }

        public void textEdit()
        {
            if (text.Length > 0)
            {
                if (keyPressed(Keys.Left))
                {
                    if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
                    {
                        if (!isSelect)
                        {
                            secondChar = caretPos;
                        }
                        caretPos--;
                        isSelect = true;
                        if (caretPos < 0)
                        {
                            caretPos = 0;
                        }
                        firstChar = caretPos;
                        selectedText = text.ToString().Substring(firstChar, secondChar - firstChar);
                    }
                    else
                    {
                        caretPos--;
                        if (caretPos < 0)
                        {
                            caretPos = 0;
                        }
                        isSelect = false;
                        selectedText = "";
                    }
                }
                else if (keyPressed(Keys.Right))
                {
                    if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
                    {
                        if (!isSelect)
                        {
                            firstChar = caretPos;
                        }
                        caretPos++;
                        isSelect = true;
                        if (caretPos > text.Length)
                        {
                            caretPos = text.Length;
                        }
                        secondChar = caretPos;
                        selectedText = text.ToString().Substring(firstChar, secondChar - firstChar);
                    }
                    else
                    {
                        caretPos++;
                        if (caretPos > text.Length)
                        {
                            caretPos = text.Length;
                        }
                        isSelect = false;
                        selectedText = "";
                    }
                }
                else if (keyPressed(Keys.Home))
                {
                    caretPos = 0;
                    isSelect = false;
                }
                else if (keyPressed(Keys.End))
                {
                    caretPos = text.Length;
                    isSelect = false;
                }
                else if (keyPressed(Keys.Back))
                {
                    if (caretPos >= 0)
                    {
                        if (!isSelect)
                        {
                            text.Remove(caretPos - 1, 1);
                            caretPos--;
                        }
                        else
                        {
                            if (caretPos == text.Length)
                            {
                                text.Remove(firstChar, secondChar - firstChar);
                                isSelect = false;
                                selectedText = "";
                                caretPos = firstChar;
                            }
                            else
                            {
                                text.Remove(firstChar, secondChar - firstChar);
                                isSelect = false;
                                selectedText = "";
                            }
                        }
                    }
                }
                else if (keyPressed(Keys.Delete))
                {
                    if (isSelect)
                    {
                        selectedText = "";
                        text.Remove(firstChar, secondChar - firstChar);
                        if (caretPos > text.Length)
                        {
                            caretPos = text.Length;
                        }
                        isSelect = false;
                    }
                    else
                    {
                        if (caretPos != text.Length)
                        {
                            text.Remove(caretPos, 1);
                        }
                    }
                }
            }

            if (isKeyDown(Keys.LeftControl) || isKeyDown(Keys.RightControl))
            {
                if (keyPressed(Keys.C))
                {
                    if (isSelect)
                    {
                        Clipboard.SetText(selectedText);
                    }
                }
                else if (keyPressed(Keys.V))
                {
                    if (isSelect)
                    {
                        text.Remove(firstChar, secondChar - firstChar);
                        selectedText = "";
                        isSelect = false;
                        text.Insert(caretPos, Clipboard.GetText());
                        caretPos += Clipboard.GetText().Length;
                    }
                    else
                    {
                        text.Insert(caretPos, Clipboard.GetText());
                        caretPos += Clipboard.GetText().Length;
                    }
                }
                else if (isKeyDown(Keys.Back))
                {
                    if (text.Length > 0)
                    {
                        text.Remove(caretPos - 1, 1);
                        caretPos--;
                        if (caretPos < 0)
                        {
                            caretPos = 0;
                        }
                    }
                }
                else if (isKeyDown(Keys.Delete))
                {
                    if (text.Length > 0)
                    {
                        if (caretPos != text.Length)
                        {
                            text.Remove(caretPos, 1);
                        }
                    }
                }
                else if (keyPressed(Keys.A))
                {
                    selectedText = text.ToString();
                    isSelect = true;
                    firstChar = 0;
                    secondChar = text.Length;
                }
            }

            if (keyPressed(Keys.Space))
            {
                text.Insert(caretPos, " ");
                caretPos++;
            }
        }

        public void textInput()
        {
            if (KState.GetPressedKeys().Length > 0)
            {
                foreach (Keys key in KState.GetPressedKeys())
                {
                    if (keyPressed(key))
                    {
                        int k = (int)key;
                        if (k >= 48 && k <= 57 || k >= 65 && k <= 90 || k >= 96 && k <= 107 || k >= 109 && k <= 111 || k >= 186 && k <= 192 || k >= 219 && k <= 222)
                        {
                            if (isSelect)
                            {
                                text.Remove(firstChar, secondChar - firstChar);
                                isSelect = false;
                                selectedText = "";
                                caretPos = firstChar;
                            }
                            if (KState.CapsLock)
                            {
                                if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
                                {
                                    text.Insert(caretPos, getAlterSymbol(key).ToLower());
                                    caretPos++;
                                }
                                else
                                {
                                    text.Insert(caretPos, getSymbol(key).ToUpper());
                                    caretPos++;
                                }
                            }
                            else
                            {
                                if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
                                {
                                    text.Insert(caretPos, getAlterSymbol(key));
                                    caretPos++;
                                }
                                else
                                {
                                    text.Insert(caretPos, getSymbol(key));
                                    caretPos++;
                                }
                            }
                        }
                    }
                }
            }
        }

        string selectedText = "";
        int firstChar, secondChar;
        bool isSelect = false;
        public void textSelect()
        {
            if (isKeyDown(Keys.LeftShift) || isKeyDown(Keys.RightShift))
            {
                if (keyPressed(Keys.Left))
                {
                    if (!isSelect)
                    {
                        firstChar = caretPos;
                    }
                    caretPos--;
                    secondChar = caretPos;
                    selectedText = text.ToString().Substring(secondChar, text.Length - firstChar);
                }
                else if (keyPressed(Keys.Right))
                {
                    if (!isSelect)
                    {
                        firstChar = caretPos;
                    }
                    caretPos++;
                    secondChar = caretPos;
                    selectedText = text.ToString().Substring(firstChar, text.Length - secondChar);
                }
            }
        }

        double elapsedTime;
        bool isVisible = true;
        public void animateCaret(SpriteBatch s, GameTime time)
        {
            elapsedTime += time.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime >= 500)
            {
                if (isVisible == true)
                {
                    isVisible = false;
                }
                else if (isVisible == false)
                {
                    isVisible = true;
                }
                elapsedTime = 0;
            }

            if (isVisible)
            {
                s.Draw(caretTex, caretVPos, new Rectangle(0, 0, caretTex.Width, caretTex.Height), Color.White, 0, Vector2.Zero, 0.2f, SpriteEffects.None, 1f);
            }
        }

        string getSymbol(Keys key)
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

        string getAlterSymbol(Keys key)
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
