using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace DctosEmi
{
    public class BusquedasDetalleDocumentos
    {
        public static void BuscarValor(DataGridViewCell cell,string nombreCol)
        {
            if (cell.ValueType.Name.ToUpper() == "DATETIME")
            {
                DaxFechas.DaxFechas fecha = new DaxFechas.DaxFechas();
                cell.Value = fecha.DaxFecha(docUtils.DaxNow().ToShortDateString());
                fecha = null;
                return;
            } 
            string comando = "";
            string titulo = "Bodega destino";

            switch (nombreCol.ToUpper())
            {
                case "DOC_BODEGA":
                    comando = "select Bod_codigo as Codigo,Bod_nombre as Descripcion from Daxsys.dbo.Emp_Bod where emp_codigo = " + datosEmpresa.codEmpresa;
                    break;
                case "TRA_EMPLEADO":
                    comando = "select  Codigo,NombreImpresion as Descripcion from Identificacion  where EsEmpleado = 1";
                    titulo = "Empleados";
                    break;
                case "TRA_COSTO":
                    comando = "select Abreviación as Codigo,Descripcion from Syscod where TipoReferencia = 'centro costo' and Abreviación <> '#'";
                    titulo = "Centros de costo";
                    break;
                case "TRA_CENTROPRODUCCION":
                    comando = "select  Abreviación as Codigo,Descripcion from Syscod where TipoReferencia = 'Centro Producción' and Abreviación <> '#'";
                    titulo = "Centro de producción";
                    break;
                case "TRA_CENTRODISTRIBUCION":
                    comando = "select  Abreviación as Codigo,Descripcion from Syscod where TipoReferencia = 'Centro Distribución' and Abreviación <> '#'";
                    titulo = "Centro de distribución";
                    break;
                case "TRA_PROYECTO":
                    comando = "select  Abreviación as Codigo,Descripcion from Syscod where TipoReferencia = 'Proyecto' and Abreviación <> '#'";
                    titulo = "Proyectos";
                    break;        
            }
            Buscar.frmBuscar busca = new Buscar.frmBuscar();
            cell.Value = busca.Buscar(datosEmpresa.strConxAdcom, comando, "Codigo", "Descripcion", "", titulo);
            busca.Dispose();
        }
    }
}
