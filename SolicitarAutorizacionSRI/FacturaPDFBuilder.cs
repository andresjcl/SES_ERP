using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GeneradorFacturaPDF
{
	public class DetalleFactura
    {
        public string CodigoPrincipal { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string CodigoAuxiliarSafe
        {
            get { return string.IsNullOrEmpty(CodigoAuxiliar) ? "-" : CodigoAuxiliar; }
        }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotal => (Cantidad * PrecioUnitario) - Descuento;
    }

    public class FacturaElectronica
    {
        public string RazonSocial { get; set; }
        public string RucEmisor { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string EmailCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public DateTime FechaEmision { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroAutorizacion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public string Ambiente { get; set; }
        public string Emision { get; set; }
        public string ClaveAcceso { get; set; }

        public List<DetalleFactura> Detalles { get; set; }
        public string DireccionMatriz { get; set; }
        public string DireccionSucursal { get; set; }
        //public string Estudiantes { get; set; }

        public decimal Subtotal { get; set; }
        public decimal SubtotalNoIVA { get; set; }
        public decimal SubtotalExentoIVA { get; set; }
        public decimal SubtotalSinImpuestos { get; set; }
        public decimal Descuento { get; set; }
        public decimal ICE { get; set; }
        public decimal Propina { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPagar { get; set; }
    }

    public class FacturaPDFBuilder
    {
		//      public void GenerarPDF(string rutaDestino, FacturaElectronica factura)
		//      {
		//	// 1. Validaciones
		//	if (string.IsNullOrEmpty(rutaDestino)) throw new ArgumentException("Ruta inválida");
		//	if (factura == null) throw new ArgumentNullException("factura");

		//	// 2. Inicialización manual CRÍTICA
		//	iTextSharp.text.io.StreamUtil.AddToResourceSearch("itextsharp.dll");
		//	iTextSharp.text.io.StreamUtil.AddToResourceSearch("BouncyCastle.Crypto.dll");

		//	string nuevaruta= "C:\\temp\\factura.pdf";
		//	//if (factura.Detalles == null || factura.Detalles.Count == 0)
		//	//    throw new ArgumentException("La factura no tiene detalles");

		//	// Asegura que el directorio exista

		//	// 3. Generación del PDF
		//	Directory.CreateDirectory(Path.GetDirectoryName(nuevaruta));

		//	using (Document doc = new Document(PageSize.A4, 25, 25, 20, 20))
		//	{
		//		if (doc == null)
		//			throw new InvalidOperationException("No se pudo crear el Document.");
		//		try
		//		{
		//			using (FileStream fs = new FileStream(nuevaruta, FileMode.Create))
		//			{
		//				if (fs == null)
		//					throw new InvalidOperationException("No se pudo crear el FileStream.");

		//				PdfWriter writer = PdfWriter.GetInstance(doc, fs);
		//				if (writer == null) throw new Exception("No se pudo crear PdfWriter");

		//				doc.Open();


		//				Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
		//				Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
		//				Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);

		//				PdfPTable header = new PdfPTable(2);
		//				header.WidthPercentage = 100;
		//				header.SetWidths(new float[] { 70, 30 });

		//				PdfPCell empresa = new PdfPCell();
		//				empresa.Border = Rectangle.NO_BORDER;
		//				empresa.AddElement(new Paragraph(factura.RazonSocial, fontBold));
		//				empresa.AddElement(new Paragraph("R.U.C: " + factura.RucEmisor, fontNormal));
		//				empresa.AddElement(new Paragraph("Dir. Matriz: " + factura.DireccionMatriz, fontNormal));
		//				empresa.AddElement(new Paragraph("Dir. Sucursal: " + factura.DireccionSucursal, fontNormal));
		//				header.AddCell(empresa);

		//				PdfPCell infoFactura = new PdfPCell();
		//				infoFactura.Border = Rectangle.BOX;
		//				infoFactura.AddElement(new Paragraph("FACTURA", fontTitle));
		//				infoFactura.AddElement(new Paragraph("No: " + factura.NumeroFactura, fontNormal));
		//				infoFactura.AddElement(new Paragraph("NÚMERO AUTORIZACIÓN", fontNormal));
		//				infoFactura.AddElement(new Paragraph(factura.NumeroAutorizacion, fontNormal));
		//				infoFactura.AddElement(new Paragraph("FECHA Y HORA DE AUTORIZACIÓN", fontNormal));
		//				infoFactura.AddElement(new Paragraph(factura.FechaAutorizacion.ToString("yyyy-MM-dd HH:mm:ss"), fontNormal));
		//				infoFactura.AddElement(new Paragraph("AMBIENTE: " + factura.Ambiente, fontNormal));
		//				infoFactura.AddElement(new Paragraph("EMISIÓN: " + factura.Emision, fontNormal));
		//				infoFactura.AddElement(new Paragraph("CLAVE DE ACCESO", fontNormal));
		//				infoFactura.AddElement(new Paragraph(factura.ClaveAcceso, fontNormal));
		//				header.AddCell(infoFactura);
		//				doc.Add(header);

		//				doc.Add(new Paragraph(" "));

		//				PdfPTable cliente = new PdfPTable(2);
		//				cliente.WidthPercentage = 100;
		//				cliente.SetWidths(new float[] { 30, 70 });

		//				cliente.AddCell(Celda("Razón Social / Nombres y Apellidos:", fontBold));
		//				cliente.AddCell(Celda(factura.NombreCliente, fontNormal));
		//				cliente.AddCell(Celda("RUC / CI:", fontBold));
		//				cliente.AddCell(Celda(factura.IdentificacionCliente, fontNormal));
		//				cliente.AddCell(Celda("Fecha Emisión:", fontBold));
		//				cliente.AddCell(Celda(factura.FechaEmision.ToString("dd/MM/yyyy"), fontNormal));
		//				doc.Add(cliente);

		//				doc.Add(new Paragraph(" "));

		//				PdfPTable tabla = new PdfPTable(7);
		//				tabla.WidthPercentage = 100;
		//				tabla.SetWidths(new float[] { 10, 10, 10, 35, 10, 10, 15 });

		//				string[] headers = { "Cod. Principal", "Cod. Auxiliar", "Cant.", "Descripción", "P. Unit.", "Desc.", "P. Total" };
		//				foreach (var h in headers)
		//					tabla.AddCell(Celda(h, fontBold, BaseColor.LIGHT_GRAY));

		//				foreach (var d in factura.Detalles)
		//				{
		//					tabla.AddCell(Celda(d.CodigoPrincipal, fontNormal));
		//					//tabla.AddCell(Celda(d.CodigoAuxiliar ?? "-", fontNormal));
		//					tabla.AddCell(Celda(d.CodigoAuxiliarSafe, fontNormal));
		//					tabla.AddCell(Celda(d.Cantidad.ToString(), fontNormal));
		//					tabla.AddCell(Celda(d.Descripcion, fontNormal));
		//					tabla.AddCell(Celda(d.PrecioUnitario.ToString("F2"), fontNormal));
		//					tabla.AddCell(Celda(d.Descuento.ToString("F2"), fontNormal));
		//					tabla.AddCell(Celda(d.PrecioTotal.ToString("F2"), fontNormal));
		//				}

		//				doc.Add(tabla);
		//				doc.Add(new Paragraph(" "));

		//				doc.Add(new Paragraph("Información Adicional", fontBold));
		//				doc.Add(new Paragraph("DIRECCIÓN: " + factura.DireccionCliente, fontNormal));
		//				doc.Add(new Paragraph("TELÉFONO: " + factura.TelefonoCliente, fontNormal));
		//				doc.Add(new Paragraph("EMAIL: " + factura.EmailCliente, fontNormal));
		//				//doc.Add(new Paragraph(factura.Estudiantes, fontNormal));
		//				doc.Add(new Paragraph(" "));

		//				PdfPTable totales = new PdfPTable(2);
		//				totales.HorizontalAlignment = Element.ALIGN_RIGHT;
		//				totales.WidthPercentage = 40;

		//				totales.AddCell(Celda("SUBTOTAL 0%", fontBold));
		//				totales.AddCell(Celda(factura.Subtotal.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("SUBTOTAL NO SUJETO IVA", fontBold));
		//				totales.AddCell(Celda(factura.SubtotalNoIVA.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("SUBTOTAL EXENTO IVA", fontBold));
		//				totales.AddCell(Celda(factura.SubtotalExentoIVA.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("SUBTOTAL SIN IMPUESTOS", fontBold));
		//				totales.AddCell(Celda(factura.SubtotalSinImpuestos.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("DESCUENTO", fontBold));
		//				totales.AddCell(Celda(factura.Descuento.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("ICE", fontBold));
		//				totales.AddCell(Celda(factura.ICE.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("PROPINA", fontBold));
		//				totales.AddCell(Celda(factura.Propina.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("VALOR TOTAL", fontBold));
		//				totales.AddCell(Celda(factura.ValorTotal.ToString("F2"), fontNormal));
		//				totales.AddCell(Celda("VALOR A PAGAR", fontBold));
		//				totales.AddCell(Celda(factura.ValorPagar.ToString("F2"), fontNormal));

		//				doc.Add(totales);

		//				doc.Close();

		//			}


		//		}
		//		catch (Exception ex)
		//		{

		//			throw new Exception($"Error al generar PDF: {ex.Message}", ex);
		//		}
		//}

		//}

		public void GenerarPDF(string rutaDestino, FacturaElectronica factura)
		{

			// 1. Configuración de seguridad para ensamblados
			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "itextsharp.dll");
				if (File.Exists(assemblyPath))
					return Assembly.LoadFrom(assemblyPath);
				return null;
			};

			// 2. Verificación de ensamblados cargados
			Console.WriteLine($"iTextSharp: {typeof(iTextSharp.text.Document).Assembly.FullName}");
			//Console.WriteLine($"BouncyCastle: {typeof(Org.BouncyCastle.Asn1.DerObjectIdentifier).Assembly.FullName}");

			// 3. Generación del PDF
			using (Document doc = new Document(PageSize.A4))
			using (FileStream fs = new FileStream(rutaDestino, FileMode.Create))
			{
				PdfWriter writer = PdfWriter.GetInstance(doc, fs);
				doc.Open();

				doc.Add(new Paragraph("¡Funciona!"));

				doc.Close();
			}
			//// Configuración inicial obligatoria
			//string tempPath = "C:\\temp\\factura.pdf"; // Ruta absoluta de prueba
			//										   // 1. Validaciones
			//if (string.IsNullOrEmpty(tempPath)) throw new ArgumentException("Ruta inválida");
			//Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

			//// Inicialización manual EXTENDIDA
			//string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			//iTextSharp.text.io.StreamUtil.AddToResourceSearch(Path.Combine(assemblyPath, "itextsharp.dll"));
			//iTextSharp.text.io.StreamUtil.AddToResourceSearch(Path.Combine(assemblyPath, "BouncyCastle.Crypto.dll"));

			//// Agrega esto temporalmente para verificar
			//Console.WriteLine(typeof(PdfWriter).Assembly.FullName);

			//using (Document doc = new Document())
			//using (FileStream fs = new FileStream("test.pdf", FileMode.Create))
			//{
			//	PdfWriter.GetInstance(doc, fs);
			//	doc.Open();
			//	doc.Add(new Paragraph("¡Funciona!"));
			//	doc.Close();
			//}

			// Configuración del documento
			//using (Document doc = new Document(PageSize.A4, 25, 25, 20, 20))

			//try
			//{
			//	using (FileStream fs = new FileStream(tempPath, FileMode.Create))
			//	{
			//		// FORMA CORRECTA en iTextSharp 5.5.x
			//		PdfWriter writer = PdfWriter.GetInstance(doc, fs);

			//		if (writer == null)
			//		{
			//			throw new InvalidOperationException("No se pudo crear PdfWriter");
			//		}
			//		else
			//		{
			//			throw new InvalidOperationException("OK");
			//		}

			//		doc.Open();

			//		doc.Close();
			//	}
			//}
			//catch (Exception ex)
			//{
			//	throw new Exception($"Error crítico al generar PDF: {ex.Message}", ex);
			//}
			//finally
			//{
			//	doc?.Dispose();
			//}
		}


		private PdfPCell Celda(string texto, Font font, BaseColor bgColor = null)
		{
			var celda = new PdfPCell(new Phrase(texto, font));
			if (bgColor != null)
				celda.BackgroundColor = bgColor;
			celda.Padding = 4;
			return celda;

			
		}
	}
}
