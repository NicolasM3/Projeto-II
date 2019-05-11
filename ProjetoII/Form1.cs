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
        char[] VLetrasPalavra, LetrasTestadas;
        int qntLetrasTestadas = 0, erros = 0, pontos = 0;


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
			int indiceEscolhido = rand.Next(100);
			palavraSorteada = vetor.Dados[indiceEscolhido].PalavraTexto.Trim();
			dicaSorteada = vetor.Dados[indiceEscolhido].DicaTexto.Trim();


            VLetrasPalavra = new char[palavraSorteada.Length];
            LetrasTestadas = new char[39];
            int i = 0;
            foreach (char letra in palavraSorteada)
            {
                VLetrasPalavra[i] = letra;
                i++;
            }
            dgvPalavraSecreta.Width = 15*26 - (26 * (15 - i));      // define o tamanho do dataGrid para o número de letras necessárias


			lblPontos.Text = "Pontos: 0";
			lblErros.Text = "Erros: 0 / 8";

			if (chkDica.Checked)
			{
				lblTimer.Text = "120s";
				// timer
				txtDica.Text = dicaSorteada;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

        private void Verificar(char tentativa)
        {
            bool achou = false;
            LetrasTestadas[qntLetrasTestadas] = tentativa; 
            for(int i = 0; i < palavraSorteada.Length; i++)
            {
                if(VLetrasPalavra[i] == Char.ToUpper(tentativa))   
                {
                    dgvPalavraSecreta.Rows[0].Cells[0].Value = tentativa;
                    pontos++;
                    achou = true;
                }
            }
            if (!achou)
            {
                pontos--;
                erros++;
            }
            qntLetrasTestadas++;
        }


        private void btnA_Click(object sender, EventArgs e)
        {
            Verificar('a');
        }

    }
}
