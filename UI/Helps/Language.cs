using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Helps
{
    public static class Language
    {
        public static Dictionary<string, string> info = new Dictionary<string, string>();

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


        public static void ChangeFileLanguage(string file)
        {
            Properties.Settings config = new Properties.Settings();
            config.lang = file;
            config.Save();
            LoadDictionary(file);
        }

        static public void controles(Form form)
        {            
            foreach (Control e in form.Controls)
            {
                
                try
                {
                    //form.Controls[control].Text = info[control];

                    foreach (var control in info.Keys)
                    {
                        if (e.Name == control)
                        {
                            form.Controls[control].Text = info[control];
                            break;
                        }
                    }


                    //if (form.Controls[control.ToString()].Controls != null)
                    //{
                    //    foreach(var subControl in form.Controls[control.ToString()].Controls)
                    //    {
                    //        form.Controls[control.ToString()].Controls[subControl.ToString()].Text = info[control.ToString()];
                    //    }

                    //}

                }
                catch{}
            }
        }

    }
}
