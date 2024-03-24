using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
    Divisao – um programa deve “ler do teclado” dois valores numéricos inteiros, separados 
    por vírgulas, correspondentes ao dividendo e divisor de uma divisão. O resultado desta 
    divisão deverá ser arredondado para o inteiro mais próximo.

 */


namespace Tarefa_7___Divisao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double divisao;
            int dividendo = 0, divisor = 0;
            string stringNumero, resultado = " ";


            Console.WriteLine("*** Divisão ***");
            Console.WriteLine("Qual é o dividendo e o divisor (digite os números separdos por vírgula e sem espaços): ");
            stringNumero = Console.ReadLine();

            Console.WriteLine(stringNumero);

            for (int i = 0; i < stringNumero.Length; i++)
            {
                if (stringNumero[i] == ',')
                {
                    dividendo = Convert.ToInt32(stringNumero.Substring(0, i));
                    //Console.WriteLine("-" + dividendo + "-");
                }
            }

            for (int i = stringNumero.Length - 1; i >= 0; i--)
            {
                if (stringNumero[i] == ',')
                {
                    resultado = stringNumero.Substring(i, stringNumero.Length - i);
                    resultado = resultado.Replace(",", "");
                    //Console.WriteLine("-" + resultado + "-");
                    divisor = Convert.ToInt32(resultado);
                    //Console.WriteLine("-" + divisor + "-");
                }
            }

            Console.WriteLine("\n\nResultado da divisão: ");

            if (divisor > 0)
            {
                divisao = (double)dividendo / divisor;
                divisao = System.Math.Round(divisao, 0);
                Console.Write(divisao);
            }
            else
            {
                Console.Write("Math Error");
            }

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
