using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
  Numeração Romana – desenvolve um programa que é capaz de receber um número compreendido entre
  1 e 99 (numeração árabe) e converte em numeração romana.
 */

namespace ex._3_Numeracao_Romana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero;
            string[] romanos = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            int[] arabes = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            Console.WriteLine("---- Númeração Romana de 1 a 2999 ---- ");

            for (int i = 1; i < 3000; i++)
            {
                numero = i;
                //acha a quantidade de elementos no array
                int indice = arabes.Length - 1;

                Console.Write($"Número {numero} - ");

                while (numero > 0)
                {
                    if (numero >= arabes[indice])
                    {
                        Console.Write(romanos[indice]);
                        numero = numero - arabes[indice];
                    }
                    else
                    {
                        indice--;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
