using System;
using System.Collections.Generic;
using System.Xml ;
using System.Xml.Schema ;
using System.Threading.Tasks;

namespace atsgenxml
{
    public class atsValXml
    {
        //Boolean esValido = true;
        //System.IO.StreamWriter file;
        //Boolean fileErrorabierto = false;
        //string pathError = "";
        string errores = "";
        public string Main(string pathfile = "", string pathSchema = "")
        {
            XmlReaderSettings booksSettings = new XmlReaderSettings();
            booksSettings.Schemas.Add(pathfile, pathSchema);
            booksSettings.ValidationType = ValidationType.Schema;
            booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

            XmlReader fileSri = XmlReader.Create(pathfile, booksSettings);

           // while (fileSri.Read()) { }
            return errores ;
        }

        private void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            string severidad = "";
            if (e.Severity == XmlSeverityType.Warning) { severidad = "PELIGRO: "; } else { severidad = "ERROR"; }
            //if (fileErrorabierto == false) { file = new System.IO.StreamWriter(pathError); fileErrorabierto = true; }
            errores = severidad + " -- " + e.Message + "\n";
        }
     }
}


    
