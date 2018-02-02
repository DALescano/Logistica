using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Framework
{
    public static class ValidationManager
    {
        public static List<string> ValidateEntity(object entity)
        {
            if (entity == null)
                return new List<string>() { "La entidad no puede ser nulo" };

            var messages = Validate(entity);
            var error = new List<string>();
            foreach (var item in messages)
            {                
                error.Add(item.ErrorMessage);               
            }

            return error;
        }

        static List<ValidationResult> Validate(object entity, bool validateAllProperties = true)
        {
           
            var validationContext = new ValidationContext(entity, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(entity, validationContext, validationResults, validateAllProperties);

            return validationResults;
        }
    }

}
