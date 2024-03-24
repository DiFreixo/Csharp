using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo
/* Tarefa 5
 ContadorPalavras – desenvolve um programa que deve “ler do teclado” uma frase ao gosto do utilizador
 e apresentar o número de palavras que a frase contém.
 */

namespace Tarefa_5___Contar_Palavras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frase;
            int contador = 0;

            Console.WriteLine("*** Contador de Palavras ***");
            Console.WriteLine("Escreva uma frase: ");
            frase = Console.ReadLine();
            Console.WriteLine();

            frase = frase.Trim();


            for (int i = 0; i < frase.Length ; i++)
            {
                if (frase[i] == ' ')
                {
                    contador++;
                }
                
            }


            Console.WriteLine("Frase digitada: " + frase);
            Console.WriteLine("\nA frase digitada tem " + (contador + 1) + " palavra(s).");



            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();

        }
    }
}
