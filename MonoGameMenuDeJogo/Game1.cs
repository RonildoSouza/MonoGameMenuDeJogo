using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonoGameMenuDeJogo
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        readonly BotaoPlay _botaoPlay = new BotaoPlay();
        readonly BotaoMenu _botaoMenu = new BotaoMenu();
        readonly BotaoExit _botaoExit = new BotaoExit();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _botaoPlay.LoadContent(Content, "botao-play");
            _botaoMenu.LoadContent(Content, "botao-menu");
            _botaoExit.LoadContent(Content, "botao-exit");

            var botoes = new List<Botao> { _botaoPlay, _botaoMenu, _botaoExit };
            var menuComponent = new MenuComponent(this, spriteBatch, botoes);

            Components.Add(menuComponent);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
