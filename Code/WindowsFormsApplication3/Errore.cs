using NLog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace WindowsFormsApplication3
{
    class Errore
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static int ultimo_errore = 0;
        public const int LIV_BASSO = 1;
        public const int LIV_MEDIO = 2;
        public const int LIV_ALTO = 3;
        public const int NO_ERR = 0;
        public const int ERR_NODO_OBBLIGATORIO = -1;
        public const int ERR_NODO_VUOTO = -2;
        public const int ERR_NODO_TYPE = -3;
        public const int ERR_NO_LINK = -4;
        public const int ERR_NO_FILE = -5;
        public const int ERR_NODO_UNICO = -6; 
        public const int ERR_NODO_DATA_ORA = -8;
        public const int ERR_NODO_HREFLANG = -7;
        public const int ERR_LINK_SELF = -9;
        public const int ERR_NODO_EMAIL = -10;
        public const int ERR_NODO_GEORSS= -11;
        public const int ERR_NO_LINK_SELF_DOWNLOAD = -12;
        public const int ERR_NO_MULTIPLO = -13;
        public const int ERR_NO_CONTENT_ALT = -14;
        public const int ERR_NO_TEMPLATE = -15;
        public const int ERR_NO_LANGUAGE = -16;

        public const string NO_ERR_STRING = "Nessun errore";
        public const string ERR_NODO_OBBLIGATORIO_STRING = "Il nodo non è presente";
        public const string ERR_NODO_VUOTO_STRING = "Il nodo è vuoto";
        public const string ERR_NODO_TYPE_STRING = "Il nodo ha l'attributo type non presente o non corretto";
        public const string ERR_NO_LINK_STRING = "Il link non esiste";
        public const string ERR_NO_FILE_STRING = "Il file non esiste";
        public const string ERR_NODO_UNICO_STRING = "Il nodo non è unico";
        public const string ERR_NODO_DATA_ORA_STRING = "Il nodo non contiene data e ora corretti";
        public const string ERR_NODO_HREFLANG_STRING = "Il nodo ha l'attributo hreflang non presente o non corretto";
        public const string ERR_LINK_SELF_STRING = "Il link non è uguale all'href del nodo /feed/link[@rel='self']";
        public const string ERR_NODO_EMAIL_STRING = "Email non valida";
        public const string ERR_NODO_GEORSS_STRING = "Devono essere presenti almeno quattro punti, di cui il primo e l'ultimo devono essere uguali";
        public const string ERR_NO_LINK_SELF_DOWNLOAD_STRING = "Il link non è uguale all'href del nodo /feed/link[@rel='self'] del file Download Service Feed";
        public const string ERR_NO_MULTIPLO_STRING = "Il link non è multiplo";
        public const string ERR_NO_CONTENT_ALT_STRING = "Il nodo entry deve avere un nodo link con rel=’alternate’ oppure deve essere presente il nodo content";
        public const string ERR_NO_TEMPLATE_STRING = "Il nodo non ha l'attributo template corretto";
        public const string ERR_NO_LANGUAGE_STRING = "Non è presente la lingua di default";

        public static string DecodificaErrore(int err)
        {
            Console.WriteLine("dentro errore");
        string value = "";
        System.Collections.Generic.Dictionary<int, string> errore = new Dictionary<int, string>();
        errore.Add(ERR_NODO_OBBLIGATORIO, ERR_NODO_OBBLIGATORIO_STRING);
        errore.Add(ERR_NODO_VUOTO,ERR_NODO_VUOTO_STRING );
        errore.Add(ERR_NODO_TYPE, ERR_NODO_TYPE_STRING);
        errore.Add(ERR_NO_LINK, ERR_NO_LINK_STRING);
        errore.Add(ERR_NO_FILE, ERR_NO_FILE_STRING);
        errore.Add(ERR_NODO_UNICO,ERR_NODO_UNICO_STRING );
        errore.Add(ERR_NODO_DATA_ORA,ERR_NODO_DATA_ORA_STRING );
        errore.Add(ERR_NODO_HREFLANG,ERR_NODO_HREFLANG_STRING );
        errore.Add(ERR_LINK_SELF, ERR_LINK_SELF_STRING);
        errore.Add(ERR_NODO_EMAIL, ERR_NODO_EMAIL_STRING);
        errore.Add(ERR_NODO_GEORSS, ERR_NODO_GEORSS_STRING);
        errore.Add(ERR_NO_LINK_SELF_DOWNLOAD, ERR_NO_LINK_SELF_DOWNLOAD_STRING);
        errore.Add(NO_ERR,NO_ERR_STRING);
        errore.Add(ERR_NO_MULTIPLO, ERR_NO_MULTIPLO_STRING);
        errore.Add(ERR_NO_CONTENT_ALT, ERR_NO_CONTENT_ALT_STRING);
        errore.Add(ERR_NO_TEMPLATE,ERR_NO_TEMPLATE_STRING);
        errore.Add(ERR_NO_LANGUAGE, ERR_NO_LANGUAGE_STRING);
        errore.TryGetValue(err, out value);
        return value;
      }

         
        public static void setUltimoErrore(int errore)
        {
            ultimo_errore = errore;
            
        }

        public int getUltimoErrore()
        {
            return ultimo_errore;
        }

        public static void clearUltimoErrore ()
        {
            ultimo_errore = NO_ERR;
        }

public static void scritturaLog(string nodo, int errore, int livello)
        {
            Errore.setUltimoErrore(errore);
            logger.Error("Errore relativo al nodo: " + nodo);
            logger.Error("Tipo di Errore: " + Errore.DecodificaErrore(errore));
            logger.Error("Livello di errore: " + livello);
        }


    }
    }


