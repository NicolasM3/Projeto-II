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
		static VetorPalavra vetor = new VetorPalavra(100);		/* instancia um objeto da classe VetorPalavra,
																 * que armazenará todas as palavras do arquivo
																 * palavras.txt e suas respectivas dicas.
																 */

		public static void LerArquivo(string arquivo)
		{
			var reader = new StreamReader(arquivo);				// acessa o arquivo especificado
			while (!reader.EndOfStream)
			{
				string linhaLida = reader.ReadLine();			// lê a linha atual e pula de linha
				string palavra = linhaLida.Substring(0, 15);	// divide a linha entre palavra
				string dica = linhaLida.Substring(15);			//						e dica

				var palavraDica = new Palavra(palavra, dica);	/* instancia um objeto da classe Palavra, usando a 
																*  palavra e dica da linha atual
																*/
				vetor.InserirAposFim(palavraDica);				// insere o objeto no vetor
			}
			reader.Close();										// ao finalizar a leitura, fecha o StreamReader
		}

		public static void SortearPalavra(int indice, ref string palavra, ref string dica)
		{
			palavra = vetor.Dados[indice].PalavraTexto.Trim();  // escolhe a palavra baseado no índice especificado e remove os espaços desnecessários
			dica = vetor.Dados[indice].DicaTexto.Trim();        // escolhe a dica baseado no índice especificado e remove os espaços desnecessários
		}

		public static void Escrever(DataGridView dgv, int posi, char escrita)
		{														// recebe um objeto DataGridView, a posição a ser escrita e o texto
			dgv.Columns[posi].HeaderText = $"{escrita}";		// escreve o texto na posição do DataGridView
		}

		public static bool Verificar(char tentativa, string palavra, DataGridView dgv, ref char[] acertos)
		{                                                       /* recebe como parâmetro a tentativa do jogador, a palavra escolhida
																 * o DataGridView a ser escrito, e o vetor acertos
																 */
			bool erro = true;									// define erro como verdadeiro
			for(int i = 0; i < palavra.Length; i++)
			{                                                   // para cada letra da palavra,
				if (palavra[i] == tentativa)					// se a letra for igual à tentativa
				{
					erro = false;								// o jogador não errou
					Escrever(dgv, i, tentativa);                // escreve a letra correta no DataGridView
					acertos[i] = tentativa;						// adiciona essa tentativa aos acertos
				}
			}
			return erro;										// retorna se o usuário errou ou não
		}
	}
}
