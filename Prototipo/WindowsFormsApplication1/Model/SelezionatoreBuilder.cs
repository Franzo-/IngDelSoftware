using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    static class SelezionatoreBuilder
    {
        private readonly static SelezionatoreTutteStatSquadra SelezionatoreTutteStatSquadra = new SelezionatoreTutteStatSquadra();
        private readonly static SelezionatoreTutteStatGiocatori SelezionatoreTutteStatGiocatore = new SelezionatoreTutteStatGiocatori();

        public static ISelezionatore Build(Type tipo, Squadra squadra = null, Partita partita = null)
        {
            ISelezionatore result = null;

            if (tipo == typeof(StatisticaSquadra))
            {
                result = SelezionatoreTutteStatSquadra;
            }
            else if (tipo == typeof(StatisticaGiocatore))
            {
                result = SelezionatoreTutteStatGiocatore;

                if (squadra != null)
                {
                    result = new SelezionatoreStatGiocatorePerSquadra((SelezionatoreStatGiocBase) result, squadra);
                }
                if (partita != null)
                {
                    result = new SelezionatoreStatGiocatorePerPartita((SelezionatoreStatGiocBase) result, partita);
                }
            }

            return result;
        }
    }
}
