using DAL.DigitosVerificadores;
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
    public class DigitosVerificadoresHGenericos
    {        
        //cierre
        public T CargarEntityConDVH<T>(T entity) where T : IEntityDV
        {            
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var cadena = new StringBuilder();
            for (int i = 0; i < Props.Length; i++)
            {
                if(Props[i].Name != ConstantesTexto.DVH)
                    cadena.Append(Props[i].GetValue(entity) ?? string.Empty);
            }
                       
            entity.DVH = new CryptoSeguridad().Encrypt(cadena.ToString());

            return entity;
        }

        //cierre
        public void UpdateDVH(IEntityDV entity, string tabla)
        {
            DigitosVerificadoresDAL digitosVerificadoresDAL = new DigitosVerificadoresDAL();
            digitosVerificadoresDAL.Update(entity, tabla);
        }

        //apertura
        public int? VerificarEntityConDVH<T>(T entity) where T : IEntityDV
        {
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int? filaCorrupta = null;
            var cadena = new StringBuilder();

            for (int i = 0; i < Props.Length; i++)
            {
                if (Props[i].Name != ConstantesTexto.DVH)
                    cadena.Append(Props[i].GetValue(entity) ?? string.Empty);
            }


            if (entity.DVH == null)
            {
                filaCorrupta = entity.id;
            }         
            else
            {
                if (!entity.DVH.SequenceEqual(new CryptoSeguridad().Encrypt(cadena.ToString())))
                {
                    filaCorrupta = entity.id;
                }
            }
            return filaCorrupta;
        }

    }


    

}
