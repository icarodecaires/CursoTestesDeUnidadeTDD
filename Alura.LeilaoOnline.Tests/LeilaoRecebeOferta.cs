using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{

	public class LeilaoRecebeOferta
	{


		[Fact]
		public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimo()
		{
			var leilao = new Leilao("Van Gogh");

			var fulano = new Interessada("fulano", leilao);
			var maria = new Interessada("maria", leilao);

			leilao.IniciaPregao();

			leilao.RecebeLance(fulano, 800);
			leilao.RecebeLance(fulano, 1000);

			leilao.TerminaPregao();


			var qtdEsperada = 1;
			var valorObtido = leilao.Lances.Count();

			Assert.Equal(qtdEsperada, valorObtido);
		}

		[Theory]
		[InlineData(2, new double[] {100,200})]
		[InlineData(5, new double[] { 100, 200, 1000, 3000, 5000 })]
		public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[]ofertas)
		{
			var leilao = new Leilao("Van Gogh");
			var fulano = new Interessada("fulano", leilao);
			var maria = new Interessada("maria", leilao);

			
			leilao.IniciaPregao();

			var _utimo = fulano;
			foreach (var oferta in ofertas)
			{
				var _interessado = _utimo == fulano ? maria : fulano;

				leilao.RecebeLance(_interessado, oferta);
				_utimo = _interessado;
			}

			leilao.TerminaPregao();


			var valorObtido = leilao.Lances.Count();

			Assert.Equal(qtdEsperada, valorObtido);
		}
	}
}
