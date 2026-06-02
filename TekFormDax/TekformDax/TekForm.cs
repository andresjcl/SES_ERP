using System;
using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using libreriasTekform;
namespace TekFormDax
{
    public partial class TekForm : Form
    {

        string TipoPintado = "";
        string NombreArchivo = "";
        bool verRecuadro = false;
        bool DebeGrabar = false;

        TextBox[] Etiquetas;
        PictureBox[] Imagenes;
        Label[] Datos;
        LineShape[] Lineas;
        OvalShape[] Circulos;
        RectangleShape[] Cuadrados;

        int IndEt = 0;
        int IndDat = 0;
        int IndIma = 0;
        int IndLin = 0;
        int IndCua = 0;
        int IndCir = 0;

        bool AlargandoAbajo;
        bool AlargandoArriba;
        bool AlargandoDerecha;
        bool AlargandoIzquierda;

        Object ControlActual;
        string tipoActual;
        int PY = 0;
        int PX = 0;

        Int32 IniMovX1 = 0;
        Int32 IniMovY1 = 0;

        Int32 IniTop = 0;
        Int32 IniLeft = 0;
        Int32 IniWidht = 0;
        Int32 IniHight = 0;



        byte ALinea = 0;
        bool moviendoControl = false;
        bool DibujandoLinea = false;

        propiedadesForma PropiedadesForm = new propiedadesForma();
        camposForma CamposDelFormato = new camposForma();
        GenDatos libtek = new libreriasTekform.GenDatos(SysEmpDatt.datosEmpresa.strConxDaxsys);
        public TekForm()
        {
            InitializeComponent();
        }

        #region INSERTAR ELEMENTOS NUEVOS 
        private void btnNvoDato_Click(object sender, EventArgs e)
        {
            DatoNuevo();
        }

        private void btnNuevaLinea_Click(object sender, EventArgs e)
        {
            LineaNueva();
        }
        private void btnNuevoCuadrado_Click(object sender, EventArgs e)
        {
            nuevoCuadrado();
        }

        private void btnNuevoCirculo_Click(object sender, EventArgs e)
        {
            nuevoCirculo();
        }

        private void btnNuevaImagen_Click(object sender, EventArgs e)
        {
            ImagenNueva();
        }

        private void btnNvaEtiqueta_Click(object sender, EventArgs e)
        {
            EtiquetaNueva();
        }

        private void EtiquetaNueva()
        {
            int Ex = -1;
            if (Etiquetas != null)
            {
                for (int i = 0; i < Etiquetas.Length; i++)
                {
                    if (Etiquetas[i].Visible == false) { Ex = i; break; }
                }
                if (Ex == -1)
                {
                    Array.Resize(ref Etiquetas, Etiquetas.Length + 1);
                    Ex = Etiquetas.Length - 1;
                }
            }
            else { Etiquetas = new TextBox[1]; Ex = 0; }

            IndEt = Ex;

            TextBox lab = new TextBox
            {
                AutoSize = false,
                Top = marcador.Top + IndEt * 20,
                Left = marcador.Left + IndEt * 5,
                Visible = true,
                Enabled = true,
                Text = "Etiq" + IndEt.ToString(),
                Name = "Etiq" + IndEt.ToString(),
                Width = 60,
                Height = 30,
                TextAlign = HorizontalAlignment.Left ,
                ForeColor = Color.Black,
                BackColor = Color.White,
                Multiline = true//,
                //MaxLength = 500
            };
            lab.Click += new System.EventHandler(this.Etiqueta_Click);
            lab.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
            lab.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

            Papel.Controls.Add(lab);
            Etiquetas[IndEt] = lab;
            ToolTip1.SetToolTip(lab, "Etiqueta " + IndEt.ToString());
            ControlActual = Etiquetas[IndEt];
            tipoActual = "Etiq";
            FijarBotonesMovimiento(ControlActual);
            marcador.Visible = false;
            Movimientos.guardarMovimiento(lab);
        }
        private void DatoNuevo()
        {
            int Ex = -1;
            if (Datos != null)
            {
                for (int i = 0; i < Datos.Length; i++)
                {
                    if (Datos[i].Visible == false) { Ex = i; break; }
                }
                if (Ex == -1)
                {
                    Array.Resize(ref Datos, Datos.Length + 1);
                    Ex = Datos.Length - 1;
                }
            }
            else { Datos = new Label[1]; Ex = 0; }

            IndDat = Ex;
            Label lab = new Label
            {
                FlatStyle = FlatStyle.Flat,
                AutoSize = false,
                Top = marcador.Top + IndDat * 20,
                Left = marcador.Left + IndDat * 5,
                Visible = true,
                Enabled = true,
                Text = "Dato" + IndDat.ToString(),
                Name = "Dato" + IndDat.ToString(),
                Width = 60,
                Height = 30,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };
            lab.Click += new System.EventHandler(this.Etiqueta_Click);
            lab.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
            lab.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

            Papel.Controls.Add(lab);
            Datos[IndDat] = lab;
            ToolTip1.SetToolTip(lab, "Dato " + IndDat.ToString());
            ControlActual = Datos[IndDat];
            tipoActual = "Dato";
            FijarBotonesMovimiento(ControlActual);
            marcador.Visible = false;
            Movimientos.guardarMovimiento(lab);
        }

        private void LineaNueva()
        {
            int Ex = -1;
            if (Lineas != null)
            {
                for (int i = 0; i < Lineas.Length; i++)
                {
                    if (Lineas[i].Visible == false) { Ex = i; break; }
                }
                if (Ex == -1)
                {
                    Array.Resize(ref Lineas, Lineas.Length + 1);
                    Ex = Lineas.Length - 1;
                }
            }
            else { Lineas = new LineShape[1]; Ex = 0; }

            IndLin = Ex;

            LineShape linea = new LineShape();
            linea.Parent = shapeContainer1;
            linea.X1 = marcador.Left;
            linea.Y1 = marcador.Top;
            linea.X2 = linea.X1 + 100;
            linea.Y2 = linea.Y1;
            linea.Visible = true;
            linea.Enabled = true;
            linea.Name = "Line" + IndLin.ToString();
            linea.BorderWidth = 1;
            linea.Click += new System.EventHandler(this.line0_Click);
            linea.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
            linea.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);
            Lineas[IndLin] = linea;
            ControlActual = null;
            tipoActual = "Line";
            marcador.Visible = false;
            FijarBtnMovimientoLinea(IndLin);
            moviendoControl = false;
            Movimientos.guardarMovimiento(linea);
        }

