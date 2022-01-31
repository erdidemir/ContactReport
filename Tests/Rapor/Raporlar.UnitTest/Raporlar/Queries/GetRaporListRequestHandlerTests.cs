using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Mappings;
using Raporlar.UnitTest.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Contact.Application.Models.Contracts;
using Shouldly;
using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Application.Features.Queries.Rapors.GetRaporList;
using Contact.Application.Models.Rapors;

namespace Raporlar.UnitTest.Raporlar.Queries
{
    public class GetRaporListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRaporRepository> _mockRepo;

        public GetRaporListRequestHandlerTests()
        {
            _mockRepo = MockRaporRepository.GetRaporRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task GetRaporListTest()
        {
            var handler = new GetRaporListQueryHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetRaporListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<RaporModel>>();
        }
    }
}
