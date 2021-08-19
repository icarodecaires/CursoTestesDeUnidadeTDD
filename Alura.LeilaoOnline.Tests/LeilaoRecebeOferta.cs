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
		[Theory]
		[InlineData(2, new double[] {100,200})]
		[InlineData(5, new double[] { 100, 200, 1000, 3000, 5000 })]
		public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdEsperada, double[]ofertas)
		{
			var leilao = new Leilao("Van Gogh");

			var fulano = new Interessada("fulano", leilao);
			var maria = new Interessada("maria", leilao);

			leilao.IniciaPregao();

			foreach(var oferta in ofertas)
			{
				leilao.RecebeLance(fulano, oferta);
			}

			leilao.TerminaPregao();


			var valorObtido = leilao.Lances.Count();

			Assert.Equal(qtdEsperada, valorObtido);
		}
	}
}
