using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Windows.Forms;
using DattCom;
namespace DaxInvent
{

//    // Public Function by Victor
//    public double CostoEstandard(string Articulo)
//    {
//        string SQLCode;
//        ADODB.Recordset RsCosStd = new ADODB.Recordset();
//        CostoEstandard = 0; // line added by Victor
//        RsCosStd.CursorType = adOpenKeyset;
//        RsCosStd.LockType = adLockOptimistic;
//        SQLCode = "SELECT * FROM AdcArt WHERE Art_codigo = '" + Articulo + "'";
//        RsCosStd.Open(SQLCode, ConxAdcom, null/* Conversion error: Set to default value for this argument */, null/* Conversion error: Set to default value for this argument */, adCmdText);
//        if (RsCosStd.RecordCount != 0)
//        {
//            if (!IsNull(RsCosStd.Art_CostoEstandard))
//                CostoEstandard = RsCosStd.Art_CostoEstandard;
//        } // 19/03/2003 changed by Victor

//        RsCosStd.Close();
//    }

//    public double UltimoCosto(string Sucursal, string Bodega, string Articulo, string FechaFin )
//    {
//        UltimoCosto = 0;
//        string Suc;
//        ADODB.Recordset RsCosUlt = new ADODB.Recordset();
//        string sel;
//        string Bod;
//        string cod;
//        RsCosUlt.CursorType = adOpenKeyset;
//        RsCosUlt.LockType = adLockOptimistic;
//        sel = "";
//        if (Sucursal != "")
//            sel = " AND doc_sucursal=  '" + Sucursal + "'";

//        // Changed by Victor
//        if (!Information.IsDate(FechaFin))
//            FechaFin = Strings.Format(DateTime.Now, "dd/mm/yyyy");

//        cod = "SELECT TOP 1 AdcTra.Opc_documento,TRA_FECHA, AdcTra.Doc_numero, AdcTra.Tra_costuni, AdcTra.Tra_cantidad, AdcTra.Tra_multiplo, AdcOpc.Opc_tipocos";
//        cod = cod + " FROM AdcTra left JOIN";
//        cod = cod + " AdcOpc ON AdcTra.Opc_documento = AdcOpc.Opc_documento";
//        cod = cod + " where Tra_Inventario = 1 and Opc_tipocos ='D' AND Tra_costuni <> 0 and Tra_codigo ='" + Articulo + "' and tra_fecha <= '" + FechaFin + "' " + sel;
//        cod = cod + " ORDER BY Tra_fecha DESC";

//        RsCosUlt.Open(cod, ConxAdcom, null/* Conversion error: Set to default value for this argument */, null/* Conversion error: Set to default value for this argument */, adCmdText);
//        {
//            var withBlock = RsCosUlt;
//            if (!withBlock.EOF)
//                UltimoCosto = Round(LibDigDat.CorrijeNuloN(withBlock.tra_costuni) * withBlock.tra_multiplo, Emp.DigitosCostos);
//            else
//                UltimoCosto = 0;
//        }

//        if (UltimoCosto == 0)
//            UltimoCosto = CostoPromedio(Articulo, FechaFin, "", Sucursal, "", 0);
//        hayError:
//        ;
//        if (RsCosUlt.State == 1)
//            RsCosUlt.Close();
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 7690
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set RsCosUlt = Nothing

// */
//    }

//    public double CostoPromedio(string Articulo, string FechaFin = , string EnMedida = , string SucDoc = , string TipoDoc = , double IdClaveDoc = )
//    {
//        string Suc;
//        ADODB.Recordset RsCosUlt;
//        string sel;
//        double CostoTotalAnt;
//        double CantidadTotalAnt;
//        double cantidad;
//        double Costo;
//        string FechLimite;
//        string FecFin;
//        string SinDoc;
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 8150
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set RsCosUlt = New ADODB.Recordset

// */
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 8185
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */
//        CostoPromedio = 0;
//        {
//            var withBlock = RsCosUlt;
//            sel = "DaxInvcstProm '" + FechaFin + "','" + Articulo + "','','" + TipoDoc + "','" + SucDoc + "'," + IdClaveDoc;
//            withBlock.Open(sel, ConxAdcom, adOpenForwardOnly, adLockReadOnly, adCmdText);
//            if (withBlock.EOF == false)
//            {
//                withBlock.MoveFirst();
//                if (withBlock.traCanti != 0)
//                    CostoPromedio = withBlock.TraCosto / (double)withBlock.traCanti;
//            }
//        }
//    }


//    public double CargarPrecio(int KeyCode, Articulo OpArticulo, double porciva, string CodigoActual = , string Aut = , double QuePrecio = , string EnMedida = , string CodCliente = )
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        if (IsMissing(EnMedida) | EnMedida == "")
//            EnMedida = OpArticulo.Unimed;
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 10803
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */
//        if (IsMissing(Aut) | Aut == "")
//            Aut = "T";
//        if (IsMissing(CodCliente))
//            CodCliente = "";

//        if (CodCliente > "")
//        {
//            CargarPrecio = precioPorCliente(OpArticulo, CodCliente, porciva);
//            if (CargarPrecio > 0)
//                return;
//        }

//        if (Aut == "R")
//        {
//            CargarPrecio = QuePrecio; return;
//        }

//        if (CodigoActual > "" & CodigoActual != OpArticulo.codigo)
//        {
//            if (OpArticulo.Cargar(CodigoActual) == false)
//            {
//                CargarPrecio = 0; return;
//            }
//        }

//        CargarPrecio = 0;
//        if (KeyCode > vbKeyF6)
//        {
//            ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 11314
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//            Set rs = New ADODB.Recordset

// */
//            rs.CursorLocation = adUseClient;
//            int INC;
//            double precio;
//            {
//                var withBlock = rs;
//                if (withBlock.State)
//                    withBlock.Close();
//                withBlock.Open(" Select * from precioventa where IdPrecioVenta = '" + KeyCode - vbKeyF1 + "'", ConIniSis, adOpenForwardOnly, adLockReadOnly);
//                if (!withBlock.EOF)
//                    INC = withBlock.IVAINCLUIDO;
//                else
//                    INC = 0;
//                if (withBlock.State)
//                    withBlock.Close();
//            }
//            rs.Open("SELECT * FROM ADCPRVTA WHERE Art_NumPrecio = " + KeyCode - vbKeyF1 + " AND Art_codigo = '" + OpArticulo.codigo + "' ", ConxAdcom, adOpenDynamic, adLockOptimistic);
//            if (rs.EOF == false)
//                precio = (LibDigDat.CorrijeNuloN(rs.Art_precvtaEsp));
//            if (rs.State == 1)
//                rs.Close();
//            if (INC != 0)
//                precio = Round(System.Convert.ToDouble(OpArticulo.PrecVta5) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            if (precio == 0)
//                KeyCode = vbKeyF2;
//            else
//                CargarPrecio = precio;
//        }
//        if (KeyCode == vbKeyF2)
//        {
//            if (OpArticulo.IncluyeIvaP1 == true)
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta1) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            else
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta1), Emp.DigitosPrecios);
//        }
//        else if (KeyCode == vbKeyF3)
//        {
//            if (OpArticulo.IncluyeIvaP2 == true)
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta2) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            else
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta2), Emp.DigitosPrecios);
//        }
//        else if (KeyCode == vbKeyF4)
//        {
//            if (OpArticulo.IncluyeIvaP3 == true)
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta3) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            else
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta3), Emp.DigitosPrecios);
//        }
//        else if (KeyCode == vbKeyF5)
//        {
//            if (OpArticulo.IncluyeIvaP4 == true)
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta4) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            else
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta4), Emp.DigitosPrecios);
//        }
//        else if (KeyCode == vbKeyF6)
//        {
//            if (OpArticulo.IncluyeIvaP5 == true)
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta5) / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            else
//                CargarPrecio = Round(System.Convert.ToDouble(OpArticulo.PrecVta5), Emp.DigitosPrecios);
//        }
//        if (OpArticulo.Unimed != EnMedida)
//            CargarPrecio = Round((CargarPrecio * MulMedida(EnMedida, OpArticulo.Unimed)), Emp.DigitosPrecios);
//    }

