using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helps
{
    /// <summary>
    /// Validación de datos ingresdos por el usuarios, a travéz de DataAnnotations
    /// </summary>
    public class DataValidations
    {
        private ValidationContext context;
        private List<ValidationResult> results;
        private bool valid;
        private string message;

        /// <summary>
        /// Constructor DataValidations, recibe object y carga en context, genera una lista de resultados y llama método TryValidateObject para verificar las DataAnnotations
        /// </summary>
        /// <param name="instance">object</param>
        public DataValidations(object instance)
        {
            context = new ValidationContext(instance);
            results = new List<ValidationResult>();
            valid = Validator.TryValidateObject(instance, context, results, true);
        }

        /// <summary>
        /// Devuelve un bool para ver si la validación fue correcta o no, en caso de ser incorrecta recorre la lista de resultados y genera un mensaje con los errores y lo devuelve junto con el bool
        /// </summary>
        /// <returns>bool,string</returns>
        public (bool, string) Validate()
        {
            if (valid == false)
            {
                foreach(var item in results)
                { message += item.ErrorMessage + "\n"; }      
            }

            return (valid, message);
        }

    }
}
