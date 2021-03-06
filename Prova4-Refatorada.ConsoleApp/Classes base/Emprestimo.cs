using System;

namespace Prova4_ClubeDaLeitura.ConsoleApp
{
    public class Emprestimo
    {
        public int id;
        public DateTime dataDoEmprestimo;
        public DateTime dataDaDevolução;
        public Revista revistaDoEmprestimo;
        public string status;
        public Amigo amigoQueEmprestou;

        public void MostrarDados()
        {
            Console.WriteLine("\nID do emprestimo: {0}", id);
            Console.WriteLine("\nData do emprestimo: {0}", dataDoEmprestimo.ToString());
            Console.WriteLine("\nData de devolução do emprestimo: {0}", (dataDaDevolução == new DateTime(1,1,1)) ? "Ainda está em aberto" : dataDaDevolução.ToString()) ;
            Console.WriteLine("\nStatus do emprestimo: {0}", status);
            Console.WriteLine("\nID da revista emprestada: {0}", revistaDoEmprestimo.id);
            Console.WriteLine("\nID do amigo que emprestou: {0}", amigoQueEmprestou.id);
            Console.WriteLine("\nNome do amigo que emprestou: {0}", amigoQueEmprestou.nome);
        }

        public void Emprestar()
        {
            status = "aberto";
            revistaDoEmprestimo.RegistrarUmEmprestimo(this);
            amigoQueEmprestou.RegistrarEmprestimo(this);
        }
        
        public void Devolver()
        {
            status = "devolvido";
            dataDaDevolução = DateTime.Now;
            revistaDoEmprestimo.RegistrarDevolucao(this);
            amigoQueEmprestou.RegistarDevolucao(this);
        }
    }
}
