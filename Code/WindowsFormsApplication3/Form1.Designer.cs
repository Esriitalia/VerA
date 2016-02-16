namespace WindowsFormsApplication3
{
    partial class frmApertura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApertura));
            this.btnControlla = new System.Windows.Forms.Button();
            this.lblNomeFile = new System.Windows.Forms.Label();
            this.txtNomeFile = new System.Windows.Forms.TextBox();
            this.btnSfoglia = new System.Windows.Forms.Button();
            this.ofdApri = new System.Windows.Forms.OpenFileDialog();
            this.dynamicTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnControlla1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnControlla2 = new System.Windows.Forms.Button();
            this.btnControllaDataset = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dynamicTexBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnControlla3 = new System.Windows.Forms.Button();
            this.btnControllaOpenSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dynamicTextBox3 = new System.Windows.Forms.TextBox();
            this.primoErrore = new System.Windows.Forms.Button();
            this.primoErroreDataset = new System.Windows.Forms.Button();
            this.bntControllaPrimoErrOpen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnControlla
            // 
            this.btnControlla.Location = new System.Drawing.Point(61, 223);
            this.btnControlla.Margin = new System.Windows.Forms.Padding(4);
            this.btnControlla.Name = "btnControlla";
            this.btnControlla.Size = new System.Drawing.Size(171, 54);
            this.btnControlla.TabIndex = 1;
            this.btnControlla.Text = "Controlla file Download Service Feed";
            this.btnControlla.UseVisualStyleBackColor = true;
            this.btnControlla.Click += new System.EventHandler(this.btnControlla_Click);
            // 
            // lblNomeFile
            // 
            this.lblNomeFile.AutoSize = true;
            this.lblNomeFile.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeFile.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lblNomeFile.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblNomeFile.Location = new System.Drawing.Point(561, 27);
            this.lblNomeFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeFile.Name = "lblNomeFile";
            this.lblNomeFile.Size = new System.Drawing.Size(369, 27);
            this.lblNomeFile.TabIndex = 2;
            this.lblNomeFile.Text = "Seleziona il file Download Service";
            this.lblNomeFile.UseWaitCursor = true;
            this.lblNomeFile.Click += new System.EventHandler(this.lblNomeFile_Click);
            // 
            // txtNomeFile
            // 
            this.txtNomeFile.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtNomeFile.Location = new System.Drawing.Point(397, 67);
            this.txtNomeFile.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomeFile.Name = "txtNomeFile";
            this.txtNomeFile.Size = new System.Drawing.Size(638, 28);
            this.txtNomeFile.TabIndex = 3;
            // 
            // btnSfoglia
            // 
            this.btnSfoglia.Location = new System.Drawing.Point(1043, 67);
            this.btnSfoglia.Margin = new System.Windows.Forms.Padding(4);
            this.btnSfoglia.Name = "btnSfoglia";
            this.btnSfoglia.Size = new System.Drawing.Size(94, 30);
            this.btnSfoglia.TabIndex = 4;
            this.btnSfoglia.Text = "sfoglia";
            this.btnSfoglia.UseVisualStyleBackColor = true;
            this.btnSfoglia.Click += new System.EventHandler(this.btnSfoglia_Click);
            // 
            // ofdApri
            // 
            this.ofdApri.Filter = "XML Document(*.xml)|*.xml";
            this.ofdApri.Title = "Seleziona un file xml";
            // 
            // dynamicTextBox
            // 
            this.dynamicTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.dynamicTextBox.ForeColor = System.Drawing.Color.Black;
            this.dynamicTextBox.Location = new System.Drawing.Point(30, 329);
            this.dynamicTextBox.Multiline = true;
            this.dynamicTextBox.Name = "dynamicTextBox";
            this.dynamicTextBox.ReadOnly = true;
            this.dynamicTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dynamicTextBox.Size = new System.Drawing.Size(448, 424);
            this.dynamicTextBox.TabIndex = 5;
            this.dynamicTextBox.WordWrap = false;
            this.dynamicTextBox.TextChanged += new System.EventHandler(this.DynamicTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(151, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lista degli errori";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "/feed/title",
            "/feed/subtitle",
            "/feed/link[@rel=\'describedby\']",
            "/feed/link[@rel=\'self\']",
            "/feed/link[@rel=\'search\']",
            "/feed/link[@rel=\'alternate\']",
            "/feed/id",
            "/feed/rights",
            "/feed/updated",
            "/feed/author",
            "/feed/entry"});
            this.comboBox1.Location = new System.Drawing.Point(61, 175);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(297, 29);
            this.comboBox1.TabIndex = 31;
            this.comboBox1.Text = "Scegli un nodo";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // btnControlla1
            // 
            this.btnControlla1.Location = new System.Drawing.Point(364, 174);
            this.btnControlla1.Name = "btnControlla1";
            this.btnControlla1.Size = new System.Drawing.Size(83, 30);
            this.btnControlla1.TabIndex = 32;
            this.btnControlla1.Text = "controlla";
            this.btnControlla1.UseVisualStyleBackColor = true;
            this.btnControlla1.Click += new System.EventHandler(this.btnControlla1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 27);
            this.label2.TabIndex = 33;
            this.label2.Text = "File Download Service Feed";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "/feed/title",
            "/feed/subtitle",
            "/feed/id",
            "/feed/rights",
            "/feed/updated",
            "/feed/author",
            "/feed/link[@rel=\'describedby\']",
            "/feed/link[@rel=\'up\']",
            "/feed/entry"});
            this.comboBox2.Location = new System.Drawing.Point(566, 183);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(295, 29);
            this.comboBox2.TabIndex = 34;
            this.comboBox2.Text = "Scegli un nodo";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(646, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 27);
            this.label3.TabIndex = 35;
            this.label3.Text = "File Dataset Feed";
            // 
            // btnControlla2
            // 
            this.btnControlla2.Location = new System.Drawing.Point(867, 183);
            this.btnControlla2.Name = "btnControlla2";
            this.btnControlla2.Size = new System.Drawing.Size(98, 26);
            this.btnControlla2.TabIndex = 36;
            this.btnControlla2.Text = "controlla";
            this.btnControlla2.UseVisualStyleBackColor = true;
            this.btnControlla2.Click += new System.EventHandler(this.btnControlla2_Click);
            // 
            // btnControllaDataset
            // 
            this.btnControllaDataset.Location = new System.Drawing.Point(601, 226);
            this.btnControllaDataset.Name = "btnControllaDataset";
            this.btnControllaDataset.Size = new System.Drawing.Size(146, 54);
            this.btnControllaDataset.TabIndex = 37;
            this.btnControllaDataset.Text = "Controlla i file Dataset Feed";
            this.btnControllaDataset.UseVisualStyleBackColor = true;
            this.btnControllaDataset.Click += new System.EventHandler(this.btnControllaDataset_Click);
            // 
            // dynamicTexBox2
            // 
            this.dynamicTexBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dynamicTexBox2.ForeColor = System.Drawing.Color.Black;
            this.dynamicTexBox2.Location = new System.Drawing.Point(557, 329);
            this.dynamicTexBox2.Multiline = true;
            this.dynamicTexBox2.Name = "dynamicTexBox2";
            this.dynamicTexBox2.ReadOnly = true;
            this.dynamicTexBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dynamicTexBox2.Size = new System.Drawing.Size(448, 424);
            this.dynamicTexBox2.TabIndex = 38;
            this.dynamicTexBox2.WordWrap = false;
            this.dynamicTexBox2.TextChanged += new System.EventHandler(this.dynamicTexBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(695, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 27);
            this.label4.TabIndex = 39;
            this.label4.Text = "Lista degli errori";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1168, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 27);
            this.label5.TabIndex = 40;
            this.label5.Text = "File Open Search Document";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "/OpenSearchDescription/Url[@rel=\'self\']",
            "/OpenSearchDescription/Url[@rel=\'results\']",
            "/OpenSearchDescription/Url[@rel=\'describedby\']",
            "/OpenSearchDescription/Url[@rel=\'results\'][last()]",
            "/OpenSearchDescription/Language"});
            this.comboBox3.Location = new System.Drawing.Point(1113, 186);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(295, 29);
            this.comboBox3.TabIndex = 41;
            this.comboBox3.Text = "Scegli un nodo";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // btnControlla3
            // 
            this.btnControlla3.Location = new System.Drawing.Point(1420, 186);
            this.btnControlla3.Name = "btnControlla3";
            this.btnControlla3.Size = new System.Drawing.Size(95, 26);
            this.btnControlla3.TabIndex = 42;
            this.btnControlla3.Text = "controlla";
            this.btnControlla3.UseVisualStyleBackColor = true;
            this.btnControlla3.Click += new System.EventHandler(this.btnControlla3_Click);
            // 
            // btnControllaOpenSearch
            // 
            this.btnControllaOpenSearch.Location = new System.Drawing.Point(1147, 229);
            this.btnControllaOpenSearch.Name = "btnControllaOpenSearch";
            this.btnControllaOpenSearch.Size = new System.Drawing.Size(146, 54);
            this.btnControllaOpenSearch.TabIndex = 43;
            this.btnControllaOpenSearch.Text = "Controlla file Open Search";
            this.btnControllaOpenSearch.UseVisualStyleBackColor = true;
            this.btnControllaOpenSearch.Click += new System.EventHandler(this.btnControllaOpenSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Baskerville Old Face", 13.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1222, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 27);
            this.label6.TabIndex = 44;
            this.label6.Text = "Lista degli errori";
            // 
            // dynamicTextBox3
            // 
            this.dynamicTextBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.dynamicTextBox3.ForeColor = System.Drawing.Color.Black;
            this.dynamicTextBox3.Location = new System.Drawing.Point(1090, 329);
            this.dynamicTextBox3.Multiline = true;
            this.dynamicTextBox3.Name = "dynamicTextBox3";
            this.dynamicTextBox3.ReadOnly = true;
            this.dynamicTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dynamicTextBox3.Size = new System.Drawing.Size(448, 424);
            this.dynamicTextBox3.TabIndex = 45;
            this.dynamicTextBox3.WordWrap = false;
            this.dynamicTextBox3.TextChanged += new System.EventHandler(this.dynamicTextBox3_TextChanged);
            // 
            // primoErrore
            // 
            this.primoErrore.Location = new System.Drawing.Point(317, 223);
            this.primoErrore.Name = "primoErrore";
            this.primoErrore.Size = new System.Drawing.Size(130, 54);
            this.primoErrore.TabIndex = 46;
            this.primoErrore.Text = "Controlla solo primo errore";
            this.primoErrore.UseVisualStyleBackColor = true;
            this.primoErrore.Click += new System.EventHandler(this.primoErrore_Click);
            // 
            // primoErroreDataset
            // 
            this.primoErroreDataset.Location = new System.Drawing.Point(820, 227);
            this.primoErroreDataset.Name = "primoErroreDataset";
            this.primoErroreDataset.Size = new System.Drawing.Size(125, 53);
            this.primoErroreDataset.TabIndex = 47;
            this.primoErroreDataset.Text = "Controlla solo primo errore";
            this.primoErroreDataset.UseVisualStyleBackColor = true;
            this.primoErroreDataset.Click += new System.EventHandler(this.primoErroreDataset_Click);
            // 
            // bntControllaPrimoErrOpen
            // 
            this.bntControllaPrimoErrOpen.Location = new System.Drawing.Point(1348, 230);
            this.bntControllaPrimoErrOpen.Name = "bntControllaPrimoErrOpen";
            this.bntControllaPrimoErrOpen.Size = new System.Drawing.Size(131, 53);
            this.bntControllaPrimoErrOpen.TabIndex = 48;
            this.bntControllaPrimoErrOpen.Text = "Controlla solo il primo errore";
            this.bntControllaPrimoErrOpen.UseVisualStyleBackColor = true;
            this.bntControllaPrimoErrOpen.Click += new System.EventHandler(this.bntControllaPrimoErrOpen_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1160, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 30);
            this.button1.TabIndex = 49;
            this.button1.Text = "Controllo completo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Goudy Old Style", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1201, 764);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(365, 23);
            this.label7.TabIndex = 50;
            this.label7.Text = "Sviluppato da Francesca Romana De Gennaro";
            // 
            // frmApertura
            // 
            this.AcceptButton = this.btnControlla;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1578, 809);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntControllaPrimoErrOpen);
            this.Controls.Add(this.primoErroreDataset);
            this.Controls.Add(this.primoErrore);
            this.Controls.Add(this.dynamicTextBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnControllaOpenSearch);
            this.Controls.Add(this.btnControlla3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dynamicTexBox2);
            this.Controls.Add(this.btnControllaDataset);
            this.Controls.Add(this.btnControlla2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnControlla1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dynamicTextBox);
            this.Controls.Add(this.btnSfoglia);
            this.Controls.Add(this.txtNomeFile);
            this.Controls.Add(this.lblNomeFile);
            this.Controls.Add(this.btnControlla);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Goudy Old Style", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmApertura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerA - Verifica automatica per la correttezza dei file Atom";
            this.Load += new System.EventHandler(this.frmApertura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnControlla;
        private System.Windows.Forms.Label lblNomeFile;
        private System.Windows.Forms.TextBox txtNomeFile;
        private System.Windows.Forms.Button btnSfoglia;
        private System.Windows.Forms.OpenFileDialog ofdApri;
        private System.Windows.Forms.TextBox dynamicTextBox;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnControlla1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnControlla2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnControllaDataset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dynamicTexBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox dynamicTextBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnControllaOpenSearch;
        private System.Windows.Forms.Button btnControlla3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button primoErrore;
        private System.Windows.Forms.Button primoErroreDataset;
        private System.Windows.Forms.Button bntControllaPrimoErrOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}

