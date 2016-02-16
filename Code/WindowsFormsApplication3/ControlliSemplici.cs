using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace WindowsFormsApplication3
{
    class ControlliSemplici
    {
        public static bool ControlloLink(XPathNavigator nav)
        {
            string url = nav.GetAttribute("href", "");
            //string type = nav.GetAttribute("type", "");
            Console.WriteLine(url);
            bool result = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";
                
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    result = !(response == null || response.StatusCode != HttpStatusCode.OK);
                    //if (response.ContentType!= type)
                     // Console.WriteLine("il tipo di link è diverso" + nav.XmlType  + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public static bool ControlloHttpGenerico(XPathNavigator nav,string url)
        {
            bool result = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";
                

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    result = !(response == null || response.StatusCode != HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public static bool ControlloLinkOpen(XPathNavigator nav)
        {
            string url = nav.GetAttribute("template", "");
            Console.WriteLine(url);
            bool result = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "HEAD";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    result = !(response == null || response.StatusCode != HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
        public static bool ControlloLingua(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String hreflang = navigator.GetAttribute("hreflang", "");
            if (hreflang != navigator.XmlLang)
                risultato = false;
            return risultato;
        }


        public static bool ApplicationXml(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            if (type != "application/xml")
                risultato = false;
            return risultato;
        }

    
        public static bool ApplicationAtomXml(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            if (type != "application/atom+xml")
                risultato = false;
            return risultato;
        }

        public static bool OpenSearchDescriptionDocument(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            if (type != "application/opensearchdescription+xml")
                risultato = false;
            return risultato;
        }
        public static bool NonVuoto(XPathNavigator navigator)
        {
            Boolean risultato = true;
            try
            {
                String contenuto = navigator.ToString();
                if (contenuto == "")
                    risultato = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }

        public static bool Email(XPathNavigator navigator)
        {
            Boolean risultato = true;
            String email = navigator.ToString();
            String MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
             + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
             + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

            Regex regex = new Regex(MatchEmailPattern);
            Match match = regex.Match(email);

            if (!match.Success)
                risultato = false;
            return risultato;
        }

        public static bool TextHtml(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            if (type != "text/html")
                risultato = false;
            return risultato;
        }
        public static bool MediaType(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            string typeGml = "application/gml+xml";
            if (type != "application/x-shapefile" && type != "application/x-filegdb" && type != "image/tiff" && type != "application/x-gmz" && type != "application/vnd.google-earth.kml+xml" &&
                type != "application/vnd.google-earth.kmz" && type != "image/jp2" && type != "application/x-ecw" && type != "application/x-ascii-grid" && type != "application/x-oracledump" && type != "application/x-las" &&
                type != "application/x-laz" && type != "application/x-tab" && type != "application/x-tab-raster" && type != "text/csv" && type != "application/x-worldfile" && type.IndexOf(typeGml) == -1)
                risultato = false;
            return risultato;
        }

        public static bool AppOpenXml(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String type = navigator.GetAttribute("type", "");
            if (type != "application/opensearchdescription+xml")
                risultato = false;
            return risultato;
        }

        public static bool OpenTemplate(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String template = navigator.GetAttribute("template", "");
            string template_code = "spatial_dataset_identifier_code=";
            string template_namespace = "spatial_dataset_identifier_namespace=";
            string template_language = "language=";
            if (template.IndexOf(template_code) == -1 && template.IndexOf(template_namespace) == -1 && template.IndexOf(template_language) == -1)
                risultato = false;
            return risultato;
        }

        public static bool OpenTemplateCrs(XPathNavigator navigator)
        {
            bool risultato = true;
            navigator.MoveToNextAttribute();
            String template = navigator.GetAttribute("template", "");
            string template_code = "spatial_dataset_identifier_code=";
            string template_namespace = "spatial_dataset_identifier_namespace=";
            string template_language = "language=";
            string template_crs = "crs";
            if (template.IndexOf(template_code) == -1 && template.IndexOf(template_namespace) == -1 && template.IndexOf(template_language) == -1 && template.IndexOf(template_crs) == -1)
                risultato = false;
            return risultato;
        }
    }
    }

