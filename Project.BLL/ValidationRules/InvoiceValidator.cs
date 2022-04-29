using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class InvoiceValidator:AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.SerialNo).MaximumLength(1).WithMessage("Seri No 1 Karakteden Fazla Olamaz");
            RuleFor(x => x.SerialNo).NotEmpty().WithMessage("Seri No Boş Geçilemez!");
            RuleFor(x => x.InvoiceNumber).MaximumLength(20).WithMessage("Sıra No 20 Karakteden Fazla Olamaz");
            RuleFor(x => x.InvoiceNumber).NotEmpty().WithMessage("Sıra No Boş Geçilemez!");
            RuleFor(x => x.TaxAuthorityNumber).MaximumLength(60).WithMessage("Vergi Dairesi Numarası 60 Karakteden Fazla Olamaz");
            RuleFor(x => x.TaxAuthorityNumber).NotEmpty().WithMessage("Vergi Dairesi Numarası Boş Geçilemez!");
            RuleFor(x => x.Submitter).MaximumLength(40).WithMessage("Gönderici ismi 40 Karakteden Fazla Olamaz");
            RuleFor(x => x.Submitter).NotEmpty().WithMessage("Gönderici ismi Boş Geçilemez!");
            RuleFor(x => x.Receiver).MaximumLength(40).WithMessage("Teslim Alan ismi 40 Karakteden Fazla Olamaz");
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Teslim Alan ismi Boş Geçilemez!");

        }
    }
}
