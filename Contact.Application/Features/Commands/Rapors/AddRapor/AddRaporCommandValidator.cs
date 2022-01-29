using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Rapors.AddRapor
{
    public class AddRaporCommandValidator : AbstractValidator<AddRaporCommand>
    {
        public AddRaporCommandValidator()
        {
            RuleFor(c => c.Tarih).NotEmpty().WithMessage("{Tarih} is required.");
        }
    }
}