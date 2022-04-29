using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class ExpensValidator:AbstractValidator<Expens>
    {
        public ExpensValidator()
        {
            RuleFor(x=>x.Description).MaximumLength(100).WithMessage("Açıklama 100 Karakterden Fazla Olamaz!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez!");
        }
    }
}
