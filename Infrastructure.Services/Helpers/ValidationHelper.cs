using Application.Services.Helpers;
using FluentValidation;
using Infrastructure.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helpers
{
    public class ValidationHelper<TObject> : IValidationHelper<TObject>
    {
        IValidator<TObject> _validator;

        public ValidationHelper(IValidator<TObject> validator)
        {
            _validator = validator;
        }

        public async Task ValidateAsync(TObject obj)
        {
            var result = await _validator.ValidateAsync(obj);

            if (!result.IsValid)
            {
                string errorMessage = "";
                foreach(var error in result.Errors)
                {
                    errorMessage += error.ErrorMessage + "\n";
                }
                throw new IncorrectRequestDataException(errorMessage);
            }
        }
    }
}
