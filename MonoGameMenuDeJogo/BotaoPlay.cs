using System;

namespace MonoGameMenuDeJogo
{
    public class BotaoPlay : Botao
    {
        public override void AcaoClick()
        {
            Console.WriteLine("*** BOTÃO START CLICADO! ***");
        }
    }
}