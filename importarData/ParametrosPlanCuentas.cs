using System.Collections.Generic;
using System.Linq;

public class ParametrosPlanCuentas
{
    public int NumNiveles { get; set; }
    public List<int> DigitosPorNivel { get; set; }

    public ParametrosPlanCuentas()
    {
        DigitosPorNivel = new List<int>();
    }
}
