using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WindowsFormsApplication3
{
    class OpenSearchDescriptionDoc
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void  ControlloFileOpenSearchDescription(string  txtNomeFile, DataTable table)
        {
             try
            {
                XmlDocument doc = new XmlDocument();
                doc = DocumentoOpenSearchDescription(txtNomeFile);

                Dictionary<int, int> diErrori = ControlloNodi.ControlloOpenSelf(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/OpenSearchDescription/Url[@rel='self']", pair.Value);
                    logger.Error("/OpenSearchDescription/Url[@rel='self']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }
                diErrori = ControlloNodi.ControlloOpenResult(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/OpenSearchDescription/Url[@rel='results']", pair.Value);
                    logger.Error("/OpenSearchDescription/Url[@rel='results']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }
                diErrori = ControlloNodi.ControlloOpenDescribedby(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/OpenSearchDescription/Url[@rel='describedby']", pair.Value);
                    logger.Error("/OpenSearchDescription/Url[@rel='describedby']");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }
                diErrori = ControlloNodi.ControlloOpenDatasetResult(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("/OpenSearchDescription/Url[@rel='results'][last()]", pair.Value);
                    logger.Error("/OpenSearchDescription/Url[@rel='results'][last()]");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                }
                diErrori = ControlloNodi.ControlloOpenLanguage(doc, DownloadServiceFeed.interoFile);
                int count = 1;
                foreach (var pair in diErrori)
                {
                    table.Rows.Add("Nodo languaguage numero: "+count+" /OpenSearchDescription/Language", pair.Value);
                    logger.Error("/OpenSearchDescription/Language");
                    logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(pair.Value));
                    count++;
                }
             
             }
            catch (XmlException e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }
        }

        public static Dictionary<string, int> ControlloPrimoErroreOpenSearchDescription(string txtNomeFile)
        {
                Dictionary<string, int> errore = new Dictionary<string, int>();
                XmlDocument doc = new XmlDocument();
                doc = DocumentoOpenSearchDescription(txtNomeFile);


                Dictionary<int, int> diErrori = ControlloNodi.ControlloOpenSelf(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("/OpenSearchDescription/Url[@rel='self']" + pair.Value);
                        errore.Add("/OpenSearchDescription/Url[@rel='self']", pair.Value);
                        return errore;
                    }
                }

                diErrori = ControlloNodi.ControlloOpenResult(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("/OpenSearchDescription/Url[@rel='results']" + pair.Value);
                        errore.Add("/OpenSearchDescription/Url[@rel='results']", pair.Value);
                        return errore;
                    }
                }

                diErrori = ControlloNodi.ControlloOpenDescribedby(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("/OpenSearchDescription/Url[@rel='describedby']" + pair.Value);
                        errore.Add("/OpenSearchDescription/Url[@rel='describedby']", pair.Value);
                        return errore;
                    }
                }

                diErrori = ControlloNodi.ControlloOpenDatasetResult(doc, DownloadServiceFeed.interoFile);
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("/OpenSearchDescription/Url[@rel='results'][last()]" + pair.Value);
                        errore.Add("/OpenSearchDescription/Url[@rel='results'][last()]", pair.Value);
                        return errore;
                    }
                }

                diErrori = ControlloNodi.ControlloOpenLanguage(doc, DownloadServiceFeed.interoFile);
            int count = 1;
                foreach (var pair in diErrori)
                {
                    if (pair.Value != 0)
                    {
                        logger.Error("Nodo languaguage numero: " + count + " /OpenSearchDescription/Language" + pair.Value);
                        errore.Add("Nodo languaguage numero: " + count + " /OpenSearchDescription/Language", pair.Value);
                        return errore;
                    }
                }
                
                return errore;

        }

        public static XmlDocument DocumentoOpenSearchDescription(string txtNomeFile)
        {
            XmlDocument doc = new XmlDocument();
            //doc = DownloadServiceFeed.Documento(txtNomeFile);

            doc.Load(txtNomeFile);
            String directory = Path.GetDirectoryName(txtNomeFile);
            
            XPathNavigator nav = doc.CreateNavigator();

            XmlNamespaceManager manager = new XmlNamespaceManager(nav.NameTable);
            manager.AddNamespace("atom", "http://www.w3.org/2005/Atom");
            String nodoHREF = "/atom:feed/atom:link[@rel='search']";
            XPathNavigator nodo = nav.SelectSingleNode(nodoHREF, manager);
            if (nodo == null)
            {
                Errore.setUltimoErrore(Errore.ERR_NO_FILE);
                logger.Error("Errore relativo al nodo: " + nodoHREF);
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(Errore.ERR_NO_FILE));
                logger.Error("Livello di errore: " + Errore.LIV_ALTO);
                return (null);
            }
            String url = nodo.GetAttribute("href", "");
            if (url == "")
            {
                Errore.setUltimoErrore(Errore.ERR_NO_FILE);
                logger.Error("Errore relativo al nodo: " + nodoHREF);
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(Errore.ERR_NO_FILE));
                logger.Error("Livello di errore: " + Errore.LIV_ALTO);
                return (null);
            }
            //costruzione path del file DATASET FEED 
            string file = null;
            file = Path.GetFileName(url);

            string nomeFile = file.ToString();
            string path = null;
            if (nomeFile == "")
            {
                Errore.setUltimoErrore(Errore.ERR_NO_FILE);
                logger.Error("Errore relativo al nodo: " + nodo);
                logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(Errore.ERR_NO_FILE));
                logger.Error("Livello di errore: " + Errore.LIV_ALTO);
            }
            else
                path = directory + "/" + file;
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(path);
            logger.Info("aperto file");
            return doc1;
        }
        }
    }

