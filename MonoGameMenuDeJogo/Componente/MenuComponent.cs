using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace MonoGameMenuDeJogo
{
    public class MenuComponent : DrawableGameComponent
    {
        readonly SpriteBatch _spriteBatch;
        readonly List<Botao> _botoes;

        public MenuComponent(Game game, SpriteBatch spriteBatch, List<Botao> botoes) : base(game)
        {
            _spriteBatch = spriteBatch;
            _botoes = botoes;

            SetaPosicaoBotoes();
        }

        private void SetaPosicaoBotoes()
        {
            for (int i = 0; i < _botoes.Count; i++)
            {
                int x = (int)((GraphicsDevice.Viewport.Width - _botoes[i].RetanguloOrigem.Width) * 0.5);
                int y = _botoes[i].RetanguloOrigem.Height * i + 100;

                _botoes[i].Posicao = new Rectangle(x, y, _botoes[i].Textura.Width / 2, _botoes[i].Textura.Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            TouchCollection touchLocations = TouchPanel.GetState();

            if (touchLocations.Count > 0 && touchLocations[0].State == TouchLocationState.Released)
            {
                var limiteDoTouch = new Rectangle(touchLocations[0].Position.ToPoint(), Point.Zero);

                foreach (var botao in _botoes)
                {
                    botao.EstadoDoBotao = EstadoBotao.Normal;

                    // Verifica sobre qual botão o touch ocorre
                    if (limiteDoTouch.Intersects(botao.Posicao))
                    {
                        botao.EstadoDoBotao = EstadoBotao.Clicado;
                        botao.AcaoClick();
                    }

                    botao.Update();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            foreach (var botao in _botoes)
                _spriteBatch.Draw(botao.Textura, botao.Posicao, botao.RetanguloOrigem, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}