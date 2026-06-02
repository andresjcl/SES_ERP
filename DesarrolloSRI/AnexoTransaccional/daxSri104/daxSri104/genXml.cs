using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Text;

namespace daxSri104
{
    static internal class genXml
    {
        static internal void generarXml(frmDax104 frm)
        {
            string pathfile = "";
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "XML files|*.XML";
            SaveFileDialog1.Title = "Digite un nombre para el archivo XML";

            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathfile = SaveFileDialog1.FileName;
            }
            SaveFileDialog1.Dispose();
            if (pathfile.Length == 0) return;

            XmlTextWriter docXml = new XmlTextWriter(pathfile, System.Text.Encoding.UTF8);
            docXml.WriteStartDocument(true);
            docXml.Formatting = Formatting.Indented;
            docXml.WriteComment("Generado por: Sistema AdcomDx de DaxsofSistem 0999906974 Quito Ecuador");

                docXml.WriteStartElement("formulario");
                docXml.WriteAttributeString("version", "0.2");

                docXml.WriteStartElement("cabecera");
                    docXml.WriteElementString("codigo_version_formulario", "04201604");
                    docXml.WriteElementString("ruc",frm.LbRuc.Text);
                    docXml.WriteElementString("codigo_moneda","1");
                docXml.WriteEndElement ();
                docXml.WriteStartElement("detalle");

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "102");
                    docXml.WriteString((frm.cmbAños.Text).ToString());
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "101");
                    docXml.WriteString((frm.cmbMeses.SelectedIndex + 1).ToString());
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "31");
                    docXml.WriteString("0");
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "104");
                    docXml.WriteString((frm.Txt104.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "202");
                    docXml.WriteString((frm.LbNom.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "201");
                    docXml.WriteString((frm.LbRuc.Text));
                    docXml.WriteEndElement();

                    for (int i = 0; i < frm.malla400.Rows.Count;i++ )
                    {
                        DataGridViewRow row = frm.malla400.Rows[i];
                        for (int j = 1; j < 6; j += 2)
                        {
                            if (row.Cells[j].Value.ToString().Length > 0)
                            {
                                docXml.WriteStartElement("campo");
                                docXml.WriteAttributeString("numero", row.Cells[j].Value.ToString());
                                if (row.Cells[j + 1].Value == null) row.Cells[j + 1].Value = "0.00";
                                docXml.WriteString((row.Cells[j + 1].Value.ToString()));
                                docXml.WriteEndElement();
                            }
                        }
                    }

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "480");
                    docXml.WriteString((frm.Txt480.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "481");
                    docXml.WriteString((frm.txt481.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "482");
                    docXml.WriteString((frm.txt482.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "483");
                    docXml.WriteString((frm.txt483.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "484");
                    docXml.WriteString((frm.txt484.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "485");
                    docXml.WriteString((frm.txt485.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "499");
                    docXml.WriteString((frm.txt499.Text));
                    docXml.WriteEndElement();

                    for (int i = 0; i < frm.malla500.Rows.Count; i++)
                    {
                        DataGridViewRow row = frm.malla500.Rows[i];
                        for (int j = 1; j < 6; j += 2)
                        {
                            if (row.Cells[j].Value.ToString().Length > 0)
                            {
                                docXml.WriteStartElement("campo");
                                docXml.WriteAttributeString("numero", row.Cells[j].Value.ToString());
                                if (row.Cells[j + 1].Value == null) row.Cells[j + 1].Value = "0.00";
                                docXml.WriteString((row.Cells[j + 1].Value.ToString()));
                                docXml.WriteEndElement();
                            }
                        }
                    }

                    for (int i = 0; i < frm.malla600.Rows.Count; i++)
                    {
                        DataGridViewRow row = frm.malla600.Rows[i];
                        docXml.WriteStartElement("campo");
                        docXml.WriteAttributeString("numero", row.Cells[1].Value.ToString());
                        if (row.Cells[2].Value == null) row.Cells[2].Value = "0.00";
                        docXml.WriteString((row.Cells[2].Value.ToString()));
                        docXml.WriteEndElement();
                    }

                    for (int i = 0; i < frm.malla700.Rows.Count; i++)
                    {
                        DataGridViewRow row = frm.malla700.Rows[i];
                        docXml.WriteStartElement("campo");
                        docXml.WriteAttributeString("numero", row.Cells[1].Value.ToString());
                        if (row.Cells[2].Value == null) row.Cells[2].Value = "0.00";
                        docXml.WriteString((row.Cells[2].Value.ToString()));
                        docXml.WriteEndElement();
                    }

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "897");
                    docXml.WriteString((frm.txt897.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "898");
                    docXml.WriteString((frm.txt898.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "899");
                    docXml.WriteString((frm.txt899.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "902");
                    docXml.WriteString((frm.TXT902.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "903");
                    docXml.WriteString((frm.txt903.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "904");
                    docXml.WriteString((frm.txt904.Text));
                    docXml.WriteEndElement();


                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "999");
                    docXml.WriteString((frm.Txt999.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "905");
                    docXml.WriteString((frm.txt905.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "906");
                    docXml.WriteString((frm.txt906.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "907");
                    docXml.WriteString((frm.txt907.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "925");
                    docXml.WriteString((frm.txt925.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "908");
                    docXml.WriteString((frm.txt908.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "909");
                    docXml.WriteString((frm.txt909.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "910");
                    docXml.WriteString((frm.txt910.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "911");
                    docXml.WriteString((frm.txt911.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "912");
                    docXml.WriteString((frm.txt912.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "913");
                    docXml.WriteString((frm.txt913.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "915");
                    docXml.WriteString((frm.txt915.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "916");
                    docXml.WriteString((frm.txt916.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "917");
                    docXml.WriteString((frm.txt917.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "918");
                    docXml.WriteString((frm.txt918.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "919");
                    docXml.WriteString((frm.txt919.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "920");
                    docXml.WriteString((frm.txt920.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "198");
                    docXml.WriteString((frm.txt920.Text));
                    docXml.WriteEndElement();

                    docXml.WriteStartElement("campo");
                    docXml.WriteAttributeString("numero", "199");
                    docXml.WriteString((frm.txt920.Text));
                    docXml.WriteEndElement();

                    docXml.WriteEndElement();
               docXml.WriteEndElement();
            docXml.WriteEndDocument();
            docXml.Flush();
            docXml.Close();
            //docXml.WriteElementString("campo", ELANIO.Text, 4, CStr(0), 4, "102")
        //docXml.WriteElementString("campo", IIf(Sustitutiva.CheckState, "S", "O"), 4, CStr(0), 4, "31")
        //docXml.WriteElementString("campo", Txt104.Text, 4, CStr(0), 4, "104")
        //docXml.WriteElementString("campo", lbRuc.Text, 4, CStr(0), 4, "201")
        //docXml.WriteElementString("campo", lbNom.Text, 4, CStr(0), 4, "202")
        //'docXml.WriteElementString "campo", "<![CDATA[ " & lbNom & "]]>", 4, 0, 4, "202"
        //docXml.WriteElementString("campo", txt301.Text, 2, CStr(10), 4, CStr(301))
        //docXml.WriteElementString("campo", txt302.Text, 2, CStr(10), 4, CStr(302))
        //docXml.WriteElementString("campo", txt303.Text, 2, CStr(10), 4, CStr(303))
        //docXml.WriteElementString("campo", txt304.Text, 2, CStr(10), 4, CStr(304))
        //docXml.WriteElementString("campo", txt399.Text, 2, CStr(10), 4, CStr(399))
		
        //With Malla400
        //    For I = 1 To .Rows - 1
        //        For j = 2 To 6 Step 2
        //            If I <> 10 Then
        //                If I < 3 Or j = 4 Or (I < 10 And j = 2) Or (I > 12 And j = 6) Or I = 9 Then
        //                    docXml.WriteElementString("campo", .get_TextMatrix(I, j), 2, CStr(15), 4, .get_TextMatrix(I, j - 1))
        //                End If
        //            End If
        //        Next j
        //    Next I
        //End With
		
        //docXml.WriteElementString("campo", Txt480.Text, 2, CStr(10), 4, CStr(480))
        //docXml.WriteElementString("campo", txt481.Text, 2, CStr(10), 4, CStr(481))
        //docXml.WriteElementString("campo", txt482.Text, 2, CStr(10), 4, CStr(482))
        //docXml.WriteElementString("campo", txt483.Text, 2, CStr(10), 4, CStr(483))
        //docXml.WriteElementString("campo", txt484.Text, 2, CStr(10), 4, CStr(484))
        //docXml.WriteElementString("campo", txt485.Text, 2, CStr(10), 4, CStr(485))
        //docXml.WriteElementString("campo", txt499.Text, 2, CStr(10), 4, CStr(499))
		
        //'docXml.WriteElementString "campo", txt460, 2, 10, 4, 460
        //'docXml.WriteElementString "campo", tXT107, 2, 10, 4, 107
		
        //With malla500
        //    For I = 1 To .Rows - 1
        //        For j = 2 To 6 Step 2
        //            If I <> 10 Then
        //                If I < 6 Or j = 4 Or (I < 8 And j = 2) Or (I > 12 And j = 6) Or I = 9 Then
        //                    docXml.WriteElementString("campo", .get_TextMatrix(I, j), 2, CStr(15), 4, .get_TextMatrix(I, j - 1))
        //                End If
        //            End If
        //        Next j
        //    Next I
        //End With
		
        //'docXml.WriteElementString "campo", txt560, 2, 10, 4, 560
        //docXml.WriteElementString("campo", txt553.Text, 2, CStr(10), 4, CStr(554))
        //docXml.WriteElementString("campo", txt554.Text, 2, CStr(10), 4, CStr(555))
		
        //docXml.WriteElementString("campo", txt601.Text, 2, CStr(10), 4, CStr(601))
        //docXml.WriteElementString("campo", txt602.Text, 2, CStr(10), 4, CStr(602))
        //'docXml.WriteElementString "campo", txt603, 2, 10, 4, 603
        //'docXml.WriteElementString "campo", txt604, 2, 10, 4, 604
        //docXml.WriteElementString("campo", txt605.Text, 2, CStr(10), 4, CStr(605))
        //docXml.WriteElementString("campo", txt607.Text, 2, CStr(10), 4, CStr(607))
        //docXml.WriteElementString("campo", txt609.Text, 2, CStr(10), 4, CStr(609))
        //docXml.WriteElementString("campo", txt611.Text, 2, CStr(10), 4, CStr(611))
        //docXml.WriteElementString("campo", txt615.Text, 2, CStr(10), 4, CStr(615))
        //docXml.WriteElementString("campo", txt617.Text, 2, CStr(10), 4, CStr(617))
        //docXml.WriteElementString("campo", txt619.Text, 2, CStr(10), 4, CStr(619))
        //docXml.WriteElementString("campo", txt621.Text, 2, CStr(10), 4, CStr(621))
        //docXml.WriteElementString("campo", Txt699.Text, 2, CStr(10), 4, CStr(699))
		
        //'docXml.WriteElementString "campo", txt901, 2, 10, 4, 901
        //docXml.WriteElementString("campo", TXT902.Text, 2, CStr(10), 4, CStr(902))
        //docXml.WriteElementString("campo", txt903.Text, 2, CStr(10), 4, CStr(903))
        //docXml.WriteElementString("campo", txt904.Text, 2, CStr(10), 4, CStr(904))
        //docXml.WriteElementString("campo", txt198.Text, 2, CStr(10), 4, CStr(198))
        //docXml.WriteElementString("campo", Txt999.Text, 2, CStr(10), 4, CStr(999))
		
        //With Malla700
        //    For I = 1 To .Rows - 1
        //        If Val(.get_TextMatrix(I, 2)) <> 0 Then
        //            docXml.WriteElementString("campo", .get_TextMatrix(I, 2), 2, CStr(15), 4, CStr(720 + I))
        //        End If
        //        '    docXml.WriteElementString "campo", .TextMatrix(i, 4), 2, 15, 4, 720 + i
        //    Next I
        //End With
		
        //docXml.WriteElementString("campo", Txt799.Text, 2, CStr(10), 4, CStr(799))
        //docXml.WriteElementString("campo", Txt859.Text, 2, CStr(10), 4, CStr(859))
        //docXml.WriteElementString("campo", Txt799.Text, 2, CStr(10), 4, CStr(899))
		
		
        //docXml.WriteElementString("campo", txt897.Text, 2, CStr(10), 4, CStr(897))
        //docXml.WriteElementString("campo", txt898.Text, 2, CStr(10), 4, CStr(898))
        //docXml.WriteElementString("campo", txt899.Text, 2, CStr(10), 4, CStr(899))
		
		
        //'docXml.WriteElementString "campo", txt901, 2, 10, 4, 901
        //docXml.WriteElementString("campo", TXT902.Text, 2, CStr(10), 4, CStr(902))
        //docXml.WriteElementString("campo", txt903.Text, 2, CStr(10), 4, CStr(903))
        //docXml.WriteElementString("campo", txt904.Text, 2, CStr(10), 4, CStr(904))
		
        //docXml.WriteElementString("campo", Txt999.Text, 2, CStr(10), 4, CStr(999))
		
        //docXml.WriteElementString("campo", txt905.Text, 2, CStr(10), 4, CStr(905))
        //docXml.WriteElementString("campo", txt906.Text, 2, CStr(10), 4, CStr(906))
        //docXml.WriteElementString("campo", txt907.Text, 2, CStr(10), 4, CStr(907))
        //docXml.WriteElementString("campo", txt908.Text, 2, CStr(10), 4, CStr(908))
        //docXml.WriteElementString("campo", txt909.Text, 2, CStr(10), 4, CStr(909))
        //docXml.WriteElementString("campo", txt910.Text, 2, CStr(10), 4, CStr(910))
        //docXml.WriteElementString("campo", txt911.Text, 2, CStr(10), 4, CStr(911))
        //docXml.WriteElementString("campo", txt912.Text, 2, CStr(10), 4, CStr(912))
        //docXml.WriteElementString("campo", txt913.Text, 2, CStr(10), 4, CStr(913))
        //docXml.WriteElementString("campo", txt914.Text, 2, CStr(10), 4, CStr(914))
        //docXml.WriteElementString("campo", txt915.Text, 2, CStr(10), 4, CStr(915))
        //docXml.WriteElementString("campo", txt916.Text, 2, CStr(10), 4, CStr(916))
        //docXml.WriteElementString("campo", txt917.Text, 2, CStr(10), 4, CStr(917))
        //docXml.WriteElementString("campo", txt918.Text, 2, CStr(10), 4, CStr(918))
        //docXml.WriteElementString("campo", txt919.Text, 2, CStr(10), 4, CStr(919))
        //'docXml.WriteElementString "campo", txt922, 2, 10, 4, 922
		
		
        //'docXml.WriteElementString "campo", Rlegal, 1, 10, 4, 198
        //'docXml.WriteElementString "campo", Rcontador, 1, 10, 4, 199
		
        //docXml.WriteElementString("detalle", "", 1, CStr(0), 3)
        //docXml.WriteElementString("formulario", "", 1, CStr(0), 3)
        }

    }
}
