
using FluentValidation.Results;

namespace Assignment.Core.Exceptions;

public class ValidatorException : ApplicationException
{
    public ValidatorException(ValidationResult result)
    {
        
    }
}