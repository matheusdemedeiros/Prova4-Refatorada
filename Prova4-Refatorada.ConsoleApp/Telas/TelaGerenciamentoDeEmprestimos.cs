using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaGerenciamentoDeEmprestimos
    {
        public string opcaoEscolhida = "";
        public int inicioMenu = 0, fimMenu = 5, opcaoEmNumero = int.MinValue;
        public bool telaContinuaSendoExibida = true;
        public Emprestimo[] emprestimos;
        public Revista[] revistas;
        public Caixa[] caixas;
        public Amigo[] amigos;
        public GeradorDeId geradorDeId;

        public void ApresentarMenu()
        {
            while (telaContinuaSendoExibida)
            {
                Console.Clear();
                Console.WriteLine("\n====== GERENCIAMENTO DE EMPRÉSTIMOS ======");
                Console.WriteLine("\n * Digite 0 para voltar ao menu anterior;");
                Console.WriteLine("\n * Digite 1 para cadastrar um novo empréstimo;");
                Console.WriteLine("\n * Digite 2 para fechar um empréstimo (devolver);");
                Console.WriteLine("\n * Digite 3 para listar todos os empréstimos;");
                Console.WriteLine("\n * Digite 4 para listar todos os empréstimos do mês;");
                Console.WriteLine("\n * Digite 5 para listar todos os empréstimos em aberto;");
                Console.Write("\nSua escolha: ");
                opcaoEscolhida = Console.ReadLine();
                opcaoEmNumero = Util.ValidaAhOpcaoInputadaPeloUsuarioEmUmMenu(opcaoEscolhida, inicioMenu, fimMenu);
                ExecutarAcao();
            }
            telaContinuaSendoExibida = true;
        }

        public void ExecutarAcao()
        {
            switch (opcaoEmNumero)
            {
                case 0:
                    telaContinuaSendoExibida = false;
                    break;
                case 1:
                    CadastrarEmprestimo();
                    break;
                case 2:
                    FecharEmprestimo();
                    break;
                case 3:
                    ListarTodosOsEmprestimos();
                    break;
                case 4:
                    ListarTodosOsEmprestimosDoMes();
                    break;
                case 5:
                    ListarTodosOsEmprestimosEmAberto();
                    break;
                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!!DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }

        public void ListarTodosOsEmprestimos()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS ======");

            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(emprestimos);

            if (posicaoLivre == 0)
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < posicaoLivre; i++)
                {
                    emprestimos[i].MostrarDados();
                }

                Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void ListarTodosOsEmprestimosEmAberto()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS EM ABERTO ======");

            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(emprestimos);

            if (posicaoLivre == 0)
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                int quantidadeDeEmprestimosAbertos = 0;

                for (int i = 0; i < posicaoLivre; i++)
                {
                    if (emprestimos[i].status == "aberto")
                    {
                        emprestimos[i].MostrarDados();
                        quantidadeDeEmprestimosAbertos++;
                    }
                }
                if (quantidadeDeEmprestimosAbertos == 0)
                    Util.ApresentarMensagem("NÃO EXISTEM EMPRÉSTIMOS EM ABERTO NO SISTEMA!!", ConsoleColor.Yellow);
            }
        }

        public void ListarTodosOsEmprestimosDoMes()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS DO MÊS ======");

            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(emprestimos);

            if (posicaoLivre == 0)
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                int quantidadeDeEmprestimosDoMes = 0;

                DateTime hoje = DateTime.Today;

                for (int i = 0; i < posicaoLivre; i++)
                {
                    if (emprestimos[i].dataDoEmprestimo.Month == hoje.Month)
                    {
                        emprestimos[i].MostrarDados();
                        quantidadeDeEmprestimosDoMes++;
                    }
                }
                if (quantidadeDeEmprestimosDoMes == 0)
                    Util.ApresentarMensagem("NÃO FORAM REALIZADOS EMPRÉSTIMOS NO MÊS ATUAL!!", ConsoleColor.Yellow);
            }
        }

        private void FecharEmprestimo()
        {
            throw new NotImplementedException();
        }

        private void CadastrarEmprestimo()
        {
            throw new NotImplementedException();
        }
    }
}