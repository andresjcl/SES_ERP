using ClassDoc;
using ClassFelec;
using DattCom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IvaRett;
using static DaxDocElectronicos.Auxiliares;
using System.Windows.Forms;

namespace DaxDocElectronicos
{
    public class RideService
    {
        docImpuestos claseImpuestos = new docImpuestos();
        private AdcFelec fel;
        private Auxiliares aux;

        public RideService()
        {
            aux = new Auxiliares();
        }

        public string GenerarRide(idDocumento IdDocumento, string queClaveSRI, string urlEs)
        {
            string imageBase64 = aux.ObtenerLogoBase64(datosEmpresa.Emp_PathImagenes);

            // Ejecutar procedimiento
            var resultado = aux.EjecutarProcedimientoCabeceraYDetalle((int)IdDocumento.idClave,IdDocumento.Sucursal,IdDocumento.Tipo,(decimal)IdDocumento.numero);

            // Obtener forma de pago
            var pago = aux.ObtenerPrimerPago(datosEmpresa.nombreBaseIvaret,datosEmpresa.suc,IdDocumento.Tipo,IdDocumento.idClave);

            string formaPagoDescripcion = pago?.nombreFpagoSri ?? "SIN UTILIZACION DEL SISTEMA FINANCIERO";
            int diasPlazo = pago?.diasPlazo ?? 0;
            decimal valorPago = pago?.Pag_Valor ?? 0;

            fel = new AdcFelec(datosEmpresa.strConxAdcom);
            fel = AdcFelec.Buscar("");
            //docImpuestos claseImpuestos = new docImpuestos();
            claseImpuestos.cargar(datosEmpresa.strConxIvaret, resultado._Doc_fecha);
            decimal ivaVigente = (decimal)claseImpuestos.impstoPorcentaje1;

            // Agrupar IVA dinámicamente
            var ivaAgrupado = resultado.Detalles
                .GroupBy(d => d._Tra_porceniva == 0 ? ivaVigente : d._Tra_porceniva)
                .Select(g =>
                {
                    decimal porcentaje = g.Key;
                    decimal baseImponible = g.Sum(x => x._Tra_prectot);
                    decimal iva = Math.Round(baseImponible * porcentaje / 100, 2);

                    return new
                    {
                        Porcentaje = porcentaje,
                        Base = baseImponible,
                        Iva = iva
                    };
                })
                .ToList();

            // Crear lista para el RIDE
            var ivaInfoList = ivaAgrupado
                .Where(x => x.Porcentaje > 0)
                .Select(x => new IvaInfo
                {
                    Porcentaje = x.Porcentaje,
                    Subtotal = x.Base,
                    Iva = x.Iva
                })
                .ToList();

            // Llenar campos tradicionales
            resultado._Base15 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 15)
                .Sum(x => x.Base);

            resultado._Iva15 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 15)
                .Sum(x => x.Iva);

