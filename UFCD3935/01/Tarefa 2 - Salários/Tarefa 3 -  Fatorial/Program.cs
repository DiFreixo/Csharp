using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo

/* Tarefa 3
 * Fatorial - Crie um programa capaz de calcular o fatoriaç de um número.
 */

namespace Tarefa_3____Fatorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int fatorial = 1;

            Console.Write("Digite um número inteiro: ");
            num = int.Parse(Console.ReadLine());

            for(int i = num; i >= 1; i--) {
                fatorial = fatorial * i;
            }

            Console.WriteLine("Fatorial de {0} é: {1}", num, fatorial);
            
            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
