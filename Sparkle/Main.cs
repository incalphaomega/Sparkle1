using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sparkle.Handlers;
using Sparkle.GUI;

using static Sparkle.Handlers.Input;
using System.Collections.Generic;
using System;

namespace Sparkle
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static ContentManager content;

        public static SpriteFont consoleFont;

        public static List<string> info;

        TextBox textBox;
        ItemCase item;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            textBox = new TextBox(new Vector2(200));
            item = new ItemCase(new Vector2(200));

            info = new List<string>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            consoleFont = ContentLoader.Load<SpriteFont>("Console");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            consoleFont.Spacing = 1;

            TextBox.LoadContent();
            ItemCase.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            if (keyPressed(Keys.Escape))
            {
                Exit();
            }

            textBox.Update();
            item.Update();


            Input.oldUpdate();
            base.Update(gameTime);
        }

        int i;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            textBox.Draw(spriteBatch, gameTime);
            item.Draw(spriteBatch);

            i = 0;
            foreach (var s in info)
            {
                spriteBatch.DrawString(consoleFont, s, new Vector2(5, 0 + consoleFont.MeasureString("W").Y * i), Color.White);
                i++;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
