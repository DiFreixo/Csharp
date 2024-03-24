using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Elaborado por Diana Freixo
/*
    ClasseSalarios (VIA CLASSES) - Uma empresa pretende criar 
    um pequeno programa que deve receber do teclado os 
    valores correspondentes aos salários brutos dos seus 
    funcionários e apresentar o respetivo recibo de pagamento 
    (discriminação apenas do salário líquido).
 */

namespace Tarefa_11___Classe_Salario
{
    internal class Program
    {
        private class Salario
        {
            //atributos da classe Salario
            protected double salarioBruto;
            protected double segSocial;
            protected double irs;

            //métodos da classe Salario
            public double getSalarioBruto()
            {
                return salarioBruto;
            }

            public void setSalarioBruto(double bruto)
            {
                salarioBruto = bruto;
            }

            public double getSegSocial()
            {
                segSocial = salarioBruto * 0.2;
                return segSocial;
            }

          
            public double getIrs()
            {
                if (salarioBruto < 500)
                {
                    irs = 0;
                }
                else if (salarioBruto >= 500 && salarioBruto < 1000)
                {
                    irs = salarioBruto * 0.12;
                }
                else if (salarioBruto >= 1000 && salarioBruto < 1500)
                {
                    irs = salarioBruto * 0.15;
                }
                else
                {
                    irs = salarioBruto * 0.18;
                }
                return irs;
            }


            public double getSalarioLiquido()
            {
                return (salarioBruto - segSocial - irs);
            }


            //Conctrutor da classe Salario
           public Salario()
            {
                salarioBruto = 1500;
                segSocial = salarioBruto * 0.2;

                if (salarioBruto < 500)
                {
                    irs = 0;
                }
                else if (salarioBruto >= 500 && salarioBruto < 1000)
                {
                    irs = salarioBruto * 0.12;
                }
                else if (salarioBruto >= 1000 && salarioBruto < 1500)
                {
                    irs = salarioBruto * 0.15;
                }
                else
                {
                    irs = salarioBruto * 0.18;
                }
            }
        }



        static void Main(string[] args)
        {
            
            //instancia a classe Area
            Salario salario1 = new Salario();

            //------------------ COM CONSTRUTOR ------------------
            Console.WriteLine("------------------ COM CONSTRUTOR ------------------");
            Console.WriteLine("Salário bruto: " + salario1.getSalarioBruto());
            Console.WriteLine("Segurança Social: " + salario1.getSegSocial());
            Console.WriteLine("IRS: " + salario1.getIrs());
            Console.WriteLine("Salário Líquido: " + salario1.getSalarioLiquido());


            //------------------ SEM CONSTRUTOR ------------------
            //Definir os valores
            salario1.setSalarioBruto(678);

            //Apresentação do resultado
            Console.WriteLine("\n------------------ SEM CONSTRUTOR ------------------");
            Console.WriteLine("Salário bruto: " + salario1.getSalarioBruto());
            Console.WriteLine("Segurança Social: " + salario1.getSegSocial());
            Console.WriteLine("IRS: " + salario1.getIrs());
            Console.WriteLine("Salário Líquido: " + salario1.getSalarioLiquido());

           



            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
