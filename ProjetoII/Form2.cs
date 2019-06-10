using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoII
{
	public partial class Form2 : Form
	{

		VetorDados<Palavra> asPalavras;

		public Form2()
		{
			InitializeComponent();
			asPalavras = new VetorDados<Palavra>(100);
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			int indice = 0;
			barraDeFerramentas.ImageList = imlBotoes;
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton)
					(item as ToolStripButton).ImageIndex = indice++;

			asPalavras.LerDados(FormForca.bancoDePalavras);     // lemos os dados na classe vetor passando como parâmetro o nome do arquivo aberto
			AtualizaDataGrid();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AtualizaDataGrid()
		{
			dgvPalavra.Rows.Clear();
			asPalavras.Ordenar();
			for (int i = 0; i < asPalavras.Tamanho; i++)
			{
				Palavra palavraDataGrid = asPalavras[i];
				dgvPalavra.Rows.Insert(i, i, palavraDataGrid.PalavraTexto, palavraDataGrid.DicaTexto);
			}
			asPalavras.PosicionarNoUltimo();
			AtualizarTela();
		}

		private void AtualizarTela()
		{
			if (!asPalavras.EstaVazio)
			{
				Palavra palavra = asPalavras[asPalavras.PosicaoAtual];
				txtPalavra.Text = palavra.PalavraTexto.Trim();
				txtDica.Text = palavra.DicaTexto.Trim();

				dgvPalavra.ClearSelection();
				dgvPalavra.Rows[asPalavras.PosicaoAtual].Selected = true;
			}
		}

		private void LimparTela()
		{
			txtPalavra.Clear();
			txtDica.Clear();
		}

		private void btnInicio_Click(object sender, EventArgs e)
		{
			asPalavras.PosicionarNoPrimeiro();
			AtualizarTela();
		}

		private void btnProximo_Click(object sender, EventArgs e)
		{
			asPalavras.AvancarPosicao();
			AtualizarTela();
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			asPalavras.RetrocederPosicao();
			AtualizarTela();
		}

		private void btnUltimo_Click(object sender, EventArgs e)
		{
			asPalavras.PosicionarNoUltimo();
			AtualizarTela();
		}

		private void btnNovo_Click(object sender, EventArgs e)
		{
			if (!asPalavras.EstaVazio)
			{
				asPalavras.SituacaoAtual = Situacao.incluindo;
				btnSalvar.Enabled = true;
				LimparTela();
				txtDica.Enabled = true;
				txtPalavra.Enabled = true;
				txtPalavra.Focus();
			}
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			asPalavras.SituacaoAtual = Situacao.editando;
			btnSalvar.Enabled = true;
			txtDica.Enabled = true;
			txtPalavra.Enabled = true;
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			string textoFinal = "";
			if (asPalavras[asPalavras.PosicaoAtual].DicaTexto.Remove(25).Trim() != asPalavras[asPalavras.PosicaoAtual].DicaTexto.Trim())
				textoFinal = "...";

			if (MessageBox.Show($"Deseja excluir esse registro?{Environment.NewLine}{Environment.NewLine}" +
				$"Palavra: {asPalavras[asPalavras.PosicaoAtual].PalavraTexto}{Environment.NewLine}" +
				$"Dica: {asPalavras[asPalavras.PosicaoAtual].DicaTexto.Remove(25).Trim()}{textoFinal}", "Exclusão", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				asPalavras.Excluir(asPalavras.PosicaoAtual);
				if (asPalavras.PosicaoAtual > asPalavras.Tamanho)
					asPalavras.PosicionarNoUltimo();
				AtualizarTela();
				AtualizaDataGrid();
				asPalavras.GravarDados(FormForca.bancoDePalavras);
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (asPalavras.SituacaoAtual == Situacao.incluindo)
			{
				if (txtDica.Text != "")
				{
					var novoDesafio = new Palavra(txtPalavra.Text.ToUpper().PadRight(15, ' '), txtDica.Text.PadRight(100, ' '));
					asPalavras.Incluir(novoDesafio);
					asPalavras.GravarDados(FormForca.bancoDePalavras);
				}
				else
					MessageBox.Show("Digite uma dica para sua palavra!");
			}
			else
				if (asPalavras.SituacaoAtual == Situacao.editando)
			{
				asPalavras[asPalavras.PosicaoAtual] = new Palavra(txtPalavra.Text.ToUpper().PadRight(15, ' '), txtDica.Text.PadRight(100, ' '));
				asPalavras.GravarDados(FormForca.bancoDePalavras);
			}
			AtualizarTela();
			AtualizaDataGrid();
			asPalavras.SituacaoAtual = Situacao.navegando;
			btnSalvar.Enabled = false;
			txtPalavra.Enabled = false;
			txtDica.Enabled = false;
		}

		private void DgvPalavra_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if ((sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
			{
				(sender as DataGridView).CurrentRow.Selected = true;
				int indiceAtual = int.Parse((sender as DataGridView).Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
				asPalavras.PosicionarEm(indiceAtual);
				AtualizarTela();
			}
		}
	}
}
