using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Mappings;
using Kisiler.UnitTest.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Contact.Application.Features.Queries.Contacts.GetKisiList;
using System.Threading;
using Contact.Application.Models.Contracts;
using Shouldly;

namespace Kisiler.UnitTest.Kisiler.Queries
{
    public class GetKisiListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IKisiRepository> _mockRepo;

        public GetKisiListRequestHandlerTests()
        {
            _mockRepo = MockKisiRepository.GetKisiRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task GetKisiListTest()
        {
            var handler = new GetKisiListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetKisiListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<KisiModel>>();
        }
    }
}