            resultado._Base5 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 5)
                .Sum(x => x.Base);

            resultado._Iva5 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 5)
                .Sum(x => x.Iva);            


            var facturaRequest = new FacturaRequest
            {
                RucEmisor = datosEmpresa.Emp_RUC,
                RazonSocialEmisor = datosEmpresa.Emp_Nombre,
                DireccionMatriz = datosEmpresa.Emp_Dirección,
                DireccionSucursal = datosEmpresa.Emp_Dirección,
                EmailEmisor = datosEmpresa.Emp_Email,
                TelefonoEmisor = datosEmpresa.Emp_Telefono_1,

                ObligadoContabilidad = Convert.ToBoolean(datosEmpresa.Emp_Conta),
                AgenteRetencion = datosEmpresa.Emp_AgeRet,
                NroCtrbuyteEspecial = datosEmpresa.Emp_ContrBuyEsp,
                Regimen = datosEmpresa.Emp_Regimen,

                NumeroFactura = resultado._Doc_NroIdDoc + "-" + resultado._Doc_numero.ToString("000000000"),
                NumeroAutorizacion = resultado._NroAutorizacionSri,

                FechaAutorizacion = resultado._fechaAutorizacion.HasValue
           ? resultado._fechaAutorizacion.Value.ToString("yyyy-MM-ddTHH:mm:ss")
           : null,

                Ambiente = resultado._tipAmbiente,
                TipoEmision = resultado._tipEmision,
                ClaveAcceso = resultado._claveAcceso,

                NombreCliente = resultado._Doc_NombreImp,
                IdentificacionCliente = resultado._Doc_CiRuc,
                FechaEmision = resultado._Doc_fecha.ToString("yyyy-MM-dd"),
                DireccionCliente = resultado._Doc_Direccion,
                TelefonoCliente = resultado._Doc_Telefono1,
                EmailCliente = resultado._CorreoElectrónico,

                FormaPago = formaPagoDescripcion,
                PlazoFormaPago = diasPlazo,
                TotalFormaPago = valorPago,
                UnidadFormaPago = "Días",

                Detalles = resultado.Detalles.Select(d => new DetalleFactura
                {
                    CodigoPrincipal = d._Tra_Codigo,
                    Cantidad = d._Tra_cantidad,
                    Descripcion = d._Tra_nombre,
                    PrecioUnitario = d._Tra_precuni,
                    Descuento = d._Tra_porcendes,
                    PrecioTotal = d._Tra_prectot,
                    Tra_porceniva = d._Tra_porceniva == 0 ? ivaVigente : d._Tra_porceniva
                }).ToList(),

                InformacionAdicional = "-",

                Subtotal0 = resultado._Doc_totsiva,
                Subtotal15 = resultado._Base15,
                Subtotal5 = resultado._Base5,
                SubtotalNoIva = 0,

                Descuento = resultado._totalDescuento,
                Ice = 0,

                Iva15 = resultado._Iva15,
                Iva5 = resultado._Iva5,

                ValorTotal = resultado._Doc_valor,

                LogoBase64 = imageBase64,

                IvaInfoList = ivaInfoList
            };

            try
            {
                var apiClient = new ApiClient();
                return apiClient.GenerarFactura(facturaRequest, fel.pathCpbGenerados, queClaveSRI, urlEs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR GENERANDO PDF:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                MessageBox.Show("Error generando PDF: " + ex.Message);
                return "";
            }
        }

        public string GenerarRide(decimal idclavedoc,string sucursal, string documento,decimal numero, string queClaveSRI, string urlEs)
        {
            string imageBase64 = aux.ObtenerLogoBase64(datosEmpresa.Emp_PathImagenes);

            // Ejecutar procedimiento
            var resultado = aux.EjecutarProcedimientoCabeceraYDetalle((int)idclavedoc, sucursal, documento, numero);

            // Obtener forma de pago
            var pago = aux.ObtenerPrimerPago(datosEmpresa.nombreBaseIvaret, datosEmpresa.suc, documento, (double)idclavedoc);

            string formaPagoDescripcion = pago?.nombreFpagoSri ?? "SIN UTILIZACION DEL SISTEMA FINANCIERO";
            int diasPlazo = pago?.diasPlazo ?? 0;
            decimal valorPago = pago?.Pag_Valor ?? 0;

            fel = new AdcFelec(datosEmpresa.strConxAdcom);
            fel = AdcFelec.Buscar("");
            //docImpuestos claseImpuestos = new docImpuestos();
            claseImpuestos.cargar(datosEmpresa.strConxIvaret, resultado._Doc_fecha);
            decimal ivaVigente = (decimal)claseImpuestos.impstoPorcentaje1;

            // Agrupar IVA dinámicamente
            var ivaAgrupado = resultado.Detalles
                .GroupBy(d => d._Tra_porceniva == 0 ? ivaVigente : d._Tra_porceniva)
                .Select(g =>
                {
                    decimal porcentaje = g.Key;
                    decimal baseImponible = g.Sum(x => x._Tra_prectot);
                    decimal iva = Math.Round(baseImponible * porcentaje / 100, 2);

                    return new
                    {
                        Porcentaje = porcentaje,
                        Base = baseImponible,
                        Iva = iva
                    };
                })
                .ToList();

            // Crear lista para el RIDE
            var ivaInfoList = ivaAgrupado
                .Where(x => x.Porcentaje > 0)
                .Select(x => new IvaInfo
                {
                    Porcentaje = x.Porcentaje,
                    Subtotal = x.Base,
                    Iva = x.Iva
                })
                .ToList();

            // Llenar campos tradicionales
            resultado._Base15 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 15)
                .Sum(x => x.Base);

            resultado._Iva15 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 15)
                .Sum(x => x.Iva);

            resultado._Base5 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 5)
                .Sum(x => x.Base);

            resultado._Iva5 = (double)ivaAgrupado
                .Where(x => x.Porcentaje == 5)
                .Sum(x => x.Iva);


            var facturaRequest = new FacturaRequest
            {
                RucEmisor = datosEmpresa.Emp_RUC,
                RazonSocialEmisor = datosEmpresa.Emp_Nombre,
                DireccionMatriz = datosEmpresa.Emp_Dirección,
                DireccionSucursal = datosEmpresa.Emp_Dirección,
                EmailEmisor = datosEmpresa.Emp_Email,
                TelefonoEmisor = datosEmpresa.Emp_Telefono_1,

                ObligadoContabilidad = Convert.ToBoolean(datosEmpresa.Emp_Conta),
                AgenteRetencion = datosEmpresa.Emp_AgeRet,
                NroCtrbuyteEspecial = datosEmpresa.Emp_ContrBuyEsp,
                Regimen = datosEmpresa.Emp_Regimen,

                NumeroFactura = resultado._Doc_NroIdDoc + "-" + resultado._Doc_numero.ToString("000000000"),
                NumeroAutorizacion = resultado._NroAutorizacionSri,

                FechaAutorizacion = resultado._fechaAutorizacion.HasValue
           ? resultado._fechaAutorizacion.Value.ToString("yyyy-MM-ddTHH:mm:ss")
           : null,

                Ambiente = resultado._tipAmbiente,
                TipoEmision = resultado._tipEmision,
                ClaveAcceso = resultado._claveAcceso,

                NombreCliente = resultado._Doc_NombreImp,
                IdentificacionCliente = resultado._Doc_CiRuc,
                FechaEmision = resultado._Doc_fecha.ToString("yyyy-MM-dd"),
                DireccionCliente = resultado._Doc_Direccion,
                TelefonoCliente = resultado._Doc_Telefono1,
                EmailCliente = resultado._CorreoElectrónico,

                FormaPago = formaPagoDescripcion,
                PlazoFormaPago = diasPlazo,
                TotalFormaPago = valorPago,
                UnidadFormaPago = "Días",

                Detalles = resultado.Detalles.Select(d => new DetalleFactura
                {
                    CodigoPrincipal = d._Tra_Codigo,
                    Cantidad = d._Tra_cantidad,
                    Descripcion = d._Tra_nombre,
                    PrecioUnitario = d._Tra_precuni,
                    Descuento = d._Tra_porcendes,
                    PrecioTotal = d._Tra_prectot,
                    Tra_porceniva = d._Tra_porceniva == 0 ? ivaVigente : d._Tra_porceniva
                }).ToList(),

                InformacionAdicional = "-",

                Subtotal0 = resultado._Doc_totsiva,
                Subtotal15 = resultado._Base15,
                Subtotal5 = resultado._Base5,
                SubtotalNoIva = 0,

                Descuento = resultado._totalDescuento,
                Ice = 0,

                Iva15 = resultado._Iva15,
                Iva5 = resultado._Iva5,

                ValorTotal = resultado._Doc_valor,

                LogoBase64 = imageBase64,

                IvaInfoList = ivaInfoList
            };

            try
            {
                var apiClient = new ApiClient();
                return apiClient.GenerarFactura(facturaRequest, fel.pathCpbGenerados, queClaveSRI, urlEs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR GENERANDO PDF:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                MessageBox.Show("Error generando PDF: " + ex.Message);
                return "";
            }
        }


    }
}
