using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Validators
{
    public class UrlValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return IsUrlValid(value)
                ? ValidationResult.Success
                : new ValidationResult($"Invalid url {value}");
        }

        private static bool IsUrlValid(object value)
        {
            try
            {
                return value is string url && new Uri(url).IsWellFormedOriginalString();
            }
            catch
            {
                return false;
            }
        }
    }
}