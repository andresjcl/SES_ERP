using System.Data;

namespace ArtInvent
{
	public partial class DataSet1
	{
		public partial class DataTable1DataTable
		{
			private void DataTable1DataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
			{
				if ((e.Column.ColumnName ?? "") == (OtrosEgresosColumn.ColumnName ?? ""))
				{

					// Agregar código de usuario aquí
				}
			}
		}
	}
}