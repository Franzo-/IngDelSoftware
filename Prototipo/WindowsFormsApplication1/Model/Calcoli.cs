using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    interface ICalcoloVisitor
    {
        void Visit(Statistica statistica, string metodo);
    }

    class CalcoloVisitor : ICalcoloVisitor
    {
        static private class CalcoloUtility
        {
            //Nota:
            //  è possibile svolgere i calcoli in maniera semplificata grazie 
            //  alla ridefinizione dell'operatore in CampoStatistiche.

            internal static CampoStatistica Media(CampoStatistica campoPrimo, CampoStatistica campoSecondo)
            {
                return campoPrimo / campoSecondo;
            }

            internal static CampoStatistica Percentuale(CampoStatistica campoParziale, CampoStatistica campoTotale)
            {
                return (campoParziale * new CampoStatistica(100.0)) / campoTotale;
            }

        }

        //Attributo Custom
        [Custom("Partite Vinte", typeof(StatisticaSquadra))]
        public void PercentualeVittorieSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Partite Vinte"), 
                                                                statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Percentuale vittorie squadra", percentuale );
        }

        //Attributo Custom
        [Custom("Partite Perse", typeof(StatisticaSquadra))]
        public void PercentualeSconfitteSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Partite Perse"),
                                                                statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Percentuale sconfitte squadra", percentuale);
        }

        //Attributo Custom
        [Custom("Punti", typeof(StatisticaSquadra))]
        public void MediaPuntiSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Punti"),
                                                    statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Media Punti Squadra", media );
        }

        //Attributo Custom
        [Custom("Tentativi Da 2 Segnati", typeof(StatisticaGiocatore))]
        public void PercentualeTiriDaDue(StatisticaGiocatore statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Tentativi Da 2 Segnati"),
                                                                statistica.GetCampo("Tentativi Da 2 Totali"));

            statistica.SetCampo("Percentuale Tiri Da 2 Segnati", new CampoStatistica(percentuale));
        }

        //Attributo Custom
        [Custom("Tentativi Da 3 Segnati", typeof(StatisticaGiocatore))]
        public void PercentualeTiriDaTre(StatisticaGiocatore statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Tentativi Da 3 Segnati"),
                                                                statistica.GetCampo("Tentativi Da 3 Totali"));

            statistica.SetCampo("Percentuale Tiri Da 3 Segnati", new CampoStatistica(percentuale));
        }

        
        //Attributo Custom
        [Custom("Tentativi Da 2 Segnati", typeof(StatisticaGiocatore))]
        [Custom("Tentativi Da 3 Segnati", typeof(StatisticaGiocatore))]
        [Custom("Tiri Liberi Totali", typeof(StatisticaGiocatore))]
        public void PercentualeTiri(StatisticaGiocatore statistica)
        {
            CampoStatistica tiriSegnati = new CampoStatistica(0);
            CampoStatistica tiriTotali = new CampoStatistica(0);

            tiriSegnati = statistica.GetCampo("Tentativi Da 3 Segnati") + statistica.GetCampo("Tentativi Da 2 Segnati") + 
                 statistica.GetCampo("Tiri Liberi Segnati");

            tiriTotali = statistica.GetCampo("Tentativi Da 3 Totali") + statistica.GetCampo("Tentativi Da 2 Totali") +
                 statistica.GetCampo("Tiri Liberi Totali");

            CampoStatistica percentuale = CalcoloUtility.Percentuale(tiriSegnati, tiriTotali);

            statistica.SetCampo("Percentuale Tiri Segnati", new CampoStatistica(percentuale));
        }

        //Attributo Custom
        [Custom("Punti", typeof(StatisticaGiocatore))]
        public void MediaPuntiPerMinuto(StatisticaGiocatore statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Punti"),
                                                    statistica.GetCampo("Minuti Giocati"));

            statistica.SetCampo("Punti Per Minuto", new CampoStatistica(media));
        }

        //Attributo Custom
        [Custom("Palle Recuperate", typeof(StatisticaGiocatore))]
        public void MediaRecuperiPerMinuto(StatisticaGiocatore statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Palle Recuperate"),
                                                    statistica.GetCampo("Minuti Giocati"));

            statistica.SetCampo("Palle Recuperate Per Minuto", new CampoStatistica(media));
        }


        public void Visit(Statistica statistica, string metodo)
        {
            //Cerchiamo i metodi del tipo della classe chiamante ( potrebbe essere anche una classe derivata )
            Type type = this.GetType();


            //Esecuzione standard del metodo passato come parametro
            MethodInfo methodInfo = type.GetMethod(metodo);

            if (methodInfo != null)
                methodInfo.Invoke(this, new Object[] { statistica });
        }

        

    }

    
}
