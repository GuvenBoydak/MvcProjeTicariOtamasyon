using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("Müşteri ismi 30 karakterden fazla Olamaz!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Müşteri ismi Boş Geçilemez!");
            RuleFor(x => x.LastName).MaximumLength(30).WithMessage("Müşteri Soyismi 30 karakterden fazla Olamaz!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Müşteri Soyismi Boş Geçilemez!");
            RuleFor(x => x.City).MaximumLength(25).WithMessage("Müşteri Şehri 25 karakterden fazla Olamaz!");
            RuleFor(x => x.City).NotEmpty().WithMessage("Müşteri Şehri Boş Geçilemez!");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Müşteri Email'i 50 karakterden fazla Olamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Müşteri Email Boş Geçilemez!");
        }
    }
}
