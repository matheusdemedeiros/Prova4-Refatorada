using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Amigo
    {

        #region Atributos

        public int id;
        public string nome;
        public string nomeDoResponsavel;
        public string telefone;
        public string endereco;
        public int quantidadeDeEmprestimosEmAberto = 0;
        public int quantidadeDeEmprestimosJaRealizados = 0;
        public Emprestimo[] emprestimosRealizados = new Emprestimo[100];

        #endregion

        #region Métodos
        public void RegistarDevolucao(Emprestimo emprestimo)
        {
            quantidadeDeEmprestimosEmAberto--;

            RemoverEmprestimoDoArray(emprestimo);
        }

        public bool TemEmprestimosEmAberto()
        {
            bool retorno = false;

            for (int i = 0; i < emprestimosRealizados.Length; i++)
            {
                if (emprestimosRealizados[i] != null)
                {
                    if (emprestimosRealizados[i].status == "aberto")
                    {
                        retorno = true;

                        break;
                    }
                }
            }
            return retorno;
        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            quantidadeDeEmprestimosEmAberto++;

            AdicionarEmprestimoNoArray(emprestimo);
        }

        public void MostrarTodosOsDados()
        {
            Console.Write("\nID: {0}\n", id);
            Console.Write("\nNome do amigo: {0}\n", nome);
            Console.Write("\nNome do responsável pelo amigo: {0}\n", nomeDoResponsavel);
            Console.Write("\nTelefone: {0}\n", telefone);
            Console.Write("\nEndereço: {0}\n", endereco);
            Console.Write("\nQuantidade de empréstimos realizados: {0}\n", RetornaAhQuantidadeDeEmprestimos());
        }

        public void MostrarIdEhNome()
        {
            Console.Write("\nID: {0}\t\tNome: {1}", id, nome);
        }

        public int RetornaAhQuantidadeDeEmprestimos()
        {
            if (Util.RetornaAhPosicaoLivreDeUmArray(emprestimosRealizados) == 0)
                return 0;
            else
                return (Util.RetornaAhPosicaoLivreDeUmArray(emprestimosRealizados) - 1);
        }

        public bool JaRealizouAlgumEmprestimo()
        {
            for (int i = 0; i < emprestimosRealizados.Length; i++)
            {
                if (emprestimosRealizados[i] != null)
                {
                    quantidadeDeEmprestimosJaRealizados++;
                }
            }
            return (quantidadeDeEmprestimosJaRealizados > 0) ? true : false;
        }

        public void AdicionarEmprestimoNoArray(Emprestimo emprestimoAhSerAdicionado)
        {
            int posicaoLivre = Util.RetornaAhPosicaoLivreDeUmArray(emprestimosRealizados);

            emprestimosRealizados[posicaoLivre] = emprestimoAhSerAdicionado;
        }

        public void RemoverEmprestimoDoArray(Emprestimo emprestimoAhSerRemovido)
        {
            for (int i = 0; i < emprestimosRealizados.Length; i++)
            {
                if (emprestimosRealizados[i] == emprestimoAhSerRemovido)
                {
                    emprestimosRealizados[i] = null;

                    break;
                }
            }
        }

        #endregion
    }
}