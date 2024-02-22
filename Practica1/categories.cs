using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class categories
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
    }

    public class CategoriasValidator : AbstractValidator<categories>
    {
        public CategoriasValidator()
        {
            RuleFor(a => a.categoryId).NotEmpty();
            RuleFor(a => a.categoryName).NotEmpty().MinimumLength(2);
           //RuleFor(a => a.categoryDescription).NotEmpty().MinimumLength(2);
            //RuleFor(a => a.categoryId).NotEmpty();
            //RuleFor(a => a.quantityPerUnit).NotEmpty();
            //RuleFor(a => a.unitPrice).NotEmpty();
            //RuleFor(a => a.unitsInStock).NotEmpty();
            //RuleFor(a => a.unitsOnOrder).NotEmpty();
            //RuleFor(a => a.recorderLevel).NotEmpty();


        }
    }
}