        private void nuevoCuadrado()
        {
            int Ex = -1;
            if (Cuadrados != null)
            {
                for (int i = 0; i < Cuadrados.Length; i++)
                {
                    if (Cuadrados[i].Visible == false) { Ex = i; break; }
                }
                if (Ex == -1)
                {
                    Array.Resize(ref Cuadrados, Cuadrados.Length + 1);
                    Ex = Cuadrados.Length - 1;
                }
            }
            else { Cuadrados = new RectangleShape[1]; Ex = 0; }

            IndCua = Ex;
            RectangleShape Cuadrado = new RectangleShape
            {
                Parent = shapeContainer1,
                Left = marcador.Left,
                Top = marcador.Top,
                Width = 50,
                Height = 50,
                Visible = true,
                Enabled = true,
                Name = "Cuad" + IndCua.ToString(),
                BorderWidth = 1,
            };
            Cuadrado.Click += new System.EventHandler(this.cuad0_Click);
            Cuadrado.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
            Cuadrado.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

            Cuadrados[IndCua] = Cuadrado;

            ControlActual = null;
            tipoActual = "Cuad";
            marcador.Visible = false;
            FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
            Movimientos.guardarMovimiento(Cuadrado);
        }

        private void nuevoCirculo()
        {
            int Ex = -1;
            if (Circulos != null)
            {
                for (int i = 0; i < Circulos.Length; i++)
                {
                    if (Circulos[i].Visible == false) { Ex = i; break; }
                }
                if (Ex == -1)
                {
                    Array.Resize(ref Circulos, Circulos.Length + 1);
                    Ex = Circulos.Length - 1;
                }
            }
            else { Circulos = new OvalShape[1]; Ex = 0; }

            IndCir = Ex;
            OvalShape Circulo = new OvalShape
            {
                Parent = shapeContainer1,
                Left = marcador.Left,
                Top = marcador.Top,
                Width = 50,
                Height = 50,
                Visible = true,
                Enabled = true,
                Name = "Circ" + IndCir.ToString(),
                BorderWidth = 1
            };
            Circulo.Click += new System.EventHandler(this.circ0_Click);
            Circulo.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
            Circulo.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

            Circulos[IndCir] = Circulo;
            ControlActual = null;
            tipoActual = "Circ";
            marcador.Visible = false;
            FijarBtnMovimientoCirculo(Circulos[IndCir]);
            Movimientos.guardarMovimiento(Circulo);
        }
        private void ImagenNueva()
        {
            string PathImagen = IngresaImagen();
            if (PathImagen.Length == 0) return;
            {
                int Ex = -1;
                if (Imagenes != null)
                {
                    for (int i = 0; i < Imagenes.Length; i++)
                    {
                        if (Imagenes[i].Visible == false) { Ex = i; break; }
                    }
                    if (Ex == -1)
                    {
                        Array.Resize(ref Imagenes, Imagenes.Length + 1);
                        Ex = Imagenes.Length - 1;
                    }
                }
                else { Imagenes = new PictureBox[1]; Ex = 0; }

                IndIma = Ex;
                {
                    PictureBox Imagen = new PictureBox();
                    Imagen.AutoSize = false;
                    Imagen.Top = marcador.Top + IndIma * 20;
                    Imagen.Left = marcador.Left + IndIma * 5;
                    Imagen.Visible = true;
                    Imagen.Enabled = true;
                    Imagen.Text = "Imag" + IndIma.ToString();
                    Imagen.Name = "Imag" + IndIma.ToString();
                    Imagen.Width = 60;
                    Imagen.Height = 30;
                    Imagen.Load(SysEmpDatt.datosEmpresa.Emp_PathImagenes + PathImagen);
                    Imagen.ForeColor = Color.Black;
                    Imagen.BackColor = Color.Transparent;
                    Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    Imagen.Click += new System.EventHandler(this.Etiqueta_Click);
                    Imagen.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                    Imagen.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

                    Papel.Controls.Add(Imagen);
                    ToolTip1.SetToolTip(Imagen, Imagen.Name);
                    Imagenes[IndIma] = Imagen;
                    ControlActual = Imagenes[IndIma];
                    tipoActual = "Imag";
                    FijarBotonesMovimiento(ControlActual);
                    marcador.Visible = false;
                    Movimientos.guardarMovimiento(Imagen);
                }
            }
        }

        #endregion Crear elementos nuevos

        #region ACTIVAR ELEMENTO  SELECCIONADO
        private void Etiqueta_Click(object sender, EventArgs e)
        {
            //if (AlargaDerecha.Visible == true) return;

            ControlActual = (Control)sender;
            tipoActual = ((Control)sender).Name.Substring(0, 4);
            switch (tipoActual)
            {
                case "Etiq":
                    IndEt = Convert.ToInt32(((Control)sender).Name.Substring(4));
                    break;
                case "Dato":
                    IndDat = Convert.ToInt32(((Control)sender).Name.Substring(4));
                    break;
                case "Imag":
                    IndIma = Convert.ToInt32(((Control)sender).Name.Substring(4));
                    break;
                default:
                    break;
            }

            FijarBotonesMovimiento(sender);
        }
        private void cuad0_Click(object sender, EventArgs e)
        {
            ControlActual = null;
            tipoActual = ((RectangleShape)sender).Name.Substring(0, 4);
            IndCua = Convert.ToInt32(((RectangleShape)sender).Name.Substring(4));
            FijarBtnMovimientoCuadrado(sender);
        }

        private void circ0_Click(object sender, EventArgs e)
        {
            ControlActual = null;
            tipoActual = ((OvalShape)sender).Name.Substring(0, 4);
            IndCir = Convert.ToInt32(((OvalShape)sender).Name.Substring(4));
            FijarBtnMovimientoCirculo(sender);
        }

