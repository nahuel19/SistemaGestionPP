using DAL.DigitosVerificadores;
using DAL.Model;
using Entities.EntidadesDigitoVerificador;
using Services;
using Services.Encriptación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DigitosVerificadores
{
    class DigitosVerificadoresVGenericos
    {
        public void CargarDVV<T>(List<T> list) where T : IEntityDV
        {
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            for (int i = 0; i < Props.Length; i++)
            {
                var cadena = new StringBuilder();

                if (Props[i].Name != ConstantesTexto.DVH)
                {
                    foreach(var e in list)
                    {
                        cadena.Append(Props[i].GetValue(e) ?? string.Empty);
                        string n = Props[i].Name;
                    }

                    DVV dvv = new DVV();
                    dvv.tabla = typeof(T).Name;
                    dvv.columna = Props[i].Name;
                    dvv.DV = new CryptoSeguridad().Encrypt(cadena.ToString());

                    new DigitosVerificadoresDAL().UpdateDVV(dvv);

                }
            }       
        }


        public bool VerificarDVV<T>(List<T> list) where T : IEntityDV
        {
            bool check = true;
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < Props.Length; i++)
            {
                var cadena = new StringBuilder();

                if (Props[i].Name != ConstantesTexto.DVH)
                {
                    foreach (var e in list)
                    {
                        cadena.Append(Props[i].GetValue(e) ?? string.Empty);
                        string n = Props[i].Name;
                    }

                    byte[] dvActual = new CryptoSeguridad().Encrypt(cadena.ToString());
                    List<DVV> DVVguardado = new DigitosVerificadoresDAL().ListDVV()
                                            .Where(x => x.tabla == typeof(T).Name && x.columna == Props[i].Name).ToList(); 

                    foreach(var e in DVVguardado)
                    {
                        if (!dvActual.SequenceEqual(e.DV))
                        {
                            check = false;      
                        }                           
                    }
                }
            }
            return check;
        }



    }
}
