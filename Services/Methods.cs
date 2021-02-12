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

        private static bool AreNotOnlyNumbers(string text)
        {
            return !Regex.IsMatch(text, @"^\d+$");
        }

        public static DataTable ConvertToDataTable<T>(List<T> models)
        {
            DataTable dataTable = new DataTable();
            // creating a data table instance and typed it as our incoming model 
            // as I make it generic, if you want, you can make it the model typed you want. DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties of that model
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Loop through all the properties            
            // Adding Column name to our datatable
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            // Adding Row and its value to our dataTable
            foreach (T item in models)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows  
                    values[i] = Props[i].GetValue(item, null);
                }
                // Finally add value to datatable  
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static void DT_to_Excel(DataTable dt, string filename)
        {
            if (!Directory.Exists(ConfigurationManager.AppSettings["FolderExcel"])) {
                DirectoryInfo di = Directory.CreateDirectory(ConfigurationManager.AppSettings["FolderExcel"]);                 
            }
                
            SLDocument doc = new SLDocument();
            doc.ImportDataTable(1, 1, dt, true);
            doc.SaveAs(Path.Combine(ConfigurationManager.AppSettings["FolderExcel"], filename));
        }
    }
}
