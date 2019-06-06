namespace ProjetoII
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
			this.imlBotoes = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.barraDeFerramentas = new System.Windows.Forms.ToolStrip();
			this.btnInicio = new System.Windows.Forms.ToolStripButton();
			this.btnAnterior = new System.Windows.Forms.ToolStripButton();
			this.btnProximo = new System.Windows.Forms.ToolStripButton();
			this.btnUltimo = new System.Windows.Forms.ToolStripButton();
			this.btnNovo = new System.Windows.Forms.ToolStripButton();
			this.btnEditar = new System.Windows.Forms.ToolStripButton();
			this.btnSalvar = new System.Windows.Forms.ToolStripButton();
			this.btnExcluir = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1.SuspendLayout();
			this.barraDeFerramentas.SuspendLayout();
			this.SuspendLayout();
			// 
			// imlBotoes
			// 
			this.imlBotoes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotoes.ImageStream")));
			this.imlBotoes.TransparentColor = System.Drawing.Color.Transparent;
			this.imlBotoes.Images.SetKeyName(0, "first.bmp");
			this.imlBotoes.Images.SetKeyName(1, "prior.bmp");
			this.imlBotoes.Images.SetKeyName(2, "next.bmp");
			this.imlBotoes.Images.SetKeyName(3, "last.bmp");
			this.imlBotoes.Images.SetKeyName(4, "Add.bmp");
			this.imlBotoes.Images.SetKeyName(5, "WINNEXT.BMP");
			this.imlBotoes.Images.SetKeyName(6, "Save.bmp");
			this.imlBotoes.Images.SetKeyName(7, "Minus.bmp");
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(779, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// barraDeFerramentas
			// 
			this.barraDeFerramentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.btnProximo,
            this.btnUltimo,
            this.btnNovo,
            this.btnEditar,
            this.btnSalvar,
            this.btnExcluir});
			this.barraDeFerramentas.Location = new System.Drawing.Point(0, 24);
			this.barraDeFerramentas.Name = "barraDeFerramentas";
			this.barraDeFerramentas.Size = new System.Drawing.Size(779, 38);
			this.barraDeFerramentas.TabIndex = 1;
			this.barraDeFerramentas.Text = "toolStrip1";
			// 
			// btnInicio
			// 
			this.btnInicio.BackColor = System.Drawing.Color.Silver;
			this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
			this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnInicio.Name = "btnInicio";
			this.btnInicio.Size = new System.Drawing.Size(40, 35);
			this.btnInicio.Text = "Início";
			this.btnInicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnAnterior
			// 
			this.btnAnterior.BackColor = System.Drawing.Color.Silver;
			this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
			this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAnterior.Name = "btnAnterior";
			this.btnAnterior.Size = new System.Drawing.Size(42, 35);
			this.btnAnterior.Text = "Voltar";
			this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnProximo
			// 
			this.btnProximo.BackColor = System.Drawing.Color.Silver;
			this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
			this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProximo.Name = "btnProximo";
			this.btnProximo.Size = new System.Drawing.Size(54, 35);
			this.btnProximo.Text = "Avançar";
			this.btnProximo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnProximo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnUltimo
			// 
			this.btnUltimo.BackColor = System.Drawing.Color.Silver;
			this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
			this.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUltimo.Name = "btnUltimo";
			this.btnUltimo.Size = new System.Drawing.Size(47, 35);
			this.btnUltimo.Text = "Último";
			this.btnUltimo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnNovo
			// 
			this.btnNovo.BackColor = System.Drawing.Color.Silver;
			this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
			this.btnNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNovo.Name = "btnNovo";
			this.btnNovo.Size = new System.Drawing.Size(44, 35);
			this.btnNovo.Text = "Incluir";
			this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnEditar
			// 
			this.btnEditar.BackColor = System.Drawing.Color.Silver;
			this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
			this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(46, 35);
			this.btnEditar.Text = "Alterar";
			this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnSalvar
			// 
			this.btnSalvar.BackColor = System.Drawing.Color.Silver;
			this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
			this.btnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(42, 35);
			this.btnSalvar.Text = "Salvar";
			this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnExcluir
			// 
			this.btnExcluir.BackColor = System.Drawing.Color.Silver;
			this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
			this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Size = new System.Drawing.Size(45, 35);
			this.btnExcluir.Text = "Excluir";
			this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 389);
			this.Controls.Add(this.barraDeFerramentas);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.barraDeFerramentas.ResumeLayout(false);
			this.barraDeFerramentas.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ImageList imlBotoes;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStrip barraDeFerramentas;
		private System.Windows.Forms.ToolStripButton btnInicio;
		private System.Windows.Forms.ToolStripButton btnAnterior;
		private System.Windows.Forms.ToolStripButton btnProximo;
		private System.Windows.Forms.ToolStripButton btnUltimo;
		private System.Windows.Forms.ToolStripButton btnNovo;
		private System.Windows.Forms.ToolStripButton btnEditar;
		private System.Windows.Forms.ToolStripButton btnSalvar;
		private System.Windows.Forms.ToolStripButton btnExcluir;
	}
}