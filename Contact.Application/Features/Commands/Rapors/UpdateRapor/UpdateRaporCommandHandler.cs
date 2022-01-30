using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Domain.Entities.Rapors;
using Contact.Domain.Enums.Rapors;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Rapors.UpdateRapor
{
    internal class UpdateRaporCommandHandler : IRequestHandler<UpdateRaporCommand>
    {
        private readonly IRaporRepository _raporRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRaporCommandHandler> _logger;

        public UpdateRaporCommandHandler(IRaporRepository raporRepository, IMapper mapper, ILogger<UpdateRaporCommandHandler> logger)
        {
            _raporRepository = raporRepository ?? throw new ArgumentNullException(nameof(raporRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateRaporCommand request, CancellationToken cancellationToken)
        {
            var raporToUpdate = await _raporRepository.GetByIdAsync(request.Id);
            if (raporToUpdate == null)
            {
                throw new Exception("Rapor bulunamadı");
            }

            _mapper.Map(request, raporToUpdate, typeof(UpdateRaporCommand), typeof(Rapor));

            if(string.IsNullOrEmpty(raporToUpdate.RaporUrl) == false )
            {
                raporToUpdate.RaporDurumEnumId = (int)RaporDurumEnum.Tamamlandı;
            }

            await _raporRepository.UpdateAsync(raporToUpdate);

            _logger.LogInformation($"Rapor {raporToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
