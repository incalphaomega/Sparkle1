using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sparkle.Handlers.KeysStroke;

namespace Sparkle.Handlers
{
    class TextEditor
    {
        //редактирование строки StringBuilder
        //логика для удаления Backspace, Ctrl+Backspace
        //каретку и её анимацию
        //выделение текста
        //вставку и копирование из буфера обмена
        StringBuilder text;

        Texture2D cursor;

        public TextEditor()
        {
            text = new StringBuilder();
        }

        public void Update(StringBuilder text)
        {
            this.text = text;

            if (keyPressed(Keys.Back))
            {
                text.Remove(text.Length - 1, 1);
            }
        }


    }
}
