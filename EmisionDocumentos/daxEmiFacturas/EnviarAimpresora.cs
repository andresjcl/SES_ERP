using ClassFelec;
using DattCom;
using DaxDocElectronicos;
using SolicitudAutSRI;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace DctosEmi
{
	class EnviarAimpresora
	{
		internal static bool imprimirDocumento(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
			//           try
			{
				ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
				int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
				datADCDOC.Doc_Adicional1 = imp;
				impProg.Dispose();
			}
			//         catch (Exception ee)
			//         { MessageBox.Show ("Excepción en impresion de documento \n" + ee.Message); return false; }
			return true;
		}
		internal static bool imprimirDocumento(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
			//           try
			{
				ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
				int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
				datADCDOC.Doc_Adicional1 = imp;
				impProg.Dispose();
			}
			//         catch (Exception ee)
			//         { MessageBox.Show ("Excepción en impresion de documento \n" + ee.Message); return false; }
			return true;
		}
        //internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        //{
        //    if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
        //    { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
        //    try
        //    {
        //        ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
        //        int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, true);
        //        datADCDOC.Doc_Adicional1 = imp;
        //        impProg.Dispose();
        //    }
        //    catch (Exception ee)
        //    { MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
        //    return true;
        //}

        internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
        {
            // Validar límite de impresiones
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            {
                MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                // 🔹 PASO 1: Generar clave SRI si está vacía
                if (string.IsNullOrEmpty(datADCDOC.claveSri))
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        // ✅ Genera clave usando datADCDOC (tipo correcto para tu método)
                        string claveGenerada = ClaveElectronica.generarClaveElectronica(datADCDOC);

                        if (string.IsNullOrEmpty(claveGenerada))
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("No se pudo generar la clave electrónica del SRI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        datADCDOC.claveSri = claveGenerada;
                        ClaveElectronica.actualizarClaveElectronica(datADCDOC);
                        Cursor.Current = Cursors.Default;
                    }
                    catch (System.TypeInitializationException tie)
                    {
                        // ⚠️ ERROR ESPECÍFICO: Falló inicialización estática
                        Cursor.Current = Cursors.Default;

                        string mensaje = "Error al inicializar el generador de claves SRI.\n\n";
                        mensaje += $"Detalle: {tie.Message}\n\n";

                        if (tie.InnerException != null)
                        {
                            mensaje += $"Causa raíz: {tie.InnerException.Message}\n\n";
                            mensaje += $"Stack: {tie.InnerException.StackTrace}\n\n";
                        }

                        mensaje += "Posibles soluciones:\n" +
                                   "1. Verificar que app.config tenga las claves de configuración\n" +
                                   "2. Verificar que la carpeta de configuración exista\n" +
                                   "3. Verificar permisos de escritura en la carpeta de la aplicación\n" +
                                   "4. Verificar que todas las DLLs estén en la carpeta de la aplicación\n" +
                                   "5. Ejecutar como Administrador";

                        // Guardar log en archivo para diagnóstico
                        string logPath = Path.Combine(Path.GetTempPath(), $"ErrorClaveSRI_{DateTime.Now:yyyyMMdd_HHmmss}.log");
                        File.WriteAllText(logPath, mensaje);

                        MessageBox.Show(mensaje + $"\n\nLog guardado en:\n{logPath}",
                            "Error de Inicialización SRI",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;

                        string mensaje = $"Error al generar clave SRI:\n{ex.Message}";
                        if (ex.InnerException != null)
                        {
                            mensaje += $"\n\nDetalle: {ex.InnerException.Message}";
                        }

                        // Guardar log
                        string logPath = Path.Combine(Path.GetTempPath(), $"ErrorClaveSRI_{DateTime.Now:yyyyMMdd_HHmmss}.log");
                        File.WriteAllText(logPath, mensaje + "\n\nStack:\n" + ex.StackTrace);

                        MessageBox.Show(mensaje + $"\n\nLog guardado en:\n{logPath}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }

                // 🔹 PASO 2: Construir ruta esperada del RIDE
                var fel = new AdcFelec(datosEmpresa.strConxAdcom);
                fel = AdcFelec.Buscar("");

                string rutaBase = !string.IsNullOrEmpty(fel?.pathCpbGenerados) ? fel.pathCpbGenerados : @"C:\CPBGenerados\";
                string carpetaPdf = Feutilidad.PathDocumntosPdf(rutaBase);
                string rutaRide = Path.Combine(carpetaPdf, datADCDOC.claveSri + ".PDF");

                // 🔹 PASO 3: ✅ Si el RIDE NO existe → GENERARLO automáticamente
                if (!File.Exists(rutaRide))
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        // Generar RIDE usando RideService (igual que en solicitarAutorizacionSRI)
                        RideService rideService = new RideService();
                        string resultado = rideService.GenerarRide(
                            idDocumentoActual,           // ✅ Tipo correcto: ClassDoc.idDocumento
                            datADCDOC.claveSri,
                            ConfiguracionCorreo.UrlSRI);

                        // Verificar si se generó en la ruta esperada
                        if (!File.Exists(rutaRide))
                        {
                            // 🔹 Buscar en ruta alternativa (GeneradosPDF)
                            string rutaAlterna = Path.Combine(
                                Path.GetDirectoryName(carpetaPdf)?.TrimEnd('\\') ?? carpetaPdf,
                                "GeneradosPDF",
                                datADCDOC.claveSri + ".PDF");

                            if (File.Exists(rutaAlterna))
                            {
                                rutaRide = rutaAlterna; // Usar ruta alternativa
                            }
                            else
                            {
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show($"No se pudo generar el RIDE.\nResultado: {resultado}\n\nRuta esperada: {rutaRide}",
                                    "Error al generar RIDE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show($"Excepción al generar RIDE: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    Cursor.Current = Cursors.Default;
                }

                // 🔹 PASO 4: ✅ IMPRIMIR EL RIDE (ya existe y está listo)
                //return ImprimirPdfExistente(rutaRide);
                return ImprimirPdfExistenteConEspera(rutaRide);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el RIDE:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //private static bool ImprimirPdfExistenteConEspera(string rutaPdf)
        //{
        //    try
        //    {
        //        if (!File.Exists(rutaPdf))
        //        {
        //            MessageBox.Show($"No se encuentra el archivo PDF:\n{rutaPdf}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return false;
        //        }

        //        // 🔹 MÉTODO 1: Buscar e intentar con Adobe Reader
        //        string adobePath = ObtenerRutaAdobeReader();
        //        if (!string.IsNullOrEmpty(adobePath))
        //        {
        //            try
        //            {
        //                ProcessStartInfo infoAdobe = new ProcessStartInfo
        //                {
        //                    FileName = adobePath,
        //                    Arguments = $"/p /h \"{rutaPdf}\"",
        //                    UseShellExecute = false,
        //                    CreateNoWindow = true,
        //                    WindowStyle = ProcessWindowStyle.Hidden
        //                };

        //                using (Process proc = Process.Start(infoAdobe))
        //                {
        //                    if (proc != null)
        //                    {
        //                        // Esperar que Adobe cargue y envíe a impresión
        //                        proc.WaitForInputIdle(5000);
        //                        Thread.Sleep(4000); // Dar tiempo para que envíe a la impresora

        //                        // Cerrar Adobe Reader
        //                        try
        //                        {
        //                            proc.CloseMainWindow();
        //                            Thread.Sleep(1000);
        //                            if (!proc.HasExited)
        //                                proc.Kill();
        //                        }
        //                        catch { }

        //                        // Verificar si realmente se envió a impresión
        //                        Thread.Sleep(2000);
        //                        return true;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                System.Diagnostics.Debug.WriteLine($"Adobe Reader falló: {ex.Message}");
        //            }
        //        }

        //        // 🔹 MÉTODO 2: Usar Microsoft Print to PDF o impresora predeterminada con printto
        //        try
        //        {
        //            string printerName = new System.Drawing.Printing.PrinterSettings().PrinterName;

        //            // Si no hay impresora predeterminada, usar "Microsoft Print to PDF"
        //            if (string.IsNullOrEmpty(printerName))
        //                printerName = "Microsoft Print to PDF";

        //            ProcessStartInfo infoPrintTo = new ProcessStartInfo
        //            {
        //                FileName = rutaPdf,
        //                Verb = "printto",
        //                Arguments = $"\"{printerName}\"",
        //                UseShellExecute = true,
        //                CreateNoWindow = true,
        //                WindowStyle = ProcessWindowStyle.Hidden
        //            };

        //            using (Process proc = Process.Start(infoPrintTo))
        //            {
        //                if (proc != null)
        //                {
        //                    proc.WaitForExit(10000);
        //                    proc.Close();
        //                    Thread.Sleep(2000);
        //                    return true;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"Verb 'printto' falló: {ex.Message}");
        //        }

        //        // 🔹 MÉTODO 3: Usar PowerShell (más compatible)
        //        try
        //        {
        //            string psCommand = $"Start-Process -FilePath \"{rutaPdf}\" -Verb Print -WindowStyle Hidden -Wait";

        //            ProcessStartInfo infoPS = new ProcessStartInfo
        //            {
        //                FileName = "powershell.exe",
        //                Arguments = $"-Command \"{psCommand}\"",
        //                UseShellExecute = false,
        //                CreateNoWindow = true,
        //                WindowStyle = ProcessWindowStyle.Hidden
        //            };

        //            using (Process proc = Process.Start(infoPS))
        //            {
        //                if (proc != null)
        //                {
        //                    proc.WaitForExit(15000);
        //                    proc.Close();
        //                    Thread.Sleep(2000);
        //                    return true;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"PowerShell falló: {ex.Message}");
        //        }

        //        // 🔹 MÉTODO 4: Usar el programa predeterminado de Windows (último recurso)
        //        try
        //        {
        //            ProcessStartInfo info = new ProcessStartInfo
        //            {
        //                FileName = rutaPdf,
        //                Verb = "print",
        //                UseShellExecute = true,
        //                CreateNoWindow = true,
        //                WindowStyle = ProcessWindowStyle.Hidden
        //            };

        //            using (Process proc = Process.Start(info))
        //            {
        //                if (proc != null)
        //                {
        //                    proc.WaitForExit(10000);
        //                    proc.Close();
        //                    Thread.Sleep(2000);
        //                    return true;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"Verb 'print' falló: {ex.Message}");
        //        }

        //        // 🔹 MÉTODO 5: Si todo falla, preguntar al usuario
        //        DialogResult result = MessageBox.Show(
        //            $"No se pudo imprimir automáticamente.\n\n" +
        //            $"Archivo: {Path.GetFileName(rutaPdf)}\n\n" +
        //            $"¿Desea abrir el PDF para imprimirlo manualmente?\n" +
        //            $"(Presione Ctrl+P una vez abierto)",
        //            "Imprimir documento",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            Process.Start(new ProcessStartInfo { FileName = rutaPdf, UseShellExecute = true });
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al imprimir:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        private static bool ImprimirPdfExistenteConEspera(string rutaPdf)
        {
            try
            {
                if (!File.Exists(rutaPdf))
                    return false;

                // Opción 1: Edge (Windows 10/11 - No abre ventanas)
                string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                if (File.Exists(edgePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = edgePath,
                        Arguments = $"--headless --print-to-default-printer \"{rutaPdf}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    });
                    Thread.Sleep(5000);
                    return true;
                }

                // Opción 2: PrintTo (No abre ventanas visibles)
                string printerName = new System.Drawing.Printing.PrinterSettings().PrinterName;
                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    Verb = "printto",
                    Arguments = $"\"{printerName}\"",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });
                Thread.Sleep(3000);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private static string ObtenerRutaAdobeReader()
        {
            // Rutas más comunes de Adobe Reader
            string[] rutasPosibles = new string[]
            {
        @"C:\Program Files\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe",
        @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe",
        @"C:\Program Files\Adobe\Reader 11.0\Reader\AcroRd32.exe",
        @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AcroRd32.exe",
        @"C:\Program Files\Adobe\Acrobat Reader\Reader\AcroRd32.exe",
        @"C:\Program Files (x86)\Adobe\Acrobat Reader\Reader\AcroRd32.exe"
            };

            foreach (string ruta in rutasPosibles)
            {
                if (File.Exists(ruta))
                {
                    System.Diagnostics.Debug.WriteLine($"Adobe Reader encontrado en: {ruta}");
                    return ruta;
                }
            }

            // Buscar en el registro de Windows
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\AcroRd32.exe"))
                {
                    if (key != null)
                    {
                        string rutaRegistro = key.GetValue("")?.ToString();
                        if (!string.IsNullOrEmpty(rutaRegistro) && File.Exists(rutaRegistro))
                        {
                            System.Diagnostics.Debug.WriteLine($"Adobe Reader encontrado en registro: {rutaRegistro}");
                            return rutaRegistro;
                        }
                    }
                }
            }
            catch { }

            System.Diagnostics.Debug.WriteLine("Adobe Reader NO encontrado en el sistema");
            return null;
        }


        private static bool ImprimirPdfExistente(string rutaPdf)
        {
            try
            {
                // Usar el verbo "print" de Windows para impresión directa
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    Verb = "print",           // ← Comando clave: imprime sin abrir visor
                    UseShellExecute = true,   // ← Requerido para usar Verb
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process proc = Process.Start(info))
                {
                    if (proc != null)
                    {
                        // Esperar brevemente para que el spooler de impresión reciba el trabajo
                        proc.WaitForInputIdle(5000);
                        proc.Close();
                    }
                }

                // Opcional: Registrar éxito en log o actualizar contador
                // System.Diagnostics.Debug.WriteLine($"RIDE impreso: {Path.GetFileName(rutaPdf)}");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo enviar a impresión:\n{ex.Message}\n\nSugerencia: Verifique que tenga un visor PDF predeterminado configurado (Adobe Reader, Edge, etc.)",
                    "Error de impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
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
		
		
		internal static string archivoAExcell()
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
