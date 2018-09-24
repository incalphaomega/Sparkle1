using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sparkle.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.GUI
{
    class TextBox
    {
        Vector2 position;
        Rectangle textRect;

        Texture2D textCursor;
        Vector2 textCursorPos;

        TextInput input;
        TextEditor edit;

        StringBuilder text;

        bool isActive;

        public TextBox(Vector2 position)
        {
            text = new StringBuilder("");

            input = new TextInput();
            edit = new TextEditor();

            isActive = false;
        }

        public void Update()
        {
            input.Update(text);
            edit.Update(text);

            textCursorPos = new Vector2(position.X + Main.consoleFont.MeasureString(text).Y, position.Y);
        }

        public void Draw(SpriteBatch s)
        {
            s.DrawString(Main.consoleFont, text, position, Color.Black);
        }
    }
}
