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
			barraDeFerramentas.ImageList = imlBotoes;						// associa imagens do ImageList aos botões
			foreach (ToolStripItem item in barraDeFerramentas.Items)
				if (item is ToolStripButton)
					(item as ToolStripButton).ImageIndex = indice++;

			asPalavras.LerDados(FormForca.bancoDePalavras);					// lê os dados na classe vetor passando como parâmetro o nome do arquivo aberto
			AtualizaDataGrid();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AtualizaDataGrid()
		{
			dgvPalavra.Rows.Clear();										// limpa o DataGridView
			asPalavras.Ordenar();											// ordena o vetor de palavras
			for (int i = 0; i < asPalavras.Tamanho; i++)                    // escreve as palavras no DataGridView
			{
				Palavra palavraDataGrid = asPalavras[i];
				dgvPalavra.Rows.Insert(i, i, palavraDataGrid.PalavraTexto, palavraDataGrid.DicaTexto);
			}
			asPalavras.PosicionarNoPrimeiro();								// seleciona o primeiro registro
			AtualizarTela();												// atualiza as TextBox
		}

		private void AtualizarTela()
		{
			if (!asPalavras.EstaVazio)
			{																// defina as TextBox com a palavra e dica selecionada
				Palavra palavra = asPalavras[asPalavras.PosicaoAtual];
				txtPalavra.Text = palavra.PalavraTexto.Trim();				// a função Trim() remove os espaços extras no fim da string
				txtDica.Text = palavra.DicaTexto.Trim();
				dgvPalavra.ClearSelection();								// desseleciona todas as linhas
				dgvPalavra.Rows[asPalavras.PosicaoAtual].Selected = true;   // seleciona a linha atual
				dgvPalavra.CurrentCell = dgvPalavra.Rows[asPalavras.PosicaoAtual].Cells[0];
				dgvPalavra.BeginEdit(true);									// faz com que a célula seja exibida na tela
				dgvPalavra.EndEdit();										// fecha a edição, para que o usuário não altere os
																			// valores diretamente no DataGridView
			}
		}

		private void LimparTela()
		{																	// limpa o texto nos dois TextBox
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
				asPalavras.SituacaoAtual = Situacao.incluindo;				// muda a situação do programa para "incluindo"
				btnSalvar.Enabled = true;									// e habilita os controles necessários
				LimparTela();
				txtDica.Enabled = true;
				txtPalavra.Enabled = true;
				txtPalavra.Focus();
			}
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			asPalavras.SituacaoAtual = Situacao.editando;					// muda a situação do programa para "editando"
			btnSalvar.Enabled = true;										// e habilita os controles necessários
			txtDica.Enabled = true;
			txtPalavra.Enabled = true;
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			string textoFinal = "";
			if (asPalavras[asPalavras.PosicaoAtual].DicaTexto.Remove(25).Trim() != asPalavras[asPalavras.PosicaoAtual].DicaTexto.Trim())
				textoFinal = "...";											// verifica se a dica precisou ser cortada antes de ser exibida
																			// se sim, exibe reticências no fim

			if (MessageBox.Show($"Deseja excluir esse registro?{Environment.NewLine}{Environment.NewLine}" +
				$"Palavra: {asPalavras[asPalavras.PosicaoAtual].PalavraTexto}{Environment.NewLine}" +
				$"Dica: {asPalavras[asPalavras.PosicaoAtual].DicaTexto.Remove(25).Trim()}{textoFinal}", "Exclusão", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning) == DialogResult.Yes)
			{																// exibe uma confirmação para a exclusão
				asPalavras.Excluir(asPalavras.PosicaoAtual);				// caso o usuário confirme, exclui o registro
				if (asPalavras.PosicaoAtual > asPalavras.Tamanho)
					asPalavras.PosicionarNoUltimo();
				AtualizarTela();
				AtualizaDataGrid();
				asPalavras.GravarDados(FormForca.bancoDePalavras);			// grava o arquivo
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (asPalavras.SituacaoAtual == Situacao.incluindo)				// caso esteja incluindo
			{
				if (txtPalavra.Text == "")									// verifica se a palavra foi digitada
					MessageBox.Show("Digite uma palavra!");
				else
				{
					if (txtDica.Text != "")									// verifica se a dica foi digitada
					{														// cria um novo objeto Palavra
						var novoDesafio = new Palavra(txtPalavra.Text.ToUpper().PadRight(15, ' '), txtDica.Text.PadRight(100, ' '));
						asPalavras.Incluir(novoDesafio);					// inclui o objeto ao vetor
						asPalavras.GravarDados(FormForca.bancoDePalavras);	// e grava o arquivo
					}
					else
						MessageBox.Show("Digite uma dica para sua palavra!");
				}
			}
			else if (asPalavras.SituacaoAtual == Situacao.editando)			// caso esteja editando
			{
				if (txtPalavra.Text != "")
				{
					if (txtDica.Text != "")
					{
						asPalavras[asPalavras.PosicaoAtual] = new Palavra(txtPalavra.Text.ToUpper().PadRight(15, ' '), txtDica.Text.PadRight(100, ' '));
						asPalavras.GravarDados(FormForca.bancoDePalavras);
					}
					else
						MessageBox.Show("A dica não pode estar vazia!");
				}
				else
					MessageBox.Show("A palavra não pode estar vazia!");
			}
			AtualizarTela();												// atualiza as caixas de texto
			AtualizaDataGrid();												// e o DataGridView
			asPalavras.SituacaoAtual = Situacao.navegando;					// define a situação como navegando
			btnSalvar.Enabled = false;										// desabilita os controles necessários
			txtPalavra.Enabled = false;
			txtDica.Enabled = false;
		}

		private void DgvPalavra_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// ao clicar numa célula, seleciona a sua linha e define-a como a posição selecionada no vetor
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
