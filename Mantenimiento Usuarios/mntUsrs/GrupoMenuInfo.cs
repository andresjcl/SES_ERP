using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace mntUsrs
{
    public class GrupoMenuInfo
    {
        public string Nombre { get; set; }
        public int OrdenMinimo { get; set; }
        public List<DataRow> Items { get; set; }
    }
}
