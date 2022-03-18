using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Revista[] todasAsRevistas = new Revista[100];
            Emprestimo[] todosOsEmprestimos = new Emprestimo[100];
            Caixa[] todasAsCaixas = new Caixa[100];
            Amigo[] todosOsAmigos = new Amigo[100];

            #region Dados para testes
            /*
            Caixa cx1 = new Caixa();
            cx1.id = 4;
            cx1.etiqueta = "primeira caixa";
            cx1.cor = "verde";
            cx1.numero = 6;

            Caixa cx2 = new Caixa();
            cx2.id = 5;
            cx2.etiqueta = "segunda caixa";
            cx2.cor = "amarela";
            cx2.numero = 8;


            Amigo a1 = new Amigo();
            a1.endereco = "rua das laranjeiras";
            a1.nomeDoResponsavel = "pai do pedro";
            a1.nome = "Pedro da Silva";
            a1.id = 77;
            a1.telefone = "49984337286";

            todasAsCaixas[0] = cx1;
            todasAsCaixas[1] = cx2;
            todosOsAmigos[0] = a1;
            */
            #endregion

            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();

            menuPrincipal.gerenciamentoDeEmprestimos = new TelaGerenciamentoDeEmprestimos();
            menuPrincipal.gerenciamentoDeEmprestimos.emprestimos = todosOsEmprestimos;
            menuPrincipal.gerenciamentoDeEmprestimos.revistas = todasAsRevistas;
            menuPrincipal.gerenciamentoDeEmprestimos.caixas = todasAsCaixas;
            menuPrincipal.gerenciamentoDeEmprestimos.amigos = todosOsAmigos;
            menuPrincipal.gerenciamentoDeEmprestimos.geradorDeId = new GeradorDeId();

            menuPrincipal.gerenciamentoDeRevistas = new TelaGerenciamentoDeRevistas();
            menuPrincipal.gerenciamentoDeRevistas.revistas = todasAsRevistas;
            menuPrincipal.gerenciamentoDeRevistas.caixas = todasAsCaixas;
            menuPrincipal.gerenciamentoDeRevistas.emprestimos = todosOsEmprestimos;
            menuPrincipal.gerenciamentoDeRevistas.geradorDeId = new GeradorDeId();

            menuPrincipal.gerenciamentoDeCaixas = new TelaGerenciamentoDeCaixas();
            menuPrincipal.gerenciamentoDeCaixas.caixas = todasAsCaixas;
            menuPrincipal.gerenciamentoDeCaixas.revistas = todasAsRevistas;
            menuPrincipal.gerenciamentoDeCaixas.geradorDeId = new GeradorDeId();

            menuPrincipal.gerenciamentoDeAmigos = new TelaGerenciamentoDeAmigos();
            menuPrincipal.gerenciamentoDeAmigos.amigos = todosOsAmigos;
            menuPrincipal.gerenciamentoDeAmigos.emprestimos = todosOsEmprestimos;
            menuPrincipal.gerenciamentoDeAmigos.geradorDeId = new GeradorDeId();


            menuPrincipal.ApresentarMenu();

            Console.ReadLine();

        }
    }
}
