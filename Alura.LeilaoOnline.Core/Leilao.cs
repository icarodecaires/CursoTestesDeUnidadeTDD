using Alura.LeilaoOnline.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
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

        public void RecebeLance(Interessada cliente, double valor)
        {
            if(Estado == EstadoLeilao.LeilaoAndamento)
			{
                _lances.Add(new Lance(cliente, valor));
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
