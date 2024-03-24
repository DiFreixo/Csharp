using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
    Idade – desenvolve um projeto que aceite a data de nascimento de um indivíduo e 
    apresente a idade e o dia da semana em que nasceu.
 */
namespace Tarefa_8___Idade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool validacaoData = false;
            DateTime dataNascimento = DateTime.Now;
            int idade;
            DayOfWeek diaSemana = new DayOfWeek();
            String valor;

            // enquanto a data de nascimento for inválida repetir
            while (!validacaoData)
            {
                int dia, mes, ano;

                Console.WriteLine("Informe a sua data de nascimento:");
                Console.Write("Dia (dd): ");
                dia = int.Parse(Console.ReadLine());
                Console.Write("Mês (mm): ");
                mes = int.Parse(Console.ReadLine());
                Console.Write("Ano (aaaa): ");
                ano = int.Parse(Console.ReadLine());

                //Console.WriteLine("Data de Nascimento: " + dia + "-" + mes + "-" + ano);

                try
                {  //validar a data de nascimento
                    dataNascimento = new DateTime(ano, mes, dia);
                    validacaoData = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nData de nascimento inválida.\n");
                }
            }

            //calcular a idade
            idade = (int)DateTime.Today.Subtract(dataNascimento).TotalDays / 365;
            Console.WriteLine("Idade: " + idade + " anos");

            diaSemana = dataNascimento.DayOfWeek;
            valor = diaSemana.ToString();
            Console.Write("Dia da semana do nascimento: ");
            switch (valor)
            {
                case "Monday":
                    Console.WriteLine("Segunda-feira");
                    break;

                case "Tuesday":
                    Console.WriteLine("Terça-feira");
                    break;

                case "Wednesday":
                    Console.WriteLine("Quarta-feira");
                    break;

                case "Thursday":
                    Console.WriteLine("Quinta-feira");
                    break;

                case "Friday":
                    Console.WriteLine("Sexta-feira");
                    break;

                case "Saturday":
                    Console.WriteLine("Sábado");
                    break;

                case "Sunday":
                    Console.WriteLine("Domingo");
                    break;
            }

            //-------------------------------
            // formato dddd -> devolve o dia da semana por extenso
            Console.WriteLine("\n\nDia da Semana: " + dataNascimento.ToString("dddd"));




            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
