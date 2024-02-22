using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Suppliers
    {
        public int supplierId { get; set; }
        public string companyName { get; set;}
        public string contactName { get; set;}

        public string contactTitle { get; set;}
        public string address { get; set; }

        public string city { get; set; }
        public string country { get; set; }
        public string phone { get; set; }

    }

    public class SuppliersValidator : AbstractValidator<Suppliers>
    {
        public SuppliersValidator()
        {
            RuleFor(a => a.supplierId).NotEmpty();
            RuleFor(a => a.companyName).NotEmpty().MinimumLength(2);
            RuleFor(a => a.contactName).NotEmpty().MinimumLength(2);
            RuleFor(a => a.contactTitle).NotEmpty().MinimumLength(2);
            RuleFor(a => a.address).NotEmpty();
            RuleFor(a => a.city).NotEmpty();
            RuleFor(a => a.country).NotEmpty().MinimumLength(2);
            RuleFor(a => a.phone).NotEmpty().MaximumLength(11);

        }
    }
}
