using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static ProjetoII.Tratamento;

namespace ProjetoII
{
	public partial class FormForca : Form
	{
		Form2 cadastro;
		public static string palavraSorteada, dicaSorteada;                         // instancia string
		public char[] LetrasTestadas, acertos;                                      // instancia vetores de char
		public static int qntLetrasTestadas = 0, erros = 0,                         // instancia e zera inteiros
                            pontos = 0, segundos = 120;                             // instancia e define o tempo
		bool iniciou;
		public static string bancoDePalavras;

		public FormForca()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bool abriu = false;     
			while (!abriu)                                                          // verifica se o jogo não esta aberto
			{
				if (dlgAbrir.ShowDialog() == DialogResult.OK)                       // verifica se o arquivo foi escolhido
				{
					abriu = true;                                                   // jogo esta aberto
					bancoDePalavras = dlgAbrir.FileName;
				}
				else
					Close();
			}
		}

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			if (iniciou)                                                                                                 
			{
				Application.Restart();                                              // restarta o programa se ja iniciou uma vez
			}
			iniciou = true;

			LerArquivo(bancoDePalavras);
			Random rand = new Random();                                             // instancia objeto random
			int indiceEscolhido = rand.Next(100);                                   // sorteia novo índice aleatório
			SortearPalavra(indiceEscolhido, ref palavraSorteada, ref dicaSorteada); // recebe a palavra e a dica sorteada

			acertos = new char[palavraSorteada.Length];                             // instancia vetor acertos que recebe as letras acertadas

            pontos = 0;                                                             // zera variáveis
            erros = 0;
            lblPontos.Text = $"Pontos: {pontos}";
            lblErros.Text = $"Erros: {erros} / 8";
            txtDica.Text = " ";
            AtualizarImagens();
            segundos = 120;
			txtDica.Text = "";

			int i = 0;                                                              // instancia contador
			foreach (char letra in palavraSorteada)
			{
				dgvPalavraSecreta.Columns[i].HeaderText = "_";                      // adiciona '_' para cada letra da palavra sorteada
				i++;                                                                // contador ++
			}
			dgvPalavraSecreta.Width = 15 * 26 - (26 * (15 - i));                    // define o tamanho do dataGrid para o número de letras necessárias

