using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassDoc;
using DattCom;
namespace daxContaDoc
{
    public class DetalleContab
    {
        public string codCta = "";
        public string nombreCta = "";
        public string DetalleAsiento = "";
        public Double ValDebe = 0;
        public Double ValHaber = 0;
        public string CentCosto = "";
        public string Empleado = "";
        public string Proyecto = "";
        public string CentProd = "";
        public string CentDistr = "";
        public String Departamento = "";
        public String Zona = "";
        public int Linea = 0;
    }


    public class AsientosContables
    {
        public List<DetalleContab> ListDetalleContab = new List<DetalleContab>();
        public void cargarDeDocumento(idDocumento idDoc)
        {
            string ssql = "Select * ";
            ssql += " from adcdia where doc_sucursal = '" + idDoc.Sucursal + "' and doc_documento = '" + idDoc.Tipo + "' and idclavedoc = " + idDoc.idClave.ToString();
            SqlDataReader dr = SqlDatos.leerBaseAdcom(ssql);
            dr.Read();
            do
            {
                double valor = 0;
                DetalleContab detalleCtb = new DetalleContab()
                {
                    CentCosto = dr["Dia_Costo"].ToString(),
                    CentDistr = dr["dia_centroDistribucion"].ToString(),
                    CentProd = dr["dia_centroproduccion"].ToString(),
                    codCta = dr["Cta_codigo"].ToString(),
                    DetalleAsiento = dr["Dia_detalle"].ToString(),
                    Empleado = dr["Dia_empleado"].ToString(),
                    nombreCta = dr["Dia_ctanombre"].ToString(),
                    Proyecto = dr["Dia_Proyecto"].ToString(),
                    Departamento = dr["Dia_Departamento"].ToString(),
                    Zona = dr["Dia_Zona"].ToString(),
                };
                try { valor = Convert.ToDouble("0" + dr["Dia_valor"].ToString()); } catch { }
                if (Convert.ToInt16(dr["DiaSigno"]) == 1) { detalleCtb.ValDebe = valor; } else { detalleCtb.ValHaber = valor; }
                ListDetalleContab.Add(detalleCtb);
            } while (dr.Read());
        }
        public void GrabarDetalleContable(DataGridView malla, idDocumento idDoc)
        {
            if (cargarDeMalla(malla) == false) return;
            GrabarDetalleContable(idDoc);
            //string ssql = "Select * ";
            //ssql += " from adcdia where doc_sucursal = '" + idDoc.Sucursal + "' and doc_documento = '" + idDoc.Tipo + "' and idclavedoc = " + idDoc.idClave.ToString();
            //using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            //{
            //    SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //    double valor = 0;
            //    double TotHaber = 0;
            //    double TotDebe = 0;
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            dr.Delete();
            //        }
            //    }
            //    int linea = 0;
            //    foreach (DataGridViewRow dgvRow in malla.Rows)
            //    {
            //        linea++;
            //        DataRow dr = dt.NewRow();
            //        dr["Doc_sucursal"] = idDoc.Sucursal;
            //        dr["Opc_documento"] = idDoc.Tipo;
            //        dr["Doc_numero"] = idDoc.numero;
            //        dr["Dia_linea"] = linea;
            //        dr["Dia_fecha"] = idDoc.fecha;
            //        dr["IdClaveDoc"] = idDoc.idClave;
            //        dr["Dia_Status"] = "";
            //        dr["Cta_codigo"] = dgvRow.Cells["Cta_codigo"].Value.ToString();
            //        dr["Dia_detalle"] = dgvRow.Cells["Dia_detalle"].Value.ToString();
            //        dr["Dia_empleado"] = dgvRow.Cells["Dia_empleado"].Value.ToString();
            //        dr["Dia_ctanombre"] = dgvRow.Cells["Dia_ctanombre"].Value.ToString();

            //        try
            //        {
            //            valor = Convert.ToDouble(dgvRow.Cells["ValDebe"].Value);
            //        }
            //        catch { valor = 0; }
            //        if (valor > 0)
            //        {
            //            dr["Dia_valor"] = valor;
            //            dr["Dia_signo"] = 1;
            //            TotDebe += valor;
            //        }
            //        else
            //        {
            //            try
            //            {
            //                valor = Convert.ToDouble(dgvRow.Cells["ValHaber"].Value);
            //            }
            //            catch { valor = 0; }
            //            dr["Dia_valor"] = valor;
            //            dr["Dia_signo"] = -1;
            //            TotHaber += valor;
            //        }

            //        dr["Dia_Costo"] = dgvRow.Cells["Dia_Costo"].Value.ToString();
            //        dr["Dia_Proyecto"] = dgvRow.Cells["Dia_Proyecto"].Value.ToString();
            //        dr["dia_centroDistribucion"] = dgvRow.Cells["dia_centroDistribucion"].Value.ToString();
            //        dr["dia_centroproduccion"] = dgvRow.Cells["dia_centroproduccion"].Value.ToString();
            //        dr["Dia_Departamento"] = dgvRow.Cells["Dia_Departamento"].Value.ToString();
            //        dr["Dia_Zona"] = dgvRow.Cells["Dia_Zona"].Value.ToString();
            //        dt.Rows.Add(dr);
            //    }
            //    da.Update(dt);
            //    dt.AcceptChanges();
            //}
        }