//    public double precioPorCliente(Articulo ElArticulo, string elcodigoCli, double porciva)
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        double precio;
//        string ssql;
//        precio = 0;
//        ssql = "SELECT AdcPrvtaLis.Lista, isnull(AdcPrvtaLis.IncluyeIva,0) as IncluyeIva, AdcPrvta.CodigoProducto, isnull(AdcPrvta.PrecioProducto,0) as PrecioProducto";
//        ssql = ssql + " FROM AdcPrvtaLis left JOIN AdcPrvta ON AdcPrvtaLis.Lista = AdcPrvta.Lista";
//        ssql = ssql + " where codigoProducto = '" + ElArticulo.codigo + "' AND cliente = '" + elcodigoCli + "' ";

//        rs.Open(ssql, ConxAdcom, adOpenDynamic, adLockReadOnly);
//        if (rs.State == 1)
//        {
//            if (rs.EOF == false)
//            {
//                precio = rs.PrecioProducto;
//                if (rs.IncluyeIva == 1)
//                    precio = Round(precio / ((porciva / 100) + 1), Emp.DigitosPrecios);
//            }
//        }

//        precioPorCliente = precio;
//    }

//    public void SaldoTallas(ADODB.Recordset rs, string Bodega, string Articulo, string FechaSaldo)
//    {
//        ADODB.Recordset Rec = new ADODB.Recordset();
//        string cod;
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 15754
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set Rec = rs

