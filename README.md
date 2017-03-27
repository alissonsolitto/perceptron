# Perceptron
Este repositório contém uma implementação do perceptron em C#

# Sobre
O perceptron é um algoritmo para a aprendizagem supervisionada de classificadores binários (funções que podem decidir se uma entrada, representada por um vetor de números, pertence a alguma classe específica ou não). É um tipo de classificador linear , ou seja, um algoritmo de classificação que faz suas previsões com base em uma função preditor linear que combina um conjunto de pesos com o vetor de características 

# Principais Métodos

Soma ponderada referente (entradas x pesos)

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

	
Função responsável por gerar os pesos ideais para resolver um problema

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

Função responsável por corrigir os pesos de acordo com o erro gerado
	
	private void CorrigirPeso(int[] entrada, int erro)
	{
		pesos[0] = pesos[0] + txAprendizagem * erro;

		for (int i = 0; i < entrada.Length; i++)
		{
			pesos[i + 1] = pesos[i + 1] + txAprendizagem * erro * entrada[i];
		}
	}
 
Limiar de ativação que determina a mudança dos estados do neurônio

	private int LimiarAtivacao(double n)
	{
		return (n >= 0 ? 1 : 0);
	}
 
# Exemplos de como usar

## Treinamento porta AND

	Perceptron p = new Perceptron(2, 4);

	p.setPadrao(new int[,] { { 0, 0,},
				 { 0, 1,},
				 { 1, 0,},
				 { 1, 1} });

	p.setSaida(new int[] { 0, 0, 0, 1 });

	p.Treinar();
	
	System.Console.WriteLine("1 AND 1 = " + p.Executar(new int[] { 1, 1 }));
	
## Treinamento porta OR
			
	Perceptron p = new Perceptron(2, 4);

	p.setPadrao(new int[,] { { 0, 0,},
				 { 0, 1,},
				 { 1, 0,},
				 { 1, 1} });

	p.setSaida(new int[] { 0, 1, 1, 1 });

	p.Treinar();
	
	System.Console.WriteLine("0 OR 1 = " + p.Executar(new int[] { 0, 1 }));
	
## Treinamento para reconhecer letra A ou T. 
A == 0 e T == 1

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
	System.Console.WriteLine("Letra: " + letra);

	
# Atualizações
- 2017 Ano de Desenvolvimento
