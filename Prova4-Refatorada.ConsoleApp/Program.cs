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
