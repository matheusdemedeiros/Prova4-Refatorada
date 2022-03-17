using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Revista
    {

        #region Atributos

        public int id;
        public string tipoDaColecao;
        public int numeroDaEdicao;
        public int ano;
        public bool estaEmprestada = false;
        public Caixa caixaQueContemAhResvista;
        public Emprestimo[] emprestimosVinculados = new Emprestimo[100];

        #endregion

        #region Proriedades
        public bool EstaEmprestada
        {
            get
            {
                return estaEmprestada;
            }
        }

        #endregion

        #region Métodos
        public void MostrarTodosOsDados()
        {
            Console.Write("\nID: {0}\n", id);
            Console.Write("\nTipo da coleção: {0}\n", tipoDaColecao);
            Console.Write("\nNúmero da edição: {0}\n", numeroDaEdicao);
            Console.Write("\nAno: {0}\n", ano);
            Console.Write("\nEstá emprestada: {0}\n", estaEmprestada == true ? "sim" : "não");
            Console.Write("\nEtiqueta da caixa que ela está vinculada: {0}\n", caixaQueContemAhResvista.etiqueta);
        }

        public void MostrarIdEhTipoColecao()
        {
            Console.Write("\nID: {0}\t\tTipo da coleção: {1}\n", id, tipoDaColecao);
        }

        public void RegistrarDevolucao()
        {
            estaEmprestada = false;
        }

        public void RegistrarUmEmprestimo()
        {
            estaEmprestada = true;
        }

        #endregion
    }
}
