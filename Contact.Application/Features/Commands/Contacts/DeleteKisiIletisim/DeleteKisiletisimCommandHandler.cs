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

namespace Contact.Application.Features.Commands.Contacts.DeleteKisiIletisim
{
    public class DeleteKisiIletisimCommandHandler : IRequestHandler<DeleteKisiIletisimCommand>
    {
        private readonly IKisiIletisimRepository _KisiIletisimRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteKisiIletisimCommandHandler> _logger;

        public DeleteKisiIletisimCommandHandler(IKisiIletisimRepository KisiIletisimRepository, IMapper mapper, ILogger<DeleteKisiIletisimCommandHandler> logger)
        {
            _KisiIletisimRepository = KisiIletisimRepository ?? throw new ArgumentNullException(nameof(KisiIletisimRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteKisiIletisimCommand request, CancellationToken cancellationToken)
        {
            var KisiIletisimToDelete = await _KisiIletisimRepository.GetByIdAsync(request.Id);
            if (KisiIletisimToDelete == null)
            {
                throw new Exception("Kişi bulunamadı");
            }

            await _KisiIletisimRepository.RemoveAsync(KisiIletisimToDelete);

            _logger.LogInformation($"KisiIletisim {KisiIletisimToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
