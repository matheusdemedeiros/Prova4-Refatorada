using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaMenuPrincipal
    {
        public string opcaoEscolhida = "";
        public int inicioMenu = 0, fimMenu = 4, opcaoEmNumero = int.MinValue;
        public bool telaContinuaSendoExibida = true;
        public TelaGerenciamentoDeRevistas gerenciamentoDeRevistas; 
        public TelaGerenciamentoDeCaixas gerenciamentoDeCaixas;
        public TelaGerenciamentoDeAmigos gerenciamentoDeAmigos;
        public TelaGerenciamentoDeEmprestimos gerenciamentoDeEmprestimos;
       

        public void ApresentarMenu()
        {
            while (telaContinuaSendoExibida)
            {
                Console.Clear();
                Console.WriteLine("\n====== MENU PRINCIPAL ======");
                Console.WriteLine("\n * Digite 0 para sair;");
                Console.WriteLine("\n * Digite 1 para acessar o gerenciamento de revistas;");
                Console.WriteLine("\n * Digite 2 para acessar o gerenciamento de caixas;");
                Console.WriteLine("\n * Digite 3 para acessar o gerenciamento de amigos;");
                Console.WriteLine("\n * Digite 4 para acessar o gerenciamento de empréstimos;");
                Console.Write("\nSua escolha: ");
                opcaoEscolhida = Console.ReadLine();
                opcaoEmNumero = Util.ValidaAhOpcaoInputadaPeloUsuarioEmUmMenu(opcaoEscolhida, inicioMenu, fimMenu);
                ExecutarAcao();
            }
        }

        public void ExecutarAcao()
        {
            switch (opcaoEmNumero)
            {
                case 0:
                    Util.ApresentarMensagem("SISTEMA ENCERRADO COM SUCESSO!! OBRIGADO PELA PREFFERÊNCIA!!", ConsoleColor.Yellow);
                    telaContinuaSendoExibida = false;
                    break;
                case 1:
                    gerenciamentoDeRevistas.ApresentarMenu();
                    break;
                case 2:
                    gerenciamentoDeCaixas.ApresentarMenu();
                    break;
                case 3:
                    gerenciamentoDeAmigos.ApresentarMenu();
                    break;
                case 4:
                    gerenciamentoDeEmprestimos.ApresentarMenu();
                    break;
                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!!DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }

    }
}
