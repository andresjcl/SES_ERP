using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxMedic
{
    public class DatosFacturaCitaMedica
    {
        public string TipoDoc = "";         
        public string CirucPaciente = "";
        public string CodigoPaciente = "";
        public double IdclaveCitaMedica = 0;     // para eliminar o modificar desde facturación si  no se confirma la factura
        public string nropedidoLab = "";        // si es 'CREAR' debe crear pedido examenes de laboratorio nuevo con paciente
        public string nroPedidoImg = "";        // si es 'CREAR' debe crear pedido exámenes de imagenología nuevo con paciente
        public string DrPedidoLab = "";
        public string DrPedidoImg = "";
        public double NroTurno = 0;
        public string CodigoDoctor = "";

        public string[] ConceptoCodigo;
        public string[] ConceptoDetalle;
        public double[] ConceptoCantidad;
        public double[] ConceptoPVunitario;
        public string[] ConceptoTipo;
        public string[] AuxVar3;  // control de pedido previo para actualizacion o creacion de pedidos
    }
}

