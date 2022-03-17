using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Caixa
    {
        public int id;
        public string etiqueta;
        public string cor;
        public int numero;
        public Revista[] revistasGuardadasAtualmente = new Revista[100];

        public void GuardarRevista(Revista revistaAhSerGuqrdada)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(revistasGuardadasAtualmente);
            revistasGuardadasAtualmente[posicaoLivre] = revistaAhSerGuqrdada;
        }

        public void RetirarRevista(Revista revistaAhSerRetirada)
        {
            for (int i = 0; i < revistasGuardadasAtualmente.Length; i++)
            {
                if (revistasGuardadasAtualmente[i] == revistaAhSerRetirada)
                {
                    revistasGuardadasAtualmente[i] = null;
                    break;
                }
            }
        }






        public void MostrarIdEhEtiqueta()
        {
            Console.Write("\nID: {0}\t\tEtiqueta: {1}\n", id, etiqueta);
        }

        public void MostrarDados()
        {
            Console.Write("\nID: {0}\n", id);
            Console.Write("\nEtiqueta da caixa: {0}\n", etiqueta);
            Console.Write("\nCor da caixa: {0}\n", cor);
            Console.Write("\nNúmero: {0}\n", numero);
            Console.Write("\nQuantidade de revistas guardadas atualmente: {0}\n", RetornaAhQuantidadeDeRevistasGuardadasAtualmente());
        }


        public int RetornaAhQuantidadeDeRevistasGuardadasAtualmente()
        {
            if (Util.RetornaAhPosicaoLivreDeUmArray(revistasGuardadasAtualmente) == 0)
                return 0;
            else
            {
                return Util.RetornaAhPosicaoLivreDeUmArray(revistasGuardadasAtualmente) - 1;
            }

        }

        internal void MostrarTodosOsDados()
        {
            throw new NotImplementedException();
        }
    }
}