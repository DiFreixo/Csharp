using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
    NomeApelido – o programa lê o nome completo do utilizador e devolve o primeiro 
    nome e o apelido
 */


namespace Tarefa_6___Nome_e_Apelido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomeCompleto, primNome = " ", apelido = " ";
            Console.WriteLine("*** Nome e Apelido ***");
            Console.WriteLine("Digite o seu nome completo: ");
            nomeCompleto = Console.ReadLine();
            Console.WriteLine();

            nomeCompleto = nomeCompleto.Trim(); //elimina espaços do início e fim, caso existam
            nomeCompleto = Regex.Replace(nomeCompleto, @"\s+", " "); //elimina espaços duplicados no interior da frase


            if (nomeCompleto.Length > 0)
            {
                
                for (int pos = 0; pos < nomeCompleto.Length; pos++)
                {
                    if (nomeCompleto[pos] == ' ')
                    {
                        primNome = nomeCompleto.Substring(0, pos);
                        break;
                    }
                        
                }
                
                for (int pos = nomeCompleto.Length - 1; pos >= 0; pos--)
                {
                    if (nomeCompleto[pos] == ' ')
                    {
                        apelido = nomeCompleto.Substring(pos, nomeCompleto.Length - pos);
                        apelido = apelido.TrimStart();
                        break;
                    }

                }
                Console.WriteLine("Nome completo:-" + nomeCompleto + "-");
                Console.WriteLine("Primeiro Nome:-" + primNome + "-");
                Console.WriteLine("Apelido:-" + apelido + "-");
            }
            else
            {
                Console.Write("NULL");
            }
   

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();

        }
    }
}
