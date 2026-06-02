using System.Data;

namespace CierreDeCaja
{
    public partial class DataSet1
    {
        partial class DataTableGenDataTable
        {
        }

        public partial class DataTable2DataTable
        {
            private void DataTable2DataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
            {
                if ((e.Column.ColumnName ?? "") == (UsuarioColumn.ColumnName ?? ""))
                {
                    // Agregar código de usuario aquí
                }
            }
        }

        public partial class DataTable1DataTable
        {
        }
    }
}