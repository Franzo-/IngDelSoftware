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
        public override IEnumerable<StatisticaSquadra> GetStatisticheSquadra()
        {
            //TODO: espressione LINQ?
            return /* GetCurrentCampionato.GetStatistiche */;
        }
    }
}
