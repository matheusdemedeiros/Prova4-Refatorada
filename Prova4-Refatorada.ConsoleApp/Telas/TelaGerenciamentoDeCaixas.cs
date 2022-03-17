using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaGerenciamentoDeCaixas
    {
        #region Declaração de atributos

        public string opcaoEscolhida = "";
        public int inicioMenu = 0, fimMenu = 4, opcaoEmNumero = int.MinValue;
        public bool telaContinuaSendoExibida = true;
        public GeradorDeId geradorDeId;
        public Caixa[] caixas;
        public Revista[] revistas;

        public bool etiquetaValida = false, corValida = false, numeroValido = false, abortarProcesso = false;
        public string etiquetaInput = "", corInput = "", numeroInput = "";
        #endregion

        #region Métodos
        public void ApresentarMenu()
        {
            while (telaContinuaSendoExibida)
            {
                ResetarVariaveisDaTela();
                Console.Clear();
                Console.WriteLine("\n====== GERENCIAMENTO DE CAIXAS ======");
                Console.WriteLine("\n * Digite 0 para voltar ao menu anterior;");
                Console.WriteLine("\n * Digite 1 para cadastrar uma caixa;");
                Console.WriteLine("\n * Digite 2 para remover uma caixa;");
                Console.WriteLine("\n * Digite 3 para listar todas as caixas;");
                Console.WriteLine("\n * Digite 4 para editar uma caixa;");
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
                    CadastrarUmaCaixa();
                    break;
                case 2:
                    RemoverUmaCaixa();
                    break;
                case 3:
                    ListarTodasAsCaixas();
                    break;
                case 4:
                    EditarUmaCaixa();
                    break;
                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!!DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }

        public void EditarUmaCaixa()
        {
            Console.Clear();

            Console.WriteLine("\n====== EDITAR UMA CAIXA ======");

            Console.WriteLine("\nPARA ABORTAR A EDIÇÂO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeCaixasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM CAIXAS CADASTRADAS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id da caixa que deseja editar: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Caixa caixaRetornada = null;

                            caixaRetornada = RetornaUmaCaixaDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (caixaRetornada == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTA É A CAIXA A SER EDITADA ===\n");

                                caixaRetornada.MostrarIdEhEtiqueta();

                                Console.Write("\nVOCÊ CONFIRMA A EDIÇÃO? (S/N): ");

                                bool confirmaEdicao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaEdicao == true)
                                {
                                    Console.WriteLine("\nINSIRA OS NOVOS DADOS PARA A CAIXA:\n");

                                    PedeTodosOsDadosDaCaixa();

                                    if (etiquetaValida == corValida && corValida == numeroValido && numeroValido == true)
                                    {
                                        caixaRetornada.cor = corInput;

                                        caixaRetornada.etiqueta = etiquetaInput;

                                        caixaRetornada.numero = int.Parse(numeroInput);

                                        Util.ApresentarMensagem("CAIXA EDITADA COM SUCESSO!!", ConsoleColor.Green);
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

        public void RemoverUmaCaixa()
        {
            Console.Clear();

            Console.WriteLine("\n====== REMOVENDO UMA CAIXA ======");

            Console.WriteLine("\nLEMBRANDO QUE SÓ PODEM SER REMOVIDAS AS CAIXAS ONDE AS REVISTAS NÃO ESTEJAM EMPRESTADAS!!\n");

            Console.WriteLine("\nPARA ABORTAR A REMOÇÃO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayDeCaixasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM CAIXAS CADASTRADAS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id da caixa que deseja remover: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Caixa caixaRetornada = null;

                            caixaRetornada = RetornaUmaCaixaDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (caixaRetornada == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTA É A CAIXA A SER REMOVIDA ===\n");

                                caixaRetornada.MostrarIdEhEtiqueta();

                                Console.Write("\nVOCÊ CONFIRMA A REMOÇÃO? (S/N): ");

                                bool confirmaRemocao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaRemocao == true)
                                {
                                    if (VerificaSeAsRevistasDaCaixaTemEmprestimo(caixaRetornada))
                                        Util.ApresentarMensagem("ESTA CAIXA NÃO PODE SER REMOVIDA, POIS TEM REVISTAS EMPRESTADAS!", ConsoleColor.Red);
                                    else
                                    {
                                        RemoverCaixaDoArray(caixaRetornada);
                                        Util.ApresentarMensagem("A CAIXA FOI REMOVIDA COM SUCESSO!!", ConsoleColor.Green);
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

        public void ListarTodasAsCaixas()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODAS AS CAIXAS ======");

            if (VerificaSeOhArrayDeCaixasEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM CAIXAS CADASTRADAS!!", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < caixas.Length; i++)
                {
                    if (caixas[i] != null)
                        caixas[i].MostrarTodosOsDados();
                }

                Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void CadastrarUmaCaixa()
        {
            Console.Clear();

            Console.WriteLine("\n====== CADASTRAR UMA CAIXA ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- EM QUALQUER UM DOS CAMPOS!!");

            PedeTodosOsDadosDaCaixa();

            if (abortarProcesso == true)
                Util.ApresentarMensagem("VOCÊ ABORTOU O CADASTRO!!", ConsoleColor.DarkCyan);
            else
            {
                if (etiquetaValida == corValida && corValida == numeroValido && numeroValido == true)
                {
                    Caixa caixa = new Caixa();

                    caixa.id = geradorDeId.GerarId();

                    caixa.etiqueta = etiquetaInput;

                    caixa.cor = corInput;

                    caixa.numero = int.Parse(numeroInput);

                    bool adicionou = AdicionarCaixaNoArray(caixa);

                    if (adicionou == true)
                        Util.ApresentarMensagem("CAIXA CADASTRADA COM SUCESSO!!", ConsoleColor.Green);
                    else
                        Util.ApresentarMensagem("FALHA AO CADASTRAR CAIXA!!", ConsoleColor.Red);
                }
            }
        }

        public void PedeTodosOsDadosDaCaixa()
        {
            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite a etiqueta da caixa com no mínimo 3 caracteres: ");

                    etiquetaInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(etiquetaInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(etiquetaInput, 3) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(etiquetaInput) == false)
                        etiquetaValida = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (etiquetaValida == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite a cor da caixa com no mínimo 3 caracteres: ");

                    corInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(corInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(corInput, 3) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(corInput) == false)
                        corValida = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (corValida == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o número da caixa: ");

                    numeroInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(numeroInput))
                        break;
                    else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(numeroInput) > 0)
                        numeroValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (numeroValido == false);
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

        public bool VerificaSeAsRevistasDaCaixaTemEmprestimo(Caixa caixaRetornada)
        {
            bool retorno = false;

            for (int i = 0; i < caixaRetornada.revistasGuardadasAtualmente.Length; i++)
            {
                if (caixaRetornada.revistasGuardadasAtualmente[i] != null)
                {
                    if (caixaRetornada.revistasGuardadasAtualmente[i].estaEmprestada == true)
                        retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public Caixa RetornaUmaCaixaDoArrayPeloId(int idCaixa)
        {
            Caixa retorno = null;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i].id == idCaixa)
                {
                    retorno = caixas[i];

                    break;
                }
            }
            return retorno;
        }

        public bool AdicionarCaixaNoArray(Caixa caixaAhSerAdicionada)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(caixas);

            caixas[posicaoLivre] = caixaAhSerAdicionada;

            return (Util.RetornaAhPosicaoLivreDeUmArray(caixas) == (posicaoLivre + 1)) ? true : false;
        }

        public bool RemoverCaixaDoArray(Caixa caixaAhSerRemovida)
        {
            bool retorno = false;

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == caixaAhSerRemovida)
                {
                    caixas[i] = null;

                    retorno = true;

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
            opcaoEmNumero = int.MinValue;
            etiquetaValida = false;
            corValida = false;
            numeroValido = false;
            abortarProcesso = false;
            etiquetaInput = "";
            corInput = "";
            numeroInput = "";
            opcaoEscolhida = "";
        }

        #endregion
    }
}