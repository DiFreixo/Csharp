using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


//Elaborado por Diana Freixo
/*
 * 1.ClasseArea(VIA CLASSES) - Dada a introdução de dois valores correspondentes ao comprimento e à 
    altura de um retângulo, apresente a área respetiva.
 */



namespace Tarefa_10___Classe_Área
{
    internal class Program
    {

        private class Area 
        {
            //atributos da classe Area
            private int comprimento;
            private int altura;

            //métodos da classe área
            public int getComprimento()
            {
                return comprimento;
            }

            public void setComprimento(int c)
            {
                comprimento = c;
            }

            public int getAltura()
            {
                return altura;
            }

            public void setAltura(int a)
            {
                altura = a;
            }

            public int getArea()
            {
                return altura * comprimento;
            }


        }
        static void Main(string[] args)
        {
            //instancia a classe Area
            Area area1 = new Area();

            //Definir os valores
            area1.setComprimento(45);
            area1.setAltura(43);

            //Apresentação do resultado
            Console.WriteLine("Comprimento: " + area1.getComprimento());
            Console.WriteLine("Altura: " + area1.getAltura());
            Console.WriteLine("Área: " + area1.getArea());
           
       
            Console.WriteLine("\n\nPressione qualquer tecla para sair...\n");
            Console.ReadKey();
        }
    }
}

