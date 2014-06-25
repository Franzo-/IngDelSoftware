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


            new ClassificaPresenter(_dataGridView);
        }

        //Quando viene selezionato un altro campionato, si ripopolano le combobox di squadra e partita
        private void CampionatoChanged(object sender, EventArgs e)
        {
            AggiornaSquadrePartite();
        }        

        private void AggiornaSquadrePartite()
        {
            Campionato campCorrente = Campionato;

            // I criteri di squadra e partita sono disponibili solo per statistiche di giocatori
            // Se la classifica corrente è di squadre, le combobox vengono nascoste

            if (_tipoStatistica == typeof(StatisticaGiocatore))
            {

                PopolaComboBox<Squadra>(_squadraComboBox, campCorrente.Squadre);

                _squadraComboBox.Visible = true;
                _squadraComboBox.SelectedIndex = 0;
                _squadraLabel.Visible = true;
                

                PopolaComboBox<Partita>(_partitaComboBox, campCorrente.Partite);

                _partitaComboBox.Visible = true;
                _partitaComboBox.SelectedIndex = 0;
                _partitaLabel.Visible = true;
            }
            else
            {
                _squadraLabel.Visible = false;
                _squadraComboBox.Visible = false;
                
                _partitaLabel.Visible = false;
                _partitaComboBox.Visible = false;    
            }

            ModificaSelezionatore();
        }

        private void PopolaComboBox<T>(ComboBox cb, IEnumerable<T> collection)
        {
            // Mantiene l'oggetto selezionato precedentemente
            object obj = cb.SelectedItem;

            // Rimuove le voci precedenti
            cb.Items.Clear();

            //Il primo elemento delle combobox deve essere una stringa che indica "nessun filtro"
            cb.Items.Add("Nessun filtro");

            foreach (T item in collection)
            {
                cb.Items.Add(item);
            }

            // Se c'è ancora, seleziona l'oggetto selezionato precedentemente
            cb.SelectedItem = obj;
        }

        private void SquadraChanged()
        {
            Squadra squadraCorrente = _squadraComboBox.SelectedItem as Squadra;
            if (squadraCorrente != null)
            {
                PopolaComboBox<Partita>(_partitaComboBox,
                    (from partita in Campionato.Partite
                     where partita.Casa == squadraCorrente || partita.Ospite == squadraCorrente
                     select partita)
                     );
            }
            else
                PopolaComboBox<Partita>(_partitaComboBox, Campionato.Partite);
        }

        private void PartitaChanged()
        {
            Partita partitaCorrente = _partitaComboBox.SelectedItem as Partita;
            if (partitaCorrente != null)
            {
                PopolaComboBox<Squadra>(_squadraComboBox,
                    (from squadra in Campionato.Squadre
                     where partitaCorrente.Casa == squadra || partitaCorrente.Ospite == squadra
                     select squadra)
                    );
            }
            else
               PopolaComboBox<Squadra>(_squadraComboBox, Campionato.Squadre);
        }

        //La modifica di criteri di selezione genera un nuovo selezionatore
        private void CriteriChanged(object sender, EventArgs e)
        {

            ComboBox cb = sender as ComboBox;

            if (cb != null)
            {
                if (cb == _squadraComboBox)
                    SquadraChanged();
                else if (cb == _partitaComboBox)
                    PartitaChanged();

                ModificaSelezionatore();
            }
        }

        private void ModificaSelezionatore()
        {
            Classifica.Selezionatore = SelezionatoreBuilder.Build(
                _tipoStatistica, 
                Campionato, 
                _squadraComboBox.SelectedItem as Squadra,
                _partitaComboBox.SelectedItem as Partita
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

        private Campionato Campionato
        {
            get { return (Campionato)_campionatoComboBox.SelectedItem; }
        }
    }
}
