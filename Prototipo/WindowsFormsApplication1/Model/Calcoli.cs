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

        public void PercentualeVittorieSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Partite Vinte"), 
                                                                statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Percentuale vittorie squadra", percentuale );
        }

        public void PercentualeSconfitteSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Partite Perse"),
                                                                statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Percentuale sconfitte squadra", percentuale);
        }

        public void MediaPuntiSquadra(StatisticaSquadra statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Punti"),
                                                    statistica.GetCampo("Partite Giocate"));

            statistica.SetCampo("Media Punti Squadra", media );
        }

        public void PercentualeTiriDaDue(StatisticaGiocatore statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Tentativi Da 2 Segnati"),
                                                                statistica.GetCampo("Tentativi Da 2 Totali"));

            statistica.SetCampo("Percentuale Tiri Da 2 Segnati", new CampoStatistica(percentuale));
        }

        public void PercentualeTiriDaTre(StatisticaGiocatore statistica)
        {
            CampoStatistica percentuale = CalcoloUtility.Percentuale(statistica.GetCampo("Tentativi Da 3 Segnati"),
                                                                statistica.GetCampo("Tentativi Da 3 Totali"));

            statistica.SetCampo("Percentuale Tiri Da 3 Segnati", new CampoStatistica(percentuale));
        }

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

        public void MediaPuntiPerMinuto(StatisticaGiocatore statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Punti"),
                                                    statistica.GetCampo("Minuti Giocati"));

            statistica.SetCampo("Punti Per Minuto", new CampoStatistica(media));
        }

        public void MediaRecuperiPerMinuto(StatisticaGiocatore statistica)
        {
            CampoStatistica media = CalcoloUtility.Media(statistica.GetCampo("Palle Recuperate"),
                                                    statistica.GetCampo("Minuti Giocati"));

            statistica.SetCampo("Palle Recuperate Per Minuto", new CampoStatistica(media));
        }


        public void Visit(Statistica statistica, string metodo)
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                //Cerchiamo i metodi del tipo della classe chiamante ( potrebbe essere anche una classe derivata )
                if (type.Name == this.GetType().Name)
                {
                    //Esecuzione standard del metodo passato come parametro
                    MethodInfo methodInfo = type.GetMethod(metodo, new Type[] {typeof(Statistica)} );
                    methodInfo.Invoke(this, new Object[] { statistica });
                    
                }
            }
        }

        

    }

    
}