        private void line0_Click(object sender, EventArgs e)
        {
            ControlActual = null;
            tipoActual = ((LineShape)sender).Name.Substring(0, 4);
            IndLin = Convert.ToInt32(((LineShape)sender).Name.Substring(4));
            FijarBtnMovimientoLinea(IndLin);
        }

        #endregion Activar control elegido
        private ContentAlignment alineacion(int valor)
        {
            if (valor == 0) return ContentAlignment.MiddleCenter;
            if (valor == 1) return ContentAlignment.MiddleRight;
            return ContentAlignment.MiddleLeft;
        }
        private HorizontalAlignment AlineaTxt(int valor)
        {
            if (valor == 0) return HorizontalAlignment.Center;
            if (valor == 1) return HorizontalAlignment.Right;
            return HorizontalAlignment.Left;
        }
        private void FijarBotonesMovimiento(object source)
        {
            Control Source = (Control)source;
            AlargaIzquierda.Top = Source.Top + Source.Height / 2 - AlargaIzquierda.Height / 2;
            AlargaIzquierda.Left = Source.Left - AlargaIzquierda.Width;
            AlargaIzquierda.Visible = true;

            AlargaSuperior.Top = Source.Top - AlargaSuperior.Height;
            AlargaSuperior.Left = Source.Left + Source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaSuperior.Visible = true;

            AlargaDerecha.Top = Source.Top + Source.Height / 2 - AlargaDerecha.Height / 2;
            AlargaDerecha.Left = Source.Left + Source.Width;
            AlargaDerecha.Visible = true;

            AlargaInferior.Top = Source.Top + Source.Height;
            AlargaInferior.Left = Source.Left + Source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaInferior.Visible = true;

            //BtnMovimiento.Top = Source.Top - BtnMovimiento.Height;
            //BtnMovimiento.Left = Source.Left - BtnMovimiento.Width;
            //BtnMovimiento.Visible = true;
            //BtnMovimiento.Enabled = true;

            //try
            //{
            //    Source.BorderStyle = BorderStyle.FixedSingle;
            //}
            //catch { }
        }


        //'			Select Case Source.Name
        //'				Case "Linea"
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(4).Text = "Linea" & "-" & Source.index
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.Y2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.X2. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.Y1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.X1. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(5).Text = "Posicion: X1=" & System.Math.Round(Source.X1 / paso, 2) & "  " & "Y1=" & System.Math.Round(Source.Y1 / paso, 2) & " , " & "X2=" & System.Math.Round(Source.X2 / paso, 2) & "  " & "Y2=" & System.Math.Round(Source.Y2 / paso, 2) & " centimetros "
        //'				Case "Etiqueta"
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(4).Text = "Etiqueta" & "-" & Source.index
        //'					'Source.BorderStyle = 1
        //'				Case "Imagen"
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(4).Text = "Imagen" & "-" & Source.index
        //'					'Source.BorderStyle = 1
        //'				Case "Dato"
        //'					a = Source.Text
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(4).Text = GenDatox.QUENOMBRE(a)
        //'					'Source.BorderStyle = 1
        //'				Case "CuadradoR"
        //'					'UPGRADE_WARNING: Couldn't resolve default property of object Source.index. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //'					'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'					.BarraEstado.Items.Item(4).Text = "Cuadrado" & "-" & Source.index
        //'					'.BarraEstado.Panels(5).Text = "Posicion: X1=" & Round(.Left, 2) & "  " & "Y1=" & Round(.Top, 2) & " , " & "X2=" & Round(.Left + .Width, 2) & "  " & "Y2=" & Round(.Top + .Height, 2) & " centimetros "
        //'					'If index = 0 Then Stop
        //'					MarCuad(index).Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Source.Top))
        //'					MarCuad(index).Left = Source.Left))
        //'					MarCuad(index).Visible = True
        //'					MarCuad(index).Enabled = True

        //'			End Select
        //'			If Source.Name <> "Linea" Then
        //'				'UPGRADE_WARNING: Lower bound of collection DisForma.BarraEstado.Panels has changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
        //'				.BarraEstado.Items.Item(5).Text = "Posicion: X=" & System.Math.Round(VB6.PixelsToTwipsX(Source.Left) / paso, 2) & "  " & "Y=" & System.Math.Round(VB6.PixelsToTwipsY(Source.Top) / paso, 2) & "  " & "Medidas: Ancho =" & System.Math.Round(VB6.PixelsToTwipsX(Source.Width) / paso, 2) & "  " & "Alto =" & System.Math.Round(VB6.PixelsToTwipsY(Source.Height) / paso, 2) & " centimetros "
        //'			End If
        //'		End With
        //'		PorGrabar = True
        //'		PonerBotones(PorGrabar, False)
        //'	}

        private void FijarBtnMovimientoLinea(Int32 index)
        {
            string a = "";
            AlargaIzquierda.Top = Lineas[index].Y1 - AlargaIzquierda.Height / 2;
            AlargaIzquierda.Left = Lineas[index].X1 - AlargaIzquierda.Width / 2;
            AlargaIzquierda.Visible = true;

            AlargaDerecha.Top = Lineas[index].Y2 - AlargaDerecha.Height / 2;
            AlargaDerecha.Left = Lineas[index].X2 - AlargaDerecha.Width / 2; ;
            AlargaDerecha.Visible = true;

            AlargaSuperior.Visible = false;
            AlargaInferior.Visible = false;

            BtnMovimiento.Top = ((Lineas[index].Y1 + Lineas[index].Y2) / 2) - (BtnMovimiento.Height / 2);
            BtnMovimiento.Left = ((Lineas[index].X1 + Lineas[index].X2) / 2) - (BtnMovimiento.Width / 2);
            BtnMovimiento.Visible = true;
            BtnMovimiento.Enabled = true;
        }

        private void Papel_DoubleClick(object sender, EventArgs e)
        {
            marcador.Top = PY - marcador.Height / 2;
            marcador.Left = PX - marcador.Width / 2;
            marcador.Visible = true;
        }

