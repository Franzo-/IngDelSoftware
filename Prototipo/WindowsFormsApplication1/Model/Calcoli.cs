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

            internal static float Media(int campoPrimo, int campoSecondo)
            {
                return campoPrimo / campoSecondo;
            }

            internal static float Percentuale(int campoParziale, int campoTotale)
            {
                return (campoParziale * 100) / campoTotale;
            }

        }

        public void PercentualeVittorieSquadra(StatisticaSquadra statistica)
        {
            float percentuale = CalcoloUtility.Percentuale((int)statistica.GetCampo("Partite Vinte").Campo, 
                                                                (int)statistica.GetCampo("Partite Giocate").Campo);

            statistica.SetCampo("Percentuale vittorie squadra", new CampoStatistica(percentuale));
        }

        public void PercentualeSconfitteSquadra(StatisticaSquadra statistica)
        {
            float percentuale = CalcoloUtility.Percentuale((int)statistica.GetCampo("Partite Perse").Campo,
                                                                (int)statistica.GetCampo("Partite Giocate").Campo);

            statistica.SetCampo("Percentuale sconfitte squadra", new CampoStatistica(percentuale));
        }

        public void MediaPuntiSquadra(StatisticaSquadra statistica)
        {
            float media = CalcoloUtility.Media((int)statistica.GetCampo("Punti").Campo,
                                                    (int)statistica.GetCampo("Partite Giocate").Campo);

            statistica.SetCampo("Media Punti Squadra", new CampoStatistica(media));
        }

        public void PercentualeTiriDaDue(StatisticaGiocatore statistica)
        {
            float percentuale = CalcoloUtility.Percentuale((int)statistica.GetCampo("Tentativi Da 2 Segnati").Campo,
                                                                (int)statistica.GetCampo("Tentativi Da 2 Totali").Campo);

            statistica.SetCampo("Percentuale Tiri Da 2 Segnati", new CampoStatistica(percentuale));
        }

        public void PercentualeTiriDaTre(StatisticaGiocatore statistica)
        {
            float percentuale = CalcoloUtility.Percentuale((int)statistica.GetCampo("Tentativi Da 3 Segnati").Campo,
                                                                (int)statistica.GetCampo("Tentativi Da 3 Totali").Campo);

            statistica.SetCampo("Percentuale Tiri Da 3 Segnati", new CampoStatistica(percentuale));
        }

        public void PercentualeTiri(StatisticaGiocatore statistica)
        {
            int tiriSegnati = 0;
            int tiriTotali = 0;

            tiriSegnati += (int)statistica.GetCampo("Tentativi Da 3 Segnati").Campo + (int)statistica.GetCampo("Tentativi Da 2 Segnati").Campo + 
                 (int)statistica.GetCampo("Tiri Liberi Segnati").Campo;

            tiriTotali += (int)statistica.GetCampo("Tentativi Da 3 Totali").Campo + (int)statistica.GetCampo("Tentativi Da 2 Totali").Campo +
                 (int)statistica.GetCampo("Tiri Liberi Totali").Campo;

            float percentuale = CalcoloUtility.Percentuale(tiriSegnati, tiriTotali);

            statistica.SetCampo("Percentuale Tiri Segnati", new CampoStatistica(percentuale));
        }

        public void MediaPuntiPerMinuto(StatisticaGiocatore statistica)
        {
            float media = CalcoloUtility.Media((int)statistica.GetCampo("Punti").Campo,
                                                    (int)statistica.GetCampo("Minuti Giocati").Campo);

            statistica.SetCampo("Punti Per Minuto", new CampoStatistica(media));
        }

        public void MediaRecuperiPerMinuto(StatisticaGiocatore statistica)
        {
            float media = CalcoloUtility.Media((int)statistica.GetCampo("Palle Recuperate").Campo,
                                                    (int)statistica.GetCampo("Minuti Giocati").Campo);

            statistica.SetCampo("Palle Recuperate Per Minuto", new CampoStatistica(media));
        }


        void Visit(Statistica statistica, string metodo)
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
