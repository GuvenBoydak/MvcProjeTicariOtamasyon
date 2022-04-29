using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class DepartmentValidator:AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Departman ismi 40 karakterden fazla Olamaz!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Departman ismi Boş Geçilemez!");
        }
    }
}
