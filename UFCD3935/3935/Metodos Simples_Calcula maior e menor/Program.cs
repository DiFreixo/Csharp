using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo

/*
 * 4. Complete a seguinte classe, utilizando os dois métodos que calculem o maior e o menor de três números.
 */

namespace Metodos_Simples_Calcula_maior_e_menor
{       

    internal class Program
    {
        public class Numeros
        {
            //método 1 da classe
            static int MaiorDe3(int X, int Y, int Z)
            {
                if (X < Y)
                    X = Y;
                if (X < Z)
                    X = Z;
                return X;
            }

            //método 2 da classe
            static int MenorDe3(int X, int Y, int Z)
            {
                if (X > Y)
                    X = Y;
                if (X > Z)
                    X = Z;
                return X;
            }
        

            static void Main(string[] args)
            {
                int X, Y, Z;
                Console.Write("Digite o primeiro valor: ");
                X = int.Parse(Console.ReadLine());
                Console.Write("Digite o segundo valor: ");
                Y = int.Parse(Console.ReadLine());
                Console.Write("Digite o terceiro valor: ");
                Z = int.Parse(Console.ReadLine());

                Console.WriteLine("Maior: " + Numeros.MaiorDe3(X, Y, Z));
                Console.WriteLine("Menor: " + Numeros.MenorDe3(X, Y, Z));

                Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
                Console.ReadKey();
            }

        }
    }

}