        public void GrabarDetalleContable(idDocumento idDoc)
        {
            string ssql = "Select * ";
            ssql += " from adcdia where doc_sucursal = '" + idDoc.Sucursal + "' and opc_documento = '" + idDoc.Tipo + "' and idclavedoc = " + idDoc.idClave.ToString();
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                double TotHaber = 0;
                double TotDebe = 0;
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr.Delete();
                    }
                }
                int linea = 0;
                foreach (DetalleContab asientoCtb in ListDetalleContab)
                {
                    linea++;
                    DataRow dr = dt.NewRow();
                    dr["Doc_sucursal"] = idDoc.Sucursal;
                    dr["Opc_documento"] = idDoc.Tipo;
                    dr["Doc_numero"] = idDoc.numero;
                    dr["Dia_linea"] = linea;
                    dr["Dia_fecha"] = idDoc.fecha;
                    dr["IdClaveDoc"] = idDoc.idClave;
                    dr["Dia_Status"] = "";
                    dr["Cta_codigo"] = asientoCtb.codCta;
                    dr["Dia_detalle"] = asientoCtb.DetalleAsiento;
                    dr["Dia_empleado"] = asientoCtb.Empleado;
                    dr["Dia_ctanombre"] = asientoCtb.nombreCta;

                    if (asientoCtb.ValDebe > 0)
                    {
                        dr["Dia_valor"] = asientoCtb.ValDebe;
                        dr["Dia_signo"] = 1;
                        TotDebe += asientoCtb.ValDebe;
                    }
                    else
                    {
                        dr["Dia_valor"] = asientoCtb.ValHaber;
                        dr["Dia_signo"] = -1;
                        TotHaber += asientoCtb.ValHaber;
                    }

                    dr["Dia_Costo"] = asientoCtb.CentCosto;
                    dr["Dia_Proyecto"] = asientoCtb.Proyecto;
                    dr["dia_centroDistribucion"] = asientoCtb.CentDistr;
                    dr["dia_centroproduccion"] = asientoCtb.CentProd;
                    dr["Dia_Departamento"] = asientoCtb.Departamento;
                    dr["Dia_Zona"] = asientoCtb.Zona;
                    dt.Rows.Add(dr);
                }
                da.Update(dt);
                dt.AcceptChanges();
            }

        }
        public bool cargarDeMalla(DataGridView malla)
        {
            if (validarAsientosContables(malla) == false) return false;
            ListDetalleContab = new List<DetalleContab>();
            foreach (DataGridViewRow dgvRow in malla.Rows)
            {
                DetalleContab detalleCtb = new DetalleContab();
                detalleCtb.codCta = dgvRow.Cells["Cta_codigo"].Value.ToString();
                detalleCtb.DetalleAsiento = dgvRow.Cells["Dia_detalle"].Value.ToString();
                detalleCtb.ValDebe = Convert.ToDouble("0" + dgvRow.Cells["ValDebe"].Value.ToString());
                detalleCtb.ValHaber = Convert.ToDouble("0" + dgvRow.Cells["ValHaber"].Value.ToString());
                detalleCtb.CentCosto = dgvRow.Cells["Dia_Costo"].Value.ToString();
                detalleCtb.CentDistr = dgvRow.Cells["dia_centroDistribucion"].Value.ToString();
                detalleCtb.CentProd = dgvRow.Cells["dia_centroproduccion"].Value.ToString();
                detalleCtb.Empleado = dgvRow.Cells["Dia_empleado"].Value.ToString();
                detalleCtb.nombreCta = dgvRow.Cells["Dia_ctanombre"].Value.ToString();
                detalleCtb.Proyecto = dgvRow.Cells["Dia_Proyecto"].Value.ToString();
                detalleCtb.Departamento = dgvRow.Cells["Dia_Departamento"].Value.ToString();
                detalleCtb.Zona = dgvRow.Cells["Dia_Zona"].Value.ToString();
                ListDetalleContab.Add(detalleCtb);
            }
            return true;
        }
        public void cargarAmalla(DataGridView malla)
        {
            string ssql = "DaxCtbDia '' ,'', 0";
            DataTable dt = SqlDatos.leerTablaAdcom(ssql);
            malla.DataSource = dt;

            //DataTable dt = (DataTable)malla.DataSource;
            foreach (DetalleContab detalleCtb in ListDetalleContab)
            {
                DataRow dRow = dt.NewRow();
                dRow["Cta_codigo"] = detalleCtb.codCta;
                dRow["Dia_detalle"] = detalleCtb.DetalleAsiento;
                dRow["ValDebe"] = detalleCtb.ValDebe;
                dRow["ValHaber"] = detalleCtb.ValHaber;
                dRow["Dia_Costo"] = detalleCtb.CentCosto;
                dRow["dia_centroDistribucion"] = detalleCtb.CentDistr;
                dRow["dia_centroproduccion"] = detalleCtb.CentProd;
                dRow["Dia_empleado"] = detalleCtb.Empleado;
                dRow["Dia_ctanombre"] = detalleCtb.nombreCta;
                dRow["Dia_Proyecto"] = detalleCtb.Proyecto;
                dRow["Dia_Departamento"] = detalleCtb.Departamento;
                dRow["Dia_Zona"] = detalleCtb.Zona;

                dt.Rows.Add(dRow);
            }
        }
        //private bool validarAsientosContables(DataGridView malla)
        //{
        //    bool vale = true;
        //    double debitos = 0;
        //    double creditos = 0;
        //    if (malla.RowCount < 1) return false;
        //    try
        //    {
        //        foreach (DataGridViewRow dgvRow in malla.Rows)
        //        {
        //            debitos += Convert.ToDouble("0" + dgvRow.Cells["valDebe"].Value);
        //            creditos += Convert.ToDouble("0" + dgvRow.Cells["valHaber"].Value);
        //            if (debitos == 0 && creditos == 0) vale = false;
        //            if (dgvRow.Cells["Cta_codigo"].Value.ToString() == "999999") vale = false;
        //        }
        //        if (vale == false) MessageBox.Show("Existen errores en la contabilizacion, \n para continuar debe corregirlos");
        //        if (debitos != creditos) { MessageBox.Show("La suma de debitos y créditos no cuadra"); vale = false; }
        //    }catch { vale = false; }
        //    return vale;
        //}

        private bool validarAsientosContables(DataGridView malla)
        {
            bool vale = true;
            decimal debitos = 0;
            decimal creditos = 0;

            if (malla.RowCount < 1) return false;

            try
            {
                foreach (DataGridViewRow dgvRow in malla.Rows)
                {
                    decimal debe = Convert.ToDecimal("0" + dgvRow.Cells["valDebe"].Value);
                    decimal haber = Convert.ToDecimal("0" + dgvRow.Cells["valHaber"].Value);

                    debitos += debe;
                    creditos += haber;

                    if (debe == 0 && haber == 0)
                        vale = false;

                    if (dgvRow.Cells["Cta_codigo"].Value?.ToString() == "999999")
                        vale = false;
                }

                if (!vale)
                    MessageBox.Show("Existen errores en la contabilizacion,\n para continuar debe corregirlos");

                if (Math.Round(debitos, 2) != Math.Round(creditos, 2))
                {
                    MessageBox.Show("La suma de debitos y créditos no cuadra");
                    vale = false;
                }
            }
            catch
            {
                vale = false;
            }

            return vale;
        }
        public void copiarAsientosContables(AsientosContables listaOrigen)
        {
            ListDetalleContab = new List<DetalleContab>();            
            foreach (DetalleContab detCtb in listaOrigen.ListDetalleContab)
            {
                ListDetalleContab.Add(detCtb);
            }
        }
    }
}
