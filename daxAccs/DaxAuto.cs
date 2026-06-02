using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace daxAccs
{
    public class propiedadesDaxAuto
    {
        Int32 empresa = 0;
        string usuario = "";
        string strIniSiss = "";
        string cmbDocumento = "";
        string strIniSis = "";
        public Int32 nroElementos = 21;
        public Int32 InicioElementosMalla = 9;
        public string[] ELEMENTOS = new string [21];

        public Boolean sinRegistro = true;
        public Boolean Crear = false;
        public Boolean Modificar = false;
        public Boolean Anular = false;
        public Boolean Eliminar = false;
        public Boolean Consultar = false;
        public Boolean Ingresos = false;
        public Boolean Gastos = false;
        public Boolean CierreCaja = false;
        public Boolean EntregaExpress = false; 
        public Boolean Imprimir = false;        
        public int NroImpresiones = 0;
        public Boolean NúmeroDocumento = false;
        public Boolean FechaDocumento = false;
        public Boolean Bodega = false;
        public string BodegaFija = "";
        public Boolean Vendedor = false;
        public string VendedorFijo = "";
        public Boolean DetalleProducto = false;
        public Boolean PrecioUnitario = false;
        public String PrecioUnitarioFijo = "";
        public Boolean DescuentoUnitario = false;
        public decimal  DescuentoUnitarioPorcMinimo = 0;
        public decimal DescuentoUnitarioPorcMaximo = 0;
        public decimal DescuentoUnitarioPorcFijo = 0;
        public Boolean DescuentoDocumento = false;
        public decimal DescuentoDocumentoPorcMinimo = 0;
        public decimal DescuentoDocumentoPorcMaximo = 0;
        public decimal DescuentoDocumentoPorcFijo = 0;
        public Boolean Impuestos = false;
        public Boolean FormaDePago = false;
        public String FormaDePagoFijo = "";
        public Boolean Contabilidad = false;

        public void cargarAccesoDoc(string Documento)        
        {
            SqlConnection conn = new SqlConnection(strIniSiss);
            SqlDataReader data;
            conn.Open();
            //ClassDxSys.sysdocaccs data = new ClassDxSys.sysdocaccs(strIniSis);
            sinRegistro = true;
            cmbDocumento = Documento;
            registraValoresDefault();

			if (usuario.ToUpper()=="ADMINISTRADOR")
			{
                registraValoresDefaultAdmin();
            }
			else
			{
                string ssql = "select * from sysdocaccs where empresa = " + empresa + " AND idusuario = '" + usuario + "' AND OPC_DOCUMENTO ='" + cmbDocumento + "' ";
                SqlCommand comm = new SqlCommand(ssql, conn);
                data = comm.ExecuteReader();
                while (data.Read())
                {
                    sinRegistro = false;
                    if (data["opcion"].ToString() == "Crear") Crear = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Modificar") Modificar = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Anular") Anular = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Eliminar") Eliminar = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Consultar") Consultar = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Ingresos") Ingresos = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "Gastos") Gastos = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "CierreCaja") CierreCaja = Convert.ToBoolean(data["Abierto"]);
                    if (data["opcion"].ToString() == "EntregaExpress") EntregaExpress = Convert.ToBoolean(data["Abierto"]);

                    if (data["opcion"].ToString() == "Imprimir")
                    {
                        Imprimir = Convert.ToBoolean(data["Abierto"]);
                        NroImpresiones = Convert.ToInt32(data["Maximo"]);
                    }

                    if (data["opcion"].ToString() == "NúmeroDocumento")
                    {
                        NúmeroDocumento = Convert.ToBoolean(data["Abierto"]);
                    }
                    if (data["opcion"].ToString() == "FechaDocumento")
                    {
                        FechaDocumento = Convert.ToBoolean(data["Abierto"]);
                    }
                    if (data["opcion"].ToString() == "Bodega")
                    {
                        Bodega = Convert.ToBoolean(data["Abierto"]);
                        BodegaFija = ("" + data["ValorFijo"].ToString().Trim());
                    }
                    if (data["opcion"].ToString() == "Vendedor")
                    {
                        Vendedor = Convert.ToBoolean(data["Abierto"]);
                        VendedorFijo = ("" + data["ValorFijo"].ToString().Trim());
                    }
                    if (data["opcion"].ToString() == "DetalleProducto")
                    {
                        DetalleProducto = Convert.ToBoolean(data["Abierto"]);
                    }
                    if (data["opcion"].ToString() == "PrecioUnitario")
                    {
                        PrecioUnitario = Convert.ToBoolean(data["Abierto"]);
                    }
                    if (data["opcion"].ToString() == "DescuentoUnitario")
                    {
                        DescuentoUnitario = Convert.ToBoolean(data["Abierto"]);
                        try
                        {
                            DescuentoUnitarioPorcFijo = Convert.ToDecimal("0" + ("" + data["ValorFijo"].ToString().Trim()));
                        }
                        catch { DescuentoUnitarioPorcFijo = 0; }
                        DescuentoUnitarioPorcMinimo = Convert.ToDecimal("0" + ("" + data["Minimo"].ToString().Trim()));
                        DescuentoUnitarioPorcMaximo = Convert.ToDecimal("0" + ("" + data["Maximo"].ToString().Trim()));
                    }
                    if (data["opcion"].ToString() == "DescuentoDocumento")
                    {
                        DescuentoDocumento = Convert.ToBoolean(data["Abierto"]);
                        try
                        {
                            DescuentoDocumentoPorcFijo = Convert.ToDecimal("0" + ("" + data["ValorFijo"].ToString().Trim()));
                        }
                        catch { DescuentoDocumentoPorcFijo = 0; }
                        DescuentoDocumentoPorcMinimo = Convert.ToDecimal("0" + ("" + data["Minimo"].ToString().Trim()));
                        DescuentoDocumentoPorcMaximo = Convert.ToDecimal("0" + ("" + data["Maximo"].ToString().Trim()));
                    }
                    if (data["opcion"].ToString() == "Impuestos")
                    {
                        Impuestos = Convert.ToBoolean(data["Abierto"]);
                    }
                    if (data["opcion"].ToString() == "FormaDePago")
                    {
                        FormaDePago = Convert.ToBoolean(data["Abierto"]);
                        FormaDePagoFijo = ("" + data["ValorFijo"].ToString().Trim());
                    }
                    if (data["opcion"].ToString() == "Contabilidad")
                    {
                        Contabilidad = Convert.ToBoolean(data["Abierto"]);
                    }

                }
                data.Close();

            }
                     
        }
        public propiedadesDaxAuto()
        { }

        public void iniciar(Int32  Empresa, string Usuario, string strIniSis)
        {
            empresa = Empresa;
            usuario = Usuario;
            strIniSiss = strIniSis;

            ELEMENTOS[0] = "Crear";
            ELEMENTOS[1] = "Modificar";
            ELEMENTOS[2] = "Anular";
            ELEMENTOS[3] = "Eliminar";
            ELEMENTOS[4] = "Consultar";
            ELEMENTOS[5] = "Ingresos";
            ELEMENTOS[6] = "Gastos";
            ELEMENTOS[7] = "CierreCaja";
            ELEMENTOS[8] = "EntregaExpress";

            ELEMENTOS[9] = "Imprimir";
            ELEMENTOS[10] = "NúmeroDocumento";
            ELEMENTOS[11] = "FechaDocumento";
            ELEMENTOS[12] = "Bodega";
            ELEMENTOS[13] = "Vendedor";
            ELEMENTOS[14] = "DetalleProducto";
            ELEMENTOS[15] = "PrecioUnitario";
            ELEMENTOS[16] = "DescuentoUnitario";
            ELEMENTOS[17] = "DescuentoDocumento";
            ELEMENTOS[18] = "Impuestos";
            ELEMENTOS[19] = "FormaDePago";
            ELEMENTOS[20] = "Contabilidad";
            revisionInicial();
        }
        private void revisionInicial()
        {
            string sSql = "";

            sSql = "IF  NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sysdocaccs]') AND type in (N'U'))";
            sSql += " BEGIN";
            /****** Object:  Table [dbo].[sysdocaccs]    Script Date: 04/10/2014 10:23:14 ******/
            sSql += " CREATE TABLE [dbo].[sysdocaccs](";
            sSql += " [empresa] [int] NOT NULL,";
            sSql += " [idUsuario] [varchar](15) NOT NULL,";
            sSql += " [opc_documento] [varchar](3) NOT NULL,";
            sSql += " [opcion] [varchar](50) NOT NULL,";
            sSql += " [Abierto] [bit] NULL,";
            sSql += " [Cantidad] [int] NULL,";
            sSql += " [Minimo] [numeric](18, 2) NULL,";
            sSql += " [Maximo] [numeric](18, 2) NULL,";
            sSql += " [ValorFijo] [varchar](50) NULL,";
            sSql += " [AuxVal1] [numeric](18, 2) NULL,";
            sSql += " [AuxVal2] [numeric](18, 2) NULL,";
            sSql += " [AuxStr1] [varchar](100) NULL,";
            sSql += " [AuxStr2] [varchar](100) NULL,";
            sSql += " CONSTRAINT [PK_sys_docaccs] PRIMARY KEY CLUSTERED ";
            sSql += " (";
            sSql += " [empresa] ASC,";
            sSql += " [idUsuario] ASC,";
            sSql += " [opc_documento] ASC,";
            sSql += " [opcion] ASC";
            sSql += " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]";
            sSql += " ) ON [PRIMARY]";
            sSql += " end ";
            ejecutarComando(sSql);
        }
        private void ejecutarComando(string comandoSQL)
        {
            try
            {               
                SqlConnection conn = new SqlConnection(strIniSiss);
                conn.Open();
                SqlCommand comm = new SqlCommand(comandoSQL, conn);
                comm.ExecuteNonQuery();
                conn.Dispose();
                comm.Dispose();
            }
            catch 
//                (Exception ee)
            {
  //              MessageBox.Show("No se pudo procesar el comando " + comandoSQL + "\n" + ee.Message);
            }
        }

        public static string TipoDocumento(string strConx,string opcDoc)
        {
            string resp = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(strConx))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand("select opc_tipo from adcopc where Opc_documento = '"+opcDoc+"'", conn);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read()) resp = dr["opc_tipo"].ToString();
                    comm.Dispose();
                }
            }
            catch { }
            return resp;
        }

        private void registraValoresDefault()
        { 
            Crear = false;
            Modificar = false;
            Anular = false;
            Eliminar = false;
            Consultar = false;
            Ingresos = false;
            Gastos = false;
            CierreCaja = false;
            EntregaExpress = false;
            Imprimir = false;        
            NroImpresiones = 0;
            NúmeroDocumento = false;
            FechaDocumento = false;
            Bodega = false;
            BodegaFija = "";
            Vendedor = false;
            VendedorFijo = "";
            DetalleProducto = false;
            PrecioUnitario = false;
            PrecioUnitarioFijo = "";
            DescuentoUnitario = false;
            DescuentoUnitarioPorcMinimo = 0;
            DescuentoUnitarioPorcMaximo = 0;
            DescuentoUnitarioPorcFijo = 0;
            DescuentoDocumento = false;
            DescuentoDocumentoPorcMinimo = 0;
            DescuentoDocumentoPorcMaximo = 0;
            DescuentoDocumentoPorcFijo = 0;
            Impuestos = false;
            FormaDePago = false;
            FormaDePagoFijo = "";
            Contabilidad = false;              
        }

        private void registraValoresDefaultAdmin()
        {
            Crear = true;
            Modificar = true;
            Anular = true;
            Eliminar = true;
            Consultar = true;
            Ingresos = true;
            Gastos = true;
            CierreCaja = true;
            EntregaExpress = true;
            Imprimir = true;
            NroImpresiones = 0;
            NúmeroDocumento = true;
            FechaDocumento = true;
            Bodega = true;
            BodegaFija = "";
            Vendedor = true;
            VendedorFijo = "";
            DetalleProducto = true;
            PrecioUnitario = true;
            PrecioUnitarioFijo = "";
            DescuentoUnitario = true;
            DescuentoUnitarioPorcMinimo = 0;
            DescuentoUnitarioPorcMaximo = 0;
            DescuentoUnitarioPorcFijo = 0;
            DescuentoDocumento = true;
            DescuentoDocumentoPorcMinimo = 0;
            DescuentoDocumentoPorcMaximo = 0;
            DescuentoDocumentoPorcFijo = 0;
            Impuestos = true;
            FormaDePago = true;
            FormaDePagoFijo = "";
            Contabilidad = true;
        }

    }
}
