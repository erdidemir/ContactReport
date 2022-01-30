using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.AddKisiIletisim
{
    public class AddKisiIletisimCommandValidator : AbstractValidator<AddKisiIletisimCommand>
    {
        public AddKisiIletisimCommandValidator()
        {
            RuleFor(c => c.KisiId).NotEmpty().WithMessage("{Kisi Id} is required.");
            RuleFor(c => c.BilgiTipId).NotEmpty().WithMessage("{BilgiTipId} is required.");

        }
    }
}
