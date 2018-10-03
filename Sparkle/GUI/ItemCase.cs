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
    class ItemCase
    {
        static Texture2D texture;
        Vector2 position;
        Rectangle rect;

        string item;
        string info;


        public ItemCase(Vector2 position)
        {
            this.position = position;
            item = "Пустая ячейка";
            rect = new Rectangle();
        }
        public static void LoadContent()
        {
            texture = ContentLoader.Load<Texture2D>("Textures/GUI/ItemCase");
        }

        public void Update()
        {
            rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            showInfo();
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(texture, position, Color.White);
            s.DrawString(Main.consoleFont, info, position, Color.Black);
        }

        public void putItemIn()
        {

        }
        public void replaceItame()
        {

        }
        //public string getItame() {}
        public void replaceItem()
        {

        }
        public void showInfo()
        {
            if (rect.Contains(Input.mousePoint))
            {
                info = item;
            }
            else
            {
                info = "";
            }
        }
    }
}
