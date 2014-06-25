using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BasketSystem.Model;

namespace BasketSystem.Presentation
{
    public partial class MainForm : Form
    {

        private Type _tipoStatistica;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _tipoStatistica = typeof(StatisticaSquadra);    //All'avvio del programma, la classifica mostrata è di squadre

            //Ai tag delle voci del menù vengono assegnati i tipi di statistica corrispondenti
            _classificaGiocatoriToolStripMenuItem.Tag = typeof(StatisticaGiocatore);
            _classificaSquadreToolStripMenuItem.Tag = typeof(StatisticaSquadra);


            

            _campionatoComboBox.DataSource = Database.Campionati.ToList();
            _campionatoComboBox.SelectedIndex = 0;      //Selezione di default
            AggiornaSquadrePartite();


            new ClassificaPresenter(_dataGridView);
        }

        //Quando viene selezionato un altro campionato, si ripopolano le combobox di squadra e partita
        private void CampionatoChanged(object sender, EventArgs e)
        {
            AggiornaSquadrePartite();
        }

        private void AggiornaSquadrePartite()
        {
            Campionato campCorrente = (Campionato) _campionatoComboBox.SelectedItem;

            // Rimuove le voci precedenti
            _squadraComboBox.Items.Clear();
            _partitaComboBox.Items.Clear();

            // I criteri di squadra e partita sono disponibili solo per statistiche di giocatori
            // Se la classifica corrente è di squadre, le combobox vengono nascoste

            if (_tipoStatistica == typeof(StatisticaGiocatore))
            {
                //Il primo elemento delle combobox deve essere un valore null perchè l'utente può non specificare il filtro corrispondente
                Object obj = new object();

                _squadraComboBox.Items.Add(obj);

                foreach (Squadra s in campCorrente.Squadre)
                {
                    //Se la partita selezionata non è l'elemento equivalente a null, qui attacco tutte le squadre contenute nella partita selezionata
                    _squadraComboBox.Items.Add(s);
                }

                _squadraComboBox.Visible = true;
                _squadraLabel.Visible = true;


                _partitaComboBox.Items.Add(new object());

                foreach (Partita p in campCorrente.Partite)
                {
                    //Se la squadra selezionata non è l'elemento equivalente a null, qui attacco le partite che contengono la squadra selezionata.
                    _partitaComboBox.Items.Add(p);
                }

                _partitaComboBox.Visible = true;
                _partitaLabel.Visible = true;
            }
            else
            {
                //Si cancellano i dati precedenti sostituendo con un null

                _squadraLabel.Visible = false;
                _squadraComboBox.Visible = false;
                

                _partitaLabel.Visible = false;
                _partitaComboBox.Visible = false;
               
            }

            ModificaSelezionatore();
        }

        //La modifica di criteri di selezione genera un nuovo selezionatore
        private void CriteriChanged(object sender, EventArgs e)
        {
            ModificaSelezionatore();
        }

        private void ModificaSelezionatore()
        {
            Classifica.Selezionatore = SelezionatoreBuilder.Build(
                _tipoStatistica, 
                (Campionato) _campionatoComboBox.SelectedItem, 
                _squadraComboBox.SelectedItem as Squadra,
                (Partita) _partitaComboBox.SelectedItem
                );
        }

        private void _classificaGiocatoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tipoStatistica = typeof(StatisticaGiocatore);
            AggiornaSquadrePartite();
        }

        private void _classificaSquadreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _tipoStatistica = typeof(StatisticaSquadra);
            AggiornaSquadrePartite();
        }


        //Utility

        public Type TipoStatistica
        {
            get { return _tipoStatistica; }
        }

        private Database Database
        {
            get { return Database.GetInstance(); }
        }

        private Classifica Classifica
        {
            get { return Classifica.GetInstance(); }
        }

        
    }
}
