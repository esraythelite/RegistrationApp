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
    public class UserConfiguration:AbstractValidator<User>
    {
        public UserConfiguration()
        {
            RuleFor(u => u.FirstName).NotEmpty().MaximumLength(30).WithMessage("Ad kısmı boş bırakılamaz!");
            RuleFor(u => u.LastName).NotEmpty().MaximumLength(30).WithMessage("Soyad kısmı boş bırakılamaz!");
            RuleFor(u => u.Email).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Girilen mail doğru formatta değildir!");
            RuleFor(u => u.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz!").LessThan(DateTime.Now);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Parola en az 6 karakter uzunluğunda olmalıdır!");
        }
    }
}
