﻿using Alura.LeilaoOnline.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
	public class Leilao
	{
		private Interessada _ultimoCliente;
		private IList<Lance> _lances;
		public IEnumerable<Lance> Lances => _lances;
		public string Peca { get; }
		public Lance Ganhador { get; private set; }
		public EstadoLeilao Estado;

		public Leilao(string peca)
		{
			Peca = peca;
			_lances = new List<Lance>();
			Estado = EstadoLeilao.LeilaoAntesDoPregao;
		}

		private bool LanceAceito(Interessada cliente, double valor)
		{
			return (Estado == EstadoLeilao.LeilaoAndamento) && (cliente != _ultimoCliente);

		}

		public void RecebeLance(Interessada cliente, double valor)
		{
			if (LanceAceito(cliente, valor))
			{
				_lances.Add(new Lance(cliente, valor));
				_ultimoCliente = cliente;
			}
		}

		public void IniciaPregao()
		{
			Estado = EstadoLeilao.LeilaoAndamento;
		}

		public void TerminaPregao()
		{
			Ganhador = Lances.DefaultIfEmpty(new Lance(null, 0)).OrderBy(l => l.Valor).LastOrDefault();
			Estado = EstadoLeilao.LeilaoFinalizado;
		}
	}
}
