using DomainLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MaximumLength(30).WithMessage("Ad kısmı boş bırakılamaz!");
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(30).WithMessage("Soyad kısmı boş bırakılamaz!");
            RuleFor(u => u.Email).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Girilen mail doğru formatta değildir!");
            RuleFor(u => u.BirthDate).NotEmpty().LessThan(DateTime.Now).WithMessage("Doğum tarihi yanlış girilmiştir!");
            RuleFor(u => u.IDNo).NotEmpty().Must(u => u.Length == 11 && (int)(u.Last())%2==0 && (int)u.First() >= 0).WithMessage("Geçerli bir kimlik numarası giriniz");
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Parola en az 6 karakter uzunluğunda olmalıdır!");
        }
    }
}
