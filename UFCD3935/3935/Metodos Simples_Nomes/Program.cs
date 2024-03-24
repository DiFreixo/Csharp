using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Elaborado por Diana Freixo

/* 
 * 2. Elabore um método que escreva os primeiros X nomes de uma lista. O procedimento tem como parâmetros de entrada a lista de 
      nomes e o número de elementos a selecionar.
 */
namespace Metodos_Simples_Nomes
{

    class Pessoas
    {
        //cria o método ImpressaoNomes
        //Como o método é declarado como STATIC não é necessário criar o objecto da classe para este ser chamado.
        //Basta utilizar o nome da classe, exemplo: Pessoas.ImpressaoNomes(Nomes, X).
        public static void ImpressaoNomes(string[] nomes, int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine(nomes[i]);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] Nomes = { "Ana", "António", "Beatriz", "Joana", "Raul", "Vitória" };
            int X = 4;

            Pessoas.ImpressaoNomes(Nomes, X);

            Console.WriteLine("Selecionámos os " + X + " primeiros nomes de uma lista de " + Nomes.Length);
 
            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
