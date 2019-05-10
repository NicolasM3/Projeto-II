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
		public Palavra(string p, string d)
		{
			PalavraTexto = p;
			DicaTexto = d;
		}

		public string PalavraTexto { get; }
		public string DicaTexto { get; }
	}
}
