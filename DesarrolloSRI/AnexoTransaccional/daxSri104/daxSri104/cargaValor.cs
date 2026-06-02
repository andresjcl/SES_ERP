using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace daxSri104
{
    static internal class cargaValor
    {
      static string formato = "#0.00";
    static internal void CargarValores400( frmDax104 frm, string strConxAdcom)
    {
        string SSQL = "DaxSr401404 " + (frm.cmbMeses.SelectedIndex + 1).ToString() + ", " + frm.cmbAños.Text;
        SqlConnection conn = new SqlConnection(strConxAdcom);
        conn.Open();
        SqlCommand comm = new SqlCommand(SSQL, conn);
        SqlDataReader rs;
        rs = comm.ExecuteReader();
        if (rs.Read())
        {
                        frm.malla400.Rows[0].Cells[2].Value = Convert.ToDouble("0"+rs["V401"]);
                        frm.malla400.Rows[0].Cells[4].Value = valFomat(rs["V411"]);
                        frm.malla400.Rows[0].Cells[6].Value = valFomat(rs["V421"]);
                        frm.malla400.Rows[1].Cells[2].Value = valFomat(rs["V402"]);
                        frm.malla400.Rows[1].Cells[4].Value = valFomat(rs["V412"]);
                        frm.malla400.Rows[1].Cells[6].Value = valFomat(rs["V422"]);
                        frm.malla400.Rows[3].Cells[2].Value = valFomat(rs["V403"]);
                        frm.malla400.Rows[3].Cells[4].Value = valFomat(rs["V413"]);
                        frm.malla400.Rows[4].Cells[2].Value = valFomat(rs["V404"]);
                        frm.malla400.Rows[4].Cells[4].Value = valFomat(rs["V414"]);

        }
        rs.Close();
		SSQL = "DaxSr480481 " + (frm.cmbMeses.SelectedIndex + 1).ToString() + ", " + frm.cmbAños.Text;
        comm = new SqlCommand(SSQL, conn);
        rs = comm.ExecuteReader();
        if (rs.Read())
        {
            frm.Txt480.Text = valFomat(rs["ValorContado"]);
            frm.txt481.Text = valFomat(rs["ValorCredito"]);
            frm.txt482.Text = valFomat(rs["ValorIvaContado"]);
            frm.tarifaIva = val(rs["TarifaIva"]);
            //select sum(case dias when 0 then valorventa else 0 end) as ValorContado,
            //    sum(case dias when 1 then valorventa else 0 end) as ValorCredito,	
            //    sum(case dias when 0 then valoriva else 0 end) as ValorIvaContado,
            //    sum(valorsiniva) as ValorVentaSinIva,
        }
    }
    static internal void CargarValores500(frmDax104 frm, string strConxAdcom)
    {
        string SSQL = "DaxSr501504 " + (frm.cmbMeses.SelectedIndex + 1).ToString() + ", " + frm.cmbAños.Text;
        SqlConnection conn = new SqlConnection(strConxAdcom);
        conn.Open();
        SqlCommand comm = new SqlCommand(SSQL, conn);
        SqlDataReader rs;
        rs = comm.ExecuteReader();
        if (rs.Read())
        {
            frm.malla500.Rows[0].Cells[2].Value = valFomat(rs["C500"]);
            frm.malla500.Rows[0].Cells[4].Value = valFomat(rs["C510"]);
            frm.malla500.Rows[0].Cells[6].Value = valFomat(rs["C520"]);
            frm.malla500.Rows[1].Cells[2].Value = valFomat(rs["C501"]);
            frm.malla500.Rows[1].Cells[4].Value = valFomat(rs["C511"]);
            frm.malla500.Rows[1].Cells[6].Value = valFomat(rs["C521"]);
            frm.malla500.Rows[2].Cells[2].Value = valFomat(rs["C502"]);
            frm.malla500.Rows[2].Cells[4].Value = valFomat(rs["C512"]);
            frm.malla500.Rows[2].Cells[6].Value = valFomat(rs["C522"]);
            frm.malla500.Rows[3].Cells[2].Value = valFomat(rs["C503"]);
            frm.malla500.Rows[3].Cells[4].Value = valFomat(rs["C513"]);
            frm.malla500.Rows[3].Cells[6].Value = valFomat(rs["C523"]);
            frm.malla500.Rows[4].Cells[2].Value = valFomat(rs["C504"]);
            frm.malla500.Rows[4].Cells[4].Value = valFomat(rs["C514"]);
            frm.malla500.Rows[4].Cells[6].Value = valFomat(rs["C524"]);
            frm.malla500.Rows[5].Cells[2].Value = valFomat(rs["C505"]);
            frm.malla500.Rows[5].Cells[4].Value = valFomat(rs["C515"]);
            frm.malla500.Rows[5].Cells[6].Value = valFomat(rs["C525"]);

            frm.malla500.Rows[6].Cells[6].Value = valFomat(rs["C526"]);

            frm.malla500.Rows[7].Cells[2].Value = valFomat(rs["C506"]);
            frm.malla500.Rows[7].Cells[4].Value = valFomat(rs["C516"]);

            frm.malla500.Rows[8].Cells[2].Value = valFomat(rs["C507"]);
            frm.malla500.Rows[8].Cells[4].Value = valFomat(rs["C517"]);

            frm.malla500.Rows[9].Cells[2].Value = valFomat(rs["C508"]);
            frm.malla500.Rows[9].Cells[4].Value = valFomat(rs["C518"]);

            frm.malla500.Rows[11].Cells[2].Value = valFomat(rs["C531"]);
            frm.malla500.Rows[11].Cells[4].Value = valFomat(rs["C541"]);

            frm.malla500.Rows[12].Cells[2].Value = valFomat(rs["C532"]);
            frm.malla500.Rows[12].Cells[4].Value = valFomat(rs["C542"]);

            frm.malla500.Rows[13].Cells[4].Value = valFomat(rs["C543"]);

            frm.malla500.Rows[14].Cells[4].Value = valFomat(rs["C544"]);
            frm.malla500.Rows[14].Cells[6].Value = valFomat(rs["C554"]);

            frm.malla500.Rows[15].Cells[2].Value = valFomat(rs["C535"]);
            frm.malla500.Rows[15].Cells[4].Value = valFomat(rs["C545"]);
            frm.malla500.Rows[15].Cells[6].Value = valFomat(rs["C555"]);

        }
        rs.Close();
    }
    static internal void CargarValores600(frmDax104 frm, string strConxAdcom)
    {
        string SSQL = "DaxSr604 " + (frm.cmbMeses.SelectedIndex + 1).ToString() + ", " + frm.cmbAños.Text;
        SqlConnection conn = new SqlConnection(strConxAdcom);
        conn.Open();
        SqlCommand comm = new SqlCommand(SSQL, conn);
        SqlDataReader rs;
        rs = comm.ExecuteReader();
        if (rs.Read())
        {
            frm.malla600.Rows[8].Cells[2].Value = valFomat(rs["TotalRet"]);
        }
        rs.Close();
    }
    static internal void CargarValores700(frmDax104 frm, string strConxAdcom)
    {
        string SSQL = "DaxSr700Dx " + (frm.cmbMeses.SelectedIndex + 1).ToString() + ", " + frm.cmbAños.Text;
        SqlConnection conn = new SqlConnection(strConxAdcom);
        conn.Open();
        SqlCommand comm = new SqlCommand(SSQL, conn);
        SqlDataReader rs;
        rs = comm.ExecuteReader();
        if (rs.Read())
        {
            frm.malla700.Rows[0].Cells[2].Value = valFomat(rs["RET10"]);
            frm.malla700.Rows[1].Cells[2].Value = valFomat(rs["RET20"]);
            frm.malla700.Rows[2].Cells[2].Value = valFomat(rs["RET30"]);
            frm.malla700.Rows[3].Cells[2].Value = valFomat(rs["RET50"]);
            frm.malla700.Rows[4].Cells[2].Value = valFomat(rs["RET70"]);
            frm.malla700.Rows[5].Cells[2].Value = valFomat(rs["RET100"]);
            frm.malla700.Rows[6].Cells[2].Value = valFomat(rs["RETTOT"]);
        }
        rs.Close();
    }

    static internal string valFomat(object valor)
    {
        return val(valor).ToString(formato);
    }
    static internal double val(object valor)
    {
        double num = 0;
        try { num = Convert.ToDouble(valor); }
        catch { num = 0; }
        return num;
    }

		
    //    SSQL = "DaxSr501509 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
    //    rs = ConxAdcom.Execute(SSQL)
    //    With malla500
    //        malla400.Rows[8, 2, "")
    //        malla400.Rows[8, 4, "")
    //        malla400.Rows[8, 6, "")
			
    //        Do Until rs.EOF
    //            'If rs!Doc_TipoDoc = "FAP" Then
    //            '    If rs!ElTipo = "A" Then
    //            malla400.Rows[1, 2].Value = rs["c501")), 2))
    //            malla400.Rows[1, 4].Value = rs["c511")), 2))
    //            malla400.Rows[1, 6].Value = rs["c521")), 2))
    //            '    ElseIf rs!ElTipo = "S" Then
    //            malla400.Rows[2, 2].Value = rs["c502")), 2))
    //            malla400.Rows[2, 4].Value = rs["c512")), 2))
    //            malla400.Rows[2, 6].Value = rs["c522")), 2))
    //            '    End If
    //            'ElseIf rs!Doc_TipoDoc = "DEP" Then
    //            malla400.Rows[7, 2].Value = rs[2)) + CorrijeNuloN(rs.Fields("c507")), 2))
    //            malla400.Rows[7, 4].Value = rs[4)) + CorrijeNuloN(rs.Fields("c517")), 2))
    //            'End If
    //            rs.MoveNext()
    //        Loop 
    //        rs.Close()
			
    //        SSQL = "DaxSr604 " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text ', ConxAdcom, adOpenForwardOnly, adLockReadOnly
    //        rs = ConxAdcom.Execute(SSQL)
    //        'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt604. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    //        If rs.EOF = False Then txt604 = roundd(CorrijeNuloN(rs.Fields("totalret")), 2)
    //        rs.Close()
    //    End With
		
    //    With Malla700
    //        rs = ConxAdcom.Execute("DaxSr700Dx " & ELMES.SelectedIndex + 1 & ", " & ELANIO.Text)
    //        If rs.State = 1 Then
    //            Do Until rs.EOF
    //                I = 0
    //                If (rs.Fields("porc")).Value = 30 Then
    //                    I = 1
    //                ElseIf (rs.Fields("porc")).Value = 70 Then 
    //                    I = 2
    //                ElseIf (rs.Fields("porc")).Value = 100 Then 
    //                    I = 3
    //                End If
    //                If I > 0 Then
    //                    malla400.Rows[I, 4].Value = rs["valorretenido")), 2))
    //                    malla400.Rows[I, 2].Value = rs["Impuesto")), 2))
    //                    'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto total. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    //                    'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto tota. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    //                    tota = total + roundd(CorrijeNuloN(rs.Fields("valorretenido")), 2)
    //                End If
    //                rs.MoveNext()
    //            Loop 
    //            rs.Close()
    //        End If
    //    End With
    //    If rs.State = 1 Then rs.Close()
    //    ',,,,,,,,chequear
    //    rs.Open("SELECT  COUNT(Opc_documento) AS Cuantos From dbo.AdcDoc " & "WHERE     (MONTH(Doc_fecha) = " & ELMES.SelectedIndex + 1 & ") AND (YEAR(Doc_fecha) = " & ELANIO.Text & ") AND (Opc_documento = 'RTP') " & "GROUP BY Opc_documento ", ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
    //    'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txt118. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    //    If rs.EOF = False Then txt118 = CorrijeNuloN(rs.Fields("Cuantos"))
    //    If rs.State = 1 Then rs.Close()
    //    Operaciones400()
    //    Operaciones500()
    //    operaciones600()
    //    Operaciones700()
    //End Sub

    }
}
