using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo
/* Tarefa 4
 PITAGORAS - Construa um programa que calcule a hipotenusa de um triângulo retângulo com entrada 
 de dois valores referentes a cada um dos catetos desse triângulo, utilizando o Teorema de Pitágoras.
 */


namespace Tarefa_4___Pitagoras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double catetoA;
            double catetoB;
            double hipotenusa;

            Console.WriteLine("*** Teorema de Pitáguras ***");
            Console.Write("\tInforme o comprimento do cateto A: ");
            catetoA = double.Parse(Console.ReadLine());
            Console.Write("\tInforme o comprimento do cateto B: ");
            catetoB = double.Parse(Console.ReadLine());

            hipotenusa = System.Math.Sqrt(System.Math.Pow(catetoA, 2) + System.Math.Pow(catetoB,2));      
            Console.WriteLine("\n\tHipotenusa: " + hipotenusa.ToString("N2"));

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
