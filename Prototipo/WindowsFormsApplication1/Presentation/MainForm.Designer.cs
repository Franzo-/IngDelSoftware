namespace BasketSystem.Presentation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._campionatoComboBox = new System.Windows.Forms.ComboBox();
            this._campionatoLabel = new System.Windows.Forms.Label();
            this._squadraLabel = new System.Windows.Forms.Label();
            this._squadraComboBox = new System.Windows.Forms.ComboBox();
            this._partitaLabel = new System.Windows.Forms.Label();
            this._partitaComboBox = new System.Windows.Forms.ComboBox();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._tipoClassificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._classificaGiocatoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._classificaSquadreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(727, 415);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this._campionatoComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._campionatoLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._squadraLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._squadraComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this._partitaLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this._partitaComboBox, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(727, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _campionatoComboBox
            // 
            this._campionatoComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._campionatoComboBox.FormattingEnabled = true;
            this._campionatoComboBox.Location = new System.Drawing.Point(3, 46);
            this._campionatoComboBox.Name = "_campionatoComboBox";
            this._campionatoComboBox.Size = new System.Drawing.Size(236, 21);
            this._campionatoComboBox.TabIndex = 1;
            // 
            // _campionatoLabel
            // 
            this._campionatoLabel.AutoSize = true;
            this._campionatoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._campionatoLabel.Location = new System.Drawing.Point(3, 0);
            this._campionatoLabel.Name = "_campionatoLabel";
            this._campionatoLabel.Size = new System.Drawing.Size(236, 43);
            this._campionatoLabel.TabIndex = 0;
            this._campionatoLabel.Text = "Seleziona Campionato";
            this._campionatoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _squadraLabel
            // 
            this._squadraLabel.AutoSize = true;
            this._squadraLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._squadraLabel.Location = new System.Drawing.Point(245, 0);
            this._squadraLabel.Name = "_squadraLabel";
            this._squadraLabel.Size = new System.Drawing.Size(236, 43);
            this._squadraLabel.TabIndex = 2;
            this._squadraLabel.Text = "Seleziona Squadra";
            this._squadraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _squadraComboBox
            // 
            this._squadraComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._squadraComboBox.FormattingEnabled = true;
            this._squadraComboBox.Location = new System.Drawing.Point(245, 46);
            this._squadraComboBox.Name = "_squadraComboBox";
            this._squadraComboBox.Size = new System.Drawing.Size(236, 21);
            this._squadraComboBox.TabIndex = 3;
            // 
            // _partitaLabel
            // 
            this._partitaLabel.AutoSize = true;
            this._partitaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._partitaLabel.Location = new System.Drawing.Point(487, 0);
            this._partitaLabel.Name = "_partitaLabel";
            this._partitaLabel.Size = new System.Drawing.Size(237, 43);
            this._partitaLabel.TabIndex = 4;
            this._partitaLabel.Text = "Seleziona Partita";
            this._partitaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _partitaComboBox
            // 
            this._partitaComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._partitaComboBox.FormattingEnabled = true;
            this._partitaComboBox.Location = new System.Drawing.Point(487, 46);
            this._partitaComboBox.Name = "_partitaComboBox";
            this._partitaComboBox.Size = new System.Drawing.Size(237, 21);
            this._partitaComboBox.TabIndex = 5;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 0);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.Size = new System.Drawing.Size(727, 325);
            this._dataGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tipoClassificaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _tipoClassificaToolStripMenuItem
            // 
            this._tipoClassificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._classificaGiocatoriToolStripMenuItem,
            this._classificaSquadreToolStripMenuItem});
            this._tipoClassificaToolStripMenuItem.Name = "_tipoClassificaToolStripMenuItem";
            this._tipoClassificaToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this._tipoClassificaToolStripMenuItem.Text = "Tipo Classifica";
            // 
            // _classificaGiocatoriToolStripMenuItem
            // 
            this._classificaGiocatoriToolStripMenuItem.Name = "_classificaGiocatoriToolStripMenuItem";
            this._classificaGiocatoriToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._classificaGiocatoriToolStripMenuItem.Text = "Classifica Giocatori";
            // 
            // _classificaSquadreToolStripMenuItem
            // 
            this._classificaSquadreToolStripMenuItem.Name = "_classificaSquadreToolStripMenuItem";
            this._classificaSquadreToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this._classificaSquadreToolStripMenuItem.Text = "Classifica Squadre";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 439);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _campionatoLabel;
        private System.Windows.Forms.ComboBox _campionatoComboBox;
        private System.Windows.Forms.Label _squadraLabel;
        private System.Windows.Forms.ComboBox _squadraComboBox;
        private System.Windows.Forms.Label _partitaLabel;
        private System.Windows.Forms.ComboBox _partitaComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _tipoClassificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _classificaGiocatoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _classificaSquadreToolStripMenuItem;
    }
}