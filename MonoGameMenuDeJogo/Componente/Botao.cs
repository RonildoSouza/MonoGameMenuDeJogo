using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameMenuDeJogo
{
    public abstract class Botao
    {
        private int _larguraBotao;

        public Texture2D Textura;
        public Rectangle Posicao;
        public Rectangle RetanguloOrigem;
        public EstadoBotao EstadoDoBotao = EstadoBotao.Normal;

        public abstract void AcaoClick();

        public void LoadContent(ContentManager content, string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
                return;

            Textura = content.Load<Texture2D>(assetName);

            _larguraBotao = Textura.Width / 2;
            RetanguloOrigem = new Rectangle(_larguraBotao, 0, _larguraBotao, Textura.Height);
        }

        public void Update()
        {
            // Define qual parte da sprite será renderizada
            RetanguloOrigem.X = (EstadoDoBotao == EstadoBotao.Clicado) ? 0 : _larguraBotao;
        }
    }

    public enum EstadoBotao
    {
        Normal,
        Clicado
    }
}