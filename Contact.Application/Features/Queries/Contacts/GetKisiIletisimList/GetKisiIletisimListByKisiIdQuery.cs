﻿using Contact.Application.Models.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Features.Queries.Contacts.GetKisiIletisimList
{
    public class GetKisiIletisimListByKisiIdQuery : IRequest<IList<KisiIletisimModel>>
    {
        public Guid KisiId { get; set; }

        public GetKisiIletisimListByKisiIdQuery(Guid kisiId)
        {
            KisiId = kisiId;
        }
    }
}
