using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaGerenciamentoDeEmprestimos
    {
        public string opcaoEscolhida = "", idRevistaInput = "", idAmigoInput = "", idEmprestimoInput = "", dataAberturaInput = "";
        public int inicioMenu = 0, fimMenu = 7, opcaoEmNumero = int.MinValue;
        public bool telaContinuaSendoExibida = true, abortarProcesso = false, revistaValida = false, amigoValido = false, emprestimoValido = false, dataDeAberturaValida = false;
        public DateTime dataAberturaDateTime = new DateTime(1, 1, 1);
        public Emprestimo[] emprestimos;
        public Revista[] revistas;
        public Caixa[] caixas;
        public Amigo[] amigos;
        public GeradorDeId geradorDeId;

        public void ApresentarMenu()
        {
            ResetarVariaveisDaTela();
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
                Console.WriteLine("\n * Digite 6 para excluir um empréstimo;");
                Console.WriteLine("\n * Digite 7 para editar um empréstimo;");
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
                case 6:
                    RemoverUmEmprestimo();
                    break;
                case 7:
                    EditarUmEmprestimo();
                    break;
                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!!DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }

        public void EditarUmEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("\n====== EDITAR UM EMPRÉSTIMO ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id do empréstimo que deseja editar: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Emprestimo emprestimoRetornado = null;

                            emprestimoRetornado = RetornaUmEmprestimoDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (emprestimoRetornado == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTE É O EMPRÉSTIMO A SER EDITADO ===\n");

                                emprestimoRetornado.MostrarDados();

                                Console.Write("\nVOCÊ CONFIRMA A DEVOLUÇÃO? (S/N): ");

                                bool confirmaEdicao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaEdicao == true)
                                {
                                    PedeOsDadosDoEmprestimo();

                                    emprestimoRetornado.dataDoEmprestimo = dataAberturaDateTime;

                                    Util.ApresentarMensagem("EMPRÉSTIMO EDITADO COM SUCESSO!!", ConsoleColor.Green);
                                }
                                else
                                {
                                    Util.ApresentarMensagem("EDIÇÃOO NÃO CONFIRMADA!!", ConsoleColor.Yellow);
                                }
                            }
                        }
                        else
                            Util.ApresentarMensagem("ENTRADA INVÁLIDA!!", ConsoleColor.Red);

                    } while (idInputadoValido == false);
                }
                if (abortarProcesso == true)
                {
                    Util.ApresentarMensagem("VOCÊ ABORTOU A EDIÇÃO!!", ConsoleColor.DarkCyan);
                }
            }
        }

        public void RemoverUmEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("\n====== REMOVER UM EMPRÉSTIMO ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id do empréstimo que deseja remover: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Emprestimo emprestimoRetornado = null;

                            emprestimoRetornado = RetornaUmEmprestimoDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (emprestimoRetornado == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTE É O EMPRÉSTIMO A SER REMOVIDO ===\n");

                                emprestimoRetornado.MostrarDados();

                                Console.Write("\nVOCÊ CONFIRMA A DEVOLUÇÃO? (S/N): ");

                                bool confirmaRemocao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaRemocao == true)
                                {
                                    if (emprestimoRetornado.status == "devolvido")
                                    {
                                        emprestimoRetornado.revistaDoEmprestimo.RemoverEmprestimoDoArray(emprestimoRetornado);

                                        emprestimoRetornado.amigoQueEmprestou.RemoverEmprestimoDoArray(emprestimoRetornado);

                                        RemoverEmprestimoDoArray(emprestimoRetornado);

                                        Util.ApresentarMensagem("EMPRÉSTIMO REMOVIDO COM SUCESSO!!", ConsoleColor.Green);
                                    }
                                    else
                                    {
                                        Util.ApresentarMensagem("EMPRÉSTIMO NÃ OPODE SER REMOVIDO, POIS ESTÁ EM ABERTO!!", ConsoleColor.Green);
                                    }
                                }
                                else
                                {
                                    Util.ApresentarMensagem("REMOÇÃO NÃO CONFIRMADA!!", ConsoleColor.Yellow);
                                }
                            }
                        }
                        else
                            Util.ApresentarMensagem("ENTRADA INVÁLIDA!!", ConsoleColor.Red);

                    } while (idInputadoValido == false);
                }
                if (abortarProcesso == true)
                {
                    Util.ApresentarMensagem("VOCÊ ABORTOU A REMOÇÃO!!", ConsoleColor.DarkCyan);
                }
            }
        }

        public void ListarTodosOsEmprestimos()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS ======");

            if (VerificaSeOhArrayDeEmprestimosEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < emprestimos.Length; i++)
                {
                    if (emprestimos[i] != null)
                        emprestimos[i].MostrarDados();
                }

                Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void ListarTodosOsEmprestimosEmAberto()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS EM ABERTO ======");

            if (VerificaSeOhArrayDeEmprestimosEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                int quantidadeDeEmprestimosEmAberto = 0;

                for (int i = 0; i < emprestimos.Length; i++)
                {
                    if (emprestimos[i] != null && emprestimos[i].status == "aberto")
                    {
                        emprestimos[i].MostrarDados();
                        quantidadeDeEmprestimosEmAberto++;
                    }
                }
                if (quantidadeDeEmprestimosEmAberto == 0)
                    Util.ApresentarMensagem("NÃO EXISTEM EMPRÉSTIMOS EM ABERTO!!", ConsoleColor.Yellow);
                else
                    Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void ListarTodosOsEmprestimosDoMes()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS EMPRÉSTIMOS DO MÊS ======");

            if (VerificaSeOhArrayDeEmprestimosEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                int quantidadeDeEmprestimosDoMes = 0;

                DateTime hoje = DateTime.Today;

                for (int i = 0; i < emprestimos.Length; i++)
                {
                    if (emprestimos[i] != null && emprestimos[i].dataDoEmprestimo.Month == hoje.Month)
                    {
                        emprestimos[i].MostrarDados();
                        quantidadeDeEmprestimosDoMes++;
                    }
                }
                if (quantidadeDeEmprestimosDoMes == 0)
                    Util.ApresentarMensagem("NÃO FORAM REALIZADOS EMPRÉSTIMOS NO MÊS ATUAL!!", ConsoleColor.Yellow);
                else
                    Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void FecharEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("\n====== FECHAR/DEVOLVER UM EMPRÉSTIMO ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM EMPRÉSTIMOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id do empréstimo que deseja fechar/devolver: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Emprestimo emprestimoRetornado = null;

                            emprestimoRetornado = RetornaUmEmprestimoDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (emprestimoRetornado == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTE É O EMPRÉSTIMO A SER FECHADO ===\n");

                                emprestimoRetornado.MostrarDados();

                                Console.Write("\nVOCÊ CONFIRMA A DEVOLUÇÃO? (S/N): ");

                                bool confirmaDevolucao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaDevolucao == true)
                                {
                                    emprestimoRetornado.Devolver();

                                    Util.ApresentarMensagem("EMPRÉSTIMO DEVOLVIDO COM SUCESSO!!", ConsoleColor.Green);
                                }
                                else
                                    Util.ApresentarMensagem("DEVOLUÇÃO NÃO CONFIRMADA!!", ConsoleColor.Yellow);
                            }
                        }
                        else
                            Util.ApresentarMensagem("ENTRADA INVÁLIDA!!", ConsoleColor.Red);

                    } while (idInputadoValido == false);
                }
                if (abortarProcesso == true)
                {
                    Util.ApresentarMensagem("VOCÊ ABORTOU A DEVOLUÇÃO!!", ConsoleColor.DarkCyan);
                }
            }
        }

        public void CadastrarEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("\n====== CADASTRAR UM EMPRÉSTIMO ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- EM QUALQUER UM DOS CAMPOS!!");

            if (VerificaSeOhArrayDeRevistasEstaVazio() == false && VerificaSeOhArrayDeAmigosEstaVazio() == false)
            {
                Revista revistaRetornada = null;

                Amigo amigoRetornado = null;

                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nInforme o Id da revista a ser emprestada: ");

                        idRevistaInput = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(idRevistaInput))
                        {
                            Util.ApresentarMensagem("VOCE ABORTOU O PROCESSO!!", ConsoleColor.DarkCyan);
                            break;
                        }
                        else
                        {
                            int idRevistaEmNumero = Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(idRevistaInput);

                            revistaRetornada = RetornaUmaRevistaDoArrayPeloId(idRevistaEmNumero);

                            if (revistaRetornada != null)
                                revistaValida = true;
                            else
                                Util.ApresentarMensagem("REVISTA NÃO ENCONTRADA!!", ConsoleColor.Yellow);
                        }
                    } while (revistaValida == false);
                }

                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nInforme o Id do amigo que realizará o empréstimo: ");

                        idAmigoInput = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(idAmigoInput))
                        {
                            Util.ApresentarMensagem("VOCE ABORTOU O PROCESSO!!", ConsoleColor.DarkCyan);
                            break;
                        }
                        else
                        {
                            int idAmigoEmNumero = Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(idAmigoInput);

                            amigoRetornado = RetornaUmAmigoDoArrayPeloId(idAmigoEmNumero);

                            if (amigoRetornado != null)
                                amigoValido = true;
                            else
                                Util.ApresentarMensagem("AMIGO NÃO ENCONTRADO!!", ConsoleColor.Yellow);
                        }
                    } while (amigoValido == false);
                }

                if (abortarProcesso == false)
                {
                    if (revistaRetornada != null && amigoRetornado != null)
                    {
                        PedeOsDadosDoEmprestimo();

                        if (abortarProcesso != true)
                        {
                            Emprestimo emprestimo = new Emprestimo();

                            emprestimo.amigoQueEmprestou = amigoRetornado;

                            emprestimo.revistaDoEmprestimo = revistaRetornada;

                            emprestimo.dataDoEmprestimo = dataAberturaDateTime;

                            emprestimo.status = "aberto";

                            emprestimo.id = geradorDeId.GerarId();

                            emprestimo.Emprestar();

                            AdicionarEmprestimoNoArray(emprestimo);

                            Util.ApresentarMensagem("EMPRÉSTIMO CADASTRADO COM SUCESSO!!", ConsoleColor.Green);
                        }
                        else
                        {
                            Util.ApresentarMensagem("VOCÊ ABORTOU O PROCESSO!!", ConsoleColor.DarkCyan);
                        }

                    }
                }
            }
            else
                Util.ApresentarMensagem("O SISTEMA NÃO POSSUI AMIGOS OU REVISTAS CADASTRADAS, PORTANTO É IMPOSSÍVEL CADASTRAR UM EMPRÉSTIMO!!", ConsoleColor.Yellow);
        }

        public void PedeOsDadosDoEmprestimo()
        {
            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite a data de abertura do empréstimo: ");

                    dataAberturaInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(dataAberturaInput))
                        break;
                    else if (Util.VerificaSeUmaStringEhUmDateTimeEhRetornaOhvalor(dataAberturaInput) != new DateTime(1, 1, 1))
                    {
                        dataDeAberturaValida = true;
                        dataAberturaDateTime = Util.VerificaSeUmaStringEhUmDateTimeEhRetornaOhvalor(dataAberturaInput);
                    }
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (dataDeAberturaValida == false);
            }
        }

        public void AdicionarEmprestimoNoArray(Emprestimo emprestimoAhSerAdicionado)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(emprestimos);

            emprestimos[posicaoLivre] = emprestimoAhSerAdicionado;
        }

        public Revista RetornaUmaRevistaDoArrayPeloId(int idRevista)
        {
            Revista retorno = null;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].id == idRevista)
                {
                    retorno = revistas[i];

                    break;
                }
            }
            return retorno;
        }

        public Amigo RetornaUmAmigoDoArrayPeloId(int idAmigo)
        {
            Amigo retorno = null;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].id == idAmigo)
                {
                    retorno = amigos[i];

                    break;
                }
            }
            return retorno;
        }

        public Emprestimo RetornaUmEmprestimoDoArrayPeloId(int idEmprestimo)
        {
            Emprestimo retorno = null;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].id == idEmprestimo)
                {
                    retorno = emprestimos[i];

                    break;
                }
            }
            return retorno;
        }

        public bool VerificaSeEhParaAbortarOhProcesso(string inputDoUsuario)
        {
            if (inputDoUsuario == "*--")
                abortarProcesso = true;
            else
                abortarProcesso = false;

            return abortarProcesso;
        }

        public void RemoverEmprestimoDoArray(Emprestimo emprestimoAhSerRemovido)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i] == emprestimoAhSerRemovido)
                {
                    emprestimos[i] = null;

                    break;
                }
            }
        }

        public bool VerificaSeOhArrayDeRevistasEstaVazio()
        {
            bool retorno = true;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    retorno = false;

                    break;
                }
            }

            return retorno;
        }

        public bool VerificaSeOhArrayDeEmprestimosEstaVazio()
        {
            bool retorno = true;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    retorno = false;

                    break;
                }
            }

            return retorno;
        }

        public bool VerificaSeOhArrayDeAmigosEstaVazio()
        {
            bool retorno = true;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    retorno = false;

                    break;
                }
            }

            return retorno;
        }

        public void ResetarVariaveisDaTela()
        {
            opcaoEscolhida = "";
            idRevistaInput = "";
            idAmigoInput = "";
            idEmprestimoInput = "";
            dataAberturaInput = "";
            opcaoEmNumero = int.MinValue;
            abortarProcesso = false;
            revistaValida = false;
            amigoValido = false;
            emprestimoValido = false;
            dataDeAberturaValida = false;
            dataAberturaDateTime = new DateTime(1, 1, 1);
        }
    }
}