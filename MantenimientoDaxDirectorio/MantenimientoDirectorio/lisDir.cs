using System;
using Microsoft.VisualBasic;

namespace directMnt
{
	public class lisDir
	{
		public void MallaDir(string queTipo = "")
		{
			var PROG = new AdcDir();
			try
			{
				Module1.Mainn();
				PROG.tipo = queTipo;
				PROG.Show();
			}
			// PROG.Dispose()
			catch (Exception ee)
			{
				Interaction.MsgBox("Excepción mallaDir: " + ee.Message);
			}
		}
	}
}