// */
//        cod = "Select doc_bodega, tra_codigo, max(tra_fecha) as ult_fecha, tal_talla, tal_color, sum(tal_cantidad * tal_signo) as tal_saldo from adctaltra where tra_fecha <= " + LibBasDat.ArmFormatoFecha(FechaSaldo);
//        if (Bodega > "")
//            cod = cod + " and doc_bodega = '" + Bodega + "'";
//        if (Articulo > "")
//            cod = cod + " and tra_codigo = '" + Articulo + "'";
//        cod = cod + " group by doc_bodega, tra_codigo, tal_talla, tal_color order by doc_bodega, tra_codigo";
//        if (Rec.State == 1)
//            Rec.Close();
//        Rec.Open(cod, ConxAdcom, adOpenKeyset, adLockOptimistic);
//    }

//    public double SaldoArt(string Articulo, string Sucursal, string Bodega, string fecha, string Tipo = , long Doc = , double SumaTranCant = , double SumaTranCost = , bool SoloMov = )
//    {
//        ADODB.Recordset RsCosTra = new ADODB.Recordset();
//        ADODB.Recordset RsMov = new ADODB.Recordset();
//        double CanMov;
//        double CosMov;
//        double CanTot;
//        string FechaCierre;
//        string Seleccion;
//        string Seleccion2;
//        string cod;
//        string NoDoc;
//        string SelDoc;
//        long ii;
//        int Anio;
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 16848
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */// /// datos que recibe la funcion
//   // *** articulo del cual se va a devolver los saldos
//   // *** almacen del cual se devolveran los saldos si es "" seran todos los almacenes
//   // *** fecha a la cual se calcularan los saldos si es la de cierre
//   // /***Cuando el documento sea espacio en blanco es costo PROMEDIO y si el docuemnto tiene valor es ULTIMO csoto
//   // saldotransac cuando ya esta sumado el saldo de las transacciones
//        SelDoc = "";
//        FechaCierre = Emp.InvUltAnu;
//        CanMov = 0;
//        CosMov = 0;
//        CanTot = 0;
//        Seleccion = "";
//        NoDoc = "";
//        if (Bodega != "" & Bodega != "T")
//            Seleccion = " AND ( mov_bodega = '0' or mov_Bodega = '" + Bodega + "') ";

