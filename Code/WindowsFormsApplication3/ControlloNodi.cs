using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.Collections.Generic;
using System.Data;


namespace WindowsFormsApplication3
{
    class ControlloNodi
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();



        public static int ControlloTitle(string nodo, XmlDocument doc, int mod)
        {
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_MEDIO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                {
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
            }

            else if (!ControlliSemplici.NonVuoto(nav))
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_MEDIO);
                    return Errore.ERR_NODO_VUOTO;
                }
                else
                {
                    return Errore.ERR_NODO_VUOTO;
                }
            }
            else
            {
                if (mod == 1)
                {
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                    return Errore.NO_ERR;
                }
                else
                    return Errore.NO_ERR;
            }

        }



        public static int ControlloSubtitle(XmlDocument doc, int mod)
        {
            String nodo = "/feed/subtitle";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (!ControlliSemplici.NonVuoto(nav))
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_BASSO);
                    return Errore.ERR_NODO_VUOTO;
                }
                else
                    return Errore.ERR_NODO_VUOTO;

            }
            else
            {
                if (mod == 1)
                {
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                    return Errore.NO_ERR;
                }
                else
                    return Errore.NO_ERR;
            }


        }

        public static Dictionary<int, int> ControlloLinkDescribedby(string nodo, XmlDocument doc, int mod)
        {

            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            Dictionary<int, int> errori = new Dictionary<int, int>();

            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            if (!ControlliSemplici.ControlloLink(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_LINK);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_LINK);
            }
            if (!ControlliSemplici.ApplicationXml(nav))
            {
                if (mod == 1)
                {
                    errori.Add(2, Errore.ERR_NODO_TYPE);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(2, Errore.ERR_NODO_TYPE);
            }

            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int, int> ControlloLinkSelf(XmlDocument doc, int mod)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
            String nodo = "/feed/link[@rel='self']";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }

            }

            if (!ControlliSemplici.ControlloLink(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_LINK);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_ALTO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_LINK);

            }
            if (!ControlliSemplici.ApplicationAtomXml(nav))
            {
                if (mod == 1)
                {
                    errori.Add(2, Errore.ERR_NODO_TYPE);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(2, Errore.ERR_NODO_TYPE);

            }
            if (!ControlliSemplici.ControlloLingua(nav))
            {
                if (mod == 1)
                {
                    errori.Add(3, Errore.ERR_NODO_HREFLANG);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_HREFLANG, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(3, Errore.ERR_NODO_HREFLANG);
            }

            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);

            }
            return errori;
        }

        public static Dictionary<int, int> ControlloLinkSearch(string theText, XmlDocument doc, int mod)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();

            string directory = Path.GetDirectoryName(theText);
            XPathExpression expr;
            String nodo = "/feed/link[@rel='search']";
            expr = nav.Compile(nodo);

            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
            }
            else
            {
                XPathNodeIterator iterator = nav.Select(expr);
                int count = 0;
                while (iterator.MoveNext())
                {
                    count++;
                }
                if (count != 1)
                {
                    if (mod == 1)
                    {
                        errori.Add(1, Errore.ERR_NODO_UNICO);
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_UNICO, Errore.LIV_MEDIO);
                    }
                    else
                        errori.Add(1, Errore.ERR_NODO_UNICO);
                }

                else
                {

                    XPathNavigator nav2 = iterator.Current.Clone();
                    String url = nav2.GetAttribute("href", "");


                    if (!ControlliSemplici.OpenSearchDescriptionDocument(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(1, Errore.ERR_NODO_TYPE);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(1, Errore.ERR_NODO_TYPE);
                    }
                    if (!ControlliSemplici.ControlloLingua(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(2, Errore.ERR_NODO_HREFLANG);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_HREFLANG, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(2, Errore.ERR_NODO_HREFLANG);
                    }

                }
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int, int> ControlloLinkAlternate(XmlDocument doc, int mod)
        {
            XPathNavigator nav = doc.CreateNavigator();
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathExpression expr;
            String nodo = "/feed/link[@rel='alternate']";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            int count = 0;
            while (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();

                if (!ControlliSemplici.ControlloLink(nav2))
                {
                    if (mod == 1)
                    {
                        errori.Add(count, Errore.ERR_NO_LINK);
                        Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                    }
                    else
                        errori.Add(count, Errore.ERR_NO_LINK);

                }
                else
                {
                    if (mod == 1)
                    {
                        errori.Add(count, Errore.NO_ERR);
                        logger.Info("Nodo: " + nodo);
                        logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                    }
                    else
                        errori.Add(count, Errore.NO_ERR);
                }
                count++;

            }

            return errori;
        }

        public static int ControlloId(XmlDocument doc, int mod)
        {
            String nodo = "/feed/id";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                String url = nav.ToString();
                XPathNavigator nav2 = doc.CreateNavigator().SelectSingleNode("/feed/link[@rel='self']");
                String href = nav2.GetAttribute("href", "");
                if (url != href)
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_LINK_SELF, Errore.LIV_MEDIO);
                        return Errore.ERR_LINK_SELF;
                    }
                    else
                        return Errore.ERR_LINK_SELF;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static int ControlloRights(XmlDocument doc, int mod)
        {
            String nodo = "/feed/rights";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                if (!ControlliSemplici.NonVuoto(nav))
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_MEDIO);
                        return Errore.ERR_NODO_VUOTO;
                    }
                    else
                        return Errore.ERR_NODO_VUOTO;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static DataTable ControlloAuthor(XmlDocument doc, int mod)
        {

            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/author";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);

            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    table.Rows.Add("/feed/author", Errore.ERR_NODO_OBBLIGATORIO);
                }
                else
                    table.Rows.Add("/feed/author", Errore.ERR_NODO_OBBLIGATORIO);
            }
            else
            {
                int count = 1;
                while (iterator.MoveNext())
                {
                    table.Rows.Add("nodo numero: " + count + " /feed/author/name", ControlloAuthorName("/feed/author/name", doc, mod));

                    foreach (var pair in ControlloAuthorEmail("/feed/author/email", doc, mod))
                    {
                        table.Rows.Add("nodo numero: " + count + " /feed/author/email", pair.Value);
                    }

                    count++;
                }
            }
            return table;

        }

        public static int ControlloAuthorName(string nodo, XmlDocument doc, int mod)
        {
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_MEDIO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                if (!ControlliSemplici.NonVuoto(nav))
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_MEDIO);
                        return Errore.ERR_NODO_VUOTO;
                    }
                    else
                        return Errore.ERR_NODO_VUOTO;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static Dictionary<int, int> ControlloAuthorEmail(string nodo, XmlDocument doc, int mod)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            expr = nav.Compile(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_MEDIO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }

            }
            else
            {
                XPathNodeIterator iterator = nav.Select(expr);
                int num = iterator.Count;
                int count = 0;
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    if (!ControlliSemplici.Email(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.ERR_NODO_EMAIL);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_EMAIL, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(count, Errore.ERR_NODO_EMAIL);
                    }
                    else
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.NO_ERR);
                            logger.Info("Nodo: " + nodo);
                            logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                        }
                        else
                            errori.Add(count, Errore.NO_ERR);

                    }
                    count++;
                    return errori;
                }
            }
            if (mod == 1)
            {
                errori.Add(1, Errore.NO_ERR);
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return errori;
            }
            else
            {
                errori.Add(1, Errore.NO_ERR);
                return errori;
            }

        }

        public static int ControlloUpdated(string nodo, XmlDocument doc, int mod)
        {
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                String contenuto = nav.ToString();
                DateTime dDate;

                if (!DateTime.TryParse(contenuto, out dDate))
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_DATA_ORA, Errore.LIV_MEDIO);
                        return Errore.ERR_NODO_DATA_ORA;
                    }
                    else
                        return Errore.ERR_NODO_DATA_ORA;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static DataTable ControlloEntry(string txtNomeFile, XmlDocument doc, int mod)
        {
            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            int errori;
            Dictionary<int, int> diErrori = new Dictionary<int, int>();
            DataTable tableAuthor = new DataTable();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/entry";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    table.Rows.Add(nodo, Errore.ERR_NODO_OBBLIGATORIO);
                }
                else
                    table.Rows.Add(nodo, Errore.ERR_NODO_OBBLIGATORIO);
            }
            else
            {
                int i = 1;

                while (iterator.MoveNext())
                {

                    XPathNavigator nav2 = iterator.Current.Clone();
                    logger.Info("Errori relativi al tag entry numero " + i + Environment.NewLine);

                    errori = ControlloNodi.ControlloTitle("/feed/entry[" + i + "]/title", doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry/title", errori);

                    diErrori = ControlloNodi.ControlloLinkDescribedby("/feed/entry[" + i + "]/link[@rel='describedby']", doc, mod);

                    foreach (var pair in diErrori)
                    {
                        logger.Info(pair.Value);
                        table.Rows.Add("entry numero: " + i + " /feed/entry/link[@rel='describedby']", pair.Value);

                    }

                    errori = ControlloNodi.ControlloLinkEntryAlternate(txtNomeFile, doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry[" + i + "]/link[@rel='alternate']", errori);

                    //ControlloLinkEntryRelated(dynamicTextBox, txtNomeFile);

                    errori = ControlloNodi.ControlloEntryId(doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry[" + i + "]/id", errori);

                    errori = ControlloNodi.ControlloEntryRights(doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry[" + i + "]/rights", errori);

                    errori = ControlloNodi.ControlloEntrySummary(doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry[" + i + "]/summary", errori);

                    tableAuthor = ControlloNodi.ControlloEntryAuthor(doc, mod, i);
                    foreach (DataRow row in tableAuthor.Rows)
                    {
                        table.Rows.Add(row.Field<string>(0), row.Field<int>(1));

                    }

                    errori = ControlloNodi.ControlloUpdated("/feed/entry[" + i + "]/updated", doc, mod);
                    table.Rows.Add("entry numero: " + i + " /feed/entry/updated", errori);

                    diErrori = ControlloNodi.ControlloEntryCategory(doc, mod, i);

                    foreach (var pair in diErrori)
                    {
                        table.Rows.Add("entry numero: " + i + " . /feed/entry/category", pair.Value);

                    }
                    i++;
                }
            }
            return table;
        }

        public static int ControlloEntryRights(XmlDocument doc, int mod)
        {
            string nodo = "/feed/entry/rights";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (!ControlliSemplici.NonVuoto(nav))
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_BASSO);
                    return Errore.ERR_NODO_VUOTO;
                }
                else
                    return Errore.ERR_NODO_VUOTO;
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static DataTable ControlloEntryAuthor(XmlDocument doc, int mod,int i)
        {

            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/entry[" + i + "]/author";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            int count = 1;
            while (iterator.MoveNext())
            {
                table.Rows.Add("nodo numero: " + count + " /feed/entry/author/name", ControlloAuthorName("/feed/entry/author/name", doc, mod));

                foreach (var pair in ControlloAuthorEmail("/feed/entry/author/email", doc, mod))
                {
                    table.Rows.Add("nodo numero: " + count + " /feed/entry/author/email", pair.Value);
                }

                count++;
            }

            return table;
        }


        public static int ControlloLinkEntryAlternate(string theText, XmlDocument doc, int mod)
        {
            String url;
            string directory = Path.GetDirectoryName(theText);
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/entry/link[@rel='alternate']";
            expr = nav.Compile(nodo);

            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                XPathNodeIterator iterator = nav.Select(expr);
                int count = 0;
                while (iterator.MoveNext())
                {
                    count++;
                }
                if (count != 1)
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_UNICO, Errore.LIV_ALTO);
                        return Errore.ERR_NODO_UNICO;
                    }
                    else
                        return Errore.ERR_NODO_UNICO;
                }
                else
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    url = nav2.GetAttribute("href", "");

                    if (!ControlliSemplici.ApplicationAtomXml(nav2))
                    {
                        if (mod == 1)
                        {
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                            return Errore.ERR_NODO_TYPE;
                        }
                        else
                            return Errore.ERR_NODO_TYPE;
                    }
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }


        /**
        public static void ControlloLinkEntryRelated(TextBox dynamicTextBox, System.Windows.Forms.TextBox txtNomeFile)
        {
            XmlDocument doc = new XmlDocument();
            doc = Documento(txtNomeFile);
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode("/feed/entry/link[@rel='related']");
            if (!ControlloHref.ControlloLink(nav))
                dynamicTextBox.AppendText("il link al nodo /feed/entry/link[@rel='related'] non esiste" + Environment.NewLine);
            if (!ControlloHref.ApplicationXml(nav))
                dynamicTextBox.AppendText("il nodo /feed/entry/link[@rel='related'] contiene un type non corretto" + Environment.NewLine);

        }**/


        public static int ControlloEntryId(XmlDocument doc, int mod)
        {
            string nodo = "/feed/entry/id";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return Errore.ERR_NODO_OBBLIGATORIO;
                }
                else
                    return Errore.ERR_NODO_OBBLIGATORIO;
            }
            else
            {
                if (!ControlliSemplici.NonVuoto(nav))
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_MEDIO);
                        return Errore.ERR_NODO_VUOTO;
                    }
                    else
                        return Errore.ERR_NODO_VUOTO;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static int ControlloEntrySummary(XmlDocument doc, int mod)
        {
            string nodo = "/feed/entry/summary";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);

            if (!ControlliSemplici.NonVuoto(nav))
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_BASSO);
                    return Errore.ERR_NODO_VUOTO;
                }
                else
                    return Errore.ERR_NODO_VUOTO;
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }

        public static Dictionary<int, int> ControlloEntryCategory(XmlDocument doc, int mod, int i)
        {
            String url;
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/entry[" + i + "]/category";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            if (iterator.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;

                }
            }
            else
            {
                int count = 0;
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    url = nav2.GetAttribute("term", "");
                    if (!ControlliSemplici.ControlloHttpGenerico(nav2, url))
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.ERR_NO_LINK);
                            Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(count, Errore.ERR_NO_LINK);

                    }
                    else
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.NO_ERR);
                            logger.Info("Nodo: " + nodo);
                            logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                        }
                        else
                            errori.Add(count, Errore.NO_ERR);
                    }

                    count++;
                }
            }

            return errori;
        }


        //gerss controlla che sia un poligono e che i primi due vertici sono ugueli agli utimi e che ci siano alemno 4 coppie
        //gestione tag inspire
        /*nav = doc.CreateNavigator().SelectSingleNode("feed/entry/georss:point");
        Console.WriteLine(nav.ToString());
        if (nav == null)
            Console.WriteLine("non è presente il tag 'entry INSPIRE identifier elements'");
        else
            ControlloNodi.NonVuoto(nav);*/

        public static Dictionary<int, int> ControlloDataSetDescribedby(XmlDocument doc, int mod)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            String nodo = "/feed/link[@rel='describedby']";
            expr = nav.Compile(nodo);

            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.LIV_ALTO);
                    return errori;
                }
            }
            else
            {

                XPathNodeIterator iterator = nav.Select(expr);
                int count = 0;
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    if (!ControlliSemplici.TextHtml(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.ERR_NODO_TYPE);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(count, Errore.ERR_NODO_TYPE);
                    }
                    if (!ControlliSemplici.ControlloLink(nav2))
                    {
                        count++;
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.ERR_NO_LINK);
                            Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_ALTO);
                        }
                        else
                            errori.Add(count, Errore.ERR_NO_LINK);
                    }
                    count++;
                }
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static int ControlloDatasetUp(XmlDocument doc, string txtNomeFile, int mod)
        {
            String url;
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/link[@rel='up']";
            expr = nav.Compile(nodo);

            XPathNodeIterator iterator = nav.Select(expr);
            int count = 0;
            while (iterator.MoveNext())
            {
                count++;
            }
            if (count != 1)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_UNICO, Errore.LIV_MEDIO);
                    return Errore.ERR_NODO_UNICO;
                }
                else
                    if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                    return Errore.ERR_NODO_UNICO;
            }
            else
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                url = nav2.GetAttribute("href", "");

                XmlDocument doc2 = new XmlDocument();
                doc2 = DownloadServiceFeed.Documento(txtNomeFile);

                XPathNavigator nav3 = doc2.CreateNavigator().SelectSingleNode("/feed/link[@rel='self']");
                string urlself = nav3.GetAttribute("href", "");
                if (url != urlself)
                {
                    if (mod == 1)
                    {
                        Errore.scritturaLog(nodo, Errore.ERR_NO_LINK_SELF_DOWNLOAD, Errore.LIV_MEDIO);
                        return Errore.ERR_NO_LINK_SELF_DOWNLOAD;
                    }
                    else
                        return Errore.ERR_NO_LINK_SELF_DOWNLOAD;
                }
            }
            if (mod == 1)
            {
                logger.Info("Nodo: " + nodo);
                logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                return Errore.NO_ERR;
            }
            else
                return Errore.NO_ERR;
        }
        public static DataTable ControlloDatasetEntry(XmlDocument doc, int mod)
        {
            DataTable table = new DataTable();
            table.Columns.Add("nodo", typeof(string));
            table.Columns.Add("errore", typeof(int));
            Dictionary<int, int> diErrori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/feed/entry";
            expr = nav.Compile(nodo);
            XPathNodeIterator iterator = nav.Select(expr);
            if (nav == null)
            {
                if (mod == 1)
                {
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    table.Rows.Add(nodo, Errore.ERR_NODO_OBBLIGATORIO);
                }
                else
                    table.Rows.Add(nodo, Errore.ERR_NODO_OBBLIGATORIO);
            }
            else
            {
                int i = 1;

                while (iterator.MoveNext())
                {
                    logger.Info("Errori relativi al tag entry numero " + i + Environment.NewLine);
                    diErrori = ControlloNodi.ControlloEntryCategory(doc, mod, i);

                    foreach (var pair in diErrori)
                    {
                        table.Rows.Add("/feed/entry[" + i + "]/category", pair.Value);

                    }
                    XPathNavigator nav2 = doc.CreateNavigator().SelectSingleNode("/feed/entry[" + i + "]/link[@rel='section']");
                    if (nav2 == null)
                    {
                        diErrori = ControlloDatasetAlternate(doc, mod, i);
                        foreach (var pair in diErrori)
                        {
                            table.Rows.Add("/feed/entry[" + i + "]/link[@rel='alternate']", pair.Value);
                        }
                    }
                    else if (nav2 != null) 
                    {
                        diErrori = ControlloDatasetSection(doc, mod, i);
                        foreach (var pair in diErrori)
                        {
                            table.Rows.Add("/feed/entry[" + i + "]/link[@rel='section']", pair.Value);
                        }
                    }
                    i++;
                }
            }
            return table;
        }

     public static Dictionary<int,int> ControlloDatasetAlternate(XmlDocument doc, int mod,int i)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
          XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            String nodo = "/feed/entry[" + i + "]/link[@rel='alternate']";
            expr = nav.Compile(nodo);

            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            else
            {
                XPathNodeIterator iterator = nav.Select(expr);
                int count = 0;
                while (iterator.MoveNext())
                {
                    count++;
                }
                if (count != 1)
                {
                    if (mod == 1)
                    {
                        errori.Add(1, Errore.ERR_NODO_UNICO);
                        Errore.scritturaLog(nodo, Errore.ERR_NODO_UNICO, Errore.LIV_ALTO);
                    }
                    else
                        errori.Add(1, Errore.ERR_NODO_UNICO);
                }

                else
                {

                    XPathNavigator nav2 = iterator.Current.Clone();
                    String url = nav2.GetAttribute("href", "");


                    if (!ControlliSemplici.MediaType(nav2))
                    {
                        logger.Info("entrata nel media type");
                        if (mod == 1)
                        {
                            errori.Add(1, Errore.ERR_NODO_TYPE);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_ALTO);
                        }
                        else
                            errori.Add(1, Errore.ERR_NODO_TYPE);
                    }
                    if (!ControlliSemplici.ControlloLink(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(2, Errore.ERR_NO_LINK);
                            Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_ALTO);
                        }
                        else
                            errori.Add(2, Errore.ERR_NO_LINK);
                    }

                }
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int,int> ControlloDatasetSection(XmlDocument doc, int mod, int i)
     {
         XPathNavigator nav = doc.CreateNavigator();
         Dictionary<int, int> errori = new Dictionary<int, int>();
         XPathExpression expr;
         String nodo = "/feed/entry[" + i + "]/link[@rel='section']";
         expr = nav.Compile(nodo);
         XPathNodeIterator iterator = nav.Select(expr);
         int count = 0;
         int g = 0;
         while (iterator.MoveNext())
         {
             g++;
         }
        if(g<=1)
        {
            if (mod == 1)
            {
                errori.Add(1, Errore.ERR_NO_MULTIPLO);
                Errore.scritturaLog(nodo, Errore.ERR_NO_MULTIPLO, Errore.LIV_ALTO);
                return errori;
            }
            else
            {
                errori.Add(count, Errore.ERR_NO_MULTIPLO);
                return errori;
            }
        }
         while (iterator.MoveNext())
         {
             XPathNavigator nav2 = iterator.Current.Clone();

             if (!ControlliSemplici.ControlloLink(nav2))
             {
                 if (mod == 1)
                 {
                     errori.Add(count, Errore.ERR_NO_LINK);
                     Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                 }
                 else
                     errori.Add(count, Errore.ERR_NO_LINK);
             }
             if (!ControlliSemplici.MediaType(nav2))
             {
                 count++;
                 if (mod == 1)
                 {
                     errori.Add(count, Errore.ERR_NODO_TYPE);
                     Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_ALTO);
                 }
                 else
                     errori.Add(count, Errore.ERR_NODO_TYPE);
             }

             XPathNavigator nav3 = doc.CreateNavigator().SelectSingleNode("/feed/entry[" + i + "]/link[@rel='alternate']");
             if(nav3==null)
             {
                 XPathNavigator nav4 = doc.CreateNavigator().SelectSingleNode("/feed/entry[" + i + "]/content");
                 if(nav4==null)
                 {
                     if (mod == 1)
                     {
                         errori.Add(count, Errore.ERR_NO_CONTENT_ALT);
                         Errore.scritturaLog(nodo, Errore.ERR_NO_CONTENT_ALT, Errore.LIV_MEDIO);
                     }
                     else
                         errori.Add(count, Errore.ERR_NO_CONTENT_ALT);
                 }
             }
             count++;
             return errori;

         }
         if (mod == 1)
         {
             errori.Add(1, Errore.NO_ERR);
             logger.Info("Nodo: " + nodo);
             logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
         }
         else
             errori.Add(1, Errore.NO_ERR);
         return errori;
     }

        public static Dictionary<int,int> ControlloOpenSelf(XmlDocument doc, int mod)
        {
            string nodo = "/OpenSearchDescription/Url[@rel='self']";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            Dictionary<int, int> errori = new Dictionary<int, int>();

            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            if (!ControlliSemplici.ControlloLinkOpen(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_LINK);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_LINK);
            }
            if (!ControlliSemplici.AppOpenXml(nav))
            {
                if (mod == 1)
                {
                    errori.Add(2, Errore.ERR_NODO_TYPE);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(2, Errore.ERR_NODO_TYPE);
            }

            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int, int> ControlloOpenResult(XmlDocument doc, int mod)
        {
            string nodo = "/OpenSearchDescription/Url[@rel='results'][1]";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            Dictionary<int, int> errori = new Dictionary<int, int>();
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            if (!ControlliSemplici.ControlloLinkOpen(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_LINK);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_LINK, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_LINK);
            }
          
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int,int> ControlloOpenDescribedby(XmlDocument doc, int mod)
        {
            string nodo = "/OpenSearchDescription/Url[@rel='describedby']";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            Dictionary<int, int> errori = new Dictionary<int, int>();
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            if (!ControlliSemplici.OpenTemplate(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_TEMPLATE);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_TEMPLATE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_TEMPLATE);
            }
            if (!ControlliSemplici.ApplicationAtomXml(nav))
            {
                if (mod == 1)
                {
                    errori.Add(2, Errore.ERR_NODO_TYPE);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(2, Errore.ERR_NODO_TYPE);
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int,int> ControlloOpenDatasetResult(XmlDocument doc, int mod)
        {
            string nodo = "/OpenSearchDescription/Url[@rel='results'][last()]";
            XPathNavigator nav = doc.CreateNavigator().SelectSingleNode(nodo);
            Dictionary<int, int> errori = new Dictionary<int, int>();
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_ALTO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }
            }
            if (!ControlliSemplici.OpenTemplateCrs(nav))
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NO_TEMPLATE);
                    Errore.scritturaLog(nodo, Errore.ERR_NO_TEMPLATE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(1, Errore.ERR_NO_TEMPLATE);
            }
            if (!ControlliSemplici.MediaType(nav))
            {
                if (mod == 1)
                {
                    errori.Add(2, Errore.ERR_NODO_TYPE);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_TYPE, Errore.LIV_MEDIO);
                }
                else
                    errori.Add(2, Errore.ERR_NODO_TYPE);
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;
        }

        public static Dictionary<int, int> ControlloOpenLanguage(XmlDocument doc, int mod)
        {
            Dictionary<int, int> errori = new Dictionary<int, int>();
            XPathNavigator nav = doc.CreateNavigator();
            XPathExpression expr;
            string nodo = "/OpenSearchDescription/Language";
            expr = nav.Compile(nodo);
            
            if (nav == null)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    Errore.scritturaLog(nodo, Errore.ERR_NODO_OBBLIGATORIO, Errore.LIV_MEDIO);
                    return errori;
                }
                else
                {
                    errori.Add(1, Errore.ERR_NODO_OBBLIGATORIO);
                    return errori;
                }

            }
            else
            {
                XPathNodeIterator iterator = nav.Select(expr);
                int count = 0;
                while (iterator.MoveNext())
                {
                    XPathNavigator nav2 = iterator.Current.Clone();
                    if (!ControlliSemplici.NonVuoto(nav2))
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.ERR_NODO_VUOTO);
                            Errore.scritturaLog(nodo, Errore.ERR_NODO_VUOTO, Errore.LIV_MEDIO);
                        }
                        else
                            errori.Add(count, Errore.ERR_NODO_VUOTO);
                    }
                    else
                    {
                        if (mod == 1)
                        {
                            errori.Add(count, Errore.NO_ERR);
                            logger.Info("Nodo: " + nodo);
                            logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                        }
                        else
                            errori.Add(count, Errore.NO_ERR);

                    }
                    count++;
                    
                }
            }
            if (errori.Count == 0)
            {
                if (mod == 1)
                {
                    errori.Add(1, Errore.NO_ERR);
                    logger.Info("Nodo: " + nodo);
                    logger.Info(Errore.DecodificaErrore(Errore.NO_ERR));
                }
                else
                    errori.Add(1, Errore.NO_ERR);
            }
            return errori;

        }
        }
    }
