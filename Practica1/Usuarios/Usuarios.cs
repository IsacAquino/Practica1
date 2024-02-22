using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Usuarios
{
    public class User
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(a => a.Nombre).NotEmpty().MaximumLength(2);
            RuleFor(a => a.Apellido).NotEmpty().MaximumLength(2);
        }
    }

}