//        cod = "select * from AdcArtMov where (art_codigo ='" + Articulo + "' ) order by mov_sucursal, Mov_bodega";
//        RsMov.CursorType = adOpenKeyset;
//        RsMov.LockType = adLockOptimistic;
//        RsMov.Open(cod, ConxAdcom, null/* Conversion error: Set to default value for this argument */, null/* Conversion error: Set to default value for this argument */, adCmdText);
//        {
//            var withBlock = RsMov;
//            if (withBlock.EOF == false)
//            {
//                while ((!withBlock.EOF | withBlock.State == 0))
//                {
//                    if (withBlock.mov_sucursal == "0" & withBlock.mov_bodega == "0")
//                        CosMov = CosMov + withBlock.mov_cantidad;
//                    else
//                    {
//                        CanTot = CanTot + withBlock.mov_cantidad;
//                        if (Bodega != "" & Bodega != "T" & Bodega == withBlock.mov_bodega)
//                            CanMov = CanMov + withBlock.mov_cantidad;
//                    }
//                    withBlock.MoveNext();
//                }
//            }
//            withBlock.Close();
//        }

//        if (Bodega != "" & Bodega != "T")
//        {
//            if (CanTot != 0)
//                CosMov = (CosMov / CanTot) * CanMov;
//            else
//                CosMov = 0;
//        }
//        else
//            CanMov = CanTot;
//        if (SoloMov == true)
//        {
//            CosMov = CosMov + SumaTranCost;
//            CanMov = CanMov + SumaTranCant;
//        }
//        else if ((DateTime)fecha > (DateTime)FechaCierre)
//        {
//            Seleccion = "";
//            if (Bodega != "" & Bodega != "T")
//            {
//                Seleccion = Seleccion + " AND doc_Bodega = '" + Bodega + "'  "; Seleccion2 = Seleccion2 + " AND tra_boddestino = '" + Bodega + "'  ";
//            }

//            cod = " SELECT tra_codigo,  sum(SalCosto) as SalCosto, sum(SalCanti) as  SalCanti from (";
//            cod = cod + " SELECT tra_codigo,  sum(tra_costtot * tra_inventario ) as SalCosto, sum(tra_cantidad * tra_inventario * tra_multiplo) as  SalCanti ";
//            cod = cod + " FROM ADCTRA ";
//            cod = cod + " where tra_inventario <> 0 and tra_fecha <= " + LibBasDat.ArmFormatoFecha(fecha) + " " + Seleccion + SelDoc + " and Tra_codigo ='" + Articulo + "' ";
//            cod = cod + " group by tra_codigo ";
//            cod = cod + " union all ";
//            cod = cod + " SELECT tra_codigo,  sum(tra_costtot * tra_inventario *-1) as SalCosto, sum(tra_cantidad * tra_inventario * tra_multiplo * -1) as  SalCanti ";
//            cod = cod + " FROM ADCTRA ";
//            cod = cod + " where tra_inventario <> 0 and tra_fecha <= " + LibBasDat.ArmFormatoFecha(fecha) + " " + Seleccion2 + SelDoc + " and Tra_codigo ='" + Articulo + "' ";
//            cod = cod + " and isnull(tra_boddestino,'') > '' ";
//            cod = cod + " group by tra_codigo ";
//            cod = cod + " ) r1 ";
//            cod = cod + " group by tra_codigo ";
//            // Debug.Print cod
//            if (RsCosTra.State)
//                RsCosTra.Close();
//            RsCosTra.Open(cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly);
//            {
//                var withBlock = RsCosTra;
//                if (!withBlock.EOF)
//                {
//                    while (!withBlock.EOF)
//                    {
//                        if (!IsNull(withBlock.salcosto))
//                            CosMov = CosMov + withBlock.salcosto;
//                        if (!IsNull(withBlock.salcanti))
//                            CanMov = CanMov + withBlock.salcanti;
//                        withBlock.MoveNext();
//                    }
//                }
//                withBlock.Close();
//            }
//            if (Tipo > "" & Doc > 0)
//            {
//                SelDoc = " AND ( Opc_documento = '" + Tipo + "' AND Doc_numero = " + Doc + " AND Doc_sucursal = '" + Sucursal + "') ";
//                cod = " SELECT tra_codigo,  sum(tra_costtot * tra_inventario ) as SalCosto, sum(tra_cantidad * tra_inventario * tra_multiplo) as  SalCanti " + " FROM ADCTRA " + " where tra_inventario <> 0 " + Seleccion + SelDoc + " and Tra_codigo ='" + Articulo + "' " + " group by tra_codigo ";

