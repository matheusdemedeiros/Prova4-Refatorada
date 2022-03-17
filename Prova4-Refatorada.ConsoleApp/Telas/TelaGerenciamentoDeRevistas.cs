using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaGerenciamentoDeRevistas
    {

        #region Declaração de Variáveis

        public int inicioMenu = 0, fimMenu = 4, opcaoEmNumero = int.MinValue;
        public bool telaContinuaSendoExibida = true;
        public GeradorDeId geradorDeId;
        public Revista[] revistas;
        public Caixa[] caixas;
        public Emprestimo[] emprestimos;

        private bool tipoColecaoValido = false, numeroEdicaoValido = false, anoValido = false, caixaValida = false, abortarProcesso = false;
        private string opcaoEscolhida = "", tipoDaColecaoInput = "", idDaCaixaInput = "", numeroDaEdicaoInput = "", anoInput = "";

        #endregion

        #region Métodos

        public void ApresentarMenu()
        {
            while (telaContinuaSendoExibida)
            {
                ResetarVariaveisDaTela();
                Console.Clear();
                Console.WriteLine("\n====== GERENCIAMENTO DE REVISTAS ======");
                Console.WriteLine("\n * Digite 0 para voltar ao menu anterior;");
                Console.WriteLine("\n * Digite 1 para cadastrar uma revista;");
                Console.WriteLine("\n * Digite 2 para remover uma revista;");
                Console.WriteLine("\n * Digite 3 para listar todas as revistas;");
                Console.WriteLine("\n * Digite 4 para editar uma revista;");
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
                    telaContinuaSendoExibida = false;
                    break;
                case 1:
                    CadastrarUmaRevista();
                    break;
                case 2:
                    RemoverUmaRevista();
                    break;
                case 3:
                    ListarTodasAsRevistas();
                    break;
                case 4:
                    EditarUmaRevista();
                    break;

                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!!DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }
        
        public void EditarUmaRevista()
        {
            Console.Clear();

            Console.WriteLine("\n====== EDITAR UMA REVISTA ======");

            Console.WriteLine("\nPARA ABORTAR A EDIÇÂO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM AMIGOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id dda revista que deseja editar: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Revista revistaRetornada = null;

                            revistaRetornada = RetornaUmaRevistaDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (revistaRetornada == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTA É A REVISTA A SER EDITADA ===\n");

                                revistaRetornada.MostrarIdEhTipoColecao();

                                Console.Write("\nVOCÊ CONFIRMA A EDIÇÃO? (S/N): ");

                                bool confirmaEdicao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaEdicao == true)
                                {
                                    Console.WriteLine("\nINSIRA OS NOVOS DADOS PARA A REVISTA:\n");

                                    PedeTodosOsDadosDaRevista();

                                    if (tipoColecaoValido == numeroEdicaoValido && numeroEdicaoValido == anoValido && anoValido == true)
                                    {
                                        revistaRetornada.tipoDaColecao = tipoDaColecaoInput;

                                        revistaRetornada.numeroDaEdicao = int.Parse(numeroDaEdicaoInput);

                                        revistaRetornada.ano = int.Parse(anoInput);

                                        Util.ApresentarMensagem("REVISTA EDITADA COM SUCESSO!!", ConsoleColor.Green);
                                    }
                                }
                                else
                                {
                                    Util.ApresentarMensagem("EDIÇÃO NÃO CONFIRMADA!!", ConsoleColor.Yellow);
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

        public void RemoverUmaRevista()
        {
            Console.Clear();

            Console.WriteLine("\n====== REMOVENDO UMA REVISTA ======");

            Console.WriteLine("\nPARA ABORTAR A REMOÇÃO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM REVISTAS CADASTRADAS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id da revista que deseja remover: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Revista revistaRetornada = null;

                            revistaRetornada = RetornaUmaRevistaDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (revistaRetornada == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTA É A REVISTA A SER REMOVIDA ===\n");

                                revistaRetornada.MostrarIdEhTipoColecao();

                                Console.Write("\nVOCÊ CONFIRMA A REMOÇÃO? (S/N): ");

                                bool confirmaRemocao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaRemocao == true)
                                {
                                    if (revistaRetornada.EstaEmprestada == true)
                                        Util.ApresentarMensagem("ESTA REVSTA NÃO PODE SER REMOVIDA, POIS TEM EMPRÉSTIMOS EM ABERTO!!", ConsoleColor.Red);
                                    else
                                    {
                                        ApagaTodosOsEmprestimosDeUmaRevista(revistaRetornada);

                                        RemoverRevistaDoArray(revistaRetornada);

                                        Util.ApresentarMensagem("A REVISTA FOI REMOVIDA COM SUCESSO, ASSIM COMO OS SEUS EMPRÉSTIMOS!!", ConsoleColor.Green);
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

        public void ListarTodasAsRevistas()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODAS AS REVISTAS ======");

            if (VerificaSeOhArrayDeRevistasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM REVISTAS CADASTRADAS!!", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < revistas.Length; i++)
                {
                    if (revistas[i] != null)
                        revistas[i].MostrarTodosOsDados();
                }

                Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void CadastrarUmaRevista()
        {
            Console.Clear();

            Console.WriteLine("\n====== CADASTRAR UMA REVISTA ======");

            Console.WriteLine("\nLEMBRANDO QUE SÓ PODEM SER REMOVIDAS AS REVISTAS QUE NÃO ESTÃO EMPRESTADAS!!");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- EM QUALQUER UM DOS CAMPOS!!");

            if (VerificaSeOhArrayDeCaixasEstaVazio() == false)
            {
                Console.Write("\nInforme o Id da caixa que irá guardar a evista: ");

                idDaCaixaInput = Console.ReadLine();

                int idCaixaEmNumero = Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(idDaCaixaInput);

                Caixa caixaRetornada = null;

                caixaRetornada = RetornaUmaCaixaDoArrayPeloId(idCaixaEmNumero);

                if (caixaRetornada != null)
                {
                    caixaValida = true;

                    PedeTodosOsDadosDaRevista();

                    if (abortarProcesso == true)
                        Util.ApresentarMensagem("VOCÊ ABORTOU O CADASTRO!!", ConsoleColor.DarkCyan);
                    else
                    {
                        if (tipoColecaoValido == numeroEdicaoValido && numeroEdicaoValido == anoValido && anoValido == caixaValida && caixaValida == true)
                        {
                            Revista revista = new Revista();

                            revista.id = geradorDeId.GerarId();

                            revista.tipoDaColecao = tipoDaColecaoInput;

                            revista.numeroDaEdicao = int.Parse(numeroDaEdicaoInput);

                            revista.ano = int.Parse(anoInput);

                            revista.caixaQueContemAhResvista = caixaRetornada;

                            bool adicionou = AdicionarRevistaNoArray(revista);

                            caixaRetornada.GuardarRevista(revista);

                            if (adicionou == true)
                                Util.ApresentarMensagem("REVISTA CADASTRADA COM SUCESSO!!", ConsoleColor.Green);
                            else
                                Util.ApresentarMensagem("FALHA AO CADASTRAR REVISTA!!", ConsoleColor.Red);
                        }
                    }
                }
                else
                {
                    Util.ApresentarMensagem("CAIXA NÃO ENCONTRADA!!", ConsoleColor.Yellow);
                }
            }
            else
            {
                Util.ApresentarMensagem("AINDA NÃO EXISTEM CAIXAS CADASTRADAS, PORTANTO NÃO PODEMOS CADASTRAR REVISTAS!!", ConsoleColor.Yellow);
            }
        }

        public void PedeTodosOsDadosDaRevista()
        {
            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o tipo da coleção com no mínimo 3 caracteres: ");

                    tipoDaColecaoInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(tipoDaColecaoInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(tipoDaColecaoInput, 3) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(tipoDaColecaoInput) == false)
                        tipoColecaoValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (tipoColecaoValido == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o número da edição: ");

                    numeroDaEdicaoInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(numeroDaEdicaoInput))
                        break;
                    else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(numeroDaEdicaoInput) > 0)
                        numeroEdicaoValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (numeroEdicaoValido == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o ano da revista: ");

                    anoInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(anoInput))
                        break;
                    else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(anoInput) > 0)
                        anoValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (anoValido == false);
            }
        }

        public bool VerificaSeEhParaAbortarOhProcesso(string inputDoUsuario)
        {
            if (inputDoUsuario == "*--")
                abortarProcesso = true;
            else
                abortarProcesso = false;

            return abortarProcesso;
        }

        public void ApagaTodosOsEmprestimosDeUmaRevista(Revista revistaRetornada)
        {
            for (int i = 0; i < revistaRetornada.emprestimosVinculados.Length; i++)
            {
                if (revistaRetornada.emprestimosVinculados[i] != null)
                {
                    for (int j = 0; j < emprestimos.Length; j++)
                    {
                        if (revistaRetornada.emprestimosVinculados[i] == emprestimos[j])
                            emprestimos[j] = null;
                    }
                }
            }
        }

        public Revista RetornaUmaRevistaDoArrayPeloId(int idRevista)
        {
            Revista retorno = null;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].id == idRevista)
                {
                    retorno = revistas[i];

                    break;
                }
            }
            return retorno;
        }

        public Caixa RetornaUmaCaixaDoArrayPeloId(int idcaixa)
        {
            Caixa retorno = null;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].id == idcaixa)
                {
                    retorno = caixas[i];

                    break;
                }
            }
            return retorno;
        }

        public bool AdicionarRevistaNoArray(Revista revistaAhSerAdicionada)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(revistas);

            revistas[posicaoLivre] = revistaAhSerAdicionada;

            return (Util.RetornaAhPosicaoLivreDeUmArray(revistas) == (posicaoLivre + 1)) ? true : false;
        }

        public bool RemoverRevistaDoArray(Revista reevistaAhSerRemovida)
        {
            bool retorno = false;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == reevistaAhSerRemovida)
                {
                    revistas[i] = null;

                    retorno = true;

                    break;
                }
            }

            return retorno;
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

        public bool VerificaSeOhArrayDeCaixasEstaVazio()
        {
            bool retorno = true;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    retorno = false;

                    break;
                }
            }

            return retorno;
        }

        public void ResetarVariaveisDaTela()
        {
            tipoColecaoValido = false;
            numeroEdicaoValido = false;
            anoValido = false;
            caixaValida = false;
            abortarProcesso = false;
            opcaoEscolhida = "";
            tipoDaColecaoInput = "";
            idDaCaixaInput = "";
            numeroDaEdicaoInput = "";
            anoInput = "";
        }

        #endregion
    }
}
