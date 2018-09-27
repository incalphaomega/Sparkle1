using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sparkle.Handlers;
using Sparkle.GUI;

using static Sparkle.Handlers.KeysStroke;

namespace Sparkle
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static ContentManager content;

        public static SpriteFont consoleFont;

        TextBox textBox;
        TextBox textBox2;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            textBox = new TextBox(new Vector2(200));
            textBox2 = new TextBox(new Vector2(200, 230));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            consoleFont = ContentLoader.Load<SpriteFont>("Console");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            consoleFont.Spacing = 1;

            TextBox.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeysStroke.Update();

            if (keyPressed(Keys.Escape))
            {
                Exit();
            }

            textBox.Update();
            textBox2.Update();

            KeysStroke.oldUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            textBox.Draw(spriteBatch, gameTime);
            textBox2.Draw(spriteBatch, gameTime);

            spriteBatch.End();

            base.Draw(gameTime);

            
        }
    }
}
