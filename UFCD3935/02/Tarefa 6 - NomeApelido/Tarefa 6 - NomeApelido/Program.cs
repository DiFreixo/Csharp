using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo
/* Tarefa 6
    NomeApelido – o programa lê o nome completo do utilizador e devolve o primeiro nome e o apelido.
 */
namespace Tarefa_6___NomeApelido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomeCompleto;
            string primNome = " ";
            //string apelido;

            Console.WriteLine("Digite o seu nome completo: ");
            nomeCompleto = Console.ReadLine();
            nomeCompleto = nomeCompleto.Trim();

            primNome = nomeCompleto.Split(' ')[0];
            apelido = nomeCompleto.Split(' ')[1];

            for (int i = 0; i < nomeCompleto.Length; i++)
            {
                if (nomeCompleto[i] == ' ')
                {
                    primNome = nomeCompleto.Substring(0, nomeCompleto[i]);
                    break;
                }
 
            }


            Console.WriteLine();
            Console.WriteLine("Nome completo: " + nomeCompleto);
            Console.WriteLine("Primeiro nome: " + primNome);
            //Console.WriteLine("Apelido: " + apelido);

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
