using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms ;
using ClassDoc;
using DattCom;

namespace leeDocXml
{
    class guardarDocumento
    {
        //static internal void guardarAdcDOc(AdcDoc class_AdcDoc)
        //{
        //    sesSys.OpcDoc opOpc = new sesSys.OpcDoc();
        //    string lug = class_AdcDoc.Doc_sucursal;
        //    string tip = class_AdcDoc.Opc_documento;
        //    opOpc.Cargar(ref tip, ref lug);

        //    class_AdcDoc.Doc_Estado = 1;
        //    class_AdcDoc.Adi_FechContab = class_AdcDoc.Doc_fecha;
        //    class_AdcDoc.Adi_TipoDocSri = opOpc.TipoSri;
        //    class_AdcDoc.Doc_TipoDoc = opOpc.TipoDoc;
        //    class_AdcDoc.Doc_docnombre = opOpc.nombre;
        //    class_AdcDoc.Doc_Inventario = Convert.ToInt16(opOpc.ClaveInventario);
        //    class_AdcDoc.Doc_Compras = Convert.ToInt16(opOpc.ClaveCompras);
        //    class_AdcDoc.Doc_Contabilidad = Convert.ToInt16(opOpc.ClaveContable);
        //    class_AdcDoc.Doc_Banco = Convert.ToInt16(opOpc.ClaveBanco);
        //    class_AdcDoc.Doc_Activo = Convert.ToInt16(opOpc.ClaveActivo);
        //    class_AdcDoc.Doc_Ventas = Convert.ToInt16(opOpc.ClaveVentas);
        //    class_AdcDoc.Doc_FechaModifica = DateTime.Now;
        //    class_AdcDoc.Doc_codusu = datosEmpresa.usr;
        //    class_AdcDoc.PuntoVta = DctosEmi.valoresPredefinidosSucursal.nomPuntoVta;
        //    class_AdcDoc.Doc_Hora = DateTime.Now;

        //    // ✅ REDONDEAR CAMPOS A 2 DECIMALES
        //    class_AdcDoc.Doc_totciva = Math.Round(class_AdcDoc.Doc_totciva, 2);
        //    class_AdcDoc.Doc_totsiva = Math.Round(class_AdcDoc.Doc_totsiva, 2);
        //    class_AdcDoc.Doc_valoriva = Math.Round(class_AdcDoc.Doc_valoriva, 2);
        //    class_AdcDoc.Doc_valor = Math.Round(class_AdcDoc.Doc_valor, 2);
        //    class_AdcDoc.Doc_valorabon = class_AdcDoc.Doc_valor; // ✅ Sincronizar
        //    class_AdcDoc.Doc_TotArtCIva = Math.Round(class_AdcDoc.Doc_TotArtCIva, 2);
        //    class_AdcDoc.Doc_TotArtSIva = Math.Round(class_AdcDoc.Doc_TotArtSIva, 2);
        //    class_AdcDoc.Doc_TotSerCIva = Math.Round(class_AdcDoc.Doc_TotSerCIva, 2);
        //    class_AdcDoc.Doc_TotSerSIva = Math.Round(class_AdcDoc.Doc_TotSerSIva, 2);

        //    // ✅ BaseImp1 = Doc_totciva (BASE IMPONIBLE, NO EL TOTAL)
        //    class_AdcDoc.BaseImp1 = class_AdcDoc.Doc_totciva;

        //    Console.WriteLine("\n=== VALORES REDONDEADOS EN ADCDOC ===");
        //    Console.WriteLine($"Doc_totciva: {class_AdcDoc.Doc_totciva}");
        //    Console.WriteLine($"Doc_TotArtCIva: {class_AdcDoc.Doc_TotArtCIva}");
        //    Console.WriteLine($"Doc_TotSerCIva: {class_AdcDoc.Doc_TotSerCIva}");
        //    Console.WriteLine($"BaseImp1: {class_AdcDoc.BaseImp1}"); // DEBE SER 25.62
        //    Console.WriteLine($"Doc_valor: {class_AdcDoc.Doc_valor}");
        //    Console.WriteLine($"Doc_valoriva: {class_AdcDoc.Doc_valoriva}");

        //    class_AdcDoc.Crear();
        //}

