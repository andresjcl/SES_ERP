using System;
using System.Data;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxEnvDocElec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(args.Length.ToString());
            if (args.Length > 1)
                try 
                {
                    SysEmpDat.datosEmpresa.Emp_RUC = args[0];
                }
                catch (Exception ex) 
                { 
                    Console.Write ( ex.Message) ; 
                }            
            SysEmpDat.datosEmpresa.fechaProceso = (DateTime.Now.ToShortDateString());
            conexionDatos.strConxAdcom = SysEmpDat.datosEmpresa.strConxAdcom;
            SysEmpDat.datosEmpresa. datosElectronicos(conexionDatos.strConxAdcom);
            EnviarDocumentosElectronicos();
        }  
        static private void EnviarDocumentosElectronicos() 
        {
            string mensaje =  Procesos.generarXml();
            if (mensaje.Substring(0, 5).ToUpper() == "ERROR") return;
        }       
    }    
}
        
        
    //    Dim progsel As New BuscadorDocumentos.frmSeleccDoc
    //    colecError.Clear()
    //    progsel.ShowDialog()
    //    If progsel.filasSelecc.Count > 0 Then
    //        'AdcGenxml.classDatEmp.cargarDatosDeNuestraEmpresa(emp.ruc, strConxadcom)
    //        'If Not valida() Then Exit Sub
    //        Dim genxml As AdcGenxml.enviarDocumentoS
    //        tipoEmision = 1
    //        '            If chkOnLine.Checked = True Then tipoEmision = 2
    //        If progsel.filasSelecc.Count = 0 Then Return

    //        If MessageBox.Show("Se procesarán " + progsel.filasSelecc.Count.ToString() + " documentos " + vbCrLf + " CONFIRMA CONTINUAR ?", "Autorización de documentos electrónicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return

    //        Me.Cursor = Cursors.WaitCursor
    //        Dim iddoc As New ClassDoc.idDocumento
    //        Dim queClave As String
    //        Dim dxlib = New DaxLib.DaxLibBases()
    //        dxlib.TipoBase = "10"
    //        Dim fel = New ClassFelec.AdcFelec(dxlib.StrAdcom())
    //        fel = ClassFelec.AdcFelec.Buscar("")
    //        dxlib = Nothing

    //        For i = 0 To progsel.filasSelecc.Count - 1
    //            Errores = ""
    //            iddoc = New ClassDoc.idDocumento
    //            iddoc = CType(progsel.filasSelecc.Item(i), idDocumento)

    //            queSuc = iddoc.Sucursal
    //            queDoc = iddoc.Tipo
    //            queNum = iddoc.numero
    //            IdClaveDoc = iddoc.idClave

    //            If queClave.Substring(0, 5).ToUpper() = "ERROR" Then
    //                Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Genera XML "
    //            Else
    //                queClaveSRI = queClave.ToUpper()

    //                Dim FM = New AdcFirelec.Firma()
    //                FM.strFileXml = queClaveSRI
    //                Dim resp As String = FM.FirmarArchivoXML()
    //                FM = Nothing

    //                If resp.Substring(0, 5).ToUpper() <> "ERROR" Then
    //                    leerDocumentoAdcom()
    //                    PathFile = fel.pathCpbFirmados + queClaveSRI + ".xml"
    //                    Dim pathAutorizados As String = fel.pathCpbAutorizados + queClaveSRI + ".xml"
    //                    Dim pathNoAutorizados As String = fel.pathpbNoAutorizados + queClaveSRI + ".xml"
    //                    Dim pathErrores As String = pathNoAutorizados.Replace("xml", "ERR")
    //                    correoElectronicoDefecto = fel.correoDefecto
    //                    Dim prog As New enviarDocumentoSri.EnviarComprobanteSri()
    //                    If prog.sendComprobanteSRI(PathFile, queClaveSRI, pathAutorizados, pathNoAutorizados, chkOnLine.Checked) = True Then

    //                        'ImpDoc(IdClaveDoc, emp.SucActual, queDoc, queNum, "A", "F", "", "FEL" + queClase, "")

    //                        Dim ArchivoXML As String = pathAutorizados

    //                        Dim ProgPdf As New documentosPdf.generacionPdf(emp.NombreBaseIvaret, strConxadcom, strConxIvaret, strConxDaxsys, strConxDaxpro, emp.codigo, emp.PatServidor)
    //                        Dim nombrePdf As String = ArchivoXML.Replace("xml", "PDF")
    //                        ProgPdf.GeneraDocPdf(iddoc.Sucursal, iddoc.Tipo, iddoc.numero.ToString(), iddoc.idClave, nombrePdf, "", "FEL" + iddoc.familia)
    //                        prog = Nothing

    //                        If Not (fel.consumidorFinal = "" And fel.consumidorFinal = queCodigoCliente) Then
    //                            If verificaCorreoElectronico(correoElectronico) = True Then
    //                                Dim eMail = New ImprDoct.classEmail
    //                                Dim docMensaje As String = "Enviamos documento electrónico  " + vbCrLf + "Favor confirmar su recepción"
    //                                eMail.enviarMailOutlookDirecto(correoElectronico2, correoElectronico, "Envío documentos electrónicos" + iddoc.Tipo + iddoc.numero.ToString(), "", ArchivoXML, nombrePdf, emp.PathImagenes + "firmaElectronica", docMensaje)
    //                                eMail = Nothing
    //                            Else
    //                                Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " no tiene un correo electrónico valido " + correoElectronico
    //                            End If

    //                            Try
    //                                System.IO.File.Delete(nombrePdf)
    //                            Catch
    //                            End Try
    //                        Else

    //                        End If
    //                    Else
    //                        Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClaveSRI + " autorizando "
    //                        Errores += publicarMensaje(pathErrores)
    //                    End If
    //                    Else
    //                        Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Firmando  "
    //                    End If
    //            End If
    //            If Errores.Length > 0 Then almacenarErrores(Errores)
    //        Next
    //        fel = Nothing
    //        genxml = Nothing
    //        Me.Cursor = Cursors.Default

    //        If colecError.Count > 0 Then
    //            MsgBox("proceso terminado, existen errores ")
    //            Dim prog As New visErrFelec.frmVisor(colecError, "Errores en autorización de documentos electrónicos")
    //            prog.Show()
    //        Else
    //            MsgBox("proceso terminado exitosamente ")
    //        End If

    //    End If
    //End Sub