        //private void Papel_MouseDown(object sender, MouseEventArgs e)
        //{
        //if (Papel.Cursor == Cursors.Cross)
        //{
        //    Lineas[IndLin].X1 = PX;
        //    Lineas[IndLin].Y1 = PY;
        //    Lineas[IndLin].X2 = PX;
        //    Lineas[IndLin].Y2 = PY;
        //    Lineas[IndLin].Visible = true;
        //    DibujandoLinea = true;
        //    ControlActual = null;
        //}
        //else if (Papel.Cursor == Cursors.Arrow)
        //{
        //    Cubridor.Top = PY;
        //    Cubridor.Left = PX;
        //    Cubridor.Visible = true;
        //    posIniSeleccionador = PY;
        //    colIniSeleccionador = PX;
        //}
        //}
        private void Papel_MouseMove(object sender, MouseEventArgs e)
        {
            PX = e.X;
            PY = e.Y;

        }
        private void Papel_MouseUp(object sender, MouseEventArgs e)
        {

            if (Papel.Cursor != Cursors.Arrow)
            {
                Papel.Cursor = Cursors.Arrow;
                DibujandoLinea = false;
                //poneralargadorlinea((IndLin))
            }
            Cubridor.Visible = false;
            Cubridor.Height = 5;
            Cubridor.Width = 5;
        }
        private void BorrarBotonesMovimiento()
        {
            AlargaIzquierda.Visible = false;
            AlargaSuperior.Visible = false;
            AlargaDerecha.Visible = false;
            AlargaInferior.Visible = false;
            BtnMovimiento.Visible = false;
        }
        private void BorrarPintados()
        {

        }
        private void CambiaPintura(Control Source, string QuePinto)
        {

            if (Source.Name.Substring(0, 4) == "Dato" && QuePinto == "E") return;
            if (Source.Name.Substring(0, 8) == "Etiqueta" && QuePinto == "D") return;
            //  UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime.Click for more: ms - help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"

            //  If Source.BackStyle = 0 Then

            //      UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime.Click for more: ms - help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"

            //     Source.BackStyle = 1

            //     Source.BackColor = System.Drawing.ColorTranslator.FromOle(&H808000)

            //     TotPintados = TotPintados + 1

            //     If TotPintados = 1 Then

            //         If Source.Name = "Dato" Then QuePinto = "D"

            //         If Source.Name = "Etiqueta" Then QuePinto = "E"

            //     End If

            // Else

            //     UPGRADE_ISSUE: Label property Source.BackStyle is not supported at runtime.Click for more: ms - help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="74E732F3-CAD8-417B-8BC9-C205714BB4A7"

            //    Source.BackStyle = 0

            //    TotPintados = TotPintados - 1

            //    If TotPintados = 0 Then QuePinto = ""

            //End If


        }

        private void BtnMovimiento_MouseDown(object sender, MouseEventArgs e)
        {
            
            IniMovX1 = e.X;
            IniMovY1 = e.Y;
            

            if (sender is RectangleShape) { cuad0_Click(sender, e); }
            else if (sender is OvalShape) { circ0_Click(sender, e); }
            else if (sender is LineShape) { line0_Click(sender, e); }
            else if (((Control)sender).Name != "BtnMovimiento") { Etiqueta_Click(sender, e); }

            BorrarBotonesMovimiento();
            moviendoControl = true;

            switch (tipoActual)
            {
                case "Etiq":
                    Etiquetas[IndEt].BorderStyle = BorderStyle.FixedSingle;
                    Etiquetas[IndEt].BringToFront();
                    break;
                case "Dato":
                    Datos[IndDat].BorderStyle = BorderStyle.FixedSingle;
                    Datos[IndDat].BringToFront();
                    break;
                case "Imag":
                    Imagenes[IndIma].BorderStyle = BorderStyle.FixedSingle;
                    break;
                case "Line":
                    Lineas[IndLin].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case "Cuad":
                    Cuadrados[IndCua].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case "Circ":
                    Circulos[IndCir].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                default:
                    break;
            }
            GuardarValoresAntesMoverControl();
        }

