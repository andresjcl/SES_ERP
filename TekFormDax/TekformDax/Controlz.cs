using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace TekFormDax
{
    class MovControl
    {
        public string tipoControl="";
        public Int32 IndiceCtrl = 0;
        public Int32 IniTop = 0;
        public Int32 IniLeft = 0;
        public Int32 IniWidht = 0;
        public Int32 IniHight = 0;

    }
    class Movimientos
    {
        static int ultimoMovimiento = 0;
        static public List<MovControl> MovControles = new List<MovControl> ();
        public static void grabarMovimiento(string tipoControl, Int32 Indice, Int32 TOP, Int32 LEFT, Int32 WIDTH, Int32 HEIGHT)
        {
            MovControl ElControl = new MovControl()
            {
                IndiceCtrl = Indice,
                IniHight = HEIGHT,
                IniLeft = LEFT,
                IniTop = TOP,
                IniWidht = WIDTH,
                tipoControl = tipoControl           
            };
            if (ultimoMovimiento < MovControles.Count) eliminarMovimientos();
            MovControles.Add(ElControl);
            ultimoMovimiento = MovControles.Count;
        }
        private static void eliminarMovimientos()
        {
            for ( Int32 i=ultimoMovimiento;i<MovControles.Count;i++)
            {
                MovControles.RemoveAt(i);
            }
        }
        public static void guardarMovimiento(Object sender)
        {
            Control EsControl;
            RectangleShape EsRectangulo;
            OvalShape EsOval;
            LineShape EsLinea;
            MovControl movimiento = new MovControl();
            
            if (sender is RectangleShape) 
            { 
                EsRectangulo = (RectangleShape)sender;             
                movimiento.tipoControl = EsRectangulo.Name.Substring(0, 4);
                movimiento.IndiceCtrl = Convert.ToInt32(EsRectangulo.Name.Substring(4));
                movimiento.IniHight = EsRectangulo.Height;
                movimiento.IniLeft = EsRectangulo.Left;
                movimiento.IniTop = EsRectangulo.Top;
                movimiento.IniWidht = EsRectangulo.Width;
            }
            else if (sender is OvalShape) 
            {
                EsOval = (OvalShape)sender;
                movimiento.tipoControl = EsOval.Name.Substring(0, 4);
                movimiento.IndiceCtrl = Convert.ToInt32(EsOval.Name.Substring(4));
                movimiento.IniHight = EsOval.Height;
                movimiento.IniLeft = EsOval.Left;
                movimiento.IniTop = EsOval.Top;
                movimiento.IniWidht = EsOval.Width;
            }
            else if (sender is LineShape) 
            { 
                EsLinea = (LineShape)sender;
                movimiento.tipoControl = EsLinea.Name.Substring(0, 4);
                movimiento.IndiceCtrl = Convert.ToInt32(EsLinea.Name.Substring(4));
                movimiento.IniTop = EsLinea.Y1;
                movimiento.IniHight = EsLinea.Y2;
                movimiento.IniLeft = EsLinea.X1;
                movimiento.IniWidht = EsLinea.X2;
            }
            else
            {
                try
                {
                    EsControl = (Control)sender;
                    movimiento.tipoControl = EsControl.Name.Substring(0, 4);
                    movimiento.IndiceCtrl = Convert.ToInt32(EsControl.Name.Substring(4));
                    movimiento.IniHight = EsControl.Height;
                    movimiento.IniLeft = EsControl.Left;
                    movimiento.IniTop = EsControl.Top;
                    movimiento.IniWidht = EsControl.Width;
                }
                catch { return; }
            }
            if (ultimoMovimiento < MovControles.Count) eliminarMovimientos();
            MovControles.Add(movimiento);
            ultimoMovimiento = MovControles.Count;
        }
        public static MovControl Deshacer()
        {
            if (ultimoMovimiento == 0) return null;
            ultimoMovimiento--;
            return MovControles[ultimoMovimiento++];
        }
        public static MovControl Rehacer()
        {
            if (ultimoMovimiento == MovControles.Count ) return null;
            ultimoMovimiento++;
            return MovControles[ultimoMovimiento--];
        }
    }

}
