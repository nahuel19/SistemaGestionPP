using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Clase para extensions methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Método extension de IDataReader para obtener un valor si es entero, se le pasa el nombre de columna y devuelve el valor
        /// </summary>
        /// <param name="column">string</param>
        /// <returns>int</returns>
        public static int GetByNameInt(this IDataReader dr, string column)
        {
            int i = dr.GetOrdinal(column);
            return !String.IsNullOrEmpty(dr.GetValue(i).ToString()) ? (int)dr.GetValue(i) : 0;
        }

        /// <summary>
        /// Método extension de IDataReader para obtener un valor si es string, se le pasa el nombre de columna y devuelve el valor
        /// </summary>
        /// <param name="column">string</param>
        /// <returns>string</returns>
        public static string GetByNameString(this IDataReader dr, string column)
        {
            int i = dr.GetOrdinal(column);
            return !String.IsNullOrEmpty(dr.GetValue(i).ToString()) ? dr.GetValue(i).ToString() : "";
        }

        /// <summary>
        /// Método extension de IDataReader para obtener un valor si es double, se le pasa el nombre de columna y devuelve el valor
        /// </summary>
        /// <param name="column">string</param>
        /// <returns>double</returns>
        public static double GetByNameDouble(this IDataReader dr, string column)
        {
            int i = dr.GetOrdinal(column);
            return !String.IsNullOrEmpty(dr.GetValue(i).ToString()) ? (double)dr.GetValue(i) : 0;
        }

        /// <summary>
        /// Método extension de IDataReader para obtener un valor si es DateTime, se le pasa el nombre de columna y devuelve el valor
        /// </summary>
        /// <param name="column">string</param>
        /// <returns>DateTime</returns>
        public static DateTime GetByNameDT(this IDataReader dr, string column)
        {
            int i = dr.GetOrdinal(column);
            return !String.IsNullOrEmpty(dr.GetValue(i).ToString()) ? Convert.ToDateTime(dr.GetValue(i)) : new DateTime();
        }

        /// <summary>
        /// Método extension de String. Modificación del StartWith pero que ignora si la cadena contiene mayúsculas o minúsculas
        /// </summary>
        /// <param name="column">string</param>
        /// <returns>bool</returns>
        public static bool StartWithIgnoreMM(this string source, string filter)
        {
            return source.StartsWith(filter, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Método extension de String. Remplaza los puntos de una cadena por comas
        /// </summary>
        /// <returns>string</returns>
        public static string ReplaceDot(this string text)
        {
            return text.Replace('.' , ',');
        }

        //public static Type GetValueByName<Type>(this IDataReader dr, string column)
        //{
        //    int i = dr.GetOrdinal(column);
        //    return (Type)dr.GetValue(i);
        //}

        //public static bool Contains(this string source, string toCheck, StringComparison comp)
        //{
        //    return source.IndexOf(toCheck, comp) >= 0;
        //}

    }
}
