using System.ComponentModel.DataAnnotations;

namespace SzkolenieTechniczne3.Common.CrossCutting.Validationattributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class NotDefaultAttribute :ValidationAttribute
    {
        public const string defaultErrorMessage = "The {0} field must not have the default value";
        public NotDefaultAttribute() : base(defaultErrorMessage) { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is null)
            {
                return ValidationResult.Success;
            }
            var type = value.GetType();
            if(type.IsValueType)
            {
                var defaultValue = Activator.CreateInstance(type);
                return !value.Equals(default)
                      ? ValidationResult.Success!
                      : new ValidationResult("Value_IS_REQUIRED"); ;
            }
            return ValidationResult.Success;
        }


    }
}
