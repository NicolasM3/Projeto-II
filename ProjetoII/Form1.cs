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
					//txtNome.Text = vetor.Dados[rand.Next(50)].PalavraTexto.Trim();
					//txtNome.Text = "a";
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
				string dica = linhaLida.Substring(16);

				var palavraDica = new Palavra(palavra, dica);

				vetor.InserirAposFim(palavraDica);
			}
			reader.Close();
		}

		private void button40_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
