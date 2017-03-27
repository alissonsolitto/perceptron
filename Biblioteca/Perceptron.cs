using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01.Biblioteca
{
    public class Perceptron
    {
        //Constantes
        private const int min = -1;
        private const int max = 2;
        private const double txAprendizagem = 0.2;

        //Variaveis
        private int nEntradas { get; set; }
        private int nPadrao { get; set; }
        private int[,] padrao { get; set; }
        private int[] saida { get; set; }
        private double[] pesos { get; set; }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="n">quantidade de entradas</param>
        /// <param name="p">quantidade de padrões</param>
        public Perceptron(int n, int p) //nEntradas, padrões
        {
            this.nEntradas = n;
            this.nPadrao = p;
            this.padrao = new int[p, n];
            this.saida = new int[p];
            this.pesos = new double[n + 1]; //peso fixo

            GerarPesos();
        }

        /// <summary>
        /// Atribuir a tabela de padrões de entrada
        /// </summary>
        /// <param name="pad">Tabela de padrões com dimensão de [p, n]</param>
        public void setPadrao(int[,] pad)
        {
            padrao = pad;
        }

        /// <summary>
        /// Atribuir valores de saida referente a tabela de padrões
        /// </summary>
        /// <param name="s"></param>
        public void setSaida(int[] s)
        {
            saida = s;
        }

        /// <summary>
        /// Gera pesos aleatórios para cada entrada do Perceptron
        /// </summary>
        private void GerarPesos()
        {
            Random random = new Random();

            for (int i = 0; i <= nEntradas; i++)
            {
                int n = 0;
                while(n == 0) n = random.Next(min, max);

                pesos[i] = Uteis.Truncate(random.NextDouble() * n, 2);
            }
        }

        /// <summary>
        /// Limiar de ativação que determina a mudança dos estados do neurônio
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int LimiarAtivacao(double n)
        {
            return (n >= 0 ? 1 : 0);
        }

        /// <summary>
        /// Soma ponderada referente (entradas x pesos)
        /// </summary>
        /// <param name="padrao">Linha da tabela de padrões contendo todas as entradas</param>
        /// <returns></returns>
        private int Somatorio(int[] padrao)
        {
            double soma = 0;

            for (int i = 0; i < padrao.Length; i++)
            {
                soma += padrao[i] * pesos[i + 1]; //A entrada x0 é default 1
            }

            soma += pesos[0]; //A entrada x0 é default 1, apenas soma

            return LimiarAtivacao(soma);
        }

        /// <summary>
        /// Função responsável por gerar os pesos ideais para resolver um problema
        /// </summary>
        public void Treinar()
        {
            bool treinar = true;

            for (int i = 0; i < nPadrao; i++)
            {
                int[] array = new int[nEntradas];
                
                for (int j = 0; j < nEntradas; j++) // Obtendo variaveis do padrão
                {
                    array[j] = padrao[i,j];
                }

                int y = Somatorio(array);

                if (y != saida[i])
                {
                    CorrigirPeso(array, saida[i] - y);
                    treinar = false;
                }
            }

            if(!treinar)
            {
                Treinar();
            }
        }

        /// <summary>
        /// Função responsável por corrigir os pesos de acordo com o erro gerado
        /// </summary>
        /// <param name="entrada">Linha da tabela de padrões contendo todas as entradas</param>
        /// <param name="erro">saida padrão - saida gerada</param>
        private void CorrigirPeso(int[] entrada, int erro)
        {
            pesos[0] = pesos[0] + txAprendizagem * erro;

            for (int i = 0; i < entrada.Length; i++)
            {
                pesos[i + 1] = pesos[i + 1] + txAprendizagem * erro * entrada[i];
            }
        }

        /// <summary>
        /// Função responsável por resolver um problema, após o Perceptron ser treinado
        /// </summary>
        /// <param name="entrada">Linha da tabela de padrões contendo todas as entradas</param>
        /// <returns></returns>
        public int Executar(int[] entrada)
        {
            return Somatorio(entrada);
        }
    }
}
