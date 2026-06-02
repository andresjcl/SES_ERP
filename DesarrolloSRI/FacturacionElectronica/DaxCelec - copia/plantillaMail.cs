using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SesFelec
{
    public class plantillaMail
    {
        public static string GenerarPlantillaCorreo(
    string empresa,
    string cliente,
    string tipoDoc,
    string numero,
    string claveAcceso,
    string fecha,
    //string total,
    string correoContacto)
        {
            return $@"
<html>
<head>
<meta charset='UTF-8'>
</head>
<body style='font-family: Arial; background-color:#f4f4f4; padding:20px;'>

<table width='600' align='center' style='background:white;border-radius:8px;padding:20px;'>

<tr>
<td style='text-align:center'>
<h2 style='color:#2c3e50;'>Nuevo comprobante electrónico</h2>
</td>
</tr>

<tr>
<td>

<p>Estimado/a <b>{cliente}</b></p>

<p>
Reciba un cordial saludo de <b>{empresa}</b>.
</p>

<p>
Nos complace informarle que su documento electrónico ha sido generado con el siguiente detalle:
</p>

<table width='100%' style='border-collapse:collapse'>

<tr>
<td style='padding:6px'><b>Tipo de documento:</b></td>
<td>{tipoDoc}</td>
</tr>

<tr>
<td style='padding:6px'><b>Número:</b></td>
<td>{numero}</td>
</tr>

<tr>
<td style='padding:6px'><b>Clave de acceso:</b></td>
<td>{claveAcceso}</td>
</tr>

<tr>
<td style='padding:6px'><b>Fecha de emisión:</b></td>
<td>{fecha}</td>
</tr>



</table>

<br>

<p>
Adjunto encontrará su comprobante electrónico en formato <b>PDF</b> y <b>XML</b>.
</p>

<br>

<p style='color:#777'>
Este es un correo automático, por favor no responder.
</p>

<p>
Si requiere ayuda puede comunicarse a:<br>
<b>{correoContacto}</b>
</p>

</td>
</tr>

<tr>
<td style='text-align:center;color:#999;font-size:12px;padding-top:20px'>
© {DateTime.Now.Year} {empresa}
</td>
</tr>

</table>

</body>
</html>";
        }
    }
}
