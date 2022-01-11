using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Validations
{
    public class ValidationErrorResult
    {
        /// <summary>
        /// Hangi property alanında hata olduğu bilgisi için
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Hata mesajı için
        /// </summary>
        public string ValidationMessage { get; set; }
    }

    public class ValidationResult
    {
        public bool IsValid { get; private set; }

        /// <summary>
        /// Nesne içerisinde birden fazla hata olma ihtimaline göre gerekli.
        /// </summary>
        public List<ValidationErrorResult> Errors { get; private set; }

        public void AddError(ValidationErrorResult error)
        {
            IsValid = false; // bir tek hata bile varsa bu nesne valid olamaz, doğrulanamaz.
            Errors.Add(error);
        }
    }

    public interface IValidator<TDto> where TDto:class
    {
        /// <summary>
        /// Validate işlemi sonrası nesnein valid olup olmadığı varsa hata mesajlarını yakalamak için yaptık.
        /// </summary>
        ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// Valip olup olmadığını görebiliriz.
        /// </summary>
        bool IsValid { get; set; }

        /// <summary>
        /// Frontend tarafında gönderlilen dtonun validasyon kurallarına uyup uymadığını kontrol ederiz.
        /// </summary>
        void Validate(TDto dto);
    }
}