        static internal void guardarAdcDOc(AdcDoc class_AdcDoc)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine($"📌 INICIO guardarAdcDOc - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"📌 Documento: Suc={class_AdcDoc.Doc_sucursal}, Opc={class_AdcDoc.Opc_documento}, Num={class_AdcDoc.Doc_numero}, Id={class_AdcDoc.IdClaveDoc}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");

            sesSys.OpcDoc opOpc = new sesSys.OpcDoc();
            string lug = class_AdcDoc.Doc_sucursal;
            string tip = class_AdcDoc.Opc_documento;
            opOpc.Cargar(ref tip, ref lug);

            class_AdcDoc.Doc_Estado = 1;
            class_AdcDoc.Adi_FechContab = class_AdcDoc.Doc_fecha;
            class_AdcDoc.Adi_TipoDocSri = opOpc.TipoSri;
            class_AdcDoc.Doc_TipoDoc = opOpc.TipoDoc;
            class_AdcDoc.Doc_docnombre = opOpc.nombre;
            class_AdcDoc.Doc_Inventario = Convert.ToInt16(opOpc.ClaveInventario);
            class_AdcDoc.Doc_Compras = Convert.ToInt16(opOpc.ClaveCompras);
            class_AdcDoc.Doc_Contabilidad = Convert.ToInt16(opOpc.ClaveContable);
            class_AdcDoc.Doc_Banco = Convert.ToInt16(opOpc.ClaveBanco);
            class_AdcDoc.Doc_Activo = Convert.ToInt16(opOpc.ClaveActivo);
            class_AdcDoc.Doc_Ventas = Convert.ToInt16(opOpc.ClaveVentas);
            class_AdcDoc.Doc_FechaModifica = DateTime.Now;
            class_AdcDoc.Doc_codusu = datosEmpresa.usr;
            class_AdcDoc.PuntoVta = DctosEmi.valoresPredefinidosSucursal.nomPuntoVta;
            class_AdcDoc.Doc_Hora = DateTime.Now;

            Console.WriteLine("\n📊 VALORES ORIGINALES:");
            Console.WriteLine($"   Doc_totciva: {class_AdcDoc.Doc_totciva}");
            Console.WriteLine($"   Doc_valoriva: {class_AdcDoc.Doc_valoriva}");
            Console.WriteLine($"   Doc_valor: {class_AdcDoc.Doc_valor}");
            Console.WriteLine($"   Doc_TotArtCIva: {class_AdcDoc.Doc_TotArtCIva}");
            Console.WriteLine($"   Doc_TotSerCIva: {class_AdcDoc.Doc_TotSerCIva}");

            // ✅ REDONDEAR A 2 DECIMALES
            class_AdcDoc.Doc_totciva = Math.Round(class_AdcDoc.Doc_totciva, 2);
            class_AdcDoc.Doc_totsiva = Math.Round(class_AdcDoc.Doc_totsiva, 2);
            class_AdcDoc.Doc_valoriva = Math.Round(class_AdcDoc.Doc_valoriva, 2);
            class_AdcDoc.Doc_valor = Math.Round(class_AdcDoc.Doc_valor, 2);
            class_AdcDoc.Doc_valorabon = class_AdcDoc.Doc_valor;
            class_AdcDoc.Doc_TotArtCIva = Math.Round(class_AdcDoc.Doc_TotArtCIva, 2);
            class_AdcDoc.Doc_TotArtSIva = Math.Round(class_AdcDoc.Doc_TotArtSIva, 2);
            class_AdcDoc.Doc_TotSerCIva = Math.Round(class_AdcDoc.Doc_TotSerCIva, 2);
            class_AdcDoc.Doc_TotSerSIva = Math.Round(class_AdcDoc.Doc_TotSerSIva, 2);
            class_AdcDoc.BaseImp1 = class_AdcDoc.Doc_totciva;

            Console.WriteLine("\n📊 VALORES REDONDEADOS:");
            Console.WriteLine($"   Doc_totciva: {class_AdcDoc.Doc_totciva}");
            Console.WriteLine($"   Doc_valoriva: {class_AdcDoc.Doc_valoriva}");
            Console.WriteLine($"   Doc_valor: {class_AdcDoc.Doc_valor}");
            Console.WriteLine($"   Doc_TotArtCIva: {class_AdcDoc.Doc_TotArtCIva}");
            Console.WriteLine($"   Doc_TotSerCIva: {class_AdcDoc.Doc_TotSerCIva}");

            // ✅ VERIFICAR CONSISTENCIA
            decimal totalVerificado = class_AdcDoc.Doc_totciva + class_AdcDoc.Doc_totsiva + class_AdcDoc.Doc_valoriva;
            Console.WriteLine($"\n🔍 VERIFICACIÓN: {class_AdcDoc.Doc_totciva} + {class_AdcDoc.Doc_totsiva} + {class_AdcDoc.Doc_valoriva} = {totalVerificado}");
            Console.WriteLine($"   Doc_valor: {class_AdcDoc.Doc_valor}");

            if (Math.Abs(totalVerificado - class_AdcDoc.Doc_valor) <= 0.01m)
                Console.WriteLine($"   ✅ CONSISTENTE");
            else
                Console.WriteLine($"   ⚠️ INCONSISTENCIA: diferencia de {totalVerificado - class_AdcDoc.Doc_valor}");

            Console.WriteLine("\n💾 GUARDANDO DOCUMENTO...");
            class_AdcDoc.Crear();
            Console.WriteLine("✅ Documento guardado exitosamente");
            Console.WriteLine($"\n✅ FIN guardarAdcDOc - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
        }

        static internal void guardarAdcTra(AdcDoc class_AdcDoc,AdcTra class_AdcTra,DataGridView mallaXml, string strconx)
        {
            ClassDoc.grabMallTra.grabarDetalleAdctraXML(mallaXml,class_AdcDoc,strconx);            
        }
        static internal void guardarAdcApl(AdcDoc class_AdcDoc, AdcSri class_AdcSri, DataGridView mallaXml, string strconx)
        {
            AdcApl class_adcapl = new AdcApl();
            class_adcapl.Apl_codbenef = class_AdcDoc.Doc_codper;
            class_adcapl.Apl_docapli = class_AdcSri.codDocSustentoAdcom;
            class_adcapl.Apl_docfecha = class_AdcSri.fechaEmisionDocSustento;
            class_adcapl.Apl_fecha = class_AdcDoc.Doc_fecha;
            class_adcapl.Apl_numapli = Convert.ToDecimal(class_AdcSri.numDocSustento);
            class_adcapl.Apl_sucapli = class_AdcSri.SRI_SUCURSAL;
            class_adcapl.Apl_valorapl = class_AdcSri.ValorRetFuente + class_AdcSri.ValorRetFuente1 + class_AdcSri.ValorRetIvaBienes + class_AdcSri.ValorRetIvaServicios;
            class_adcapl.Doc_numero = class_AdcDoc.Doc_numero;
            class_adcapl.Doc_sucursal = class_AdcDoc.Doc_sucursal;
            class_adcapl.Idclaveapl = class_AdcSri.IdClaveDocSustento;
            class_adcapl.Idclaveapl = 1;
            class_adcapl.IdClaveDoc = class_AdcSri.IdClaveDoc;
            class_adcapl.IdClaveDocApl = class_AdcSri.IdClaveDocSustento;
            class_adcapl.Opc_documento = class_AdcDoc.Opc_documento;
            class_adcapl.tra_Ventas = 1;
            class_adcapl.Actualizar();
        }
        static internal void guardarAdcSri(AdcSri class_AdcSri, AdcDoc class_AdcDoc)
        {
            class_AdcSri.SRI_DOCUMENTO = class_AdcDoc.Opc_documento;
            class_AdcSri.SRI_NUMERORET = class_AdcDoc.Doc_numero;
            class_AdcSri.SRI_SUCURSAL = class_AdcDoc.Doc_sucursal;
            class_AdcSri.IdClaveDoc = class_AdcDoc.IdClaveDoc;
            class_AdcSri.Sri_tipoDoc = class_AdcDoc.Doc_TipoDoc;
            class_AdcSri.Actualizar();
        }
        static internal void guardarAdcApl(AdcSri class_AdcSri, AdcDoc class_AdcDoc)
        {
            
            AdcApl cAdcApl = new AdcApl();

            cAdcApl.Doc_sucursal = class_AdcDoc.Doc_sucursal;
            cAdcApl.Opc_documento = class_AdcDoc.Opc_documento;
            cAdcApl.Doc_numero = class_AdcDoc.Doc_numero;
            cAdcApl.IdClaveDoc = class_AdcDoc.IdClaveDoc;

            cAdcApl.Apl_codbenef = class_AdcDoc.Doc_codper;
            cAdcApl.Apl_docfecha = class_AdcSri.fechaEmisionDocSustento;
            cAdcApl.Apl_fecha = class_AdcDoc.Doc_fecha;

            cAdcApl.Apl_sucapli = class_AdcSri.SRI_SUCURSAL;
            cAdcApl.Apl_docapli = class_AdcSri.codDocSustentoAdcom;
            cAdcApl.Apl_numapli = Convert.ToDecimal(class_AdcSri.numDocSustento);
            cAdcApl.IdClaveDocApl = class_AdcSri.IdClaveDocSustento;
            cAdcApl.Apl_valorapl = class_AdcSri.ValorRetFuente + class_AdcSri.ValorRetFuente1 + class_AdcSri.ValorRetIvaBienes + class_AdcSri.ValorRetIvaServicios;

            cAdcApl.Actualizar();

        }
    }
}
