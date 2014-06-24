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


            new ClassificaPresenter(_dataGridView);

            _campionatoComboBox.DataSource = Database.Campionati;
            _campionatoComboBox.SelectedIndex = 0;      //Selezione di default
            AggiornaSquadrePartite();
            



            //SetupLayout();
            //SetupDataGridView();
            //PopulateDataGridView();
        }

        //Quando viene selezionato un altro campionato, si ripopolano le combobox di squadra e partita
        private void CampionatoChanged(object sender, EventArgs e)
        {
            AggiornaSquadrePartite();
        }

        private void AggiornaSquadrePartite()
        {
            Campionato campCorrente = (Campionato) _campionatoComboBox.SelectedItem;

            List<Squadra> squadraSource = new List<Squadra>();
            squadraSource.Add(null);

            List<Partita> partitaSource = new List<Partita>();
            partitaSource.Add(null);

            // I criteri di squadra e partita sono disponibili solo per statistiche di giocatori
            // Se la classifica corrente è di squadre, le combobox vengono nascoste

            if (_tipoStatistica == typeof(StatisticaGiocatore))
            {
                //Il primo elemento delle combobox deve essere un valore null perchè l'utente può non specificare il filtro corrispondente
                
                _squadraComboBox.DataSource = squadraSource.Concat(campCorrente.Squadre);
                _squadraComboBox.SelectedIndex = 0;
                _squadraComboBox.Visible = true;
                
                _partitaComboBox.DataSource = partitaSource.Concat(campCorrente.Partite);
                _partitaComboBox.SelectedIndex = 0;
                _partitaComboBox.Visible = true;
            }
            else
            {
                //Si cancellano i dati precedenti sostituendo con un null

                _squadraComboBox.Visible = false;
                _squadraComboBox.DataSource = squadraSource;
                _squadraComboBox.SelectedIndex = 0;

                _partitaComboBox.Visible = false;
                _partitaComboBox.DataSource = partitaSource;
                _partitaComboBox.SelectedIndex = 0;
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
                (Squadra) _squadraComboBox.SelectedItem,
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






        //private void SetupLayout()
        //{
        //    this.Size = new Size(600, 500);

        //    _dataGridView.Text = "Add Row";
        //    _dataGridView.Location = new Point(10, 10);

        //    _dataGridView.Text = "Delete Row";
        //    _dataGridView.Location = new Point(100, 10);

            
        //    _dataGridView.Height = 50;
        //    _dataGridView.Dock = DockStyle.Bottom;

        //}

        //private void SetupDataGridView()
        //{
        //    //this.Controls.Add(_dataGridView);

        //    _dataGridView.ColumnCount = 5;

        //    _dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
        //    _dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    _dataGridView.ColumnHeadersDefaultCellStyle.Font =
        //        new Font(_dataGridView.Font, FontStyle.Bold);

        //    _dataGridView.Name = "_dataGridView";
        //   /* _dataGridView.Location = new Point(8, 8);
        //    _dataGridView.Size = new Size(500, 250);
        //    _dataGridView.AutoSizeRowsMode =
        //        DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
        //    _dataGridView.ColumnHeadersBorderStyle =
        //        DataGridViewHeaderBorderStyle.Single;
        //    _dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;*/
        //    _dataGridView.GridColor = Color.Black;
        //    _dataGridView.RowHeadersVisible = false;

        //    _dataGridView.Columns[0].Name = "Release Date";
        //    _dataGridView.Columns[1].Name = "Track";
        //    _dataGridView.Columns[2].Name = "Title";
        //    _dataGridView.Columns[3].Name = "Artist";
        //    _dataGridView.Columns[4].Name = "Album";
        //    _dataGridView.Columns[4].DefaultCellStyle.Font =
        //        new Font(_dataGridView.DefaultCellStyle.Font, FontStyle.Italic);

        //    _dataGridView.SelectionMode =
        //        DataGridViewSelectionMode.FullRowSelect;
        //    _dataGridView.MultiSelect = false;
        //    _dataGridView.Dock = DockStyle.Fill;

        //}

        //private void PopulateDataGridView()
        //{

        //    string[] row0 = { "11/22/1968", "29", "Revolution 9", 
        //    "Beatles", "The Beatles [White Album]" };
        //    string[] row1 = { "1960", "6", "Fools Rush In", 
        //    "Frank Sinatra", "Nice 'N' Easy" };
        //    string[] row2 = { "11/11/1971", "1", "One of These Days", 
        //    "Pink Floyd", "Meddle" };
        //    string[] row3 = { "1988", "7", "Where Is My Mind?", 
        //    "Pixies", "Surfer Rosa" };
        //    string[] row4 = { "5/1981", "9", "Can't Find My Mind", 
        //    "Cramps", "Psychedelic Jungle" };
        //    string[] row5 = { "6/10/2003", "13", 
        //    "Scatterbrain. (As Dead As Leaves.)", 
        //    "Radiohead", "Hail to the Thief" };
        //    string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

        //    _dataGridView.Rows.Add(row0);
        //    _dataGridView.Rows.Add(row1);
        //    _dataGridView.Rows.Add(row2);
        //    _dataGridView.Rows.Add(row3);
        //    _dataGridView.Rows.Add(row4);
        //    _dataGridView.Rows.Add(row5);
        //    _dataGridView.Rows.Add(row6);

        //    _dataGridView.Columns[0].DisplayIndex = 3;
        //    _dataGridView.Columns[1].DisplayIndex = 4;
        //    _dataGridView.Columns[2].DisplayIndex = 0;
        //    _dataGridView.Columns[3].DisplayIndex = 1;
        //    _dataGridView.Columns[4].DisplayIndex = 2;
        //}



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
