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

        TextInput input;
        TextEditor edit;

        StringBuilder text;

        public TextBox(Vector2 position)
        {
            text = new StringBuilder("");

            input = new TextInput();
            edit = new TextEditor();
        }

        public void Update()
        {
            input.Update(text);
            edit.Update(text);
        }

        public void Draw(SpriteBatch s)
        {
            s.DrawString(Main.consoleFont, text, position, Color.Black);
        }
    }
}
