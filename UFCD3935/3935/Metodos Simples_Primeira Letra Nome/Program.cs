using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
 * 5. Elabore um método que conte o número de nomes começados por A, B ou C. 
 * O método tem como parâmetro um nome e o valor corrente do contador.
 */


namespace Metodos_Simples_Primeira_Letra_Nome
{
    internal class Program
    {

        //método
        public static int ContaIniciais(string nome, int conta)
        {
         
            if (nome[0] == 'A' || nome[0] == 'B' || nome[0] == 'C')
            {
                conta++;
            }
            
            return conta;
        }

        static void Main(string[] args)
        {
            int conta = 0;
            string nome;

            Console.WriteLine("Digite um nome ou ZZZ para terminar: ");
            nome = Console.ReadLine().ToUpper();

            while (nome != "ZZZ")
            {
                conta = ContaIniciais(nome, conta);
   
                Console.WriteLine("Digite um nome ou ZZZ para terminar: ");
                nome = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Há " + conta + " nome(s) começado(s) por A, B ou C");


            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
