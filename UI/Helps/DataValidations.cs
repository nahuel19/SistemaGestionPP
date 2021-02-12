using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Helps
{
    public class DataValidations
    {
        private ValidationContext context;
        private List<ValidationResult> results;
        private bool valid;
        private string message;

        public DataValidations(object instance)
        {
            context = new ValidationContext(instance);
            results = new List<ValidationResult>();
            valid = Validator.TryValidateObject(instance, context, results, true);
        }

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
