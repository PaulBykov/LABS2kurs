using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    internal class BelarusPassport : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext? validationContext = null)
        {
            if (value == null)
            {
                return new ValidationResult("Значение пусто");
            }

            string passportNumber = ((TextBox)value).Text;

            // Проверяем, соответствует ли номер паспорта формату МС1234567
            Regex regex = new Regex(@"^MC\d{7}$");
            if (!regex.IsMatch(passportNumber))
            {
                return new ValidationResult("Номер паспорта не соответствует формату МС1234567.");
            }

            return new ValidationResult("Успех!");
        }
    }
}
