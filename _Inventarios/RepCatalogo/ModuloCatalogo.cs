
namespace DaxInvent
{
    static class ModuloCatalogo
    {
        public static string ConsultaArt()
        {
            string art = "";
            var bus = new Buscar.frmBuscar();
            art = bus.Buscar(DattCom.datosEmpresa.strConxAdcom, "select Art_Codigo, Art_nombre, Art_unimed   from adcart ", "art_Codigo", "art_nombre", "Consulta", "Buscar Articulo");
            return art;
        }
    }
}