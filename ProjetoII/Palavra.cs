using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoII
{
	class Palavra
	{
		string palavra;
		string dica;

		public Palavra(string p, string d)
		{
			palavra = p;
			dica = d;
		}

		public string PalavraTexto { get => palavra; }
		public string DicaTexto { get => dica; }
	}
}
