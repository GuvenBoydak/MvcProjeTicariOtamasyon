using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class InvoiceBodyValidator:AbstractValidator<InvoiceBody>
    {
        public InvoiceBodyValidator()
        {
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama 100 Karakterden Fazla Olamaz!");
        }
    }
}
