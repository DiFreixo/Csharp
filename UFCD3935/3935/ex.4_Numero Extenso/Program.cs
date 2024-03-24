using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
 Número Extenso – crie um programa capaz de obter um número inteiro compreendido 
 entre 0 e 999 e de o apresentar por extenso (por exemplo, 532 – quinhentos e trinta e dois).
 */

namespace ex._4_Numero_Extenso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Números por extenso do 0 ao 999 ****");

            int numero, unidade, dezena, centena;
            //nomes das unidades
            string[] nomeUnidades = { "Zero", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove" };
            //nomes dos números entre 10 e 20
            string[] nomeDezAvinte = { "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezasseis", "Dezassete", "Dezoito", "Dezanove" };
            //nomes das dezenas
            string[] nomeDezenas = { "", "", "Vinte", "Trinta", "Quarenta", "Cinquenta", "Sessenta", "Setenta", "Oitenta", "Noventa" };
            //nomes das centenas
            string[] nomeCentenas = { "", "Cento", "Duzentos", "Trezentos", "Quatrocentos", "Quinhentos", "Seiscentos", "Setecentos", "Oitocentos", "Novecentos" };

            /* //Pedir um número ao utilizador
             Console.WriteLine("Digite um número inteiro entre 0 e 999: ");
             numero = int.Parse(Console.ReadLine());

             //verifica se o número digitado está entre 0 e 999
             if(numero < 0 || numero > 999)
             {
                 Console.WriteLine("Atenção!!");
                 Console.WriteLine("Digite um número inteiro entre 0 e 999: ");
                 numero = int.Parse(Console.ReadLine());
             }
            */

            for (int i = 0; i < 1000; i++)
            {
                numero = i;
                //Separar o número em unidade, dezena e centena
                unidade = numero % 10;
                dezena = (numero / 10) % 10;
                centena = numero / 100;

                Console.Write($"Número {numero} - ");

                //Converter Centenas
                if (centena > 0 && (dezena > 0 || unidade > 0))
                {
                    Console.Write(nomeCentenas[centena] + " e ");
                }
                else
                {
                    if (centena == 1)
                    {
                        Console.Write("Cem");
                    }
                    else
                    {
                        Console.Write(nomeCentenas[centena]);
                    }

                    //Para não imprimir "Zero" quando centenas > 0 e  unidades = 0
                    // E para não ter que repetir o conversor de dezenas e unidades
                    if (centena > 0)
                    {
                        nomeUnidades[0] = "";
                    }
                }

                //Converter Dezenas e unidades
                if (dezena > 1)
                {
                    if (unidade > 0)
                    {
                        Console.Write(nomeDezenas[dezena] + " e " + nomeUnidades[unidade]);
                    }
                    else
                    {
                        Console.Write(nomeDezenas[dezena]);
                    }
                }
                else
                {
                    if (dezena == 1)
                    {
                        Console.Write(nomeDezAvinte[unidade]);
                    }
                    else
                    {
                        Console.Write(nomeUnidades[unidade]);
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
