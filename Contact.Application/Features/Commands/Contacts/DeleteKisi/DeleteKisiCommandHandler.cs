using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Features.Commands.Contacts.DeleteKisi
{
    public class DeleteKisiCommandHandler : IRequestHandler<DeleteKisiCommand>
    {
        private readonly IKisiRepository _kisiRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteKisiCommandHandler> _logger;

        public DeleteKisiCommandHandler(IKisiRepository kisiRepository, IMapper mapper, ILogger<DeleteKisiCommandHandler> logger)
        {
            _kisiRepository = kisiRepository ?? throw new ArgumentNullException(nameof(kisiRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteKisiCommand request, CancellationToken cancellationToken)
        {
            var kisiToDelete = await _kisiRepository.GetByIdAsync(request.Id);
            if (kisiToDelete == null)
            {
                throw new Exception("Kişi bulunamadı");
            }

            await _kisiRepository.RemoveAsync(kisiToDelete);

            _logger.LogInformation($"Kisi {kisiToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
