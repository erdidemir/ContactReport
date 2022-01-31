using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Features.Commands.Contacts.AddKisi;
using Contact.Application.Mappings;
using Kisiler.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kisiler.UnitTest.Kisiler.Commands
{
    public class CreateKisiCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IKisiRepository> _mockRepo;
        private readonly AddKisiCommand _addKisiCommand;

        public CreateKisiCommandHandlerTests()
        {
            _mockRepo = MockKisiRepository.GetKisiRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);

            _addKisiCommand = new AddKisiCommand()
            {
                Ad = "Kisi",
                Soyad = "Soyad",
                Firma = "Firma"
            };
        }

        [Fact]
        public async Task CreateKisi()
        {
            var handler = new AddKisiCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(_addKisiCommand, CancellationToken.None);

            var kisiler = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<int>();

        }
    }
}