//                if (RsCosTra.State)
//                    RsCosTra.Close();
//                RsCosTra.Open(cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly);
//                {
//                    var withBlock = RsCosTra;
//                    if (!withBlock.EOF)
//                    {
//                        while (!withBlock.EOF)
//                        {
//                            if (!IsNull(withBlock.salcosto))
//                                CosMov = CosMov - withBlock.salcosto;
//                            if (!IsNull(withBlock.salcanti))
//                                CanMov = CanMov - withBlock.salcanti;
//                            withBlock.MoveNext();
//                        }
//                    }
//                    withBlock.Close();
//                }
//            }
//        }

//        AuxCostoTot = CosMov;

//        if (AuxCostoTot != 0 & CanMov != 0)
//            AuxCostoUni = Round(AuxCostoTot / CanMov, Emp.DigitosCostos);
//        SaldoArt = CanMov;
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 21384
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set RsMov = Nothing

// */
//    }

//    public double PonerNumeroTicket(string codArt, string Color, string talla, string Serie)
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        string Aux;
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 21835
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */// WHERE CONVERT(char(20), ytd_sales)
//        rs.CursorLocation = adUseClient;
//        rs.Open("Select max(ISNULL(TIK_NUMERO,0)) AS TiketMayor from adctik", ConxAdcom, adOpenKeyset);
//        if (rs.EOF)
//            PonerNumeroTicket = 1;
//        else
//        {
//            Aux = val(rs.tiketmayor);
//            Aux = Mid(Aux, 1, 12);
//            if (Aux == "")
//                Aux = 0;
//            PonerNumeroTicket = System.Convert.ToDouble(Aux) + 1;
//        }

//        rs.Close();
//    }

//    public double VentaArt(string Articulo, string Sucursal, string fecha, string fechaf)
//    {
//        ADODB.Recordset RsCosTra = new ADODB.Recordset();
//        double CanMov;
//        double CosMov;
//        string FechaCierre;
//        string Seleccion;
//        string cod;
//        long ii;
//        FechaCierre = Emp.InvUltAnu;
//        if (!Information.IsDate(fecha))
//            fecha = FechaCierre;
//        if (!Information.IsDate(fechaf))
//            fechaf = Format<DateTime, >;
//        Seleccion = "";
//        if (Sucursal != "" & Sucursal != "T")
//            Seleccion = Seleccion + " AND doc_sucursal = '" + Sucursal + "'  ";

//        cod = " SELECT tra_codigo,  sum(Tra_prectot * tra_ventas ) as SalCosto, sum(tra_cantidad * tra_ventas * tra_multiplo) as  SalCanti " + " FROM ADCTRA " + " where tra_ventas <> 0 and tra_fecha >= " + LibBasDat.ArmFormatoFecha(fecha) + " and tra_fecha <= " + LibBasDat.ArmFormatoFecha(fechaf) + Seleccion + " and Tra_codigo ='" + Articulo + "' " + " group by tra_codigo ";

//        if (RsCosTra.State)
//            RsCosTra.Close();
//        RsCosTra.Open(cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly);
//        {
//            var withBlock = RsCosTra;
//            if (!withBlock.EOF)
//            {
//                while (!withBlock.EOF)
//                {
//                    if (!IsNull(withBlock.salcosto))
//                        CosMov = CosMov + withBlock.salcosto;
//                    if (!IsNull(withBlock.salcanti))
//                        CanMov = CanMov + withBlock.salcanti;
//                    withBlock.MoveNext();
//                }
//            }
//            withBlock.Close();
//        }

