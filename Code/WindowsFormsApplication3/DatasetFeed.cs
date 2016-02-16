using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using NLog;
using System.Data;

namespace WindowsFormsApplication3
{
    class DatasetFeed
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void ControlloFileDatasetFeed(string txtNomeFile, DataTable table)
        {
            try
            {
                Dictionary<int,string> docDataset = DocumentoDatasetFeed(txtNomeFile);
                foreach (var pairD in docDataset)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(pairD.Value);
                    logger.Info(Path.GetFileName(pairD.Value),"Errori relativi al file: " + pairD.Value);

                    int errori = ControlloNodi.ControlloTitle("/feed/title", doc, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/title", errori);
                    logger.Error("Errore relativo al nodo: /feed/title");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                    errori = ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/subtitle", errori);
                    logger.Error("Errore relativo al nodo: /feed/subtitle");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));


                    errori = ControlloNodi.ControlloEntryId(doc, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/id", errori);
                    logger.Error("Errore relativo al nodo: /feed/id");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                    errori = ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/rights", errori);
                    logger.Error("Errore relativo al nodo: /feed/rights");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                    DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
                    foreach (DataRow row in tableAuthor.Rows)
                    {
                        table.Rows.Add(Path.GetFileName(pairD.Value), row.Field<string>(0), row.Field<int>(1));
                        logger.Error("Errore relativo al nodo: " + row.Field<string>(0));
                        logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(row.Field<int>(1)));

                    }

                    errori = ControlloNodi.ControlloUpdated("/feed/updated", doc, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/updated", errori);
                    logger.Error("Errore relativo al nodo: /feed/updated");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));


                    Dictionary<int, int> diErrori = ControlloNodi.ControlloDataSetDescribedby(doc, DownloadServiceFeed.interoFile);
                    foreach (var pair in diErrori)
                    {
                        table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/link[@rel='describedby']", pair.Value);
                        logger.Error("Errore relativo al nodo: /feed/link[@rel='describedby']");
                        logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));

                    }

                    errori = ControlloNodi.ControlloDatasetUp(doc, txtNomeFile, DownloadServiceFeed.interoFile);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/link[@rel='up']", errori);
                    logger.Error("Errore relativo al nodo: /feed/link[@rel='up']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                    DataTable tableEntry = ControlloNodi.ControlloDatasetEntry(doc, DownloadServiceFeed.interoFile);
                    foreach (DataRow row in tableEntry.Rows)
                    {
                        table.Rows.Add(Path.GetFileName(pairD.Value), row.Field<string>(0), row.Field<int>(1));
                        logger.Error("Errore relativo al nodo: " + row.Field<string>(0));
                        logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(row.Field<int>(1)));
                    }
                }
            }

            catch (XmlException e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }
        }

        public static DataTable ControlloPrimoErrDatasetFeed(string txtNomeFile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("file", typeof(string));
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            Dictionary<int, string> docDataset = DocumentoDatasetFeed(txtNomeFile);
            foreach (var pairD in docDataset)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pairD.Value);
                logger.Info("File: " + Path.GetFileName(pairD.Value) + Environment.NewLine);

                int errori = ControlloNodi.ControlloTitle("/feed/title", doc, DownloadServiceFeed.primoErr);
                if (errori != 0)
                {
                    logger.Error("/feed/title" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/title", errori);
                    break;
                }
                errori = ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile);
                if (errori != 0)
                {
                    logger.Error("/feed/subtitle" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/subtitle", errori);
                    break;
                }


                errori = ControlloNodi.ControlloEntryId(doc, DownloadServiceFeed.interoFile);
                if (errori != 0)
                {
                    logger.Error("/feed/id" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/id", errori);
                    break;
                }

                errori = ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile);
                if (errori != 0)
                {
                    logger.Error("/feed/rights" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/rights", errori);
                    break;
                }

                DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
                foreach (DataRow row in tableAuthor.Rows)
                {
                    if (row.Field<int>(1) != 0)
                    {
                        logger.Error(row.Field<string>(0), row.Field<int>(1));
                        table.Rows.Add(Path.GetFileName(pairD.Value), row.Field<string>(0), row.Field<int>(1));
                        break;
                    }
                }
                errori = ControlloNodi.ControlloUpdated("/feed/updated", doc, DownloadServiceFeed.interoFile);
                if (errori != 0)
                {
                    logger.Error("/feed/updated" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/updated", errori);
                    break;
                }


                Dictionary<int, int> diErrori = ControlloNodi.ControlloDataSetDescribedby(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("/feed/link[@rel='describedby']" + pair.Value);
                        table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/link[@rel='describedby']", pair.Value);
                        break;
                    }
                }

                errori = ControlloNodi.ControlloDatasetUp(doc, txtNomeFile, DownloadServiceFeed.interoFile);
                if (errori != 0)
                {
                    logger.Error("/feed/link[@rel='up']" + errori);
                    table.Rows.Add(Path.GetFileName(pairD.Value), "/feed/link[@rel='up']", errori);
                    break;
                }

                DataTable tableEntry = ControlloNodi.ControlloDatasetEntry(doc, DownloadServiceFeed.interoFile);
                foreach (DataRow row in tableEntry.Rows)
                {
                    if (row.Field<int>(1) != 0)
                    {
                        logger.Error(row.Field<string>(0), row.Field<int>(1));
                        table.Rows.Add(Path.GetFileName(pairD.Value), row.Field<string>(0), row.Field<int>(1));
                        break;
                    }
                }
                int i=0;
                foreach (DataRow row in table.Rows)
                {
                    i++;
                }
                if(i==0)
                {
                    table.Rows.Add(Path.GetFileName(pairD.Value), "file", 0);
                    logger.Info("nessun errore nel File");
                }
            }
            return table;
        }

        public static Dictionary<int,string> DocumentoDatasetFeed(string theText)
        {
            XmlDocument doc = new XmlDocument();
            doc = DownloadServiceFeed.Documento(theText);

            doc.Load(theText);
            string directory = Path.GetDirectoryName(theText);
            Dictionary<int, string> doc1 = new Dictionary<int, string>();
            String url;
            string nodo = "/feed/entry/link[@rel='alternate']";
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            int i = 0;
            Console.WriteLine(iterator.Count);
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                url = nav2.GetAttribute("href", "");
                //costruzione path del file DATASET FEED 
                string file = null;
                file = Path.GetFileName(url);
                
                string nomeFile = file.ToString();
                string path = null;
                if (file.ToString() == "")
                {
                    Errore.setUltimoErrore(Errore.ERR_NO_FILE);
                    logger.Error("Errore relativo al nodo: " + nodo);
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(Errore.ERR_NO_FILE));
                    logger.Error("Livello di errore: " + Errore.LIV_ALTO);
                }
                else
                    path = directory + "\\" + file;
                doc1.Add(i,path);
                i++;

            }
            return doc1;
        }

    }
}
