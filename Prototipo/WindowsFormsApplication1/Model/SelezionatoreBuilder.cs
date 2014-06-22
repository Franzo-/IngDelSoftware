using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    static class SelezionatoreBuilder
    {

        public static ISelezionatore Build(Type tipo, Campionato campionato, Squadra squadra = null, Partita partita = null)
        {
            ISelezionatore result = null;

            if (tipo == typeof(StatisticaSquadra))
            {
                result = new SelezionatoreTutteStatSquadra(campionato);
            }
            else if (tipo == typeof(StatisticaGiocatore))
            {
                result = new SelezionatoreTutteStatGiocatori(campionato);

                if (squadra != null)
                {
                    result = new SelezionatoreStatGiocatorePerSquadra((SelezionatoreStatGiocBase) result, squadra, campionato.Anno);
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