//        AuxCostoTot = CosMov;
//        VentaArt = CanMov;
//    }

//    public void SaldoPorCodBase(ref ADODB.Recordset RecSaldo, string CodigoBase, DateTime AFecha, string Suc, string Tipo = )
//    {
//        string ssql;
//        int ii;
//        string VtaIn;
//        string SelBod;
//        string GROUPBOD;
//        CodigoBase = Trim(CodigoBase);
//        ii = Strings.Len(CodigoBase);
//        if (RecSaldo.State == 1)
//            RecSaldo.Close();
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 23984
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set RecSaldo = New ADODB.Recordset

// */
//        if (!Information.IsDate(AFecha))
//            AFecha = DateTime.Now;
//        if (Suc == "T")
//        {
//            SelBod = " 'Empresa' as doc_bodega, ";
//            GROUPBOD = "";
//        }
//        else
//        {
//            SelBod = " AdcTra.Doc_Bodega, ";
//            GROUPBOD = " AdcTra.Doc_Bodega,";
//        }

//        ssql = "SELECT " + SelBod + " AdcTra.Tra_Codigo, Sum([Tra_Inventario]*[tra_cantidad]*tra_multiplo) AS Saldo, max(AdcTik.TIK_COLOR) AS COLOR, max(AdcTik.TIK_TALLA) AS TALLA " + " FROM AdcTra Left  join AdcTik ON AdcTra.Tra_Codigo = AdcTik.TIK_ARTCODI " + " Where AdcTra.Tra_fecha <= " + LibBasDat.ArmFormatoFecha(Conversion.Str(AFecha)) + " AND left(ADCTRA.TRA_CODIGO," + ii + ")='" + CodigoBase + "' " + " GROUP BY " + GROUPBOD + " AdcTra.Tra_Codigo order by " + GROUPBOD + " adctra.tra_codigo";

//        // If Tipo = "V" Then
//        // VtaIn = " TRA_VENTAS "
//        // Else
//        // VtaIn = " TRA_INVENTARIO "
//        // End If

//        // sSQL = "TRANSFORM Sum(" & VtaIn & " * tra_cantidad) AS Saldo " & _
//        // " SELECT " & SelBod & " AdcTik.TIK_COLOR " & _
//        // " FROM AdcTra Left  join AdcTik ON AdcTra.Tra_Codigo = AdcTik.TIK_ARTCODI " & _
//        // " Where AdcTra.Tra_fecha <= " & libbasdat. LIBBASDAT.ArmFormatoFecha(Str(AFecha)) & " AND left(ADCTRA.TRA_CODIGO," & ii & ")='" & CodigoBase & "' " & _
//        // " AND TRA_CANTIDAD <> 0 and " & VtaIn & " <> 0" & _
//        // " GROUP BY " & GROUPBOD & " AdcTik.TIK_COLOR " & _
//        // " PIVOT AdcTik.TIK_TALLA "
//        // MsgBox sSQL
//        // RecSaldo.CursorLocation = adUseClient
//        RecSaldo.Open(ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly);
//    }

