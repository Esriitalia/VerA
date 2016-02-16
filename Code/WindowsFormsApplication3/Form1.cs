using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication3
{
    public partial class frmApertura : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public frmApertura()
        {
            InitializeComponent();
        }

        private void frmApertura_Load(object sender, EventArgs e)
        {

        }

        private void btnSfoglia_Click(object sender, EventArgs e)
        {
            if (ofdApri.ShowDialog() == DialogResult.OK)
                txtNomeFile.Text = ofdApri.FileName;

        }

        private void btnControlla_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
           DownloadServiceFeed.ControlloFileDownloadServiceFeed(theText, table);
            string[] textBoxLines = dynamicTextBox.Lines;
            
            foreach (DataRow row in table.Rows)
            {
                dynamicTextBox.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTextBox.AppendText(Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine + Environment.NewLine); 
                
            }
        }

        private void lblNomeFile_Click(object sender, EventArgs e)
        {
        }

        private void DynamicTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void btnControlla1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string theText = txtNomeFile.Text;
            doc = DownloadServiceFeed.Documento(theText);

            if (comboBox1.Text == "/feed/title")
            {
                String nodo = "/feed/title";
                string[] textBoxLines = dynamicTextBox.Lines;
                dynamicTextBox.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloTitle(nodo, doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            else if (comboBox1.Text == "/feed/subtitle")
            {
                string[] textBoxLines = dynamicTextBox.Lines;
                dynamicTextBox.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            else if (comboBox1.Text == "/feed/link[@rel='describedby']")
            {
                String nodo = "/feed/link[@rel='describedby']";
                Dictionary<int, int> d = ControlloNodi.ControlloLinkDescribedby(nodo, doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);

                }
                
            }
            else if (comboBox1.Text == "/feed/link[@rel='self']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloLinkSelf(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);

                }
            }
            else if (comboBox1.Text == "/feed/link[@rel='search']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloLinkSearch(theText, doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                   

                }
            }
            else if (comboBox1.Text == "/feed/link[@rel='alternate']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloLinkAlternate(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox.Lines;
                int count = 1;
                foreach (var pair in d)
                {
                    dynamicTextBox.AppendText("nodo numero: " + count + Environment.NewLine);
                    dynamicTextBox.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                    count++;

                }
            }
            else if (comboBox1.Text == "/feed/id")
            {
                
                string[] textBoxLines = dynamicTextBox.Lines;
                dynamicTextBox.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloId(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            else if (comboBox1.Text == "/feed/rights")
            {
                 string[] textBoxLines = dynamicTextBox.Lines;
                 dynamicTextBox.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            else if (comboBox1.Text == "/feed/author")
            {
                string[] textBoxLines = dynamicTextBox.Lines;
                DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
                foreach (DataRow row in tableAuthor.Rows)
                {
                    dynamicTextBox.AppendText(row.Field<string>(0) + Environment.NewLine + Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine);
                }
            }
            else if (comboBox1.Text == "/feed/updated")
            {
                String nodo = "/feed/updated";
                string[] textBoxLines = dynamicTextBox.Lines;
                dynamicTextBox.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloUpdated(nodo, doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            else if (comboBox1.Text == "/feed/entry")
            {

                DataTable tableEntry = ControlloNodi.ControlloEntry(theText, doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox.Lines;
                foreach (DataRow row in tableEntry.Rows)
                {
                    dynamicTextBox.AppendText(row.Field<string>(0) + Environment.NewLine + Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine);
                }
            }
        }

        private void btnControlla2_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;

            if (comboBox2.Text == "/feed/title")
            {
                 Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
                 foreach (var pairD in docDataset)
                 {
                     XmlDocument doc = new XmlDocument();
                     doc.Load(pairD.Value);
                     logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                     dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                     String nodo = "/feed/title";
                     string[] textBoxLines = dynamicTexBox2.Lines;
                     dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloTitle(nodo, doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
                 }
            }
            else if (comboBox2.Text == "/feed/subtitle")
            {Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                string[] textBoxLines = dynamicTexBox2.Lines;
                dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            }
            
            else if (comboBox2.Text == "/feed/id")
            {
                Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
                foreach (var pairD in docDataset)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pairD.Value);
                    logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    string[] textBoxLines = dynamicTexBox2.Lines;
                    dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloEntryId(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
                }
            }
            else if (comboBox2.Text == "/feed/rights")
            {
                Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
                foreach (var pairD in docDataset)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pairD.Value);
                    logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    string[] textBoxLines = dynamicTexBox2.Lines;
                    dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
                }
            }
            else if (comboBox2.Text == "/feed/author")
            {
                Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
                foreach (var pairD in docDataset)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pairD.Value);
                    logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                    string[] textBoxLines = dynamicTexBox2.Lines;
                    DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
                    foreach (DataRow row in tableAuthor.Rows)
                    {
                        dynamicTexBox2.AppendText(row.Field<string>(0) + Environment.NewLine + Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine);
                    }
                }
            }
            else if (comboBox2.Text == "/feed/updated")
            {Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                String nodo = "/feed/updated";
                string[] textBoxLines = dynamicTexBox2.Lines;
                dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloUpdated(nodo, doc, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            }
            else if (comboBox2.Text == "/feed/link[@rel='describedby']")
            {Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                Dictionary<int, int> d = ControlloNodi.ControlloDataSetDescribedby(doc, DownloadServiceFeed.interoFile); ;
                string[] textBoxLines = dynamicTexBox2.Lines;
                foreach (var pair in d)
                {
                    dynamicTexBox2.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }
            }
            else if (comboBox2.Text == "/feed/link[@rel='up']")
            {Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                string[] textBoxLines = dynamicTexBox2.Lines;
                dynamicTexBox2.AppendText(Errore.DecodificaErrore(ControlloNodi.ControlloDatasetUp(doc, theText, DownloadServiceFeed.interoFile)) + Environment.NewLine);
            }
            }

            else if(comboBox2.Text=="/feed/entry")
            {Dictionary<int, string> docDataset = DatasetFeed.DocumentoDatasetFeed(theText);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                dynamicTexBox2.AppendText("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);
                DataTable tableEntry = ControlloNodi.ControlloDatasetEntry(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTexBox2.Lines;
                foreach (DataRow row in tableEntry.Rows)
                {
                    dynamicTexBox2.AppendText(row.Field<string>(0) + Environment.NewLine + Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine);
                }
            }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnControllaDataset_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("file", typeof(string));
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            string theText = txtNomeFile.Text;
           DatasetFeed.ControlloFileDatasetFeed(theText,table);
            string[] textBoxLines = dynamicTexBox2.Lines;

            foreach (DataRow row in table.Rows)
            {
                dynamicTexBox2.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTexBox2.AppendText(row.Field<string>(1) + Environment.NewLine);
                dynamicTexBox2.AppendText(Errore.DecodificaErrore(row.Field<int>(2)) + Environment.NewLine + Environment.NewLine);

            }
        }

        private void dynamicTexBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnControlla3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string theText = txtNomeFile.Text;
            doc = OpenSearchDescriptionDoc.DocumentoOpenSearchDescription(theText);

            if (comboBox3.Text == "/OpenSearchDescription/Url[@rel='self']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloOpenSelf(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox3.Lines;
                foreach (var pair in d)
                {

                    dynamicTextBox3.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }
            else if (comboBox3.Text == "/OpenSearchDescription/Url[@rel='results']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloOpenResult(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox3.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox3.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }
            else if (comboBox3.Text == "/OpenSearchDescription/Url[@rel='describedby']")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloOpenDescribedby(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox3.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox3.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }

            else if (comboBox3.Text == "/OpenSearchDescription/Url[@rel='results'][last()]")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloOpenDatasetResult(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox3.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox3.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }

            else if (comboBox3.Text == "/OpenSearchDescription/Language")
            {
                Dictionary<int, int> d = ControlloNodi.ControlloOpenLanguage(doc, DownloadServiceFeed.interoFile);
                string[] textBoxLines = dynamicTextBox3.Lines;
                foreach (var pair in d)
                {
                    dynamicTextBox3.AppendText(Errore.DecodificaErrore(pair.Value) + Environment.NewLine);
                }
            }
        }

        private void btnControllaOpenSearch_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
           OpenSearchDescriptionDoc.ControlloFileOpenSearchDescription(theText, table);
           string[] textBoxLines = dynamicTextBox3.Lines;

            foreach (DataRow row in table.Rows)
            {
                dynamicTextBox3.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTextBox3.AppendText(Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void primoErrore_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            Dictionary<string,int> d=DownloadServiceFeed.ControlloPrimoErrDownloadServiceFeed(theText);
            string[] textBoxLines = dynamicTextBox.Lines;
            foreach (var pair in d)
            {
                dynamicTextBox.AppendText(pair.Key + Environment.NewLine + Errore.DecodificaErrore(pair.Value));
            }
        }

        private void primoErroreDataset_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            DataTable d = DatasetFeed.ControlloPrimoErrDatasetFeed(theText);
            string[] textBoxLines = dynamicTexBox2.Lines;
            foreach (DataRow row in d.Rows)
            {
                dynamicTexBox2.AppendText(row.Field<string>(0) + Environment.NewLine + row.Field<string>(1) + Environment.NewLine + Errore.DecodificaErrore(row.Field<int>(2)) + Environment.NewLine + Environment.NewLine);
            }
        }

        private void bntControllaPrimoErrOpen_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            Dictionary<string, int> d = OpenSearchDescriptionDoc.ControlloPrimoErroreOpenSearchDescription(theText);
            string[] textBoxLines = dynamicTextBox3.Lines;
            foreach (var pair in d)
            {
                dynamicTextBox3.AppendText(pair.Key + Environment.NewLine + Errore.DecodificaErrore(pair.Value));
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dynamicTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string theText = txtNomeFile.Text;
            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            DownloadServiceFeed.ControlloFileDownloadServiceFeed(theText, table);
            string[] textBoxLines = dynamicTextBox.Lines;

            foreach (DataRow row in table.Rows)
            {
                dynamicTextBox.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTextBox.AppendText(Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine + Environment.NewLine);

            }

            DataTable table1 = new DataTable();
            table1.Columns.Add("file", typeof(string));
            table1.Columns.Add("nodo", typeof(string));
            table1.Columns.Add("errore", typeof(int));
            string theText1 = txtNomeFile.Text;
            DatasetFeed.ControlloFileDatasetFeed(theText1, table1);
            string[] textBoxLines1 = dynamicTexBox2.Lines;

            foreach (DataRow row in table1.Rows)
            {
                dynamicTexBox2.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTexBox2.AppendText(row.Field<string>(1) + Environment.NewLine);
                dynamicTexBox2.AppendText(Errore.DecodificaErrore(row.Field<int>(2)) + Environment.NewLine + Environment.NewLine);

            }

            string theText2 = txtNomeFile.Text;
            DataTable table2 = new DataTable();
            table2.Columns.Add("nodo", typeof(string));
            table2.Columns.Add("errore", typeof(int));
            OpenSearchDescriptionDoc.ControlloFileOpenSearchDescription(theText2, table2);
            string[] textBoxLines2 = dynamicTextBox3.Lines;

            foreach (DataRow row in table2.Rows)
            {
                dynamicTextBox3.AppendText(row.Field<string>(0) + Environment.NewLine);
                dynamicTextBox3.AppendText(Errore.DecodificaErrore(row.Field<int>(1)) + Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
