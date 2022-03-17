using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class GeradorDeId
    {
        public int id = 0;

        public int GerarId()
        {
            id += 1;
            return id;
        }

    }
}
