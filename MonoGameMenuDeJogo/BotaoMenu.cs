using System;

namespace MonoGameMenuDeJogo
{
    public class BotaoMenu : Botao
    {
        public override void AcaoClick()
        {
            Console.WriteLine("*** BOTÃO MENU CLICADO! ***");
        }
    }
}