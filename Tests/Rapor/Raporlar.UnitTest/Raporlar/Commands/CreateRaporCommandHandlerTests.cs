using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Mappings;
using Raporlar.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Application.Features.Commands.Rapors.AddRapor;
using Contact.Domain.Enums.Rapors;

namespace Raporlar.UnitTest.Raporlar.Commands
{
    public class CreateRaporCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRaporRepository> _mockRepo;
        private readonly AddRaporCommand _addRaporCommand;

        public CreateRaporCommandHandlerTests()
        {
            _mockRepo = MockRaporRepository.GetRaporRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);

            _addRaporCommand = new AddRaporCommand()
            {
                 Tarih = new DateTime(2022,01,01)
            };
        }

        [Fact]
        public async Task CreateRapor()
        {
            var handler = new AddRaporCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(_addRaporCommand, CancellationToken.None);

            var kisiler = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<Guid>();

        }
    }
}
