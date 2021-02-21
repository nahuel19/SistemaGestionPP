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
    /// <summary>
    /// Contiene métodos genéricos para mandejo de entidades con DVH
    /// </summary>
    public class DigitosVerificadoresHGenericos
    {
       
        /// <summary>
        /// Carga una entidad con su DVH
        /// </summary>
        /// <typeparam name="T">Entidad que herede de IEntityDV</typeparam>
        /// <param name="entity">Entidad</param>
        /// <returns>Entidad</returns>
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

        /// <summary>
        /// Llama update de DAL para actualizar una entidad con su DVH 
        /// </summary>
        /// <param name="entity">IEntityDV</param>
        /// <param name="tabla">string</param>
        public void UpdateDVH(IEntityDV entity, string tabla)
        {
            DigitosVerificadoresDAL digitosVerificadoresDAL = new DigitosVerificadoresDAL();
            digitosVerificadoresDAL.Update(entity, tabla);
        }

        /// <summary>
        /// Verifica que el DVH guardad de una entidad coincida con el DVH calculado al día con los datos de la entidad
        /// </summary>
        /// <typeparam name="T">IEntityDV</typeparam>
        /// <param name="entity">Entidad</param>
        /// <returns>int?, devuelve el id de la entidad en caso de que esté corrupta</returns>
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
