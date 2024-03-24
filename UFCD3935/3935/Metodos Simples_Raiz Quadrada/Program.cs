using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo

/*
 * 1. Elabore um método que imprima as raízes quadradas dos inteiros de um determinado intervalo. 
 * O programa principal deverá invocar este procedimento para imprimir as raízes quadradas dos números 
 * inteiros compreendidos entre 1 e 20, 25 e 50, e 100 e 120.
 */

namespace Metodos_Simples_Raiz_Quadrada
{
    internal class Program
    {

        //Criar a Classe CalcularRaizesQuad
        public class CalcularRaizesQuad
        {

            //Cria o método RaizesQuad - que imprime as raízes quadradas dos números inteiros num dado intervalo
            private static void RaizesQuad(int inf, int sup)
            {
                for (int i = inf; i <= sup; i++)
                {
                    Console.WriteLine($"Raiz quadrada de {i} = " + (System.Math.Sqrt(i).ToString("0.00")) );
                }
            }


            //Método Main - executa o programa
            static void Main(string[] args)
            {
                Console.WriteLine("Raízes quadradas dos números entre 1 e 20: ");
                RaizesQuad(1, 20);
                Console.WriteLine("\nRaízes quadradas dos números entre 25 e 50: ");
                RaizesQuad(25, 50);
                Console.WriteLine("\nRaízes quadradas dos números entre 100 e 200: ");
                RaizesQuad(100, 120);

                Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
                Console.ReadKey();
            }

            //Nota: Os Métodos RaizesQuad e Main têm de estar na mesma classe, para que o métodos RaizesQuad
            //      possa ser acedido pelo método Main, dado que, o método RaizesQuad é private.
        }
    }
}
