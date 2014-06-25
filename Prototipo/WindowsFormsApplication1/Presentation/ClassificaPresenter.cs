using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using BasketSystem.Model;


namespace BasketSystem.Presentation
{
    class ClassificaPresenter
    {
        private readonly DataGridView _control;

        public ClassificaPresenter(DataGridView control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            _control = control;
            Classifica.GetInstance().Changed += OnClassificaChanged;
            Refresh();
        }

        public DataGridView Control
        {
            get { return _control; }
        }

        private void OnClassificaChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            // Elimina gli elementi precedenti
            Control.Columns.Clear();
            Control.Rows.Clear();

            // Il refresh deve ricevere la collezione di statistiche, 
            IEnumerable<Statistica> statistiche = Classifica.GetInstance().GetStatistiche();

            // costruire le colonne della grid view,
            string[] campi = statistiche.ElementAt(0).GetNomiCampi();
            Control.ColumnCount = campi.Length;

            for (int i = 0; i < Control.ColumnCount; i++)
            {
                DataGridViewColumn currentCol = Control.Columns[i];

                currentCol.Name = campi[i];
                
                
                // effettuare reflection per i menù dei calcoli,
                currentCol.ContextMenuStrip = new ContextMenuStrip();
                PopolaCalcoliMenuStrip(currentCol.ContextMenuStrip, campi[i]);
            }

            
            // popolare la griglia con le statistiche
            foreach (Statistica statistica in statistiche)
            {
                DataGridViewRow row = new DataGridViewRow();

                foreach (string campo in campi)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = statistica.GetCampo(campo);
                    row.Cells.Add(cell);
                }

                Control.Rows.Add(row);
            }
        }

        private void PopolaCalcoliMenuStrip(ContextMenuStrip menu, string nomeCampo)
        {
            MethodInfo[] methods = Classifica.GetInstance().Visitor.GetType().GetMethods();
            Type tipoStatistica = ((MainForm)Control.FindForm()).TipoStatistica;

            foreach (MethodInfo method in methods)
            {
                CustomAttribute[] attributes = (CustomAttribute[])method.GetCustomAttributes(typeof(CustomAttribute), false);

                if (attributes.Length == 0)     //se non ha l'attributo, la proprietà è saltata
                    continue;

                foreach (CustomAttribute attribute in attributes)
                {
                    //Il metodo è aggiunto solo se corrisponde al tipo di statistica e al campo correnti
                    if (attribute.Tipo == tipoStatistica && attribute.Campo == nomeCampo)
                    {
                        AddMenuItem(method.Name, menu);
                    }
                }
            }

            //Se non sono stati trovati calcoli, si mette una voce non selezionabile
            if (menu.Items.Count == 0)
            {
                ToolStripMenuItem item = new ToolStripMenuItem("Nessun calcolo disponibile");
                item.Enabled = false;
                menu.Items.Add(item);
            }
        }

        private void AddMenuItem(string nomeMetodo, ContextMenuStrip menu)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(nomeMetodo);
            item.Click += _calcoloToolStripMenuItem_Click;
            menu.Items.Add(item);
        }

        private void _calcoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
                Classifica.GetInstance().EseguiCalcolo(item.Text);
        }
    }
}
