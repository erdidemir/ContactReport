using AutoMapper;
using Contact.Application.Features.Commands.Contacts.AddKisi;
using Contact.Application.Features.Commands.Contacts.AddKisiIletisim;
using Contact.Application.Features.Commands.Rapors.UpdateRapor;
using Contact.Application.Models.Contracts;
using Contact.Application.Models.Rapors;
using Contact.Domain.Entities.Contacts;
using Contact.Domain.Entities.Rapors;
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

            CreateMap<KisiIletisim, AddKisiIletisimCommand>().ReverseMap();
            CreateMap<KisiIletisim, KisiIletisimModel>()
               .ForMember(dest => dest.KisiAd, mo => mo.MapFrom(src => src.Kisi.Ad))
               .ForMember(dest => dest.BilgiTipAd, mo => mo.MapFrom(src => src.BilgiTip.Ad))
               .ReverseMap();

            CreateMap<KisiIletisimModel, KisiIletisim>().ReverseMap();

            #endregion

            #region Rapors

            CreateMap<Rapor, RaporModel>().ReverseMap();
            CreateMap<Rapor, UpdateRaporCommand>().ReverseMap();

            #endregion


        }

    }
}
