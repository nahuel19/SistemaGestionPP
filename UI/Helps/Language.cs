using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Helps
{
    /// <summary>
    /// Clase para manejar el cambio de idioma
    /// </summary>
    public static class Language
    {
        public static Dictionary<string, string> info = new Dictionary<string, string>();

        /// <summary>
        /// Carga un diccionario con los valores de los txt de idioma
        /// </summary>
        /// <param name="file">string</param>
        private static void LoadDictionary(string file)
        {
            string folder = ConfigurationManager.AppSettings["folderLang"];
            info.Clear();
            foreach (string line in File.ReadLines(folder + file))
            {
                if (line.Contains("="))
                {
                    string[] s = line.Split(new char[] { '=' });
                    info.Add(s[0], s[1]);
                }
            }
        }

        /// <summary>
        /// Cambia el valor del archivo de idioma en la cofiguración del sistema y manda a cargar el diccionario con el archivo especificado
        /// </summary>
        /// <param name="file">string</param>
        public static void ChangeFileLanguage(string file)
        {
            Properties.Settings config = new Properties.Settings();
            config.lang = file;
            config.Save();
            LoadDictionary(file);
        }

        /// <summary>
        /// Recorre los controles de un form y les va asignando los valores que correspondan del archivo de idioma
        /// </summary>
        /// <param name="form">Form</param>
        static public void controles(Form form)
        {            
            foreach (Control e in form.Controls)
            {
                try
                {
                    form.Controls[e.Name].Text = info[e.Name];

                    //foreach (var control in info.Keys)
                    //{
                    //    if (e.Name == control)
                    //    {
                    //        form.Controls[control].Text = info[control];
                    //        break;
                    //    }
                    //}
                }
                catch(Exception ex){
                    //InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, "Language", MethodInfo.GetCurrentMethod().Name, "Error idioma: " + e.Name, ex.StackTrace, ex.Message));
                }
            }
        }

        public static string SearchValue(string key)
        {
            try {
                return info[key];
            }
            catch { 
                return key; 
            }            
        }

    }
}
