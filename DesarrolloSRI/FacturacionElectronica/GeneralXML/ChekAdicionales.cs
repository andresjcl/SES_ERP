using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using DattCom;

namespace DaxDocElectronicos
{
    class ChekAdicionales
    {
        internal static void registrarfuncionalidadEmisor(XmlTextWriter docXml)
        {
            try
            {
                //if ( classDatEmp.NroAgenteRetencion.Length > 0)
                //    docXml.WriteElementString("agenteRetencion", classDatEmp.NroAgenteRetencion);
                if (datosEmpresa.Emp_AgeRet.Length > 0)
                    docXml.WriteElementString("agenteRetencion", datosEmpresa.Emp_AgeRet);

            }
            catch
            {
            }
            try
            {
                //if (!(classDatEmp.esRIMPE == "SI"))
                //    return;
                //docXml.WriteElementString("contribuyenteRimpe", "CONTRIBUYENTE RÉGIMEN RIMPE");
                if (datosEmpresa.Emp_Regimen.ToUpper() == "Régimen Simplificado Para Negocios Populares" || datosEmpresa.Emp_Regimen.ToUpper() == "Régimen Simplificado Para Emprendedores")
                    return;
                docXml.WriteElementString("contribuyenteRimpe", "CONTRIBUYENTE RÉGIMEN RIMPE");
            }
            catch
            {
            }
        }

        internal static void registrarAdicionales(DataRow doc, XmlTextWriter docXml, bool esExportacion)
        {
            if (ChekAdicionales.tieneAdicionales(doc) <= 0 && !esExportacion)
                return;
            docXml.WriteStartElement("infoAdicional");
            try
            {
                if (doc["ExportadorHabitualDeBienes"].ToString().Length > 0)
                {
                    docXml.WriteStartElement("campoAdicional");
                    docXml.WriteAttributeString("nombre", "ExportadorHabitualDeBienes");
                    docXml.WriteString("Exportador Habitual de Bienes");
                    docXml.WriteEndElement();
                }
            }
            catch
            {
            }
            try
            {
                if (doc["Doc_Detalle"].ToString().Length > 0)
                {
                    docXml.WriteStartElement("campoAdicional");
                    docXml.WriteAttributeString("nombre", "Detalle");
                    docXml.WriteString(doc["Doc_Detalle"].ToString());
                    docXml.WriteEndElement();
                }
            }
            catch
            {
            }
            //try
            //{
            //    if (datosEmpresa.Emp_AgeRet.Length > 0)
            //    {
            //        docXml.WriteStartElement("campoAdicional");
            //        docXml.WriteAttributeString("nombre", "Agente");
            //        docXml.WriteString("Agente de Retención NAC-DNCRASC20-00000001");
            //        docXml.WriteEndElement();
            //    }
            //    //if (classDatEmp.NroAgenteRetencion.Length > 0)
            //    //{
            //    //    docXml.WriteStartElement("campoAdicional");
            //    //    docXml.WriteAttributeString("nombre", "Agente");
            //    //    docXml.WriteString("Agente de Retención NAC-DNCRASC20-00000001");
            //    //    docXml.WriteEndElement();
            //    //}
            //}
            //catch
            //{
            //}
            //try
            //{
            //    if (doc["Doc_NumSop"].ToString().Length > 0)
            //    {
            //        docXml.WriteStartElement("campoAdicional");
            //        docXml.WriteAttributeString("nombre", "pedido");
            //        docXml.WriteString(doc["Doc_NumSop"].ToString());
            //        docXml.WriteEndElement();
            //    }
            //}
            //catch
            //{
            //}
            //try
            //{
            //    if (doc["Doc_NroLoteDoc"].ToString().Length > 0)
            //    {
            //        docXml.WriteStartElement("campoAdicional");
            //        docXml.WriteAttributeString("nombre", "ORDEN COMPRA");
            //        docXml.WriteString(doc["Doc_NroLoteDoc"].ToString());
            //        docXml.WriteEndElement();
            //    }
            //}
            //catch
            //{
            //}
            //try
            //{
            //    if (doc["PreEntrada"].ToString().Length > 0)
            //    {
            //        docXml.WriteStartElement("campoAdicional");
            //        docXml.WriteAttributeString("nombre", "PreEntrada");
            //        docXml.WriteString(doc["PreEntrada"].ToString());
            //        docXml.WriteEndElement();
            //    }
            //}
            //catch
            //{
            //}
            if (esExportacion)
            {
                try
                {
                    if (doc["ConsignarA"].ToString().Length > 0)
                    {
                        docXml.WriteStartElement("campoAdicional");
                        docXml.WriteAttributeString("nombre", "ConsignarA");
                        docXml.WriteString(doc["ConsignarA"].ToString());
                        docXml.WriteEndElement();
                    }
                    if (doc["Transporte"].ToString().Length > 0)
                    {
                        docXml.WriteStartElement("campoAdicional");
                        docXml.WriteAttributeString("nombre", "Transportista");
                        docXml.WriteString(doc["Transporte"].ToString());
                        docXml.WriteEndElement();
                    }
                    if (doc["EndosarA"].ToString().Length > 0)
                    {
                        docXml.WriteStartElement("campoAdicional");
                        docXml.WriteAttributeString("nombre", "EndosarA");
                        docXml.WriteString(doc["EndosarA"].ToString());
                        docXml.WriteEndElement();
                    }
                    if (doc["CondicionesVenta"].ToString().Length > 0)
                    {
                        docXml.WriteStartElement("campoAdicional");
                        docXml.WriteAttributeString("nombre", "CondicionesVta");
                        docXml.WriteString(doc["CondicionesVenta"].ToString());
                        docXml.WriteEndElement();
                    }
                }
                catch
                {
                }
            }
            docXml.WriteEndElement();
        }

        internal static int tieneAdicionales(DataRow dt)
        {
            int num = 0;
            try
            {
                if (Convert.ToBoolean(dt["RegimenMicroempresas"]))
                    return 1;
            }
            catch
            {
            }
            try
            {
                if (dt["Regimen"].ToString().Length > 0 || dt["ConsignarA"].ToString().Length > 0 || dt["Transporte"].ToString().Length > 0 || dt["endosarA"].ToString().Length > 0 || dt["CondicionesVenta"].ToString().Length > 0)
                    return 1;
            }
            catch
            {
            }
            try
            {
                if (dt["PreEntrada"].ToString().Length > 0 || dt["ConsignarA"].ToString().Length > 0 || dt["Transporte"].ToString().Length > 0 || dt["endosarA"].ToString().Length > 0 || dt["CondicionesVenta"].ToString().Length > 0)
                    return 1;
            }
            catch
            {
            }
            try
            {
                if (dt["ExportadorHabitualDeBienes"].ToString().Length > 0)
                    return 9;
            }
            catch
            {
            }
            try
            {
                if (dt["Doc_NumSop"].ToString().Length > 0)
                    return 8;
            }
            catch
            {
            }
            try
            {
                if (dt["Doc_Detalle"].ToString().Length > 0)
                    return 1;
            }
            catch
            {
            }
            return num;
        }

        internal static bool tieneExportacion(DataRow dt)
        {
            bool flag = false;
            try
            {
                if (dt["TerminosVent"].ToString().Length > 0 || dt["OrigProducto"].ToString().Length > 0 || dt["paisDestino"].ToString().Length > 0)
                    return true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

    }
}
