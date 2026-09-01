using System;
using System.Xml;
using System.Xml.Schema;
using System.Text;
using System.Collections.Generic;

namespace sesDocElectronicos
{
        public class AdcValxml
        {
            //string pathFile = "";
            System.IO.StreamWriter file ;
            Boolean fileErrorabierto = false;
            string pathError = "";

          
            public Boolean Main(string pathfile = "", string pathSchema = "")
            {
                XmlReaderSettings booksSettings = new XmlReaderSettings();
                booksSettings.Schemas.Add(pathfile , pathSchema );
                booksSettings.ValidationType = ValidationType.Schema;
                booksSettings.ValidationEventHandler += new ValidationEventHandler(booksSettingsValidationEventHandler);

                XmlReader fileSri = XmlReader.Create(pathfile, booksSettings);

                while (fileSri.Read()) { }
                return fileErrorabierto;
            }

            private void booksSettingsValidationEventHandler(object sender, ValidationEventArgs e)
            {
                string severidad = "";
                if (e.Severity == XmlSeverityType.Warning) { severidad = "WARNING: "; } else {severidad = "ERROR"; }
               
                if (fileErrorabierto == false) { file = new System.IO.StreamWriter(pathError); fileErrorabierto = true; }
                file.WriteLine(severidad  + " -- " + e.Message);
            }


        }
    }

    

