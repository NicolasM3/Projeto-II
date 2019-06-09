using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoII
{
	class Palavra : IComparable<Palavra>, IRegistro
    {
        string palavraTexto, dicaTexto;
        const int tamanhoPalavra = 15;
        const int tamanhoDica = 100;

        const int inicioPalavra = 0;
        const int inicioDica = inicioPalavra + tamanhoPalavra;
        public Palavra()
        {

        }
		public Palavra(string p, string d)
		{
			palavraTexto = p;
			dicaTexto = d;
		}

		public string PalavraTexto { get => palavraTexto; set => palavraTexto = value;}
		public string DicaTexto { get => dicaTexto; set => dicaTexto = value;}

        public void LerRegistro(StreamReader str)
        {
			if (!str.EndOfStream) // se o arquivo não acabou
			{
				string linha = str.ReadLine(); // linha do arquivo
				PalavraTexto = linha.Substring(inicioPalavra, tamanhoPalavra); //divide a linha em strings "palavraUsada" e "dicaUsada"
				DicaTexto = linha.Substring(inicioDica);
			}
        }

        public string ParaArquivo()
        {
            return PalavraTexto.PadRight(15, ' ') + DicaTexto.PadRight(100, ' '); ;
        }

        public int CompareTo(Palavra outro)
        {
            // codigoLivro é string, e a classe string já vem com
            // um método CompareTo pronto e, assim, nós o chamamos
            // para comparar o código do livro desta instância com
            // o código do livro do outro objeto Livro (parâmetro outro)
            return 1;
        }
    }
}
