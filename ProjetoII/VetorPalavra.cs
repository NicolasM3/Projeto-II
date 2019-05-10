using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoII
{
	class VetorPalavra
	{
		int tamanhoMaximo;  // tamanho físico do vetor dados
		int qtosDados;      // tamanho lógico do vetor dados
		Palavra[] dados;

		public VetorPalavra(int tamanhoDesejado)
		{
			dados = new Palavra[tamanhoDesejado];
			qtosDados = 0;
			tamanhoMaximo = tamanhoDesejado;
		}

		public Palavra[] Dados { get => dados; }

		/*public void LerDados(string nomeArq)   // ler de um arquivo texto
		{
			var arq = new StreamReader(nomeArq);
			qtosDados = 0;  // esvaziamos o vetor
			while (!arq.EndOfStream)
			{
				int dadoLido = int.Parse(arq.ReadLine());
				InserirAposFim(dadoLido);
			}
			arq.Close();
		}*/

		public void InserirAposFim(Palavra valorAInserir)
		{
			if (qtosDados >= tamanhoMaximo)
				ExpandirVetor();

			dados[qtosDados] = valorAInserir;
			qtosDados++;
		}

		private void ExpandirVetor()
		{
			tamanhoMaximo += 10;
			Palavra[] vetorMaior = new Palavra[tamanhoMaximo];
			for (int indice = 0; indice < qtosDados; indice++)
				vetorMaior[indice] = dados[indice];

			dados = vetorMaior;
		}
	}
}
