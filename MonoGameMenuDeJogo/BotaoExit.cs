using System;

namespace MonoGameMenuDeJogo
{
    public class BotaoExit : Botao
    {
        public override void AcaoClick()
        {
            Console.WriteLine("*** BOTÃO EXIT CLICADO! ***");
        }
    }
}