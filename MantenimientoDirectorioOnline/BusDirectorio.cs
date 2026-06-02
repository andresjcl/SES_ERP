//using MantenimientoDirectorioOnline;
using System;
using System.Windows.Forms;

namespace MantenimientoDirectorioOnline
{
    public class BusDirectorio
{
    public string BusDirect(ref string codigo, ref string CEDULA, ref string Nombre, ref string NombreAlias, string Tipo = "", string ConNuevo = "")
    {
        string ElCodigo = "";
        Mainn();
        try
        {
            BuscaClien PROG = new BuscaClien();
            ElCodigo = PROG.IniBuscaCliOPro(Tipo, Nombre, NombreAlias, ConNuevo);
            PROG.Dispose();
        }
        catch (Exception ee)
        {
            MessageBox.Show("excepción busDirect: " + ee.Message);
        }
        return ElCodigo;
    }

    public string BusDirect(string codigo, string CEDULA, ref string Nombre, string NombreAlias, string Tipo = "", string ConNuevo = "", string neutro = "")
    {
        string ElCodigo = "";
        Mainn();
        try
        {
            BuscaClien PROG = new BuscaClien();
            ElCodigo = PROG.IniBuscaCliOPro(Tipo, Nombre, NombreAlias, ConNuevo);
            PROG.Dispose();
        }
        catch (Exception ee)
        {
            MessageBox.Show("excepción busDirect: " + ee.Message);
        }
        return ElCodigo;
    }

    public string BusDirect(string codigo, string cedula, string nombre, string nomAlias)
    {
        string ElCodigo = "";
        Mainn();
        try
        {
            BuscaClien PROG = new BuscaClien();
            ElCodigo = PROG.IniBuscaCliOPro("", nombre, nomAlias, "");
            PROG.Dispose();
        }
        catch (Exception ee)
        {
            MessageBox.Show("excepción busDirect: " + ee.Message);
        }
        return ElCodigo;
    }

    public void ManDir(ref string ConCodigo)
    {
        Mainn();
        DEEP01 PROG = new DEEP01();
        // PROG.Autorizacion = datosEmpresa.auto;
        if (ConCodigo == "&&")
        {
            PROG.QUECODIGO = "";
            PROG.IniciaNuevo();
        }
        else
        {
            PROG.QUECODIGO = ConCodigo;
            PROG.Show();
        }
    }

    private void Mainn()
    {
        // Implementación de Mainn si es necesaria
    }
}
}