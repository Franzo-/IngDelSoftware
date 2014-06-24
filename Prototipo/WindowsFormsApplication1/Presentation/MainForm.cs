﻿using System;
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
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _campionatoComboBox.DataSource = Database.Campionati;
            _campionatoComboBox.SelectedIndex = 0;      //Selezione di default



            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void AggiornaSquadrePartite()
        {
            Campionato campCorrente = (Campionato) _campionatoComboBox.SelectedItem;
            _squadraComboBox.DataSource = campCorrente.Squadre;
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);

            _dataGridView.Text = "Add Row";
            _dataGridView.Location = new Point(10, 10);

            _dataGridView.Text = "Delete Row";
            _dataGridView.Location = new Point(100, 10);

            
            _dataGridView.Height = 50;
            _dataGridView.Dock = DockStyle.Bottom;

        }

        private void SetupDataGridView()
        {
            //this.Controls.Add(_dataGridView);

            _dataGridView.ColumnCount = 5;

            _dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            _dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(_dataGridView.Font, FontStyle.Bold);

            _dataGridView.Name = "_dataGridView";
           /* _dataGridView.Location = new Point(8, 8);
            _dataGridView.Size = new Size(500, 250);
            _dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            _dataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            _dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;*/
            _dataGridView.GridColor = Color.Black;
            _dataGridView.RowHeadersVisible = false;

            _dataGridView.Columns[0].Name = "Release Date";
            _dataGridView.Columns[1].Name = "Track";
            _dataGridView.Columns[2].Name = "Title";
            _dataGridView.Columns[3].Name = "Artist";
            _dataGridView.Columns[4].Name = "Album";
            _dataGridView.Columns[4].DefaultCellStyle.Font =
                new Font(_dataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            _dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            _dataGridView.MultiSelect = false;
            _dataGridView.Dock = DockStyle.Fill;

        }

        private void PopulateDataGridView()
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9", 
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In", 
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days", 
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?", 
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind", 
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13", 
            "Scatterbrain. (As Dead As Leaves.)", 
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            _dataGridView.Rows.Add(row0);
            _dataGridView.Rows.Add(row1);
            _dataGridView.Rows.Add(row2);
            _dataGridView.Rows.Add(row3);
            _dataGridView.Rows.Add(row4);
            _dataGridView.Rows.Add(row5);
            _dataGridView.Rows.Add(row6);

            _dataGridView.Columns[0].DisplayIndex = 3;
            _dataGridView.Columns[1].DisplayIndex = 4;
            _dataGridView.Columns[2].DisplayIndex = 0;
            _dataGridView.Columns[3].DisplayIndex = 1;
            _dataGridView.Columns[4].DisplayIndex = 2;
        }

        //Utility

        private Database Database
        {
            get { return Database.GetInstance(); }
        }
    }
}
