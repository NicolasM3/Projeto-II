using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static ProjetoII.FormForca;
using System.Windows.Forms;

namespace ProjetoII
{
	public class Tratamento
	{
		static FormForca form = new FormForca();
		static VetorPalavra vetor = new VetorPalavra(100);

		public static void LerArquivo(string arquivo)
		{
			var reader = new StreamReader(arquivo);
			while (!reader.EndOfStream)
			{
				string linhaLida = reader.ReadLine();
				string palavra = linhaLida.Substring(0, 15);
				string dica = linhaLida.Substring(15);

				var palavraDica = new Palavra(palavra, dica);

				vetor.InserirAposFim(palavraDica);
			}
			reader.Close();
		}

		public static void SortearPalavra(int indice, ref string palavra, ref string dica)
		{
			palavra = vetor.Dados[indice].PalavraTexto.Trim();
			dica = vetor.Dados[indice].DicaTexto.Trim();
		}

		public static void Escrever(DataGridView dgv, int posi, char escrita)
		{
			dgv.Columns[posi].HeaderText = $"{escrita}";
		}

		public static bool Verificar(char tentativa, string palavra, DataGridView dgv, ref char[] acertos)
		{
			bool erro = true;
			for(int i = 0; i < palavra.Length; i++)
			{
				if(palavra[i] == tentativa)
				{
					erro = false;
					Escrever(dgv, i, tentativa);
					acertos[i] = tentativa;
				}
			}
			return erro;
		}
	}
}
