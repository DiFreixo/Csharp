using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
  7. LerTelefone - crie um programa capaz de ler um número de telefone nacional e de 
apresentar ao utilizador se o número que introduziu é, ou não, válido. Informe o utilizador 
acerca da rede de comunicações (FIXA, MEO, Vodafone ou NOS) à qual corresponde o número introduzido.
 */


namespace ex._7_LerTelefone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numero = " ";
            bool validacaoNumero = false;

            while (!validacaoNumero)
            {
                Console.WriteLine("Informe o número de telefone: ");
                numero = Console.ReadLine();

                // Verifica se o número de telefone é válido  
                Regex Rgx = new Regex(@"(^[0-9]{9}$)"); //formato XXXXXXXXX

                if (Rgx.IsMatch(numero))
                {
                    validacaoNumero = true;
                    Console.WriteLine("\nNúmero válido");
                }
                else
                {
                    validacaoNumero = false;
                    Console.WriteLine("Número inválido\n");
                }           
            }
           
 

            // Verificar de qual rede é o número de telefone
            if (validacaoNumero)
            {
                if (numero.Substring(0, 2) == "91")
                {
                    Console.WriteLine($"O número de telefone {numero} é da rede Vodafone.");
                }
                else if (numero.Substring(0, 2) == "93")
                {
                    Console.WriteLine($"O número de telefone {numero} é da rede NOS.");
                }
                else if (numero.Substring(0, 2) == "96")
                {
                    Console.WriteLine($"O número de telefone {numero} é da rede MEO.");
                }
                else if (numero.Substring(0, 1) == "2")
                {
                    Console.WriteLine($"O número de telefone {numero} é da rede FIXA.");
                }
            }
            

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
