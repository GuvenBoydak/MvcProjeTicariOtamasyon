using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x=>x.FirstName).MaximumLength(30).WithMessage("Çalişan ismi 30 karakterden fazla Olamaz!");
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Çalişan ismi Boş Geçilemez!");
            RuleFor(x=>x.LastName).MaximumLength(30).WithMessage("Çalişan Soyismi 30 karakterden fazla Olamaz!");
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("Çalişan Soyismi Boş Geçilemez!");
        }
    }
}