        private void BtnMovimiento_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (tipoActual == "Etiq")
                {
                    Etiquetas[IndEt].Top = e.Y + Etiquetas[IndEt].Top - IniMovY1;
                    Etiquetas[IndEt].Left = e.X + Etiquetas[IndEt].Left - IniMovX1;
                }
                if (tipoActual == "Dato")
                {
                    Datos[IndDat].Top = e.Y + Datos[IndDat].Top - IniMovY1;
                    Datos[IndDat].Left = e.X + Datos[IndDat].Left - IniMovX1;
                }
                if (tipoActual == "Imag")
                {
                    Imagenes[IndIma].Top = e.Y + Imagenes[IndIma].Top - IniMovY1;
                    Imagenes[IndIma].Left = e.X + Imagenes[IndIma].Left - IniMovX1;
                }
                if (tipoActual == "Line")
                {
                    Int32 movTop = e.Y + BtnMovimiento.Top - IniMovY1;
                    Int32 movLeft = e.X + BtnMovimiento.Left - IniMovX1;
                    BtnMovimiento.Top = movTop;
                    BtnMovimiento.Left = movLeft;
                    Lineas[IndLin].Y1 = e.Y + Lineas[IndLin].Y1 - IniMovY1; ;
                    Lineas[IndLin].X1 = e.X + Lineas[IndLin].X1 - IniMovX1; ;
                    Lineas[IndLin].Y2 = e.Y + Lineas[IndLin].Y2 - IniMovY1; ;
                    Lineas[IndLin].X2 = e.X + Lineas[IndLin].X2 - IniMovX1; ;
                }
                if (tipoActual == "Cuad")
                {
                    Cuadrados[IndCua].Top = e.Y + Cuadrados[IndCua].Top - IniMovY1;
                    Cuadrados[IndCua].Left = e.X + Cuadrados[IndCua].Left - IniMovX1;
                }
                if (tipoActual == "Circ")
                {
                    Circulos[IndCir].Top = e.Y + Circulos[IndCir].Top - IniMovY1;
                    Circulos[IndCir].Left = e.X + Circulos[IndCir].Left - IniMovX1;
                }
            }
        }

        private void BtnMovimiento_MouseUp(object sender, MouseEventArgs e)
        {
            if (moviendoControl)
            {
                moviendoControl = false;
                switch (tipoActual)
                {
                    case "Etiq":
                        Etiquetas[IndEt].BorderStyle = BorderStyle.FixedSingle;
                        FijarBotonesMovimiento(Etiquetas[IndEt]);
                        break;
                    case "Dato":
                        Datos[IndDat].BorderStyle = BorderStyle.FixedSingle;
                        FijarBotonesMovimiento(Datos[IndDat]);
                        break;
                    case "Imag":
                        Imagenes[IndIma].BorderStyle = BorderStyle.FixedSingle;
                        FijarBotonesMovimiento(Imagenes[IndIma]);
                        break;
                    case "Line":
                        Lineas[IndLin].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        FijarBtnMovimientoLinea(IndLin);
                        break;
                    case "Cuad":
                        Cuadrados[IndCua].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
                        break;
                    case "Circ":
                        Circulos[IndCir].BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                        FijarBtnMovimientoCirculo(Circulos[IndCir]);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Etiqueta_DoubleClick(object sender, EventArgs e)
        {
            //string a = inputDialogo.inputDialogo.ingresar("TEKFORM - Generador de formatos de impresión", "Registrar Texto para la etiqueta", ((Label)sender).Text);
            //if (a.Length == 0) ((Label)sender).Text = ((Label)sender).Name;
            //else ((Label)sender).Text = a;
            //FijarBotonesMovimiento(sender);
        }

        private void detiqueta_Click(object sender, EventArgs e)
        {
            EtiquetaNueva();
        }


        #region ALARGAR CONTROLES
        private void Alarga_MouseDown(object sender, MouseEventArgs e)
        {
            IniMovX1 = e.X;
            IniMovY1 = e.Y;
            AlargandoArriba = (((Control)sender).Name == "AlargaSuperior");
            AlargandoAbajo = (((Control)sender).Name == "AlargaInferior");
            AlargandoIzquierda = (((Control)sender).Name == "AlargaIzquierda");
            AlargandoDerecha = (((Control)sender).Name == "AlargaDerecha");
            Movimientos.guardarMovimiento(sender);
        }
        private void Alarga_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (AlargandoIzquierda)
            {
                switch (tipoActual)
                {
                    case "Etiq":
                        Etiquetas[IndEt].Left += e.X;
                        Etiquetas[IndEt].Width -= e.X;
                        FijarBotonesMovimiento(Etiquetas[IndEt]);
                        break;
                    case "Dato":
                        Datos[IndDat].Left += e.X;
                        Datos[IndDat].Width -= e.X;
                        FijarBotonesMovimiento(Datos[IndDat]);
                        break;
                    case "Imag":
                        Imagenes[IndIma].Left += e.X;
                        Imagenes[IndIma].Width -= e.X;
                        FijarBotonesMovimiento(Imagenes[IndIma]);
                        break;
                    case "Line":
                        Lineas[IndLin].X1 += e.X;
                        Lineas[IndLin].Y1 += e.Y;
                        FijarBtnMovimientoLinea(IndLin);
                        break;
                    case "Cuad":
                        Cuadrados[IndCua].Left += e.X;
                        Cuadrados[IndCua].Width -= e.X;
                        FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
                        break;
                    case "Circ":
                        Circulos[IndCir].Left += e.X;
                        Circulos[IndCir].Width -= e.X;
                        FijarBtnMovimientoCirculo(Circulos[IndCir]);
                        break;
                    default:
                        break;
                }
            }
            else if (AlargandoDerecha)
            {

                switch (tipoActual)
                {
                    case "Etiq":
                        Etiquetas[IndEt].Width += e.X;
                        FijarBotonesMovimiento(Etiquetas[IndEt]);
                        break;
                    case "Dato":
                        Datos[IndDat].Width += e.X;
                        FijarBotonesMovimiento(Datos[IndDat]);
                        break;
                    case "Imag":
                        Imagenes[IndIma].Width += e.X;
                        FijarBotonesMovimiento(Imagenes[IndIma]);
                        break;
                    case "Line":
                        Lineas[IndLin].X2 += e.X;
                        Lineas[IndLin].Y2 += e.Y;
                        FijarBtnMovimientoLinea(IndLin);
                        break;
                    case "Cuad":
                        Cuadrados[IndCua].Width += e.X;
                        FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
                        break;
                    case "Circ":
                        Circulos[IndCir].Width += e.X;
                        FijarBtnMovimientoCirculo(Circulos[IndCir]);
                        break;
                    default:
                        break;
                }
            }
            else if (AlargandoAbajo)
            {

                switch (tipoActual)
                {
                    case "Etiq":
                        Etiquetas[IndEt].Height += e.Y;
                        FijarBotonesMovimiento(Etiquetas[IndEt]);
                        break;
                    case "Dato":
                        Datos[IndDat].Height += e.Y;
                        FijarBotonesMovimiento(Datos[IndDat]);
                        break;
                    case "Imag":
                        Imagenes[IndIma].Height += e.Y;
                        FijarBotonesMovimiento(Imagenes[IndIma]);
                        break;
                    case "Line":
                        Lineas[IndLin].X2 += e.X;
                        Lineas[IndLin].Y2 += e.Y;
                        FijarBtnMovimientoLinea(IndLin);
                        break;
                    case "Cuad":
                        Cuadrados[IndCua].Height += e.Y;
                        FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
                        break;
                    case "Circ":
                        Circulos[IndCir].Height += e.Y;
                        FijarBtnMovimientoCirculo(Circulos[IndCir]);
                        break;
                    default:
                        break;
                }

            }
            else if (AlargandoArriba)
            {

                switch (tipoActual)
                {
                    case "Etiq":
                        Etiquetas[IndEt].Top += e.Y;
                        Etiquetas[IndEt].Height -= e.Y;
                        FijarBotonesMovimiento(Etiquetas[IndEt]);
                        break;
                    case "Dato":
                        Datos[IndDat].Top += e.Y;
                        Datos[IndDat].Height -= e.Y;
                        FijarBotonesMovimiento(Datos[IndDat]);
                        break;
                    case "Imag":
                        Imagenes[IndIma].Top += e.Y;
                        Imagenes[IndIma].Height -= e.Y;
                        FijarBotonesMovimiento(Imagenes[IndIma]);
                        break;
                    case "Cuad":
                        Cuadrados[IndCua].Top += e.Y;
                        Cuadrados[IndCua].Height -= e.Y;
                        FijarBtnMovimientoCuadrado(Cuadrados[IndCua]);
                        break;
                    case "Circ":
                        Circulos[IndCir].Top += e.Y;
                        Circulos[IndCir].Height -= e.Y;
                        FijarBtnMovimientoCirculo(Circulos[IndCir]);
                        break;
                    default:
                        break;
                }
            }

            #endregion  ALARGAR CONTROLES
        }

        private void Alarga_MouseUp(object sender, MouseEventArgs e)
        {
            AlargandoAbajo = false;
            AlargandoArriba = false;
            AlargandoDerecha = false;
            AlargandoIzquierda = false;
            //if (verRecuadro) ((Label)ControlActual).BorderStyle = BorderStyle.FixedSingle;
            //else ((Label)ControlActual).BorderStyle = BorderStyle.None;
            //FijarBotonesMovimiento(ControlActual);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma iniciar un nuevo fromato ?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
            borrarElementos();
        }
        private void borrarElementos()
        {

            if (Etiquetas != null)
            {

                foreach (TextBox lab in Etiquetas)
                {
                    lab.Dispose();
                };
            }
            if (Datos != null)
            {
                foreach (Label lab in Datos)
                {
                    lab.Dispose();
                };
            }
            if (Imagenes != null)
            {

                foreach (PictureBox ima in Imagenes)
                {
                    ima.Dispose();
                };
            }
            if (Lineas != null)
            {

                foreach (LineShape lin in Lineas)
                {
                    lin.Dispose();
                };
            }
            if (Cuadrados != null)
            {

                foreach (RectangleShape rec in Cuadrados)
                {
                    rec.Dispose();
                };
            }
            if (Circulos != null)
            {

                foreach (OvalShape ova in Circulos)
                {
                    ova.Dispose();
                };
            }
            Etiquetas = new TextBox[0];
            Datos = new Label[0];
            Imagenes = new PictureBox[0];
            Lineas = new LineShape[0];
            Cuadrados = new RectangleShape[0];
            Circulos = new OvalShape[0];
            BorrarBotonesMovimiento();
        }

        private void AbrirFormato()
        {
            string nom;
            if (DebeGrabar)
            {
                //if (MessageBox.Show("Desea grabar el registro actual ? " + NombreArchivo, "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //    mnuFileSave_Click();
            }
            nom = VerNombre("O");
            if (nom.Length == 0) return;
            if (MessageBox.Show("Confirma abrir el formato: \n" + nom, "", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                CargarArchivo(nom);
            }
            //PonerBotones(false, false);
        }
        private string VerNombre(string Q)
        {
            BuscarFormatos prog = new BuscarFormatos(SysEmpDatt.datosEmpresa.strConxAdcom);
            return prog.BuscarFormato("");
        }
        //private string SoloNombre(string Archivo)
        //{
        //    int j = 0;
        //    for (int i = 0; i < Archivo.Length; i++)
        //    {
        //        if (Archivo.Substring(i, 1) == "\\" || Archivo.Substring(i, 1) == "/")
        //        { j = i; }
        //    }
        //    return Archivo.Substring(j + 1);
        //}
        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            AcercaDeTekForm prog = new AcercaDeTekForm();
            prog.ShowDialog();
            prog.Dispose();
        }
        private void FijarBtnMovimientoCuadrado(object Source)
        {
            RectangleShape source = (RectangleShape)Source;
            string a = "";
            AlargaIzquierda.Top = source.Top + source.Height / 2 - AlargaIzquierda.Height / 2;
            AlargaIzquierda.Left = source.Left - AlargaIzquierda.Width;
            AlargaIzquierda.Visible = true;

            AlargaSuperior.Top = source.Top - AlargaSuperior.Height;
            AlargaSuperior.Left = source.Left + source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaSuperior.Visible = true;

            AlargaDerecha.Top = source.Top + source.Height / 2 - AlargaDerecha.Height / 2;
            AlargaDerecha.Left = source.Left + source.Width;
            AlargaDerecha.Visible = true;

            AlargaInferior.Top = source.Top + source.Height;
            AlargaInferior.Left = source.Left + source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaInferior.Visible = true;

            //BtnMovimiento.Top = source.Top - BtnMovimiento.Height;
            //BtnMovimiento.Left = source.Left - BtnMovimiento.Width - 1;
            //BtnMovimiento.Enabled = true;
            //BtnMovimiento.Visible = false;
        }
        private void FijarBtnMovimientoCirculo(object Source)
        {
            OvalShape source = (OvalShape)Source;
            string a = "";
            AlargaIzquierda.Top = source.Top + source.Height / 2 - AlargaIzquierda.Height / 2;
            AlargaIzquierda.Left = source.Left - AlargaIzquierda.Width;
            AlargaIzquierda.Visible = true;

            AlargaSuperior.Top = source.Top - AlargaSuperior.Height;
            AlargaSuperior.Left = source.Left + source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaSuperior.Visible = true;

            AlargaDerecha.Top = source.Top + source.Height / 2 - AlargaDerecha.Height / 2;
            AlargaDerecha.Left = source.Left + source.Width;
            AlargaDerecha.Visible = true;

            AlargaInferior.Top = source.Top + source.Height;
            AlargaInferior.Left = source.Left + source.Width / 2 - AlargaSuperior.Width / 2;
            AlargaInferior.Visible = true;

            //BtnMovimiento.Top = source.Top - BtnMovimiento.Height;
            //BtnMovimiento.Left = source.Left - BtnMovimiento.Width - 1;
            //BtnMovimiento.Visible = true;
            //BtnMovimiento.Enabled = true;
        }
        private string IngresaImagen()
        {
            string PathImagen = "";
            string nombreImagen = "";
            OpenFileDialog abrirImagen = new OpenFileDialog();
            abrirImagen.Title = "Ecojer Imagen ";
            abrirImagen.InitialDirectory = SysEmpDatt.datosEmpresa.Emp_PathImagenes;
            abrirImagen.Filter = "Imágenes (*.bmp;*.ico;*.jpg)|*.bmp;*.ico;*.jpg";
            abrirImagen.ShowDialog();
            PathImagen = abrirImagen.FileName;
            nombreImagen = abrirImagen.SafeFileName;
            nombreImagen = null;
            abrirImagen.Dispose();
            try
            {
                if (PathImagen.Length > 0) File.Copy(PathImagen, SysEmpDatt.datosEmpresa.Emp_PathImagenes + nombreImagen, true);
            }
            catch (Exception ee) { MessageBox.Show("Error : \n" + ee.Message); }
            return nombreImagen +"";
        }

        private void Papel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            AbrirFormato();
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            AbrirFormato();
        }
        private bool LeerPropiedadesFormato(string Formato)
        {
            bool resp = true;

            string ssql = "select * from sysforms where l0='" + Formato + "' and s1 = 'A'";
            DataTable dt = SysEmpDatt.SqlDatos.leerTablaAdcom(ssql);

            if (dt.Rows.Count == 0)
            {
                resp = false;
            }
            else
            {
                leerDefinicionFormato.LeerPropiedades(dt.Rows[0]["l1"].ToString(), ref PropiedadesForm);
            }
            return resp;
        }

        private void CargarArchivo(string formato)
        {
            if (LeerPropiedadesFormato(formato) == false)
            {
                MessageBox.Show("El formato solicitado " + formato + " no existe ");
                return;
            }
            DataTable rs = SysEmpDatt.SqlDatos.leerTablaAdcom("select * from sysforms where l0 = '" + formato + "'  and S1 <> 'A' order by S1 ");
            borrarElementos();

            Papel.Width = PropiedadesForm.APapel;
            Papel.Height = PropiedadesForm.Lpapel;
            string Version = "";
            try { rs.Rows[0]["Version"].ToString(); } catch { }

            foreach (DataRow row in rs.Rows)
            {
                leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref CamposDelFormato, 0, Version);
                switch (row["S1"].ToString())
                {
                    case "D":
                        {
                            Label Dato = new Label();
                            {                                
                                Dato.Visible = true;
                                Dato.Enabled = true;
                                Dato.ForeColor = Color.Black;
                                Dato.BackColor = Color.White;
                                Dato.Top =  CamposDelFormato.Ftop;
                                Dato.Left = CamposDelFormato.FLeft;
                                Dato.Height = CamposDelFormato.FHeight;
                                Dato.Width = CamposDelFormato.FWidth;
                                Dato.Text = CamposDelFormato.Valor;
                                FontStyle fs = new FontStyle();

                                //Microsoft Sans Serif; 8.25pt; style = Bold, Italic, Underline
                                //Microsoft Sans Serif; 8.25pt
//                                FontFamily FF = new FontFamily(ChequearFonts(CamposDelFormato.FontNombre));
                                string NomFont = ChequearFonts(CamposDelFormato.FontNombre);
                                Font ffont = new Font(NomFont,CamposDelFormato.FontSize,FontStyle.Regular);
                                if(CamposDelFormato.FontEnNegrita == 1) ffont = new Font(ffont, FontStyle.Bold);
                                if (CamposDelFormato.FontItalica == 1) ffont = new Font(ffont, FontStyle.Italic);
                                if (CamposDelFormato.FontSubrayada == 1) ffont = new Font(ffont, FontStyle.Underline);
                                Dato.Font = ffont;
                                Dato.TextAlign = alineacion(ALinea);
                                Dato.Name = "Dato" + Etiquetas.Length.ToString();

                                //Dato.DataField = Numlin;
                                //Dato.DataMember = NumHor;
                            }

                            Dato.Click += new System.EventHandler(this.Etiqueta_Click);
                            Dato.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                            Dato.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

                            Papel.Controls.Add(Dato);

                            Array.Resize(ref Datos, Datos.Length + 1);
                            Datos[Datos.Length - 1] = Dato;
                            break;
                        }

                    case "E":
                        {
                            TextBox Etiqueta = new TextBox();
                            {
                                Etiqueta.Visible = true;
                                Etiqueta.Enabled = true;
                                Etiqueta.ForeColor = Color.Black;
                                Etiqueta.BackColor = Color.White;
                                Etiqueta.Top = CamposDelFormato.Ftop;
                                Etiqueta.Left = CamposDelFormato.FLeft;
                                Etiqueta.Height = CamposDelFormato.FHeight;
                                Etiqueta.Width = CamposDelFormato.FWidth;
                                Etiqueta.Text = CamposDelFormato.Valor;
                                FontFamily FF = new FontFamily(ChequearFonts(CamposDelFormato.FontNombre));
                                Font ffont = new Font(FF, CamposDelFormato.FontSize, FontStyle.Regular);
                                if (CamposDelFormato.FontEnNegrita == 1) ffont = new Font(ffont, FontStyle.Bold);
                                if (CamposDelFormato.FontItalica == 1) ffont = new Font(ffont, FontStyle.Italic);
                                if (CamposDelFormato.FontSubrayada == 1) ffont = new Font(ffont, FontStyle.Underline);
                                Etiqueta.Font = ffont;
                                Etiqueta.TextAlign = AlineaTxt(ALinea);
                                Etiqueta.Name = "Etiq" + Etiquetas.Length.ToString();
                                Etiqueta.Multiline = true;
                                Etiqueta.MaxLength = 500;

                                Etiqueta.Click += new System.EventHandler(this.Etiqueta_Click);
                                Etiqueta.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                                Etiqueta.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

                                Papel.Controls.Add(Etiqueta);

                                Array.Resize(ref Etiquetas, Etiquetas.Length + 1);
                                Etiquetas[Etiquetas.Length - 1] = Etiqueta;
                                break;
                            }
                        }
                    case "I":
                        {
                            if (CamposDelFormato.Valor.Length  > 0)
                            {
                                PictureBox  Imagen = new PictureBox();
                                Imagen.Visible = true;
                                Imagen.Enabled = true;
                                Imagen.Top = CamposDelFormato.Ftop;
                                Imagen.Left = CamposDelFormato.FLeft;
                                Imagen.Height = CamposDelFormato.FHeight;
                                Imagen.Width = CamposDelFormato.FWidth;
                                Imagen.Image = System.Drawing.Image.FromFile(SysEmpDatt.datosEmpresa.Emp_PathImagenes + CamposDelFormato.Valor);
                                Imagen.Name = "Imag" + Lineas.Length.ToString();

                                Array.Resize(ref Imagenes, Imagenes.Length + 1);
                                Imagenes[Imagenes.Length - 1] = Imagen;

                                Imagen.Click += new System.EventHandler(this.Etiqueta_Click);
                                Imagen.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                                Imagen.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

                                Papel.Controls.Add(Imagen);
                            }
                            break;
                        }

                    case "L":
                        {
                            
                            LineShape  linea = new LineShape();
                            linea.Visible = true;
                            linea.Enabled = true;
                            linea.Y1 = CamposDelFormato.Ftop;
                            linea.X1 = CamposDelFormato.FLeft;
                            linea.Y2 = CamposDelFormato.FHeight;
                            linea.X2 = CamposDelFormato.FWidth;
                            linea.BorderWidth = Convert.ToInt32(CamposDelFormato.Valor);
                            linea.BorderStyle = (System.Drawing.Drawing2D.DashStyle)CamposDelFormato.FontSize;
                            linea.Name = "Line" + Lineas.Length.ToString();

                            Array.Resize(ref Lineas, Lineas.Length + 1);
                            Lineas[Lineas.Length - 1] = linea;


                            linea.Parent = shapeContainer1;
                            linea.Click += new System.EventHandler(this.line0_Click);
                            linea.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                            linea.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);

                            break;
                        }

                    case "C":
                        {
                            RectangleShape Cuadrado = new RectangleShape();
                            Cuadrado.Visible = true;
                            Cuadrado.Enabled = true;
                            Cuadrado.Top = CamposDelFormato.Ftop;
                            Cuadrado.Left = CamposDelFormato.FLeft;
                            Cuadrado.Height = CamposDelFormato.FHeight;
                            Cuadrado.Width = CamposDelFormato.FWidth;
                            Cuadrado.BorderWidth = Convert.ToInt32(CamposDelFormato.Valor);
                            Cuadrado.BorderStyle = (System.Drawing.Drawing2D.DashStyle)CamposDelFormato.FontSize;
                            Cuadrado.Name = "Cuad" + Cuadrados.Length;

                            Cuadrado.Click += new System.EventHandler(this.cuad0_Click);
                            Cuadrado.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                            Cuadrado.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);
                            
                            Cuadrado.Parent = shapeContainer1;
                            Array.Resize(ref Cuadrados, Cuadrados.Length + 1);
                            Cuadrados[Cuadrados.Length - 1] = Cuadrado;
                            break;
                        }
                    case "O":
                        {
                            OvalShape Circulo = new OvalShape();
                            Circulo.Visible = true;
                            Circulo.Enabled = true;
                            Circulo.Top = CamposDelFormato.Ftop;
                            Circulo.Left = CamposDelFormato.FLeft;
                            Circulo.Height = CamposDelFormato.FHeight;
                            Circulo.Width = CamposDelFormato.FWidth;
                            Circulo.BorderWidth = Convert.ToInt32(CamposDelFormato.Valor);
                            Circulo.BorderStyle = (System.Drawing.Drawing2D.DashStyle)CamposDelFormato.FontSize;
                            Circulo.Parent = shapeContainer1;

                            Circulo.Name = "Circ" + IndCir.ToString();

                            Circulo.Click += new System.EventHandler(this.circ0_Click);
                            Circulo.MouseMove += new MouseEventHandler(this.BtnMovimiento_MouseMove);
                            Circulo.MouseDown += new MouseEventHandler(this.BtnMovimiento_MouseDown);


                            Array.Resize(ref Circulos, Circulos.Length + 1);
                            Circulos[Circulos.Length - 1] = Circulo;
                            break;
                        }

                }
            }        
            rs.Dispose();
            reposicionarControles();
            //CambiarOpcionDatos(false);
            //PorGrabar = true;
            //Nuevo = 2;
            //PonerTitulo();

        }
        private void reposicionarControles()
        {
            for (int i = 0; i < Datos.Length; i++)
            {
                Datos[i].BringToFront();
            }
            for (int i = 0; i < Etiquetas.Length; i++)
            {
                Etiquetas[i].BringToFront();
            }
        }
        private string ChequearFonts(string tipo)
        {
            if (tipo.ToUpper() == "MS SANS SERIF") return "Microsoft Sans Serif";
            if (tipo.ToUpper() == "ARIAL") MessageBox.Show("arial");
            return "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void GuardarValoresAntesMoverControl()
        {
        }
        private void RegresarControlMovido()
        {
            switch (tipoActual)
            {
                case "Etiq":
                    Etiquetas[IndEt].Top = IniTop;
                    Etiquetas[IndEt].Left = IniLeft;
                    Etiquetas[IndEt].Height = IniHight;
                    Etiquetas[IndEt].Width = IniWidht;
                    break;
                case "Dato":
                    Datos[IndDat].Top = IniTop;
                    Datos[IndDat].Left = IniLeft;
                    Datos[IndDat].Height = IniHight;
                    Datos[IndDat].Width = IniWidht;
                    break;
                case "Imag":
                    Imagenes[IndIma].Top = IniTop;
                    Imagenes[IndIma].Left = IniLeft;
                    Imagenes[IndIma].Height = IniHight;
                    Imagenes[IndIma].Width = IniWidht;
                    break;
                case "Circ":
                    Circulos[IndCir].Top = IniTop;
                    Circulos[IndCir].Left = IniLeft;
                    Circulos[IndCir].Height = IniHight;
                    Circulos[IndCir].Width = IniWidht;
                    break;
                case "Line":
                    Lineas[IndLin].Y1 = IniTop;
                    Lineas[IndLin].X1 = IniLeft;
                    Lineas[IndLin].Y2 = IniHight;
                    Lineas[IndLin].X2 = IniWidht;
                    break;
                case "Cuad":
                    Cuadrados[IndCua].Top = IniTop;
                    Cuadrados[IndCua].Left = IniLeft;
                    Cuadrados[IndCua].Height = IniHight;
                    Cuadrados[IndCua].Width = IniWidht;
                    break;
                default:
                    break;
            }
            BorrarBotonesMovimiento();
        }

        private void Reacer_Click(object sender, EventArgs e)
        {
            RegresarControlMovido();
        }
    }
}

