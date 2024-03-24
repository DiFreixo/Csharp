using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo

/*
 * 3. Elabore um método que receba dois parâmetros alfanuméricos e troque os seus valores.
 */

namespace Metodos_Simples_Alfanumericos
{
   
    internal class Program
    {
        class Alfanumericos
        {
            public static void Troca(ref string x, ref string y)
            {
                string aux;
                aux = x;
                x = y;
                y = aux;
            }

      
            static void Main(string[] args)
            {
                string X1, Y1;
                Console.Write("Digite o valor da primeira variável (X): ");
                X1 = Console.ReadLine();
                Console.Write("Digite o valor da segunda variável (Y): ");
                Y1 = Console.ReadLine();

                Troca(ref X1, ref Y1);

                Console.WriteLine("X= " + X1);
                Console.WriteLine("Y= " + Y1);

                Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
                Console.ReadKey();
            }
        }
    }
}
