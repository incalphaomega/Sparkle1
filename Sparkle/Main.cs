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

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
        }

        protected override void Initialize()
        {
            textBox = new TextBox(new Vector2(200,200));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            consoleFont = ContentLoader.Load<SpriteFont>("Console");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            consoleFont.Spacing = 1;
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

            KeysStroke.oldUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            textBox.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
