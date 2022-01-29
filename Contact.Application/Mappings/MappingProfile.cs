using AutoMapper;
using Contact.Application.Features.Commands.Contacts.AddKisi;
using Contact.Application.Models.Contracts;
using Contact.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Contracts

            CreateMap<Kisi, AddKisiCommand>().ReverseMap();
            CreateMap<Kisi, KisiModel>().ReverseMap();

            #endregion


        }

    }
}
