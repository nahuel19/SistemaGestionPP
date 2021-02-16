using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Clase para agregar metodos generales de apoyo a otras clases
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Calcula la edad a partir de una fecha de nacimiento
        /// </summary>
        /// <param name="dateBorn">Datetime</param>
        /// <returns>int edad</returns>
        public static int CalculateAge(DateTime dateBorn)
        {
            int age;
            DateTime today = DateTime.Today;

            age = today.Year - dateBorn.Year;

            if (dateBorn.Month > today.Month)
                --age;
            
            return age;
        }
           
        /// <summary>
        /// Convierte una lista a dataTable
        /// </summary>
        /// <typeparam name="T">tipo de lista genérico</typeparam>
        /// <param name="models">List</param>
        /// <returns>DataTable</returns>
        public static DataTable ConvertToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable();
            
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (PropertyInfo prop in Props)
            {  
                dataTable.Columns.Add(prop.Name);
            }
            
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {                    
                    values[i] = Props[i].GetValue(item, null);
                }                
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }


        //public  static List<T> ConvertToList<T>(DataTable dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T item = GetItem<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}
        //private static T GetItem<T>(DataRow dr)
        //{           
        //    Type temp = typeof(T);
        //    T obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (PropertyInfo pro in temp.GetProperties())
        //        {
        //            if (pro.Name == column.ColumnName)     
        //                pro.SetValue(obj, dr[column.ColumnName], null);
        //            else
        //                continue;
        //        }
        //    }
        //    return obj;
        //}


        //private static bool AreNotOnlyNumbers(string text)
        //{
        //    return !Regex.IsMatch(text, @"^\d+$");
        //}

        //public static void DT_to_Excel(DataTable dt, string filename)
        //{
        //    if (!Directory.Exists(ConfigurationManager.AppSettings["FolderExcel"])) {
        //        DirectoryInfo di = Directory.CreateDirectory(ConfigurationManager.AppSettings["FolderExcel"]);                 
        //    }

        //    SLDocument doc = new SLDocument();
        //    doc.ImportDataTable(1, 1, dt, true);
        //    doc.SaveAs(Path.Combine(ConfigurationManager.AppSettings["FolderExcel"], filename));
        //}
    }
}
