using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.AddKisi
{
    public class AddKisiValidator : AbstractValidator<AddKisiCommand>
    {
        public AddKisiValidator()
        {
            RuleFor(c => c.Ad).NotEmpty().WithMessage("{Ad Address} is required.");
            RuleFor(c => c.Firma).NotEmpty().WithMessage("{Firma} is required.");

        }
    }
}
