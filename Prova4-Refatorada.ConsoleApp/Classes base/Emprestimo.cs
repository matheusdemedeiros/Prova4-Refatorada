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
            Console.WriteLine("\nData de devolução do emprestimo: {0}", dataDaDevolução.ToString());
            Console.WriteLine("\nStatus do emprestimo: {0}", status);
            Console.WriteLine("\nID da revista emprestada: {0}", revistaDoEmprestimo.id);
            Console.WriteLine("\nID do amigo que emprestou: {0}", amigoQueEmprestou.id);
            Console.WriteLine("\nNome do amigo que emprestou: {0}", amigoQueEmprestou.nome);
        }

        public void Emprestar()
        {
            status = "aberto";

            revistaDoEmprestimo.RegistrarUmEmprestimo();
            amigoQueEmprestou.RegistrarEmprestimo(this);
            
        }



    }
}
