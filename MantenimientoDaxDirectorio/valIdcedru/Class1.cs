using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace valIdcedru
{
    public class valcedruc
    {
        public Int32 final = 0;
        public Int32 NUMERO_DE_PROVINCIAS = 24;

        public Boolean valCr(string numero, string tipo, string persona)
        {
            Boolean esNumero = true;
            Boolean esValido = false;

            try
            {
                numero = "" + numero.Trim();
                Decimal nn = 0;
                nn = Decimal.Parse(numero);
            }
            catch
            {
                esNumero = false;
            }

            if (numero.Length >= 10 & esNumero == true)
            {
                int prov = int.Parse(numero.Substring(0, 2));
                if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS))) { return false; }

                if (tipo == "F" && numero == "9999999999999") { esValido = true; }
                if (tipo == "C" && persona == "P") { esValido = esCedulaValida(numero); }
                if (tipo == "R" && persona == "P")
                {
                    esValido = validaRucPersonal(numero);
                    if (esValido == false) { esValido = ValidarRucPerExt(numero); }
                    //if (esValido == false) {esValido = ValidarRucPerEXSC(numero);}
                }
                //aqui debe venir
                if (tipo == "R" && persona != "P")
                {
                    esValido = ValidarRucEmpresa(numero);

                    ////ruc nuevo MODIFICADO 05/06/2023
                    if (esValido == false) { esValido = validaRucEP(numero); }
                    if (esValido == false) { esValido = validaRucEX(numero); }
                    if (esValido == false) { esValido = validaRucEXEmp(numero); }
                    if (esValido == false) { esValido = validaRucEXUno(numero); }
                    //if (esValido == false) { esValido = validaRucEPP(numero); }
                }
            }
            return esValido;
        }

        private Boolean esCedulaValida(String cedula)
        {
            //verifica que tenga 10 dígitos y que contenga solo valores numéricos
            long nn = 0;
            if (!((cedula.Length == 10) && long.TryParse(cedula, out nn))) { return false; }

            //verifica que los dos primeros dígitos correspondan a un valor entre 1 y NUMERO_DE_PROVINCIAS
            //int prov = int.Parse(cedula.Substring(0, 2));
            //if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS))) { return false; }

            //verifica que el último dígito de la cédula sea válido
            int[] d = new int[10];

            //Asignamos el string a un array
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = Int32.Parse(cedula[i] + "");
            }

            int imp = 0;
            int par = 0;

            //sumamos los duplos de posición impar
            for (int i = 0; i < d.Length; i += 2)
            {
                d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
                imp += d[i];
            }

            //sumamos los digitos de posición par
            for (int i = 1; i < (d.Length - 1); i += 2)
            {
                par += d[i];
            }

            //Sumamos los dos resultados
            int suma = imp + par;

            //Restamos de la decena superior
            int d10 = int.Parse((suma + 10).ToString().Substring(0, 1) + "0") - suma;

            //Si es diez el décimo dígito es cero        
            d10 = (d10 == 10) ? 0 : d10;

            //si el décimo dígito calculado es igual al digitado la cédula es correcta
            return (d10 == d[9]);
        }

        private Boolean validaRucPersonal(String cedula)
        {
            if (cedula.Length != 13) return false;
            if (cedula.Substring(10, 3) != "001") return false;
            return esCedulaValida(cedula.Substring(0, 10));


        }

        private Boolean ValidarRucEmpresa(string ruc)
        {
            if (ruc.Length != 13) return false;
            //            if (ruc.Substring(11, 3) != "001") return false;
            int[] coeficientes = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int constante = 11;

            //int prov = int.Parse(ruc.Substring(0, 2));
            //if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS) )) { return false; }

            int[] d = new int[10];
            int suma = 0;

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            for (int i = 0; i < d.Length - 1; i++)
            {
                d[i] = d[i] * coeficientes[i];
                suma += d[i];
            }



            int aux;
            int resp;

            aux = suma % constante;
            resp = constante - aux;

            resp = (aux == 0) ? 0 : resp;
            return (resp == d[9]);
        }

        /*private Boolean ValidarRucPerEXSC(string ruc)
        {
            if (ruc.Length != 13) return false;
            //            if (ruc.Substring(11, 3) != "001") return false;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2, };
            int constante = 10;

            //int prov = int.Parse(ruc.Substring(0, 2));
            //if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS) )) { return false; }

            int[] d = new int[10];
            int suma = 0;

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            for (int i = 0; i < d.Length - 1; i++)
            {
                d[i] = d[i] * coeficientes[i];
                suma += d[i];
            }



            int aux;
            int resp;

            aux = suma % constante;
            resp = constante - aux;

            resp = (aux == 0) ? 0 : resp;
            return (resp == d[9]);
        }*/

        private Boolean ValidarRucPerExt(string ruc)
        {
            if (ruc.Length != 13) return false;
            //            if (ruc.Substring(11, 3) != "001") return false;
            int[] coeficientes = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int constante = 11;

            //int prov = int.Parse(ruc.Substring(0, 2));
            //if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS) )) { return false; }

            int[] d = new int[10];
            int suma = 0;

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            for (int i = 0; i < d.Length - 1; i++)
            {
                d[i] = d[i] * coeficientes[i];
                suma += d[i];
            }



            int aux;
            int resp;

            aux = suma % constante;
            resp = constante - aux;

            resp = (aux == 0) ? 0 : resp;
            return (resp == d[9]);
        }

        public Boolean validaRucEPP(String ruc)
        {
            if (ruc.Length != 13) return false;
            //        
            Boolean resp = false;
            int v1, v2, v3, v4, v5, v6, v7, v8, v9;
            int sumatoria;
            int modulo;
            int digito;
            int[] d = new int[ruc.Length];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            v1 = d[0] * 3;
            v2 = d[1] * 2;
            v3 = d[2] * 7;
            v4 = d[3] * 6;
            v5 = d[4] * 5;
            v6 = d[5] * 4;
            v7 = d[6] * 3;
            v8 = d[7] * 2;
            v9 = d[8];

            sumatoria = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8;
            modulo = sumatoria % 11;
            if (modulo == 0)
            {
                return true;
            }
            digito = 11 - modulo;

            if (digito.Equals(v9))
            {
                resp = true;
            }
            else
            {
                resp = false;
            }
            return resp;
        }
        public Boolean validaRucEP(String ruc)
        {
            if (ruc.Length != 13) return false;
            //        
            Boolean resp = false;
            int v1, v2, v3, v4, v5, v6, v7, v8, v9;
            int sumatoria;
            int modulo;
            int digito;
            int[] d = new int[ruc.Length];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            v1 = d[0] * 3;
            v2 = d[1] * 2;
            v3 = d[2] * 7;
            v4 = d[3] * 6;
            v5 = d[4] * 5;
            v6 = d[5] * 4;
            v7 = d[6] * 3;
            v8 = d[7] * 2;
            v9 = d[8];

            sumatoria = v1 + v2 + v3 + v4 + v5 + v6 + v7 + v8;
            modulo = sumatoria % 11;
            if (modulo == 0)
            {
                return true;
            }
            digito = 11 - modulo;

            if (digito.Equals(v9))
            {
                resp = true;
            }
            else
            {
                resp = false;
            }
            return resp;
        }
        public Boolean validaRucEX(String ruc)
        {
            //Boolean resp = false;
            int num = 3;
            if (ruc.Length != 13) return false;


            int prov = int.Parse(ruc.Substring(0, 2));
            if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS))) { return false; }

            Boolean resp = false;
            int v1, v2, v3, v4, v5, v6, v7, v8, v9;

            int[] d = new int[ruc.Length];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            v1 = d[0];
            v2 = d[1];
            v3 = d[2];
            v4 = d[3];
            v5 = d[4];
            v6 = d[5];
            v7 = d[6];
            v8 = d[7];
            v9 = d[8];


            if (v4.Equals(num))
            {
                resp = true;
            }
            else
            {
                resp = false;
            }
            return resp;
        }

        public Boolean validaRucEXEmp(String ruc)
        {
            //Boolean resp = false;
            int num1 = 6;
            if (ruc.Length != 13) return false;
            //int num2= int.Parse(ruc.Substring(0, 2));
            int prov = int.Parse(ruc.Substring(0, 2));
            if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS))) { return false; }

            Boolean resp = false;
            int v1, v2, v3, v4, v5, v6, v7, v8, v9;

            int[] d = new int[ruc.Length];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            v1 = d[0];
            v2 = d[1];
            v3 = d[2];
            v4 = d[3];
            v5 = d[4];
            v6 = d[5];
            v7 = d[6];
            v8 = d[7];
            v9 = d[8];


            if (v6.Equals(num1))
            {
                resp = true;
            }
            else
            {
                resp = false;
            }
            return resp;
        }

        public Boolean validaRucEXUno(String ruc)
        {
            //Boolean resp = false;
            int num1 = 1;
            if (ruc.Length != 13) return false;
            //int num2= int.Parse(ruc.Substring(0, 2));
            int prov = int.Parse(ruc.Substring(0, 2));
            if (prov != 30) if (!((prov > 0) && (prov <= NUMERO_DE_PROVINCIAS))) { return false; }

            Boolean resp = false;
            int v1, v2, v3, v4, v5, v6, v7, v8, v9;

            int[] d = new int[ruc.Length];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(ruc[i] + "");
            }

            v1 = d[0];
            v2 = d[1];
            v3 = d[2];
            v4 = d[3];
            v5 = d[4];
            v6 = d[5];
            v7 = d[6];
            v8 = d[7];
            v9 = d[8];


            if (v4.Equals(num1))
            {
                resp = true;
            }
            else
            {
                resp = false;
            }
            return resp;
        }

    }
}
