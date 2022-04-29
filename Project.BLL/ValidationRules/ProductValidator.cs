using FluentValidation;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Ürün ismi 40 karakterden Fazla Olamaz!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismi Boş Geçilemez!");
            RuleFor(x => x.Brand).MaximumLength(40).WithMessage("Ürün markası 40 karakterden Fazla Olamaz!");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Ürün markası Boş Geçilemez!");

        }
    }
}