			if (chkDica.Checked)                                                    // verifica se a dica foi acionada
			{
				txtDica.Text = dicaSorteada;                                        // exibe a dica no formulário
				timerJogo.Start();                                                  // inicia o timer
			}
		}

		private void VerificarBotao(object sender, EventArgs e)
		{
			try
			{
				if (iniciou)
				{
					string letraStr;
					(sender as Button).Enabled = false;                                                // desativa o botão clicado
					if((sender as Button).Text == "")                                                  // "" = " " (corrige para que o botão de espaço funcione)
						letraStr = " ";
					else
						letraStr = (sender as Button).Text;                                            // letra recebe o texto do botão clicado 
					char letra = letraStr[0];
					if (Verificar(letra, palavraSorteada, dgvPalavraSecreta, ref acertos))             // verifica se a tentiva está no vetor que contem as letras das palavras
					{
						pontos--;                                                                      // tira pontos e soma erros
						erros++;
					}
					else
					{
						pontos++;                                                                       // soma erros
					}
					AtualizarImagens();                                                                 // atualiza os valores
					lblPontos.Text = $"Pontos: {pontos}";
					lblErros.Text = $"Erros: {erros} / 8";
					VerificarVitoria();                                                                 // verifica se venceu
				}   
				else                                                                                    // se o jogo não foi iniciado
                {           
					throw new Exception("Inicie o jogo primeiro");                                      // lança exceção
				}
			}
			catch (Exception ex)
			{
				ExibirErro(ex.Message);
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			segundos--;                                                         // diminui os segundos
			lblTimer.Text = $"{segundos}s";                                     // exibe os segundos
			if (segundos == 0)                                                  // verifica se o tempo acabou
			{
				Derrota("O tempo acabou.");
			}
		}

		private void TxtNome_TextChanged(object sender, EventArgs e)
		{
			if (txtNome.Text == "")                                     /* verifica se o nome ja foi colocado para deixar */
			{                                                           /* o botão iniciar ativo */
				btnIniciar.Enabled = false;
			}
			else
			{
				btnIniciar.Enabled = true;
			}
		}

		public void VerificarVitoria()
		{
			bool correto = true;                                            // instancia o bool correto
			for (int i = 0; i < palavraSorteada.Length; i++)                // percorre o vetor com as letras das palavras
			{
				if (acertos[i] != palavraSorteada[i])                       /* verifica se o vetor que contem os acertos */
                {                                                           /* é diferente o vetor que contem as letras da palavra*/

                    correto = false;                                        // se for diferente a palavra ainda correto = false
					break;                                                  // sai da repetição
				}
			}
			if (correto)                                                    // se correto = true o jogo esta ganho                          
			{
				GravarDadosEmArquivo();                                     // grava dados no arquivo
				MessageBox.Show("Acertou!");
				timerJogo.Stop();
			}
		}

		private void Derrota(string motivo)
		{
			MessageBox.Show($"Perdeu! {motivo}\nA palavra era \"{palavraSorteada}\"");	// exibe mensagem de derrota
			timerJogo.Stop();															// para o timer
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//if(cadastro == null)
			cadastro = new Form2();
			cadastro.Show();
		}

		private void ExibirErro(string message)
		{
			lblErro.Text = message;                                                     // exibe erro no label acima do teclado 
			timerErro.Start();                                                          // starta um timer para o tempo em que ele ficará na tela
		}

		private void timerErro_Tick(object sender, EventArgs e)
		{
			lblErro.Text = "";                                                          // limpa o label erro                                           
			timerErro.Stop();                                                           // para o timer erro
		}

		public void AtualizarImagens()
		{
			switch(erros)                                                           // adiciona imagens de acordo com os erros
			{                                                                       
				case 0: break;
				case 1: forca1.Visible = true; forca1_1.Visible = true; break;
				case 2: forca2.Visible = true; break;
				case 3: forca3.Visible = true; break;
				case 4: forca4.Visible = true; break;
				case 5: forca5.Visible = true; break;
				case 6: forca6.Visible = true; break;
				case 7: forca6.Visible = true; break;
				case 8: forca7.Visible = true; Derrota("Errou 8 vezes."); break;    
			}
		}

		public void GravarDadosEmArquivo()
		{
			string arquivo = @"..\..\..\pontos.txt";
			int pontosEscrever = pontos;
			var reader = new StreamReader(arquivo);                                 // inicializa um StreamReader no arquivo pontos.txt
			int linha = 0;															// define a linha atual como 0
			bool achou = false;														// o loop não achou o nome
			while (!reader.EndOfStream)
			{
				linha++;															// incrementa a linha
				string linhaLida = reader.ReadLine();								// lê a linha atual
				string nomeLido = linhaLida.Substring(0, 30).Trim();				// divide em nome
				int pontoLido = int.Parse(linhaLida.Substring(30));					//           e ponto

				if (nomeLido == txtNome.Text.ToUpper())								// se o nome lido for o nome do jogador
				{
					pontosEscrever = pontoLido + pontos;							/* o programa pega os pontos do arquivo
																					 * e soma à pontuação atual, isso será escrito no arquivo
																					 */
					achou = true;													// o programa achou o nome do jogador
					break;															// quebra o loop
				}
			}
			reader.Close();                                                         // fecha o StreamReader
			if (achou) EditarLinha($"{txtNome.Text.ToUpper().PadRight(30)}{pontosEscrever}", arquivo, linha);   /* se o programa achou o nome do jogador,
																												 * chama a função EditarLinha(), passando
																												 * como parâmetros o texto a ser escrito,
																												 * o arquivo pontos.txt e a linha onde se
																												 * encontra a pontuação somada do jogador
																												 */
			else																								// senão,
			{
				var writer = new StreamWriter(arquivo, append: true);                                           /* instancia um StreamWriter definindo os
																												 * parâmetros arquivo e especificando que
																												 * ele deve inserir (append) texto, e não
																												 * sobrescrever o texto existente
																												 */
				writer.WriteLine($"{txtNome.Text.ToUpper().PadRight(30)}{pontosEscrever}");						/* escreve uma nova linha com o novo nome
																												 * e pontuação
																												 */
				writer.Close();                                                                                 // fecha o StreamWriter
			}
		}

		static void EditarLinha(string texto, string arquivo, int linha)			// método para editar uma linha especificada
		{
			string[] arrLine = File.ReadAllLines(arquivo);                          // usa o método ReadAllLines() da classe File para ler todas as linhas
			arrLine[linha - 1] = texto;												// encontra, na array de linhas lidas, a que será reescrita e envia o texto
			File.WriteAllLines(arquivo, arrLine);									// escreve todas as linhas de volta, sem alteração exceto a editada
		}

	}
}
    