using ClassFelec;
using DattCom;
using daxAccs;
using DaxDocElectronicos;
using DctosEmi;
using sesSys;
using SolicitudAutSRI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImpresionDoc
{
    public class EnviarAimpresora
    {
        public static bool imprimirDocumento(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            return true;
        }

        public static bool imprimirDocumento(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            return true;
        }

        public static bool imprimirDocumentoDirectamente(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            try
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, true);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            catch (Exception ee)
            { MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
            return true;
        }

        public static bool imprimirDocumentoDirectamente(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            try
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, true);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            catch (Exception ee)
            { MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
            return true;
        }


        public static bool imprimirDocumentoDirectamenteOtros(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 &&
                accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            {
                MessageBox.Show("Ha llegado al límite de impresiones permitidas",
                    "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                // ============================================================
                // GENERAR CLAVE SRI
                // ============================================================
                if (string.IsNullOrEmpty(datADCDOC.claveSri))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        string claveGenerada = ClaveElectronica.generarClaveElectronica(datADCDOC);
                        if (string.IsNullOrEmpty(claveGenerada))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("No se pudo generar la clave electrónica del SRI.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        datADCDOC.claveSri = claveGenerada;
                        ClaveElectronica.actualizarClaveElectronica(datADCDOC);
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show($"Error al generar clave SRI:\n{ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                // ============================================================
                // GENERAR RIDE (PDF)
                // ============================================================
                var fel = new AdcFelec(datosEmpresa.strConxAdcom);
                fel = AdcFelec.Buscar("");

                string rutaBase = !string.IsNullOrEmpty(fel?.pathCpbGenerados) ? fel.pathCpbGenerados : @"C:\CPBGenerados\";
                string carpetaPdf = Feutilidad.PathDocumntosPdf(rutaBase);
                string rutaRide = Path.Combine(carpetaPdf, datADCDOC.claveSri + ".PDF");

                if (!File.Exists(rutaRide))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        RideService rideService = new RideService();
                        string resultado = rideService.GenerarRide(idDocumentoActual, datADCDOC.claveSri, ConfiguracionCorreo.UrlSRI);

                        if (!File.Exists(rutaRide))
                        {
                            string rutaAlterna = Path.Combine(Path.GetDirectoryName(carpetaPdf)?.TrimEnd('\\') ?? carpetaPdf,
                                "GeneradosPDF", datADCDOC.claveSri + ".PDF");

                            if (File.Exists(rutaAlterna))
                            {
                                rutaRide = rutaAlterna;
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show($"No se pudo generar el RIDE.\n\nRuta esperada: {rutaRide}", "Error al generar RIDE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show($"Error al generar RIDE:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    Cursor.Current = Cursors.Default;
                }

                // ============================================================
                // DETECTAR TIPO DE IMPRESORA
                // ============================================================
                string impresoraPredeterminada = "";
                try
                {
                    impresoraPredeterminada = new System.Drawing.Printing.PrinterSettings().PrinterName;
                }
                catch { }

                bool esImpresoraPDF = !string.IsNullOrEmpty(impresoraPredeterminada) &&
                    (impresoraPredeterminada.IndexOf("PDF", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     impresoraPredeterminada.IndexOf("Adobe", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     impresoraPredeterminada.IndexOf("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     impresoraPredeterminada.IndexOf("XPS", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     impresoraPredeterminada.IndexOf("OneNote", StringComparison.OrdinalIgnoreCase) >= 0);

                // ============================================================
                // IMPRIMIR SEGÚN TIPO DE IMPRESORA
                // ============================================================
                if (esImpresoraPDF)
                {
                    // ✅ IMPRESORA PDF: Guardar y mostrar mensaje
                    return GuardarRIDEComoPDF(rutaRide, datADCDOC);
                }
                else
                {
                    // ✅ IMPRESORA FÍSICA: Imprimir directamente
                    bool impreso = ImprimirRIDEFisico(rutaRide, impresoraPredeterminada);

                    if (impreso)
                    {
                        datADCDOC.Doc_Adicional1++;
                        //MessageBox.Show("RIDE impreso correctamente", "Éxito",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al imprimir el RIDE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return impreso;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el RIDE:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool ImprimirRIDEFisico(string rutaRide, string impresora)
        {
            try
            {
                if (!File.Exists(rutaRide))
                    return false;

                // ✅ Intentar imprimir usando el comando printto
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = rutaRide,
                        Verb = "printto",
                        Arguments = $"\"{impresora}\"",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    using (Process proc = Process.Start(psi))
                    {
                        if (proc != null)
                        {
                            // Esperar máximo 10 segundos
                            if (!proc.WaitForExit(10000))
                            {
                                proc.Close();
                            }
                            return true;
                        }
                    }
                }
                catch
                {
                    // ✅ Si falla printto, intentar con print normal
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = rutaRide,
                            Verb = "print",
                            UseShellExecute = true,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        using (Process proc = Process.Start(psi))
                        {
                            if (proc != null)
                            {
                                if (!proc.WaitForExit(10000))
                                {
                                    proc.Close();
                                }
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error imprimiendo RIDE físico: {ex.Message}");
                return false;
            }
        }


        private static bool GuardarRIDEComoPDF(string rutaRide, ClassDoc.AdcDoc datADCDOC)
        {
            try
            {
                if (!File.Exists(rutaRide))
                {
                    MessageBox.Show("No se encontró el archivo RIDE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // ✅ Crear carpeta en Documentos
                string carpetaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RIDES");

                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                // ✅ Copiar el archivo
                string nombreArchivo = Path.GetFileName(rutaRide);
                string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

                // Evitar sobrescritura
                int contador = 1;
                string nombreBase = Path.GetFileNameWithoutExtension(nombreArchivo);
                string extension = Path.GetExtension(nombreArchivo);

                while (File.Exists(rutaDestino))
                {
                    string nuevoNombre = $"{nombreBase}_{contador}{extension}";
                    rutaDestino = Path.Combine(carpetaDestino, nuevoNombre);
                    contador++;
                }

                File.Copy(rutaRide, rutaDestino, true);

                datADCDOC.Doc_Adicional1++;

                // ✅ Mostrar mensaje y abrir carpeta
                //MessageBox.Show(
                //    $"La impresora predeterminada es PDF.\n\n" +
                //    $"El RIDE se ha guardado en:\n{rutaDestino}\n\n" +
                //    $"Se abrirá la carpeta para que pueda abrirlo e imprimirlo manualmente.",
                //    "RIDE Guardado",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information);

                // Abrir carpeta
                Process.Start("explorer.exe", carpetaDestino);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el RIDE:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================
        // IMPRIMIR TICKET
        // ============================================
        public static bool ImprimirTicket(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual, sesSys.OpcDoc propiedadesDoc)
        {
            if (accesosLocalizados.NroImpresiones > 0 &&
                accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            {
                MessageBox.Show("Ha llegado al límite de impresiones permitidas",
                    "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                string impresoraTicket = propiedadesDoc?.Impresora_1;
                if (string.IsNullOrEmpty(impresoraTicket))
                {
                    impresoraTicket = new System.Drawing.Printing.PrinterSettings().PrinterName;
                }

                // ✅ DETECTAR SI ES IMPRESORA PDF
                bool esImpresoraPDF = impresoraTicket.IndexOf("PDF", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                      impresoraTicket.IndexOf("Adobe", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                      impresoraTicket.IndexOf("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0;

                var cabecera = ObtenerCabeceraTicket(datADCDOC, idDocumentoActual);
                var lineas = ObtenerLineasTicket(idDocumentoActual);
                var empresa = ObtenerDatosEmpresa();

                string ticket = GenerarTicket(cabecera, lineas, empresa, 1);
                bool impreso = false;

                if (esImpresoraPDF)
                {
                    // ✅ Para PDF: guardar directamente como archivo
                    impreso = GuardarTicketComoPDF(ticket, datADCDOC);
                }
                else
                {
                    // ✅ Para impresora física: usar PrintDocument
                    impreso = ImprimirTicketConPrintDocument(ticket, impresoraTicket);
                }

                if (impreso)
                {
                    datADCDOC.Doc_Adicional1++;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción en impresión de ticket: \n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool GuardarTicketComoPDF(string texto, ClassDoc.AdcDoc datADCDOC)
        {
            try
            {
                // Crear carpeta en Documentos del usuario
                string carpetaTickets = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "Tickets_POS");

                if (!Directory.Exists(carpetaTickets))
                {
                    Directory.CreateDirectory(carpetaTickets);
                }

                // Nombre del archivo
                string nombreBase = $"Ticket_{datADCDOC.Doc_numero}_{DateTime.Now:yyyyMMdd_HHmmss}";
                string rutaTXT = Path.Combine(carpetaTickets, nombreBase + ".txt");

                // ✅ Guardar como TXT (siempre funciona)
                File.WriteAllText(rutaTXT, texto, Encoding.UTF8);

                // ✅ Intentar guardar como PDF usando PrintDocument
                string rutaPDF = Path.Combine(carpetaTickets, nombreBase + ".pdf");
                bool pdfGenerado = false;

                try
                {
                    using (System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument())
                    {
                        pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                        pd.PrinterSettings.PrintToFile = true;
                        pd.PrinterSettings.PrintFileName = rutaPDF;

                        pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Ticket", 300, 800);
                        pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

                        pd.PrintPage += (sender, e) =>
                        {
                            e.Graphics.DrawString(texto, new Font("Courier New", 8), Brushes.Black, 10, 10);
                        };

                        pd.Print();
                        pdfGenerado = true;
                    }
                }
                catch (Exception exPDF)
                {
                    System.Diagnostics.Debug.WriteLine($"Error generando PDF: {exPDF.Message}");
                    // Si falla el PDF, al menos tenemos el TXT
                }

                // ✅ Abrir la carpeta automáticamente
                System.Diagnostics.Process.Start("explorer.exe", carpetaTickets);

                string mensaje = $"Ticket guardado exitosamente en:\n{carpetaTickets}\n\n";
                if (pdfGenerado)
                {
                    mensaje += $"📄 PDF: {Path.GetFileName(rutaPDF)}";
                }
                else
                {
                    mensaje += $"📄 TXT: {Path.GetFileName(rutaTXT)}";
                }

                MessageBox.Show(mensaje, "Ticket Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar ticket: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool ImprimirTicketConPrintDocument(string texto, string nombreImpresora)
        {
            try
            {
                using (System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument())
                {
                    if (!string.IsNullOrEmpty(nombreImpresora))
                    {
                        pd.PrinterSettings.PrinterName = nombreImpresora;
                    }

                    // ✅ Usar PrintController silencioso
                    pd.PrintController = new System.Drawing.Printing.StandardPrintController();

                    pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Ticket", 300, 800);
                    pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);

                    pd.PrintPage += (sender, e) =>
                    {
                        using (Font fuente = new Font("Courier New", 8, FontStyle.Regular))
                        {
                            float y = e.MarginBounds.Top;
                            float left = e.MarginBounds.Left;
                            string[] lineas = texto.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string linea in lineas)
                            {
                                e.Graphics.DrawString(linea, fuente, Brushes.Black, left, y);
                                y += 15;

                                if (y > e.MarginBounds.Bottom)
                                {
                                    e.HasMorePages = true;
                                    return;
                                }
                            }
                            e.HasMorePages = false;
                        }
                    };

                    pd.Print();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error imprimiendo ticket: {ex.Message}");
                MessageBox.Show($"Error al imprimir ticket: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================
        // MÉTODOS AUXILIARES PARA TICKET
        // ============================================

        private static ImpresionCabeceraDto ObtenerCabeceraTicket(ClassDoc.AdcDoc datADCDOC, ClassDoc.idDocumento idDocumentoActual)
        {
            var cabecera = new ImpresionCabeceraDto
            {
                Doc_NroIdDoc = datADCDOC.Doc_NroIdDoc,
                Doc_numero = datADCDOC.Doc_numero,
                Doc_NombreImp = datADCDOC.Doc_NombreImp,
                Doc_Direccion = datADCDOC.Doc_Direccion,
                Doc_CiRuc = datADCDOC.Doc_CiRuc,
                Doc_fecha = datADCDOC.Doc_fecha,
                Doc_Telefono1 = datADCDOC.Doc_Telefono1,
                Doc_totciva = datADCDOC.Doc_totciva,
                Doc_totsiva = datADCDOC.Doc_totsiva,
                Doc_valordes1 = datADCDOC.Doc_valordes1,
                Doc_valor = datADCDOC.Doc_valor,
                Doc_valoriva = datADCDOC.Doc_valoriva,
                Doc_porceniva = datADCDOC.Doc_porceniva,
                ClaveSRI = datADCDOC.claveSri,
                Pagos = new List<ImpresionPagoDto>()
            };

            try
            {
                string sql = @"
                    SELECT TOP 1 
                        Pag_IdPago,
                        Pag_Descripcion,
                        Pag_Valor
                    FROM AdcPag
                    WHERE  IdClaveDoc = @IdClaveDoc and Opc_documento=@doc and Doc_sucursal=@suc and Doc_numero=@num ";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdClaveDoc", idDocumentoActual.idClave);
                        cmd.Parameters.AddWithValue("@doc", idDocumentoActual.Tipo);
                        cmd.Parameters.AddWithValue("@suc", idDocumentoActual.Sucursal);
                        cmd.Parameters.AddWithValue("@num", idDocumentoActual.numero);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cabecera.Pagos.Add(new ImpresionPagoDto
                                {
                                    IdPago = reader["Pag_IdPago"]?.ToString() ?? "EFE",
                                    Descripcion = reader["Pag_Descripcion"]?.ToString() ?? "",
                                    Monto = Convert.ToDecimal(reader["Pag_Valor"])
                                });
                            }
                        }
                    }
                }
            }
            catch { }

            return cabecera;
        }

        private static List<ImpresionLineaDto> ObtenerLineasTicket(ClassDoc.idDocumento idDocumentoActual)
        {
            var lineas = new List<ImpresionLineaDto>();

            try
            {
                string sql = @"
            SELECT 
                Tra_Codigo,
                Tra_nombre,
                Tra_cantidad,
                Tra_precuni,
                Tra_prectot,
                Tra_porceniva,
                Tra_valoriva
            FROM AdcTra
            WHERE IdClaveDoc = @IdClaveDoc
                AND Opc_documento = @OpcDocumento
                AND Doc_numero = @DocNumero
                AND Doc_sucursal = @DocSucursal
            ORDER BY Tra_numlinea";

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdClaveDoc", idDocumentoActual.idClave);
                        cmd.Parameters.AddWithValue("@OpcDocumento", idDocumentoActual.Tipo);
                        cmd.Parameters.AddWithValue("@DocNumero", idDocumentoActual.numero);
                        cmd.Parameters.AddWithValue("@DocSucursal", idDocumentoActual.Sucursal);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lineas.Add(new ImpresionLineaDto
                                {
                                    Tra_Codigo = reader["Tra_Codigo"].ToString(),
                                    Tra_nombre = reader["Tra_nombre"].ToString(),
                                    Tra_cantidad = Convert.ToDecimal(reader["Tra_cantidad"]),
                                    Tra_precuni = Convert.ToDecimal(reader["Tra_precuni"]),
                                    Tra_prectot = Convert.ToDecimal(reader["Tra_prectot"]),
                                    Tra_porceniva = reader["Tra_porceniva"] != DBNull.Value ? Convert.ToDecimal(reader["Tra_porceniva"]) : 0,
                                    Tra_valoriva = reader["Tra_valoriva"] != DBNull.Value ? Convert.ToDecimal(reader["Tra_valoriva"]) : 0
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo líneas: {ex.Message}");
            }

            return lineas;
        }
        private static ImpresionEmpresaDto ObtenerDatosEmpresa()
        {
            return new ImpresionEmpresaDto
            {
                Nombre = datosEmpresa.Emp_Nombre,
                Ruc = datosEmpresa.Emp_RUC,
                Direccion = datosEmpresa.Emp_Dirección,
                Telefono = datosEmpresa.Emp_Telefono_1,
                Email = datosEmpresa.Emp_Email,
                NroCtrbuyteEspecial = datosEmpresa.Emp_ContrBuyEsp,
                NroAcdoAgntRetencion = datosEmpresa.Emp_AgeRet,
                ObligLlevarConta = datosEmpresa.Emp_Conta ? "SI" : "NO"
            };
        }

        private static string GenerarTicket(ImpresionCabeceraDto cabecera, List<ImpresionLineaDto> lineas, ImpresionEmpresaDto empresa, int numeroCopia)
        {
            var sb = new StringBuilder();
            int ancho = 48;

            // ==================== ENCABEZADO ====================
            sb.AppendLine(new string('=', ancho));
            sb.AppendLine(Centrar(empresa.Nombre, ancho));

            if (!string.IsNullOrEmpty(empresa.Ruc))
                sb.AppendLine(Centrar("RUC " + empresa.Ruc, ancho));

            if (!string.IsNullOrEmpty(empresa.NroCtrbuyteEspecial))
            {
                sb.AppendLine(Centrar("Contribuyente Especial", ancho));
                sb.AppendLine(Centrar($"Resolución Nro. NAC-DGERCGC20-{empresa.NroCtrbuyteEspecial}", ancho));
            }

            if (!string.IsNullOrEmpty(empresa.NroAcdoAgntRetencion))
            {
                sb.AppendLine(Centrar("Agente de Retención", ancho));
                sb.AppendLine(Centrar($"Resolución Nro. NAC-{empresa.NroAcdoAgntRetencion}", ancho));
            }

            if (!string.IsNullOrEmpty(empresa.Direccion))
                sb.AppendLine(Centrar(empresa.Direccion, ancho));

            if (!string.IsNullOrEmpty(empresa.Telefono))
                sb.AppendLine(Centrar("Teléfono: " + empresa.Telefono, ancho));

            sb.AppendLine(Centrar("Documento sin validez tributaria", ancho));
            sb.AppendLine();

            if (!string.IsNullOrEmpty(empresa.ObligLlevarConta))
            {
                sb.AppendLine(Centrar($"OBLIGADO A LLEVAR CONTABILIDAD: {empresa.ObligLlevarConta}", ancho));
                sb.AppendLine();
            }

            // ==================== NÚMERO DE FACTURA ====================
            string nroFactura = cabecera.Doc_NroIdDoc + "-" + cabecera.Doc_numero.ToString("0").PadLeft(9, '0');
            sb.AppendLine(Centrar("Factura: " + nroFactura, ancho));
            sb.AppendLine(Centrar("Autorización S.R.I.", ancho));
            sb.AppendLine(Centrar(cabecera.ClaveSRI ?? "", ancho));
            sb.AppendLine();

            // ==================== INDICADOR DE COPIA ====================
            if (numeroCopia > 1)
            {
                string textoCopia = numeroCopia == 1 ? "COPIA CLIENTE" : "COPIA DESPACHO";
                sb.AppendLine(Centrar("*** " + textoCopia + " ***", ancho));
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine(Centrar("*** ORIGINAL ***", ancho));
                sb.AppendLine();
            }

            // ==================== CLIENTE ====================
            sb.AppendLine("Cliente: " + cabecera.Doc_NombreImp);
            sb.AppendLine("Dirección: " + (cabecera.Doc_Direccion ?? ""));
            sb.AppendLine("RUC/Céd: " + cabecera.Doc_CiRuc);
            sb.AppendLine("Fecha: " + cabecera.Doc_fecha.ToString("dd/MM/yyyy HH:mm:ss"));

            if (!string.IsNullOrEmpty(cabecera.Doc_Telefono1))
                sb.AppendLine("Teléfono: " + cabecera.Doc_Telefono1);

            if (!string.IsNullOrEmpty(empresa.Email))
                sb.AppendLine("Correo: " + empresa.Email);

            sb.AppendLine();

            // ==================== PRODUCTOS ====================
            sb.AppendLine("CANT. ARTICULO                     P.U.    P.TOTAL");
            sb.AppendLine(new string('-', ancho));

            foreach (var linea in lineas)
            {
                string nombre = linea.Tra_nombre ?? "";
                int anchoDescripcion = 26;
                int anchoCantidad = 5;
                int anchoPrecio = 7;
                int anchoTotal = 8;

                string cantidad = linea.Tra_cantidad.ToString("0").PadLeft(anchoCantidad);
                string precioUnitario = linea.Tra_precuni.ToString("0.00").PadLeft(anchoPrecio);
                string subtotal = linea.Tra_prectot.ToString("0.00").PadLeft(anchoTotal);

                List<string> lineasDescripcion = DividirTexto(nombre, anchoDescripcion);

                string primerLinea = cantidad + " " + lineasDescripcion[0].PadRight(anchoDescripcion);
                sb.AppendLine(primerLinea + " " + precioUnitario + " " + subtotal);

                for (int i = 1; i < lineasDescripcion.Count; i++)
                {
                    sb.AppendLine("".PadLeft(anchoCantidad + 1) + lineasDescripcion[i].PadRight(anchoDescripcion));
                }
            }

            sb.AppendLine(new string('-', ancho));

            // ==================== TOTALES ====================
            decimal subtotalGeneral = cabecera.Doc_totciva + cabecera.Doc_totsiva;
            decimal descuento = cabecera.Doc_valordes1;
            decimal total = cabecera.Doc_valor;
            decimal tarifa0 = cabecera.Doc_totsiva;
            decimal tarifaConIva = cabecera.Doc_totciva;
            decimal iva = cabecera.Doc_valoriva;

            string FormatearLineaTotal(string etiqueta, decimal valor)
            {
                int anchoEtiqueta = 14;
                int anchoValor = 10;
                string valorStr = valor.ToString("0.00").PadLeft(anchoValor);
                string etiquetaStr = etiqueta.PadRight(anchoEtiqueta);
                return (etiquetaStr + valorStr).PadLeft(ancho);
            }

            sb.AppendLine(FormatearLineaTotal("Sub total", subtotalGeneral));
            sb.AppendLine(FormatearLineaTotal("Descuento", descuento));

            // ✅ MOSTRAR TARIFA 0% SI EXISTE
            if (tarifa0 > 0)
            {
                sb.AppendLine(FormatearLineaTotal("Tarifa 0%", tarifa0));
            }

            // ✅ MOSTRAR IVA POR CADA PORCENTAJE
            var ivaPorPorcentaje = lineas
                .Where(l => l.Tra_porceniva > 0)
                .GroupBy(l => l.Tra_porceniva)
                .Select(g => new {
                    Porcentaje = g.Key,
                    TotalIVA = g.Sum(l => l.Tra_valoriva),
                    BaseImponible = g.Sum(l => l.Tra_prectot)
                })
                .OrderBy(g => g.Porcentaje)
                .ToList();

            if (ivaPorPorcentaje.Any())
            {
                foreach (var item in ivaPorPorcentaje)
                {
                    // ✅ FORMATEAR PORCENTAJE SIN DECIMALES
                    string porcentajeStr = item.Porcentaje.ToString("0") + "%";

                    sb.AppendLine(FormatearLineaTotal($"Base {porcentajeStr}", item.BaseImponible));
                    sb.AppendLine(FormatearLineaTotal($"IVA {porcentajeStr}", item.TotalIVA));
                }
            }
            else
            {
                // Si no hay IVA desglosado por línea, usar los valores de cabecera
                if (tarifaConIva > 0)
                {
                    // ✅ FORMATEAR PORCENTAJE SIN DECIMALES
                    int porcentajeIva = cabecera.Doc_porceniva > 0 ? (int)Math.Round(cabecera.Doc_porceniva) : 12;
                    string porcentajeStr = porcentajeIva.ToString() + "%";

                    sb.AppendLine(FormatearLineaTotal($"Base {porcentajeStr}", tarifaConIva));
                }
                if (iva > 0)
                {
                    int porcentajeIva = cabecera.Doc_porceniva > 0 ? (int)Math.Round(cabecera.Doc_porceniva) : 12;
                    string porcentajeStr = porcentajeIva.ToString() + "%";

                    sb.AppendLine(FormatearLineaTotal($"IVA {porcentajeStr}", iva));
                }
            }

            sb.AppendLine(new string('=', ancho));
            sb.AppendLine(FormatearLineaTotal("T O T A L", total));
            sb.AppendLine(new string('=', ancho));

            // ==================== FORMA DE PAGO ====================
            string formaPago = "VARIOS";
            if (cabecera.Pagos != null && cabecera.Pagos.Count > 0)
            {
                var pago = cabecera.Pagos[0];
                string idPago = pago.IdPago ?? "";
                string idPagoUpper = idPago.ToUpper();

                if (idPagoUpper == "GLO")
                    formaPago = "GLOVO";
                else if (idPagoUpper == "RAP")
                    formaPago = "RAPPI";
                else if (idPagoUpper == "UBE")
                    formaPago = "UBER";
                else if (idPagoUpper == "EFE")
                    formaPago = "EFECTIVO";
                else if (idPagoUpper == "TAR")
                    formaPago = "TARJETA";
                else if (!string.IsNullOrEmpty(pago.Descripcion))
                    formaPago = pago.Descripcion;
                else
                    formaPago = idPago;
            }

            string pagoLabel = "Forma de Pago:";
            string pagoValor = formaPago;
            string pagoMonto = total.ToString("0.00");

            sb.AppendLine(pagoLabel.PadRight(35) + pagoValor.PadLeft(10));
            sb.AppendLine("".PadRight(35) + pagoMonto.PadLeft(10));

            // ==================== PIE DE PÁGINA ====================
            sb.AppendLine(new string('=', ancho));
            sb.AppendLine(Centrar("¡GRACIAS POR SU COMPRA!", ancho));
            sb.AppendLine(Centrar("VUELVA PRONTO", ancho));
            sb.AppendLine(new string('=', ancho));

            // Líneas en blanco al final
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
        private static List<string> DividirTexto(string texto, int ancho)
        {
            var lineas = new List<string>();

            if (string.IsNullOrEmpty(texto))
            {
                lineas.Add("");
                return lineas;
            }

            if (texto.Length <= ancho)
            {
                lineas.Add(texto);
                return lineas;
            }

            var palabras = texto.Split(' ');
            string lineaActual = "";

            foreach (var palabra in palabras)
            {
                if ((lineaActual + " " + palabra).Length <= ancho)
                {
                    if (string.IsNullOrEmpty(lineaActual))
                        lineaActual = palabra;
                    else
                        lineaActual += " " + palabra;
                }
                else
                {
                    if (!string.IsNullOrEmpty(lineaActual))
                        lineas.Add(lineaActual);

                    if (palabra.Length <= ancho)
                        lineaActual = palabra;
                    else
                    {
                        for (int i = 0; i < palabra.Length; i += ancho)
                        {
                            string parte = palabra.Substring(i, Math.Min(ancho, palabra.Length - i));
                            lineas.Add(parte);
                        }
                        lineaActual = "";
                    }
                }
            }

            if (!string.IsNullOrEmpty(lineaActual))
                lineas.Add(lineaActual);

            return lineas;
        }

        private static string Centrar(string texto, int ancho)
        {
            if (string.IsNullOrEmpty(texto) || texto.Length >= ancho)
                return texto;

            int espacios = (ancho - texto.Length) / 2;
            return new string(' ', espacios) + texto;
        }

        private static bool ImprimirTexto(string texto, string nombreImpresora)
        {
            try
            {
                using (System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument())
                {
                    if (!string.IsNullOrEmpty(nombreImpresora))
                    {
                        pd.PrinterSettings.PrinterName = nombreImpresora;
                    }

                    pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Ticket", 200, 1000);
                    pd.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(5, 5, 5, 5);

                    pd.PrintPage += (sender, e) =>
                    {
                        using (Font fuente = new Font("Courier New", 8, FontStyle.Regular))
                        {
                            float y = e.MarginBounds.Top;
                            float left = e.MarginBounds.Left;
                            string[] lineas = texto.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string linea in lineas)
                            {
                                e.Graphics.DrawString(linea, fuente, Brushes.Black, left, y);
                                y += 15;

                                if (y > e.MarginBounds.Bottom)
                                {
                                    e.HasMorePages = true;
                                    return;
                                }
                            }
                            e.HasMorePages = false;
                        }
                    };

                    pd.Print();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error imprimiendo ticket: {ex.Message}");
                return false;
            }
        }

        // ============================================
        // CLASES DTO
        // ============================================

        public class ImpresionCabeceraDto
        {
            public string Doc_NroIdDoc { get; set; }
            public decimal Doc_numero { get; set; }
            public string Doc_NombreImp { get; set; }
            public string Doc_Direccion { get; set; }
            public string Doc_CiRuc { get; set; }
            public DateTime Doc_fecha { get; set; }
            public string Doc_Telefono1 { get; set; }
            public decimal Doc_totciva { get; set; }
            public decimal Doc_totsiva { get; set; }
            public decimal Doc_valordes1 { get; set; }
            public decimal Doc_valor { get; set; }
            public decimal Doc_valoriva { get; set; }
            public decimal Doc_porceniva { get; set; }
            public string ClaveSRI { get; set; }
            public List<ImpresionPagoDto> Pagos { get; set; }

            // ✅ NUEVO: Para agrupar IVA por porcentaje
            public Dictionary<decimal, decimal> IVAPorPorcentaje { get; set; }
        }

        public class ImpresionLineaDto
        {
            public string Tra_Codigo { get; set; }
            public string Tra_nombre { get; set; }
            public decimal Tra_cantidad { get; set; }
            public decimal Tra_precuni { get; set; }
            public decimal Tra_prectot { get; set; }
            public decimal Tra_porceniva { get; set; }
            public decimal Tra_valoriva { get; set; }
        }

        public class ImpresionEmpresaDto
        {
            public string Nombre { get; set; }
            public string Ruc { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public string NroCtrbuyteEspecial { get; set; }
            public string NroAcdoAgntRetencion { get; set; }
            public string ObligLlevarConta { get; set; }
        }

        public class ImpresionPagoDto
        {
            public string IdPago { get; set; }
            public string Descripcion { get; set; }
            public decimal Monto { get; set; }
        }

        // ============================================
        // MÉTODOS DE IMPRESIÓN PDF
        // ============================================

        private static bool ImprimirPdfExistenteConEspera(string rutaPdf)
        {
            try
            {
                if (!File.Exists(rutaPdf))
                    return false;

                string printerName = new System.Drawing.Printing.PrinterSettings().PrinterName;

                System.Diagnostics.Debug.WriteLine($"Impresora predeterminada: {printerName}");

                // ✅ DETECTAR IMPRESORA PDF
                bool esImpresoraPDF = !string.IsNullOrEmpty(printerName) &&
                    (printerName.IndexOf("PDF", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     printerName.IndexOf("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     printerName.IndexOf("Adobe", StringComparison.OrdinalIgnoreCase) >= 0 ||
                     printerName.IndexOf("XPS", StringComparison.OrdinalIgnoreCase) >= 0);

                if (string.IsNullOrEmpty(printerName) || esImpresoraPDF)
                {
                    // Si es PDF, buscar una impresora física
                    printerName = ObtenerImpresoraFisica();
                    System.Diagnostics.Debug.WriteLine($"Impresora física encontrada: {printerName}");

                    // Si no hay impresora física, abrir el PDF para que el usuario lo guarde
                    if (string.IsNullOrEmpty(printerName))
                    {
                        System.Diagnostics.Process.Start(rutaPdf);
                        MessageBox.Show("No se encontró una impresora física.\nSe abrirá el PDF para que lo guarde o imprima manualmente.",
                            "Abrir PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }

                if (string.IsNullOrEmpty(printerName))
                {
                    System.Diagnostics.Debug.WriteLine("No hay impresora disponible");
                    return false;
                }

                System.Diagnostics.Debug.WriteLine($"Imprimiendo en: {printerName}");

                // ✅ Usar Process para imprimir en segundo plano
                try
                {
                    // Primero intentar con printto (más directo)
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = rutaPdf,
                        Verb = "printto",
                        Arguments = $"\"{printerName}\"",
                        UseShellExecute = true,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    using (Process proc = Process.Start(psi))
                    {
                        if (proc != null)
                        {
                            // Esperar un poco pero no demasiado
                            if (!proc.WaitForExit(3000))
                            {
                                // Si no termina, no esperar más
                                proc.Close();
                            }
                            return true;
                        }
                    }
                }
                catch
                {
                    // Si falla, intentar con print normal
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = rutaPdf,
                            Verb = "print",
                            UseShellExecute = true,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        using (Process proc = Process.Start(psi))
                        {
                            if (proc != null)
                            {
                                // No esperamos, dejamos que el sistema maneje la impresión
                                return true;
                            }
                        }
                    }
                    catch
                    {
                        // Si todo falla, abrir el PDF
                        System.Diagnostics.Process.Start(rutaPdf);
                        MessageBox.Show("No se pudo imprimir automáticamente.\nSe abrirá el PDF para que lo imprima manualmente.",
                            "Abrir PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general: {ex.Message}");
                return false;
            }
        }

        private static string ObtenerImpresoraFisica()
        {
            try
            {
                var impresoras = System.Drawing.Printing.PrinterSettings.InstalledPrinters;

                string[] excluir = {
            "PDF", "OneNote", "XPS", "Fax",
            "Microsoft Print to PDF", "Microsoft XPS Document Writer",
            "AnyDesk", "Adobe PDF", "PDFCreator", "CutePDF",
            "Foxit Reader PDF Printer", "Bullzip PDF", "doPDF"
        };

                System.Diagnostics.Debug.WriteLine("=== Impresoras instaladas ===");
                foreach (string impresora in impresoras)
                {
                    System.Diagnostics.Debug.WriteLine($"- {impresora}");
                }

                // ✅ Primero intentar con la impresora predeterminada si es física
                string defaultPrinter = new System.Drawing.Printing.PrinterSettings().PrinterName;
                if (!string.IsNullOrEmpty(defaultPrinter))
                {
                    bool esVirtual = false;
                    foreach (string excl in excluir)
                    {
                        if (defaultPrinter.IndexOf(excl, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            esVirtual = true;
                            break;
                        }
                    }

                    if (!esVirtual)
                    {
                        System.Diagnostics.Debug.WriteLine($"Usando impresora predeterminada física: {defaultPrinter}");
                        return defaultPrinter;
                    }
                }

                // ✅ Buscar una impresora física
                foreach (string impresora in impresoras)
                {
                    bool esVirtual = false;
                    foreach (string excl in excluir)
                    {
                        if (impresora.IndexOf(excl, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            esVirtual = true;
                            break;
                        }
                    }

                    if (!esVirtual && !string.IsNullOrEmpty(impresora))
                    {
                        System.Diagnostics.Debug.WriteLine($"Usando impresora física: {impresora}");
                        return impresora;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error obteniendo impresora: {ex.Message}");
            }

            return null;
        }

        private static bool ImprimirPdfExistente(string rutaPdf)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    Verb = "print",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process proc = Process.Start(info))
                {
                    if (proc != null)
                    {
                        proc.WaitForInputIdle(5000);
                        proc.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo enviar a impresión:\n{ex.Message}\n\nSugerencia: Verifique que tenga un visor PDF predeterminado configurado (Adobe Reader, Edge, etc.)",
                    "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static string archivoAExcell()
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                OverwritePrompt = true,
                Title = "Nombre de archivo para exportar documento",
                InitialDirectory = @"\tmp",
                Filter = "Archivos tipo excell (*.xls)|*.xls"
            };
            sfd.ShowDialog();
            return sfd.FileName;
        }
    }
}
