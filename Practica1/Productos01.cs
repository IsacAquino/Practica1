using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Productos01
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int supplierId { get; set; }
        public int categoryId { get; set; }
        public double quantityPerUnit { get; set; }
        public double unitPrice { get; set; }
        public double unitsInStock { get; set; }
        public double unitsOnOrder { get; set; }
        public int recorderLevel { get; set; }
    }

    public class ProductosValidator : AbstractValidator<Productos01>
    {
        public ProductosValidator()
        {
            RuleFor(a => a.productId).NotEmpty();
            RuleFor(a => a.productName).NotEmpty().MinimumLength(2);
            RuleFor(a => a.supplierId).NotEmpty();
            RuleFor(a => a.categoryId).NotEmpty();
            //RuleFor(a => a.quantityPerUnit).NotEmpty();
            //RuleFor(a => a.unitPrice).NotEmpty();
            //RuleFor(a => a.unitsInStock).NotEmpty();
            //RuleFor(a => a.unitsOnOrder).NotEmpty();
            //RuleFor(a => a.recorderLevel).NotEmpty();


        }

    }
}
