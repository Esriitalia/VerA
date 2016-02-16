using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NLog;
using System.Xml.XPath;
using System.Data;

namespace WindowsFormsApplication3
{
    class DownloadServiceFeed
    {
        public const int primoErr = 0;
        public const int interoFile = 1;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void ControlloFileDownloadServiceFeed(string txtNomeFile, DataTable table)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc = Documento(txtNomeFile);
                
                //aggiungendo il namespace non funziona comunque
                //NameTable nt = new NameTable();
                //XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
                //nsmgr.AddNamespace("feed", "http://www.w3.org/2005/Atom");
                // Console.WriteLine(doc.GetNamespaceOfPrefix("xmlns"));

                int errori = ControlloNodi.ControlloTitle("/feed/title", doc, DownloadServiceFeed.interoFile);
                table.Rows.Add("/feed/title", errori);
                logger.Error("Errore relativo al nodo: /feed/title");
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                errori = ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile);
                table.Rows.Add("/feed/subtitle", errori);
                logger.Error("Errore relativo al nodo: /feed/subtitle");
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                Dictionary<int, int> diErrori = ControlloNodi.ControlloLinkDescribedby("/feed/link[@rel='describedby']", doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/feed/link[@rel='describedby']", pair.Value);
                    logger.Error("Errore relativo al nodo: /feed/link[@rel='describedby']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }

                diErrori = ControlloNodi.ControlloLinkSelf(doc, DownloadServiceFeed.interoFile);
                
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/feed/link[@rel='self']", pair.Value);
                    logger.Error("Errore relativo al nodo: /feed/link[@rel='self']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }

                diErrori = ControlloNodi.ControlloLinkSearch(txtNomeFile, doc, DownloadServiceFeed.interoFile);
                
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/feed/link[@rel='search']", pair.Value);
                    logger.Error("Errore relativo al nodo: /feed/link[@rel='search']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }

                diErrori = ControlloNodi.ControlloLinkAlternate(doc, DownloadServiceFeed.interoFile);
                int count = 1;
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("nodo alternate numero: "+count+"/feed/link[@rel='alternate']", pair.Value);
                    logger.Error("Errore relativo al nodo: /feed/link[@rel='alternate']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                    count++;
                }

                errori = ControlloNodi.ControlloId(doc, DownloadServiceFeed.interoFile);
                table.Rows.Add("/feed/id", errori);
                logger.Error("Errore relativo al nodo: /feed/id");
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                errori = ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile);
                table.Rows.Add("/feed/rights", errori);
                logger.Error("Errore relativo al nodo: /feed/rights");
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
                foreach (DataRow row in tableAuthor.Rows)
                {
                    table.Rows.Add(row.Field<string>(0), row.Field<int>(1));
                    logger.Error("Errore relativo al nodo: " + row.Field<string>(0));
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(row.Field<int>(1)));

                }

                errori = ControlloNodi.ControlloUpdated("/feed/updated", doc, DownloadServiceFeed.interoFile);
                table.Rows.Add("/feed/updated", errori);
                logger.Error("Errore relativo al nodo: /feed/updated");
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errori));

