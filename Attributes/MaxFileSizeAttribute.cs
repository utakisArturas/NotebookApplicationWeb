using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Upload_Download_Api.Attributes
{
    public class MaxFileSizeAttribute :ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if(file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Max file size is { _maxFileSize } bytes.";
        }
    }
   
}
