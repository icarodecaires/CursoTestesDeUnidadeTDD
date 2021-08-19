using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
	class Program
	{
		static void Main()
		{
			var leilao = new Leilao("Van Gogh");
			var fulano = new Interessada("fulano", leilao);
			var maria = new Interessada("maria", leilao);

			leilao.RecebeLance(fulano, 800);
			leilao.RecebeLance(maria, 900);
			leilao.RecebeLance(fulano, 1000);


			leilao.TerminaPregao();

			Console.WriteLine(leilao.Ganhador.Valor);

		}
	}
}