                DataTable tableEntry = ControlloNodi.ControlloEntry(txtNomeFile, doc, DownloadServiceFeed.interoFile);
                foreach (DataRow row in tableEntry.Rows)
                {
                    table.Rows.Add(row.Field<string>(0), row.Field<int>(1));
                    logger.Error("Errore relativo al nodo: " + row.Field<string>(0));
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(row.Field<int>(1)));

                }
            }
                
            catch (XmlException e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }
        }

        public static Dictionary<string, int> ControlloPrimoErrDownloadServiceFeed(string txtNomeFile)
        {
            Dictionary<string, int> errore = new Dictionary<string, int>();
            XmlDocument doc = new XmlDocument();
            doc = Documento(txtNomeFile);
            int errori = ControlloNodi.ControlloTitle("/feed/title", doc, DownloadServiceFeed.primoErr);
            if(errori!=0)
            {
                logger.Error("/feed/title" + errori);
                errore.Add("/feed/title", errori);
                return errore;
            }
            errori = ControlloNodi.ControlloSubtitle(doc, DownloadServiceFeed.interoFile);
            if (errori != 0)
            {
                logger.Error("/feed/subtitle" + errori);
                errore.Add("/feed/subtitle", errori);
                return errore;
            }

            Dictionary<int, int> diErrori = ControlloNodi.ControlloLinkDescribedby("/feed/link[@rel='describedby']", doc, DownloadServiceFeed.interoFile);
            foreach (var pair in diErrori)
            {
                if (pair.Value != 0)
                {
                    logger.Error("/feed/link[@rel='describedby']" + pair.Value);
                    errore.Add("/feed/link[@rel='describedby']", pair.Value);
                    return errore;
                }
            }

            diErrori = ControlloNodi.ControlloLinkSelf(doc, DownloadServiceFeed.interoFile);

            foreach (var pair in diErrori)
            {
                if (pair.Value != 0)
                {
                    logger.Error("/feed/link[@rel='self']" + pair.Value);
                    errore.Add("/feed/link[@rel='self']", pair.Value);
                    return errore;
                }
            }

            diErrori = ControlloNodi.ControlloLinkSearch(txtNomeFile, doc, DownloadServiceFeed.interoFile);

            foreach (var pair in diErrori)
            {
                if (pair.Value != 0)
                {
                    logger.Error("/feed/link[@rel='search']" + pair.Value);
                    errore.Add("/feed/link[@rel='search']", pair.Value);
                    return errore;
                }
            }

            diErrori = ControlloNodi.ControlloLinkAlternate(doc, DownloadServiceFeed.interoFile);
            int count = 1;
            foreach (var pair in diErrori)
            {
                if (pair.Value != 0)
                {
                    logger.Error("nodo alternate numero: " + count + "/feed/link[@rel='alternate']" + pair.Value);
                    errore.Add("nodo alternate numero: " + count + "/feed/link[@rel='alternate']", pair.Value);
                    return errore;
                }
                count++;
            }

            errori = ControlloNodi.ControlloId(doc, DownloadServiceFeed.interoFile);
            if (errori != 0)
            {
                logger.Error("/feed/id" + errori);
                errore.Add("/feed/id", errori);
                return errore;
            }

            errori = ControlloNodi.ControlloRights(doc, DownloadServiceFeed.interoFile);
            if (errori != 0)
            {
                logger.Error("/feed/rights" + errori);
                errore.Add("/feed/rights", errori);
                return errore;
            }

            DataTable tableAuthor = ControlloNodi.ControlloAuthor(doc, DownloadServiceFeed.interoFile);
            foreach (DataRow row in tableAuthor.Rows)
            {
                if (row.Field<int>(1) != 0)
                {
                    logger.Error(row.Field<string>(0), row.Field<int>(1));
                    errore.Add(row.Field<string>(0), row.Field<int>(1));
                    return errore;
                }

            }

            errori = ControlloNodi.ControlloUpdated("/feed/updated", doc, DownloadServiceFeed.interoFile);
            if (errori != 0)
            {
                logger.Error("/feed/updated" + errori);
                errore.Add("/feed/updated", errori);
                return errore;

            }

            DataTable tableEntry = ControlloNodi.ControlloEntry(txtNomeFile, doc, DownloadServiceFeed.interoFile);
            foreach (DataRow row in tableEntry.Rows)
            {
                if (row.Field<int>(1) != 0)
                {
                    logger.Error(row.Field<string>(0), row.Field<int>(1));
                    errore.Add(row.Field<string>(0), row.Field<int>(1));
                    return errore;
                }

            }
            errore.Add("file",0);
            logger.Info("nessun errore nel File");
            return errore;
        }
        public static XmlDocument Documento(string theText)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(theText);
            return doc;
        }
        }
    }

