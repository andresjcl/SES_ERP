using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DattCom;
using System.Windows.Forms;
namespace IvaRett
{
    public class NomTipoRetencion
    {
        public const string IvaBienes = "IvaBienes";
        public const string IvaServicios = "IvaServicios";
        public const string RetFuente = "RetFuente";
    }
    public class nombreTablas
    {
        public const string CodigosDistritoAduanero = "CodigosDistritoAduanero";
        public const string CodigosRegimen = "CodigosRegimen";
        public const string ComprobantesAutorizados = "ComprobantesAutorizados";
        public const string ConceptosRetencion = "ConceptosRetencion";
        public const string FormasDePago = "FormasDePago";
        public const string IdentificacionProveedor = "IdentificacionProveedor";
        public const string Paises = "Paises";
        public const string PorcentajeIva = "PorcentajeIva";
        public const string PorcentajeIce = "PorcentajeIce";
        public const string RetencionIvaBienes = "RetencionIvaBienes";
        public const string RetencionIvaServicios = "RetencionIvaServicios";
        public const string SustentoComprobante = "SustentoComprobante";
        public const string TarjetasCredito = "TarjetasCredito";
        public const string TipoDeIdentificacion = "TipoIdentificacion";
        public const string TipoExportacion = "TipoExportacion";
        public const string TiposFideicomisos = "TiposFideicomisos";
        public const string TiposPago = "TiposPago";
        // Public TiposTransacciones As const string = "TiposTransacciones    "
        public const string RefTiposIdentificacion = "RefTiposIdentificacion";
        public const string RefTiposTransacciones = "RefTiposTransacciones";
        public const string ImpRentaPersonasNaturales = "ImpRentaPersonasNaturales";
        public double PorcentajeIvaBienes(string codigo, DateTime AFecha)
        {
            double valor = 0;
            if (codigo.Length == 0) return 0;
            if (AFecha == null) AFecha = DateTime.Now;
            string ssql = "select  cast(Descripción as numeric(10,2)  as valor,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
            ssql += " from RetencionIvaBienes";
            ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + AFecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + AFecha.ToShortDateString() + "'";
            ssql += " and Código = '" + codigo + "'";
            SqlDataReader dr = SqlDatos.leerBaseIvaret(ssql);
            if (dr.Read())
            {
                valor = Convert.ToDouble(dr["valor"]);
            }
            else
            {
                mensajeError(codigo);
            }
            return valor;
        }
        public double PorcentajeIvaServicios(string codigo, DateTime AFecha)
        {
            double valor = 0;
            if (codigo.Length == 0) return 0;
            if (AFecha == null) AFecha = DateTime.Now;
            string ssql = "select  cast(Descripción as numeric(10,2)  as valor,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
            ssql += " from RetencionIvaServicios";
            ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + AFecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + AFecha.ToShortDateString() + "'";
            ssql += " and Código = '" + codigo + "'";
            SqlDataReader dr = SqlDatos.leerBaseIvaret(ssql);
            if (dr.Read())
            {
                valor = Convert.ToDouble(dr["valor"]);
            }
            else
            {
                mensajeError(codigo);
            }
            return valor;
        }
        public double PorcentajeRetencionFuente(string codigo, DateTime AFecha)
        {
            double valor = 0;
            if (codigo.Length == 0) return 0;
            if (AFecha == null) AFecha = DateTime.Now;
            string ssql = "select  isnull(porcentaje,0)  as valor,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
            ssql += " from ConceptosRetencion";
            ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + AFecha.ToShortDateString() + "' and isnull(FechaFin,'31/12/2999') >= '" + AFecha.ToShortDateString() + "'";
            ssql += " and Código = '" + codigo + "'";
            SqlDataReader dr = SqlDatos.leerBaseIvaret(ssql);
            if (dr.Read())
            {
                valor = Convert.ToDouble(dr["valor"]);
            }
            else
            {
                mensajeError(codigo);
            }
            return valor;
        }
        private void mensajeError(string codigo)
        {
            MessageBox.Show("El código digitado   [" + codigo + "]  no existe o no es válido a la ", "Valida codigo retención ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string armarConsulta(string tipo, string Fecha, Int16 tipoTransaccion, Int16 sustento, Int16 tipComprobante)
        {
            string ssql = "";
            switch (tipo)
            {
                case CodigosDistritoAduanero:
                    {
                        ssql = "select * from CodigosDistritoAduanero";
                        break;
                    }

                case CodigosRegimen:
                    {
                        ssql = "select Código,Descripción,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from CodigosRegimen";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >='" + Fecha + "'";
                        break;
                    }

                case ComprobantesAutorizados:
                    {
                        ssql = "select Código,Descripción,isnull(FechaFin,'31/12/2999') as FechaFin,*";
                        ssql += " from ComprobantesAutorizados";
                        ssql += " where  isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        if (tipoTransaccion > 0)
                            ssql += " and patindex('%" + tipoTransaccion.ToString() + "%',SecuencialTransaccion) > 0 ";
                        if (sustento > 0)
                            ssql += " and patindex('%" + sustento.ToString() + "%',SustentoTributario) > 0 ";
                        break;
                    }

                case ConceptosRetencion:
                    {
                        ssql = "select Código,Descripción";
                        ssql += " ,case when isnull(porcentaje,'-') = '-' then '0' else porcentaje end as porcentaje";
                        ssql += " ,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from ConceptosRetencion";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        break;
                    }

                case FormasDePago:
                    {
                        ssql = "select Código,Descripción from FormasDePago";
                        break;
                    }

                case IdentificacionProveedor:
                    {
                        ssql = "select Código,Descripción from IdentificacionProveedor";
                        break;
                    }

                case Paises:
                    {
                        ssql = "select Código,Descripción from Paises";
                        break;
                    }

                case PorcentajeIva:
                    {
                        ssql = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from PorcentajeIva";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        break;
                    }

                case PorcentajeIce:
                    {
                        ssql = "select Porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from PorcentajeIce";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        break;
                    }

                case RetencionIvaBienes:
                    {
                        ssql = "select Código,Código + ' - ' + cast(Descripción as varchar(10)) + '%' as Descripción,cast(isnull(Descripción,'0') as numeric(10,2))  as porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from RetencionIvaBienes";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        break;
                    }

                case RetencionIvaServicios:
                    {
                        ssql = "select Código,Código + ' - ' + cast(Descripción as varchar(10)) + '%' as Descripción, cast(isnull(Descripción,'0') as numeric(10,2))  as porcentaje,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from RetencionIvaServicios";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        break;
                    }

                case SustentoComprobante:
                    {
                        ssql = "select Código,Descripción,tipoComprobante,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin";
                        ssql += " from SustentoComprobante";
                        ssql += " where isnull(FechaInicio,'01/01/1900') <= '" + Fecha + "' and isnull(FechaFin,'31/12/2999') >= '" + Fecha + "'";
                        if (tipComprobante > 0)
                            ssql += " and patindex('%" + tipComprobante.ToString() + "%',tipoComprobante) > 0 ";
                        break;
                    }

                case TarjetasCredito:
                    {
                        break;
                    }

                case TipoDeIdentificacion:
                    {
                        ssql = "select Código,Descripción,TipoTransaccion from TipoDeIdentificacion ";
                        if (tipoTransaccion > 0)
                            ssql += " and patindex('%" + tipoTransaccion.ToString() + "%',SecuencialTransaccion) > 0 ";
                        break;
                    }

                case TipoExportacion:
                    {
                        ssql = "select Código,Descripción from TipoExportacion ";
                        break;
                    }

                case TiposFideicomisos:
                    {
                        ssql = "select Código,Descripción from TipoFidecomisos ";
                        break;
                    }

                case TiposPago:
                    {
                        ssql = "select Código,Descripción from TiposPago";
                        break;
                    }

                case ImpRentaPersonasNaturales:
                    {
                        ssql = "select *from ImpRentaPersonasNaturales";
                        break;
                    }
            }
            return ssql;
        }

        public string[] listaTablas()
        {
            string resp = CodigosDistritoAduanero + ";" + CodigosRegimen + ";" + ComprobantesAutorizados + ";" + ConceptosRetencion + ";" + FormasDePago + ";" + IdentificacionProveedor + ";" + Paises + ";" + PorcentajeIva + ";" + PorcentajeIce + ";" + RetencionIvaBienes + ";" + RetencionIvaServicios + ";" + SustentoComprobante + ";" + TarjetasCredito + ";" + TipoDeIdentificacion + ";" + TipoExportacion + ";" + TiposFideicomisos + ";" + TiposPago + ";" + RefTiposIdentificacion + ";" + RefTiposTransacciones + ";" + ImpRentaPersonasNaturales;
            return resp.Split(Convert.ToChar( ";"));
        }
    }


}

