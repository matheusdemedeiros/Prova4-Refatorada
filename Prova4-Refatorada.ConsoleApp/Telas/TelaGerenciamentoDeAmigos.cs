using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class TelaGerenciamentoDeAmigos
    {
        #region Declaração de atributos

        public GeradorDeId geradorDeId;
        public Amigo[] amigos;
        public Emprestimo[] emprestimos;

        private int inicioMenu = 0, fimMenu = 4, opcaoEmNumero = int.MinValue;
        private bool nomeValido = false, nomeResponsavelValido = false, telefoneValido = false, enderecoValido = false, abortarProcesso = false, telaContinuaSendoExibida = true;
        private string nomeInput = "", nomeResponsavelInput = "", telefoneInput = "", enderecoInput = "", opcaoEscolhida = "";

        #endregion

        #region Métodos

        public void ApresentarMenu()
        {
            while (telaContinuaSendoExibida)
            {
                ResetarVariaveisDaTela();
                Console.Clear();
                Console.WriteLine("\n====== GERENCIAMENTO DE AMIGOS ======");
                Console.WriteLine("\n * Digite 0 para voltar ao menu anterior;");
                Console.WriteLine("\n * Digite 1 para cadastrar um amigo;");
                Console.WriteLine("\n * Digite 2 para remover um amigo;");
                Console.WriteLine("\n * Digite 3 para listar todos os amigos;");
                Console.WriteLine("\n * Digite 4 para editar um amigo;");
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
                    CadastrarUmAmigo();
                    break;
                case 2:
                    RemoverUmAmigo();
                    break;
                case 3:
                    ListarTodosOsAmigos();
                    break;
                case 4:
                    EditarUmAmigo();
                    break;
                case int.MinValue:
                    Util.ApresentarMensagem("ENTRADA INVÁLIDA!! DIGITE APENAS NÚMEROS DE " + inicioMenu + " ATÉ " + fimMenu, ConsoleColor.Red);
                    break;
            }
        }

        public void EditarUmAmigo()
        {
            Console.Clear();

            Console.WriteLine("\n====== EDITAR UM AMIGO ======");

            Console.WriteLine("\nPARA ABORTAR A EDIÇÂO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM AMIGOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id do amigo que deseja editar: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Amigo amigoRetornado = null;

                            amigoRetornado = RetornaUmAmigoDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (amigoRetornado == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTE É O AMIGO A SER EDITADO ===\n");

                                amigoRetornado.MostrarIdEhNome();

                                Console.Write("\nVOCÊ CONFIRMA A EDIÇÃO? (S/N): ");

                                bool confirmaEdicao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaEdicao == true)
                                {
                                    Console.WriteLine("\nINSIRA OS NOVOS DADOS PARA O AMIGO:\n");

                                    PedeTodosOsDadosDoAmigo();

                                    if (enderecoValido == telefoneValido && telefoneValido == nomeResponsavelValido && nomeResponsavelValido == nomeValido && nomeValido == true)
                                    {
                                        amigoRetornado.nome = nomeInput;

                                        amigoRetornado.nomeDoResponsavel = nomeResponsavelInput;

                                        amigoRetornado.telefone = telefoneInput;

                                        amigoRetornado.endereco = enderecoInput;

                                        Util.ApresentarMensagem("AMIGO EDITADO COM SUCESSO!!", ConsoleColor.Green);
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

        public void RemoverUmAmigo()
        {
            Console.Clear();

            Console.WriteLine("\n====== REMOVENDO UM AMIGO ======");

            Console.WriteLine("\nLEMBRANDO QUE SÓ PODEM SER REMOVIDOS OS AMIGOS QUE NÃO TIVEREM EMPRÉSTIMOS EM ABERTO!!\n\nALÉM DISSO, AO REMOVER O AMIGO OS EMPRÉSTIMOS DELE TAMBÉM SERÃO APAGADOS DO SISTEMA\n\n(CASO NÃO ESTEJAM ABERTOS)!!\n");

            Console.WriteLine("\nPARA ABORTAR A REMOÇÃO DIGITE *-- !!");

            bool idInputadoValido = false;

            string inputDoUsuario = "";

            if (VerificaSeOhArrayEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM AMIGOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                if (abortarProcesso == false)
                {
                    do
                    {
                        Console.Write("\nDigite o Id do amigo que deseja remover: ");

                        inputDoUsuario = Console.ReadLine();

                        if (VerificaSeEhParaAbortarOhProcesso(inputDoUsuario))
                            break;
                        else if (Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(inputDoUsuario))
                        {
                            idInputadoValido = true;

                            Amigo amigoRetornado = null;

                            amigoRetornado = RetornaUmAmigoDoArrayPeloId(Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiroEhRetornaOhValor(inputDoUsuario));

                            if (amigoRetornado == null)
                                Util.ApresentarMensagem("O ID INFORMADO NÃO FOI ENCONTRADO NO SISTEMA!!", ConsoleColor.Yellow);
                            else
                            {
                                Console.WriteLine("\n=== ESTE É O AMIGO A SER REMOVIDO ===\n");

                                amigoRetornado.MostrarIdEhNome();

                                Console.Write("\nVOCÊ CONFIRMA A REMOÇÃO? (S/N): ");

                                bool confirmaRemocao = Util.PedeConfirmacaoDoUsuario(Console.ReadLine());

                                if (confirmaRemocao == true)
                                {
                                    if (amigoRetornado.JaRealizouAlgumEmprestimo())
                                    {
                                        if (amigoRetornado.TemEmprestimosEmAberto())
                                            Util.ApresentarMensagem("ESTE AMIGO NÃO PODE SER REMOVIDO, POIS TEM EMPRÉSTIMOS EM ABERTO!!", ConsoleColor.Red);
                                        else
                                        {
                                            ApagaTodosOsEmprestimosDeUmAmigo(amigoRetornado);

                                            RemoverAmigoDoArray(amigoRetornado);

                                            Util.ApresentarMensagem("O AMIGO FOI REMOVIDO COM SUCESSO, ASSIM COMO OS SEUS EMPRÉSTIMOS!!", ConsoleColor.Green);
                                        }
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

        public void ListarTodosOsAmigos()
        {
            Console.Clear();

            Console.WriteLine("\n====== LISTANDO TODOS OS AMIGOS ======");

            if (VerificaSeOhArrayEstaVazio())
                Util.ApresentarMensagem("AINDA NÃO EXISTEM AMIGOS CADASTRADOS!!", ConsoleColor.Yellow);
            else
            {
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] != null)
                        amigos[i].MostrarTodosOsDados();
                }

                Util.ApresentarMensagem("FIM DOS RESULTADOS!!", ConsoleColor.Cyan);
            }
        }

        public void CadastrarUmAmigo()
        {
            Console.Clear();

            Console.WriteLine("\n====== CADASTRAR UM AMIGO ======");

            Console.WriteLine("\nPARA ABORTAR O CADASTRO DIGITE *-- EM QUALQUER UM DOS CAMPOS!!");

            PedeTodosOsDadosDoAmigo();

            if (abortarProcesso == true)
                Util.ApresentarMensagem("VOCÊ ABORTOU O CADASTRO!!", ConsoleColor.DarkCyan);
            else
            {
                if (enderecoValido == telefoneValido && telefoneValido == nomeResponsavelValido && nomeResponsavelValido == nomeValido && nomeValido == true)
                {
                    Amigo amigo = new Amigo();

                    amigo.id = geradorDeId.GerarId();

                    amigo.nome = nomeInput;

                    amigo.nomeDoResponsavel = nomeResponsavelInput;

                    amigo.telefone = telefoneInput;

                    amigo.endereco = enderecoInput;

                    bool adicionou = AdicionarAmigoNoArray(amigo);

                    if (adicionou == true)
                        Util.ApresentarMensagem("AMIGO CADASTRADO COM SUCESSO!!", ConsoleColor.Green);
                    else
                        Util.ApresentarMensagem("FALHA AO CADASTRAR AMIGO!!", ConsoleColor.Red);
                }
            }
        }

        public void PedeTodosOsDadosDoAmigo()
        {
            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o nome do amigo com no mínimo 6 caracteres: ");

                    nomeInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(nomeInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(nomeInput, 6) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(nomeInput) == false)
                        nomeValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (nomeValido == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o nome do responsável do amigo com no mínimo 6 caracteres: ");

                    nomeResponsavelInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(nomeResponsavelInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(nomeResponsavelInput, 6) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(nomeResponsavelInput) == false)
                        nomeResponsavelValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (nomeResponsavelValido == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o telefone do amigo com DDD: ");

                    telefoneInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(telefoneInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(telefoneInput, 11))
                        telefoneValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (telefoneValido == false);
            }

            if (abortarProcesso != true)
            {
                do
                {
                    Console.Write("\nDigite o endereco do amigo com no mínimo 10 caracteres: ");

                    enderecoInput = Console.ReadLine();

                    if (VerificaSeEhParaAbortarOhProcesso(enderecoInput))
                        break;
                    else if (Util.VerificaSeUmaStringTemUmTamanhoMinimoPreDeterminado(enderecoInput, 10) && Util.VerificaSeOhInputDoUsuarioEhUmNumeroInteiro(enderecoInput) == false)
                        enderecoValido = true;
                    else
                        Util.ApresentarMensagem("ENTRADA INVÁLIDA!! TENTE NOVAMENTE!!", ConsoleColor.Red);

                } while (enderecoValido == false);
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

        public void ApagaTodosOsEmprestimosDeUmAmigo(Amigo amigoRetornado)
        {
            for (int i = 0; i < amigoRetornado.emprestimosRealizados.Length; i++)
            {
                if (amigoRetornado.emprestimosRealizados[i] != null)
                {
                    for (int j = 0; j < emprestimos.Length; j++)
                    {
                        if (amigoRetornado.emprestimosRealizados[i] == emprestimos[j])
                            emprestimos[j] = null;
                    }
                }
            }
        }

        public Amigo RetornaUmAmigoDoArrayPeloId(int idAmigo)
        {
            Amigo retorno = null;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].id == idAmigo)
                {
                    retorno = amigos[i];

                    break;
                }
            }
            return retorno;
        }

        public bool AdicionarAmigoNoArray(Amigo amigoSerAdicionado)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(amigos);

            amigos[posicaoLivre] = amigoSerAdicionado;

            return (Util.RetornaAhPosicaoLivreDeUmArray(amigos) == (posicaoLivre + 1)) ? true : false;
        }

        public bool RemoverAmigoDoArray(Amigo amigoAhSerRemovido)
        {
            bool retorno = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == amigoAhSerRemovido)
                {
                    amigos[i] = null;

                    retorno = true;

                    break;
                }
            }

            return retorno;
        }

        public bool VerificaSeOhArrayEstaVazio()
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
            opcaoEmNumero = int.MinValue;
            nomeValido = false;
            nomeResponsavelValido = false;
            telefoneValido = false;
            enderecoValido = false;
            abortarProcesso = false;
            nomeInput = "";
            nomeResponsavelInput = "";
            telefoneInput = "";
            enderecoInput = "";
            opcaoEscolhida = "";
        }

        #endregion
    }
}