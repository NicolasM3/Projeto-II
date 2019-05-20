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
		public static string palavraSorteada, dicaSorteada;
		public char[] LetrasTestadas, acertos;
		public static int qntLetrasTestadas = 0, erros = 0, pontos = 0, segundos = 120;
		bool iniciou;

		public FormForca()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			bool abriu = false;
			while (!abriu)
			{
				if (dlgAbrir.ShowDialog() == DialogResult.OK)
				{
					abriu = true;
					LerArquivo(dlgAbrir.FileName);
				}
			}
		}

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			if (iniciou)
			{
				Application.Restart();
			}
			iniciou = true;

			forca1.Visible = false;
			forca1_1.Visible = false;
			forca2.Visible = false;
			forca3.Visible = false;
			forca4.Visible = false;
			forca5.Visible = false;
			forca6.Visible = false;
			forca7.Visible = false;
			forca8.Visible = false;
			forca9.Visible = false;

			Random rand = new Random();
			int indiceEscolhido = rand.Next(100);
			SortearPalavra(indiceEscolhido, ref palavraSorteada, ref dicaSorteada);

			LetrasTestadas = new char[39];
			acertos = new char[palavraSorteada.Length];

            pontos = 0;
            erros = 0;
            lblPontos.Text = $"Pontos: {pontos}";
            lblErros.Text = $"Erros: {erros} / 8";
            txtDica.Text = " ";
            AtualizarImagens();
            segundos = 120;
			txtDica.Text = "";

			int i = 0;
			foreach (char letra in palavraSorteada)
			{
				dgvPalavraSecreta.Columns[i].HeaderText = "_";
				i++;
			}
			dgvPalavraSecreta.Width = 15 * 26 - (26 * (15 - i));      // define o tamanho do dataGrid para o número de letras necessárias

			if (chkDica.Checked)
			{
				txtDica.Text = dicaSorteada;
				timerJogo.Start();
			}
		}

		private void VerificarBotao(object sender, EventArgs e)
		{
			try
			{
				if (iniciou)
				{
					string letraStr;
					(sender as Button).Enabled = false;
					if((sender as Button).Text == "")
						letraStr = " ";
					else
						letraStr = (sender as Button).Text;
					char letra = letraStr[0];
					if (Verificar(letra, palavraSorteada, dgvPalavraSecreta, ref acertos))
					{
						pontos--;
						erros++;
					}
					else
					{
						pontos++;
					}
					AtualizarImagens();
					lblPontos.Text = $"Pontos: {pontos}";
					lblErros.Text = $"Erros: {erros} / 8";
					VerificarVitoria();
				}
				else
				{
					throw new Exception("Inicie o jogo primeiro");
				}
			}
			catch (Exception ex)
			{
				ExibirErro(ex.Message);
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			segundos--;
			lblTimer.Text = $"{segundos}s";
			if (segundos == 0)
			{
				Derrota("O tempo acabou.");
			}
		}

		private void TxtNome_TextChanged(object sender, EventArgs e)
		{
			if (txtNome.Text == "")
			{
				btnIniciar.Enabled = false;
			}
			else
			{
				btnIniciar.Enabled = true;
			}
		}

		public void VerificarVitoria()
		{
			bool correto = true;
			for (int i = 0; i < palavraSorteada.Length; i++)
			{
				if (acertos[i] != palavraSorteada[i])
				{
					correto = false;
					break;
				}
			}
			if (correto)
			{
				GravarDadosEmArquivo();
				MessageBox.Show("Acertou!");
			}
		}

		private void Derrota(string motivo)
		{
			MessageBox.Show($"Perdeu! {motivo}\nA palavra era \"{palavraSorteada}\"");
			timerJogo.Stop();
		}

		private void ExibirErro(string message)
		{
			lblErro.Text = message;
			timerErro.Start();
		}

		private void timerErro_Tick(object sender, EventArgs e)
		{
			lblErro.Text = "";
			timerErro.Stop();
		}

		public void AtualizarImagens()
		{
			switch(erros)
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
			var reader = new StreamReader(arquivo);
			int linha = 0;
			bool achou = false;
			while (!reader.EndOfStream)
			{
				linha++;
				string linhaLida = reader.ReadLine();
				string nomeLido = linhaLida.Substring(0, 30).Trim();
				int pontoLido = int.Parse(linhaLida.Substring(30));

				if (nomeLido == txtNome.Text.ToUpper())
				{
					pontosEscrever = pontoLido + pontos;
					achou = true;
					break;
				}
			}
			reader.Close();
			if (achou) EditarLinha($"{txtNome.Text.ToUpper().PadRight(30)}{pontosEscrever}", arquivo, linha);
			else
			{
				var writer = new StreamWriter(arquivo, append: true);
				writer.WriteLine($"{txtNome.Text.ToUpper().PadRight(30)}{pontosEscrever}");
				writer.Close();
			}
		}

		static void EditarLinha(string texto, string arquivo, int linha)
		{
			string[] arrLine = File.ReadAllLines(arquivo);
			arrLine[linha - 1] = texto;
			File.WriteAllLines(arquivo, arrLine);
		}

	}
}
