using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{

	public class LeilaoTerminaPregao
	{
		[Theory]
		[InlineData(1200,new double[] { 800, 900, 1000, 1200 })]
		[InlineData(1000,new double[] { 800, 900, 1000, 990 })]
		[InlineData(800,new double[] { 800 })]
		public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado,double[] ofertas)
		{
			var leilao = new Leilao("Van Gogh");
			var fulano = new Interessada("fulano", leilao);
			var maria = new Interessada("maria", leilao);


			leilao.IniciaPregao();

			var _utimo = fulano;
			foreach (var oferta in ofertas)
			{
				var _interessado = (_utimo == fulano) ? maria : fulano;

				leilao.RecebeLance(_interessado, oferta);
				_utimo = _interessado;
			}


			leilao.TerminaPregao();

			var valorObtido = leilao.Ganhador.Valor;

			Assert.Equal(valorEsperado, valorObtido);
			//Assert.Equal(fulano, leilao.Ganhador.Cliente);
		}



		[Fact]
		public void RetornaZeroDadoLeilaoSemLances()
		{
			var leilao = new Leilao("Van Gogh");
			
			leilao.IniciaPregao();
		

			leilao.TerminaPregao();

			var valorEsperado = 0;
			var valorObtido = leilao.Ganhador.Valor;

			Assert.Equal(valorEsperado, valorObtido);
		}
	}

}
