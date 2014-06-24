using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    abstract class SelezionatoreStatSquadraBase : ISelezionatore
    {
        public IEnumerable<Statistica> GetStatistiche()
        {
            return GetStatisticheSquadra();
        }

        public abstract IEnumerable<StatisticaSquadra> GetStatisticheSquadra();
    }

    class SelezionatoreTutteStatSquadra : SelezionatoreStatSquadraBase
    {
        private readonly Campionato _campionato;

        public SelezionatoreTutteStatSquadra(Campionato campionato)
        {
            if (campionato == null)
                throw new ArgumentException("campionato == null");

            _campionato = campionato;
        }

        public override IEnumerable<StatisticaSquadra> GetStatisticheSquadra()
        {
            // LINQ con clone delle statistiche
            return from stat in _campionato.Statistiche
                   where stat.GetType() == typeof(StatisticaSquadra)
                   select (StatisticaSquadra) stat.Clone();
        }
    }
}
