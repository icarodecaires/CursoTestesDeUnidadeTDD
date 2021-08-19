using Alura.LeilaoOnline.Core;
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

			foreach (var valor in ofertas)
			{
				leilao.RecebeLance(fulano, valor);
			}
			

			leilao.TerminaPregao();

			var valorObtido = leilao.Ganhador.Valor;

			Assert.Equal(valorEsperado, valorObtido);
			Assert.Equal(fulano, leilao.Ganhador.Cliente);
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