//    public double SaldoMalla(string codigo, Variant Malla, int rr)
//    {
//        int I;
//        double Saldo;
//        double SaldoEnMalla;
//        double AuxNum8;
//        double AuxNum3;
//        string Bodega;
//        SaldoEnMalla = 0;
//        {
//            var withBlock = Malla;
//            Bodega = withBlock.TextMatrix(rr, 20);
//            for (I = 1; I <= withBlock.Rows - 1; I++)
//            {
//                AuxNum8 = LibDigDat.CorrijeNuloN(withBlock.TextMatrix(I, 18));
//                AuxNum3 = LibDigDat.CorrijeNuloN(withBlock.TextMatrix(I, 3));
//                // If val(.TextMatrix(i, 18)) = 0 Then .TextMatrix(i, 18) = 1
//                // If Not IsNumeric(.TextMatrix(i, 3)) Then .TextMatrix(i, 3) = 0
//                // If .TextMatrix(i, 1) = codigo And rr <> i Then SaldoEnMalla = SaldoEnMalla + val(.TextMatrix(i, 3)) * val(.TextMatrix(i, 18))
//                if (Bodega > "")
//                {
//                    if (withBlock.TextMatrix(I, 1) == codigo & rr != I & withBlock.TextMatrix(I, 20) == Bodega)
//                        SaldoEnMalla = SaldoEnMalla + AuxNum3 * AuxNum8;
//                }
//                else if (withBlock.TextMatrix(I, 1) == codigo & rr != I)
//                    SaldoEnMalla = SaldoEnMalla + AuxNum3 * AuxNum8;
//            }
//        }

//        SaldoMalla = SaldoEnMalla;
//    }

//    public void Pr()/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        ArtAnterior = LibDigDat.CorrijeNulo(ArtAnterior);
//        rs.Open("SELECT  TOP 1 Art_codigo From dbo.AdcArt Where (Art_codigo > '" + ArtAnterior + "') ", ConxAdcom, adOpenForwardOnly, adLockReadOnly);
//        if (rs.State == 0)
//        {
//            Pr/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */ = ""; return;
//        }

//        if (rs.EOF)
//            Pr/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */ = "";
//        else
//            Pr/* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */ = rs.Art_codigo;
//        rs.Close();
//    }

//    public double CostoConsulta(string codigo, string AlaFecha)
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 26968
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */
//        CostoConsulta = 0;
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 27007
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//'MsgBox codigo
//'MsgBox AlaFecha
//Set rs = ConxAdcom.Execute("CostoProd '" & codigo & "','" & AlaFecha & "' ")

// */
//        if (rs.State == 0)
//            return;
//        if (rs.EOF == false)
//            CostoConsulta = rs.promedio;
//        // MsgBox CostoConsulta & "   " & rs!Promedio
//        rs.Close();
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 27255
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set rs = Nothing

// */
//    }

//    public double SaldoPorEntregar(string AlaFecha, string codigo, string DocSuc, string DocTip, string DocNum, string DocSucOM, string DocTipOM, string DocNumOM)
//    {
//        ADODB.Recordset rs = new ADODB.Recordset();
//        string ssql;
//        ;/* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 27566
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitOnErrorResumeNextStatement(OnErrorResumeNextStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.OnErrorResumeNextStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//On Error Resume Next

// */
//        ssql = "ADC_SALNTRG '" + AlaFecha + "','" + codigo + "','" + DocSuc + "','" + DocTip + "'," + DocNum + ",'" + DocSucOM + "','" + DocTipOM + "'," + DocNumOM;
//        SaldoPorEntregar = 0;
//        Debug.Print(ssql);
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 27781
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set rs = ConxAdcom.Execute(ssql)

// */
//        if (rs.State == 0)
//            return;
//        if (rs.EOF == false)
//            SaldoPorEntregar = rs.Pendiente;
//        rs.Close();
//        ;/* Cannot convert EmptyStatementSyntax, CONVERSION ERROR: Conversion for EmptyStatement not implemented, please report this issue in '' at character 27913
//   at ICSharpCode.CodeConverter.CSharp.VisualBasicConverter.MethodBodyVisitor.DefaultVisit(SyntaxNode node)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.VisitEmptyStatement(EmptyStatementSyntax node)
//   at Microsoft.CodeAnalysis.VisualBasic.Syntax.EmptyStatementSyntax.Accept[TResult](VisualBasicSyntaxVisitor`1 visitor)
//   at Microsoft.CodeAnalysis.VisualBasic.VisualBasicSyntaxVisitor`1.Visit(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.ConvertWithTrivia(SyntaxNode node)
//   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.DefaultVisit(SyntaxNode node)

//Input: 
//Set rs = Nothing

// */

}
