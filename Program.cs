using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01.Biblioteca;

namespace Trabalho01
{
    class Program
    {
        static void Main(string[] args)
        {
            Perceptron p = new Perceptron(2, 4);

            //TREINAR PERCEPTRON PARA RECONHECER PORTA AND
            p.setPadrao(new int[,] { { 0, 0,},
                                     { 0, 1,},
                                     { 1, 0,},
                                     { 1, 1} });

            p.setSaida(new int[] { 0, 0, 0, 1 });

            p.Treinar();

            System.Console.WriteLine("0 AND 0 = " + p.Executar(new int[] { 0, 0 }));
            System.Console.WriteLine("0 AND 1 = " + p.Executar(new int[] { 0, 1 }));
            System.Console.WriteLine("1 AND 0 = " + p.Executar(new int[] { 1, 0 }));
            System.Console.WriteLine("1 AND 1 = " + p.Executar(new int[] { 1, 1 }));


            //TREINAR PERCEPTRON PARA RECONHECER PORTA OR
            p.setPadrao(new int[,] { { 0, 0,},
                                     { 0, 1,},
                                     { 1, 0,},
                                     { 1, 1} });

            p.setSaida(new int[] { 0, 1, 1, 1 });

            p.Treinar();

            System.Console.WriteLine("\n0 OR 0 = " + p.Executar(new int[] { 0, 0 }));
            System.Console.WriteLine("0 OR 1 = " + p.Executar(new int[] { 0, 1 }));
            System.Console.WriteLine("1 OR 0 = " + p.Executar(new int[] { 1, 0 }));
            System.Console.WriteLine("1 OR 1 = " + p.Executar(new int[] { 1, 1 }));

            
            //TREINAR PERCEPTRON PARA RECONHECER LETRA A ou T
            p = new Perceptron(25, 2);

            p.setPadrao(new int[,] { { 1, 1, 1, 1, 1, //A
                                       1, 0, 0, 0, 1,
                                       1, 1, 1, 1, 1,
                                       1, 0, 0, 0, 1,
                                       1, 0, 0, 0, 1 },

                                     { 1, 1, 1, 1, 1, //T
                                       0, 0, 1, 0, 0,
                                       0, 0, 1, 1, 0,
                                       0, 0, 1, 0, 0,
                                       0, 0, 1, 0, 0 }
            });
            
            p.setSaida(new int[] { 0, 1 });
            p.Treinar();

            int res = p.Executar(new int[] { 1, 1, 1, 1, 1, //A
                                             1, 0, 0, 0, 1,
                                             1, 1, 1, 1, 1,
                                             1, 0, 0, 0, 1,
                                             1, 0, 0, 0, 1 } );

            string letra = (res > 0 ? "T" : "A");
            System.Console.WriteLine("\nLetra: " + letra);


            Console.Read();
        }
    }
}
