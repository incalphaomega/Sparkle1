using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sparkle.Handlers;
using static Sparkle.Handlers.KeysStroke;

namespace Sparkle
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static ContentManager content;

        public static SpriteFont consoleFont;

        TextInput text;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
        }

        protected override void Initialize()
        {
            text = new TextInput(new Vector2(5));
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

            text.Update();
            привет Иришка

            KeysStroke.oldUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            text.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
