using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo
/*
  Tarefa 1 - Área Retângulo
  
  AREA - Dada a introdução de dois valores correspondentes ao comprimento e à
         altura de um retângulo, apresente a área respetiva.
 */

namespace Tarefa_1___Área_Rectângulo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float comp = 0;
            float alt = 0;
            float area = 0;

            Console.WriteLine("\t----- Calculo da área de um retângulo -----\n");
            Console.Write("\tInforme o comprimento: ");
            comp = float.Parse(Console.ReadLine());
            Console.Write("\tInforme a altura: ");
            alt = float.Parse(Console.ReadLine());

            area = comp * alt;
            Console.WriteLine("\n\tÁrea: " + area.ToString("N2"));

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
