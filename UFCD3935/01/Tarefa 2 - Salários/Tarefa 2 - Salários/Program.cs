using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Elaborado por Diana Freixo
/* Tarefa 2 
 * SALÁRIOS - Uma empresa pretende criar um pequeno programa que deve receber do teclado os valores
 * correspondentes aos salários brutos dos seus funcionários e apresentar o respetivo recibo de pagamento
 * (discriminação apenas do salário líquido).
 * 
 * Tenha em atenção à informação seguinte:
 * - Desconto para a Segurança Social (20% do vencimento bruto):
 * - Desconto para o IRS, aplicando as diferentes taxas:
 *      ~ Se o vencimento bruto for inferior a 500€, há isenção;
 *      ~ Se o vencimento bruto for superior ou igual a 500€ e inferior a 1000€, a dedução será de 12%;
 *      ~ Se o vencimento bruto for superior ou igual a 1000€ e inferior a 1500€, a dedução será de 15%;
 *      ~ Se o vencimento bruto for superior ou igual a 1500€, a dedução será de 18%.
 * 
 */

namespace Tarefa_2___Salários
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double salBruto = 0;
            double salLiquido = 0;

            Console.WriteLine("*** Calculo do Salário Líquido ***");
            Console.Write("Informe o salário bruto do funcionário: ");
            salBruto = float.Parse(Console.ReadLine());

            // Aplicar o desconto de 20% da SS
            salLiquido = salBruto - salBruto * 0.20;

            // Aplicar o desconto de IRS conforme o escalão
            if(salBruto < 500)
            {
                Console.WriteLine("Salário Líquido : " + salLiquido.ToString("N2"));
            }
            else if(salBruto < 1000)
            {
                salLiquido = salLiquido - salBruto * 0.12;
                Console.WriteLine("Salário Líquido : " + salLiquido.ToString("N2"));
            }
            else if (salBruto < 1500)
            {
                salLiquido = salLiquido - salBruto * 0.15;
                Console.WriteLine("Salário Líquido : " + salLiquido.ToString("N2"));
            }
            else
            {
                salLiquido = salLiquido - salBruto * 0.18;
                Console.WriteLine("Salário Líquido : " + salLiquido.ToString("N2"));
            }

            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}
