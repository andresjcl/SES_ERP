using System;
using System.Xml;
using System.Xml.Schema;
using System.Text;
using System.Collections.Generic;

namespace DaxDocElectronicos
    {
        public class AdcValxml
        {
            //string pathFile = "";
            System.IO.StreamWriter file ;
            Boolean fileErrorabierto = false;
            string pathError = "";

            //public Boolean Main(string pathfile = "", string pathSchema= "")
            //{
            //    pathError = pathfile.Replace("XML", "err");

            //    // pathFile = pathfile;
                
            //    XmlTextReader tr = new XmlTextReader(pathfile);
            //    XmlValidatingReader vr = new XmlValidatingReader(tr);
                

            //    vr.Schemas.Add("", pathSchema );
            //    vr.ValidationType = ValidationType.Schema;
            //    vr.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);

            //    while (vr.Read()) ;
            //    //Console.WriteLine("Validation finished");

            //        tr.Close();
            //        vr.Close();
            //        if (fileErrorabierto == true)
            //        {
            //            file.Flush();
            //            file.Close();
            //            file.Dispose();
            //        }
            //        return fileErrorabierto;
            //}

            //public void ValidationHandler(object sender, ValidationEventArgs args)
            //{
                
            //    if (fileErrorabierto == false) {file = new System.IO.StreamWriter(pathError); fileErrorabierto = true;} 
            //    file.WriteLine("excepcíon : "+ args.Severity + " -- " + args.Message);
            //}

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
                //if (e.Severity == XmlSeverityType.Warning)
                //{
                //    Console.Write("WARNING: ");
                //    Console.WriteLine(e.Message);
                //}
                //else if (e.Severity == XmlSeverityType.Error)
                //{
                //    Console.Write("ERROR: ");
                //    Console.WriteLine(e.Message);
                //}
                if (fileErrorabierto == false) { file = new System.IO.StreamWriter(pathError); fileErrorabierto = true; }
                file.WriteLine(severidad  + " -- " + e.Message);
            }


        }
    }

    

