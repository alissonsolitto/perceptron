using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01.Biblioteca
{
    public static class Uteis
    {
        /// <summary>
        /// Efetuar o truncate
        /// </summary>
        /// <param name="n">Número</param>
        /// <param name="d">Número de casas decimais</param>
        /// <returns></returns>
        public static double Truncate(double n, int d)
        {
            var exp = Math.Pow(10, d);
            return (Math.Truncate(n * exp) / exp);
        }

        /// <summary>
        /// Desenhar matriz na tela
        /// </summary>
        /// <param name="m"></param>
        public static void PrintMatriz(int[,] m)
        {
            for (int i = 0; i < m.Rank; i++)
            {
                for (int j = 0; j < (m.Length/m.Rank); j++)
                {
                    Console.Write(m[i, j] + "\t");
                }

                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Desenhar matriz na tela
        /// </summary>
        /// <param name="m"></param>
        public static void PrintMatriz(int[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                Console.Write(m[i] + "\t");                
            }

            Console.WriteLine("");
        }
    }
}
