using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Util
    {
        public static bool VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(string stringAhSerAnalisada, int tamanhoMinimo)
        {
            if (stringAhSerAnalisada.Length >= tamanhoMinimo)
                return true;
            else
                return false;
        }

        public static int VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(string opcaoInputada)
        {
            return int.TryParse(opcaoInputada, out int retorno) == true ? retorno : int.MinValue;
        }

        public static bool VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(string campoInputado)
        {
            return int.TryParse(campoInputado, out int retorno) == true ? true : false;
        }

        public static int VerificaSeOhInputDoUsuarioPertenceAhUmIntervaloEhRetornaOhValor(int opcaoInputada, int primeiraOpcao, int ultimaOpcao)
        {
            return (opcaoInputada >= primeiraOpcao && opcaoInputada <= ultimaOpcao) ? opcaoInputada : int.MinValue;
        }

        public static int ValidaAhOpcaoInputadaPeloUsuarioEmUmMenu(string opcaoInputada, int inicioMenu, int fimMenu)
        {
            int retorno = int.MinValue;

            if (VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(opcaoInputada) != int.MinValue)
            {
                if (VerificaSeOhInputDoUsuarioPertenceAhUmIntervaloEhRetornaOhValor(int.Parse(opcaoInputada), inicioMenu, fimMenu) != int.MinValue)
                    retorno = int.Parse(opcaoInputada);
            }

            return retorno;
        }

        public static void ApresentarMensagem(string mensagemAhSerApresentada, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine("\n----------------------------------------------------------------------\n");

            Console.WriteLine("\n" + mensagemAhSerApresentada + "\n");

            Console.WriteLine("\nTECLE ENTER PARA CONTINUARMOS!!\n");

            Console.WriteLine("\n----------------------------------------------------------------------\n");

            Console.ResetColor();

            Console.ReadLine();
        }

        public static int RetornaAhPosicaoLivreDeUmArray(Object[] arrayAhSerAnalisado)
        {
            int retorno = int.MinValue;

            for (int i = 0; i < arrayAhSerAnalisado.Length; i++)
            {
                if (arrayAhSerAnalisado[i] == null)
                {
                    retorno = i;
                    break;
                }
            }
            return retorno;
        }

        public static bool PedeConfirmacaoDoUsuario(string confirmacao)
        {
            if (confirmacao == "s" || confirmacao == "S")
                return true;
            else
                return false;
        }

        public static DateTime VerificaSeUmaStringEhUmDateTimeEhRetornaOhvalor(string data)
        {
            DateTime retorno = new DateTime(1, 1, 1);

            if (DateTime.TryParse(data, out retorno) == true)
                return retorno;
            else
                return retorno;
        }

    }
}
