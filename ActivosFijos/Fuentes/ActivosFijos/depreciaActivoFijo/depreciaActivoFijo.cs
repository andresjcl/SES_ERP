using System;
using System.Collections.Generic;
using System.Data ;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace depreciaActivoFijo
{    
    public class depreciaActivoFijo
    {
        DateTime fechIni=new DateTime(1900,1,1);
        DateTime fechFin=new DateTime(1900,1,1);
        int[] proMes = new int[00];
        Int32[] proAño = new int[100];
        string strConxadcom = "";
        string usuario = "";
        Boolean esUltimoMes = false;
        
        public void calcularDepreciaciones(string strConx,string codigoActivo ,DateTime fechaLimInicio, DateTime fechaLimFin,string user)
        {
            strConxadcom = strConx;
            usuario = user;
            AdcAcf datosActivo = new AdcAcf(strConxadcom);
            datosActivo = AdcAcf.Buscar(" codigo = '" + codigoActivo + "'");
            if (datosActivo == null) return;

            if (datosActivo.TipoDepreciacionCont==1)  depreciacionLineal(datosActivo, fechaLimInicio, fechaLimFin,"F",strConx);
//            if (datosActivo.TipoDepreciacionCont == 1) depreciacionProduccion(datosActivo, fechaLimInicio, fechaLimFin, "F", strConx);
            if (datosActivo.TipoDepreciacionTributa == 1) depreciacionLineal(datosActivo, fechaLimInicio, fechaLimFin, "T", strConx);
        }

        public void depreciacionLineal(AdcAcf datosActivo,DateTime solicitaDepreFechaIni, DateTime solicitaDepreFechaFin,string solicitaTipoDepreciacion, string strConx)
        {            
            
            if ((datosActivo.FecSalida <= solicitaDepreFechaIni && datosActivo.FecSalida > Convert.ToDateTime("01/01/1900")) || datosActivo.FecIngreso >= solicitaDepreFechaFin) return;            

            // chequear si activo no puede ser depreciado en el periodo solicitado

            if (datosActivo.FecIngreso > solicitaDepreFechaFin || (datosActivo.FecSalida < solicitaDepreFechaIni && datosActivo.FecSalida > Convert.ToDateTime("01/01/1900"))) return;

            Int32 vidaUtil = Convert.ToInt32(datosActivo.VidaUtilCont);
            if (solicitaTipoDepreciacion == "T") vidaUtil = Convert.ToInt32(datosActivo.VidaUtilTributa);

            TimeSpan ts = new TimeSpan(-1, 0, 0, 0);

            DateTime fechaUltDepreActivo = new DateTime(datosActivo.FecIngreso.Year + vidaUtil, datosActivo.FecIngreso.Month, datosActivo.FecIngreso.Day);
            fechaUltDepreActivo += ts;
            if (fechaUltDepreActivo < solicitaDepreFechaIni) return;

            //...

            // establecer el período en que debe ser depreciado el activo

            DateTime periodoDeprFechIni = solicitaDepreFechaIni;
            DateTime periodoDeprFechFin = solicitaDepreFechaFin;

            if (datosActivo.FecSalida < Convert.ToDateTime("31/12/1900")) 
            {
                periodoDeprFechFin = fechaUltDepreActivo;
            }
            else
            {
                periodoDeprFechFin = datosActivo.FecSalida;
            }

            if (periodoDeprFechFin > solicitaDepreFechaFin) periodoDeprFechFin = solicitaDepreFechaFin;
            
            if (datosActivo.FecIngreso < solicitaDepreFechaIni) 
            {
                periodoDeprFechIni = solicitaDepreFechaIni;
            }
            else
            {
                periodoDeprFechIni = datosActivo.FecIngreso;
            }

            // .....

            //int añoIniDep = periodoDeprFechIni.Year;
            //int mesIniDep = periodoDeprFechIni.Month;
            //int diasIniDepr = periodoDeprFechIni.Day;

            //int añoFinDep = periodoDeprFechFin.Year;
            //int mesFinDep = periodoDeprFechFin.Month;
            //int diaFinDep = periodoDeprFechFin.Day;

            decimal depreciacionMes = 0;
            decimal CostoInicialActivo = datosActivo.CostoIngreso;
            decimal ValorResidualActivo = datosActivo.ValorResidual;


            DateTime fechaDeprecia = periodoDeprFechIni;
            decimal diasDeprecia = 30;
            decimal diasMes = 30;
            do 
            {                 
                esUltimoMes = false;
                if (fechaDeprecia.Year * 100 + fechaDeprecia.Month == fechaUltDepreActivo.Year *100 + fechaUltDepreActivo.Month) esUltimoMes = true;
                decimal valorDeprMensual = Math.Round(((CostoInicialActivo - ValorResidualActivo) / vidaUtil) / 12, 2);
                depreciacionMes = valorDeprMensual;
                diasDeprecia = 30;

                if (fechaDeprecia.Year * 100 + fechaDeprecia.Month == datosActivo.FecIngreso.Year * 100 + datosActivo.FecIngreso.Month)
                {
                    if (datosActivo.FecIngreso.Day > 29 || (datosActivo.FecIngreso.Day > 27 && datosActivo.FecIngreso.Month == 2))
                    { diasDeprecia = 0;}
                    else
                    {
                        diasDeprecia = 31 - datosActivo.FecIngreso.Day;
                    }
                    diasMes = (diasDeprecia / 30);
                    depreciacionMes =   valorDeprMensual * diasMes;
                    //depreciacion primer mes
                }
                else if (fechaDeprecia.Year == datosActivo.FecSalida.Year && fechaDeprecia.Month == datosActivo.FecSalida.Month)
                {
                    if (fechaUltDepreActivo.Day > 29 || (fechaUltDepreActivo.Day > 27 && fechaUltDepreActivo.Month == 2))
                        { diasDeprecia = 30;}
                    else { diasDeprecia = datosActivo.FecSalida.Day + 1; }
                    depreciacionMes = valorDeprMensual * (diasDeprecia/30);
                    //depreciacion del mes de salida
                }
                else if (fechaDeprecia.Year == fechaUltDepreActivo.Year && fechaDeprecia.Month == fechaUltDepreActivo.Month)
                {
                    if (datosActivo.FecSalida.Day > 29 || (datosActivo.FecSalida.Day > 27 && datosActivo.FecSalida.Month == 2))
                    { diasDeprecia = 30; }
                    else { diasDeprecia = datosActivo.FecSalida.Day + 1; }
                    depreciacionMes = valorDeprMensual * (diasDeprecia / 30);
                    //depreciacion del mes de salida
                }
                actualizarDepreciacion(datosActivo, fechaDeprecia.Year, fechaDeprecia.Month, solicitaTipoDepreciacion, depreciacionMes, Convert.ToInt32(diasDeprecia));
                fechaDeprecia = fechaDeprecia.AddMonths(1);
            }while ((fechaDeprecia.Year *  100 + fechaDeprecia.Month) <= (periodoDeprFechFin.Year * 100 + periodoDeprFechFin.Month));
        }
        private void actualizarDepreciacion(AdcAcf datosActivo, Int32 año, Int32 mes, string tipoDep, decimal valorDepreciacion,int diasDepreciados)
        {
            acfDatos acfAcuNvo = new acfDatos(strConxadcom, Convert.ToInt64( mes), Convert.ToInt64( año),datosActivo.Codigo);

            decimal acuDepreciacion = 0;
            decimal acuRevalorizacion = 0;
            decimal acuDeterioro = 0;

            if (tipoDep == "F")
            {
                acuDepreciacion = Convert.ToDecimal( acfAcuNvo.valDepreciacionAcuF);
                acuRevalorizacion = Convert.ToDecimal( acfAcuNvo.valRevalorizaAcuF);
                acuDeterioro = Convert.ToDecimal(acfAcuNvo.valDeterioroAcuF);
            }
            else
            {
                acuDepreciacion = Convert.ToDecimal(acfAcuNvo.valDepreciacionAcuT);
                acuRevalorizacion = Convert.ToDecimal(acfAcuNvo.valRevalorizaAcuT);
                acuDeterioro = Convert.ToDecimal(acfAcuNvo.valDeterioroAcuT);
            }

            long añoAcumula = año * 100 + mes - 1;
            if (mes == 1) añoAcumula = (año - 1 ) * 100 + 12;

            //calcularAcumulados(añoAcumula.ToString(), tipoDep, ref acuDepreciacion, ref acuDeterioro, ref acuRevalorizacion);

            AdcAcfDep datDepreciacion = leerDepreciaciones(datosActivo.Codigo, año, mes, tipoDep);
            if (esUltimoMes)
            {
                valorDepreciacion = Math.Round( datosActivo.CostoIngreso - datosActivo.ValorResidual - acuDepreciacion,2);
            }
            datDepreciacion.Codigo = datosActivo.Codigo;
            datDepreciacion.año = año;
            datDepreciacion.Mes = mes;
            datDepreciacion.ClaseDepreciacion = tipoDep;            
            datDepreciacion.DepreciacionMes = valorDepreciacion;
            datDepreciacion.NroDiasLiquidacion = diasDepreciados;
            datDepreciacion.AcumDepreciacion = acuDepreciacion;
            datDepreciacion.AcumDeterioro = acuDeterioro;
            datDepreciacion.AcumRevaloriizacion = acuRevalorizacion;
            datDepreciacion.FechaProceso = DateTime.Now;
            datDepreciacion.UsuarioProceso = usuario;

            datDepreciacion.Actualizar();

        }
        private AdcAcfDep leerDepreciaciones(string codigo, Int32 año, Int32 mes, string tipoDep)
        {
            AdcAcfDep dat = new AdcAcfDep(strConxadcom);            
            dat = AdcAcfDep.Buscar(" codigo = '" + codigo + "' and año =" + año.ToString() + " and mes = " + mes.ToString() + " and ClaseDepreciacion = '" + tipoDep + "'");
            if (dat == null) dat = new AdcAcfDep();
            return dat;
        }


        //private void mesesAliquidar(ref int[] prosAño, ref int[] prosMes)
        //{
        //    DateTime fechAux = fechIni;
        //    DateTime fechRest= new DateTime(0,1,0);
        //    Boolean i = true;            
        //    int P = 0;
        //    do
        //    {
        //        prosAño[P] = fechAux.Year;
        //        prosMes[P] = fechAux.Month;
        //        if (fechAux.Month == 12) 
        //            { fechAux = new DateTime(fechAux.Year + 1, 1, fechAux.Day); }
        //        else
        //            { fechAux = new DateTime(fechAux.Year,fechAux.Month + 1, fechAux.Day); }
        //    } while (fechAux <= fechFin);
        //}
    }
}
