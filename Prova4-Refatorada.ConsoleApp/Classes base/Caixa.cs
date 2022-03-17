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

        public void GuardarRevista(Revista revistaAhSerGuardada)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(revistasGuardadasAtualmente);
            revistasGuardadasAtualmente[posicaoLivre] = revistaAhSerGuardada;
        }

        public void RetirarRevista(Revista revistaAhSerRetirada)
        {
            for (int i = 0; i < revistasGuardadasAtualmente.Length; i++)
            {
                if (revistasGuardadasAtualmente[i] != null && revistasGuardadasAtualmente[i] == revistaAhSerRetirada)
                {
                    revistasGuardadasAtualmente[i].estaEmprestada = true;
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
            Console.Write("\nQuantidade de revistas guardadas atualmente: {0}\n", VerificSeACaixaPossuiAlgumaRevistaEmprestada());
        }

        public bool VerificSeACaixaPossuiAlgumaRevistaEmprestada()
        {
            bool retorno = false;
            
            for (int i = 0; i < revistasGuardadasAtualmente.Length; i++)
            {
                if(revistasGuardadasAtualmente[i] != null && revistasGuardadasAtualmente[i].estaEmprestada == true)
                {
                    retorno = true;

                    break;
                }
            }
            return retorno;
        }

        public void MostrarTodosOsDados()
        {
            Console.WriteLine("\nID: {0}", id);
            Console.WriteLine("\nEtiqueta: {0}", etiqueta);
            Console.WriteLine("\nCor: {0}", cor);
            Console.WriteLine("\nNúmero: {0}", numero);
        }
    }
}