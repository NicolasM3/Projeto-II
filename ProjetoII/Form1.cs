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

namespace ProjetoII
{
	public partial class FormForca : Form
	{
		VetorPalavra vetor = new VetorPalavra(100);
		Random rand = new Random();
		string palavraSorteada, dicaSorteada;
        char[] VLetrasPalavra, LetrasTestadas, acertos;
        int qntLetrasTestadas = 0, erros = 0, pontos = 0, segundos = 122;
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
                    //txtNome.Text = vetor.Dados[rand.Next(100)].PalavraTexto.Trim();
                }
			}
		}

		private void LerArquivo(string arquivo)
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

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			iniciou = true;
			int indiceEscolhido = rand.Next(100);
			palavraSorteada = vetor.Dados[indiceEscolhido].PalavraTexto.Trim();
			dicaSorteada = vetor.Dados[indiceEscolhido].DicaTexto.Trim();


			VLetrasPalavra = new char[palavraSorteada.Length];
			LetrasTestadas = new char[39];
			acertos = new char[palavraSorteada.Length];

			int i = 0;
			foreach (char letra in palavraSorteada)
			{
				VLetrasPalavra[i] = letra;
				dgvPalavraSecreta.Columns[i].HeaderText = "_";
				i++;
			}
			dgvPalavraSecreta.Width = 15 * 26 - (26 * (15 - i));      // define o tamanho do dataGrid para o número de letras necessárias


			lblPontos.Text = "Pontos: 0";
			lblErros.Text = "Erros: 0 / 8";

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
					string letraStr = (sender as Button).Text;
					char letra = letraStr[0];
					Verificar(letra);
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

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

        private void Verificar(char tentativa)
        {
			int onde = -1;
			bool existe = false;
			for (int indice = 0; !existe && indice < qntLetrasTestadas; indice++)
				if (LetrasTestadas[indice] == tentativa)
				{
					existe = true;
					onde = indice;
				}
			if (!existe)
			{
				bool achou = false;
				LetrasTestadas[qntLetrasTestadas] = tentativa;
				for (int i = 0; i < palavraSorteada.Length; i++)
				{
					if (VLetrasPalavra[i] == Char.ToUpper(tentativa))
					{
						dgvPalavraSecreta.Columns[i].HeaderText = tentativa.ToString();
						acertos[i] = tentativa;
						pontos++;
						achou = true;
						VerificarVitoria();
					}
				}
				if (!achou)
				{
					pontos--;
					erros++;
				}
				qntLetrasTestadas++;
				lblPontos.Text = $"Pontos: {pontos}";
				lblErros.Text = $"Erros: {erros} / 8";
				AtualizarImagens();
			}
			else
			{
				ExibirErro("Você já tentou essa letra!");
			}
		}

		private void VerificarVitoria()
		{
			bool correto = true;
			for (int i = 0; i < palavraSorteada.Length; i++)
			{
				if (acertos[i] != VLetrasPalavra[i])
				{
					correto = false;
					break;
				}
			}
			if (correto)
				MessageBox.Show("Acertou!");
		}

		private void Derrota()
		{
			iniciou = false;
			MessageBox.Show("Perdeu");
			//forca9.Visible = true;
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

		private void AtualizarImagens()
		{
			// Forca_xx
			// 05/08, 09, 07, 10, 14, 16, 17, 1_05

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
				case 8: forca7.Visible = true; Derrota(); break;
			}
		}

	}
}
