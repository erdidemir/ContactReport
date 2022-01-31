using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Domain.Entities.Rapors;
using Contact.Domain.Enums.Rapors;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raporlar.UnitTest.Mocks
{
    public static class MockRaporRepository
    {
        public static Mock<IRaporRepository> GetRaporRepository()
        {
            var raporList = new List<Rapor>()
            {
                new Rapor(){ Id = Guid.NewGuid(), Tarih = new DateTime(2022,01,01), RaporDurumEnumId =(int)RaporDurumEnum.Hazirlaniyor},
                new Rapor(){ Id = Guid.NewGuid(), Tarih = new DateTime(2022,02,01), RaporDurumEnumId =(int)RaporDurumEnum.Tamamlandı, RaporUrl = @"C:\1.xlsx"},
                new Rapor(){ Id = Guid.NewGuid(), Tarih = new DateTime(2022,03,01), RaporDurumEnumId =(int)RaporDurumEnum.Hazirlaniyor},
            };

            var mockRepo = new Mock<IRaporRepository>();

            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(raporList);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Rapor>())).ReturnsAsync((Rapor rapor) =>
            {
                raporList.Add(rapor);
                return rapor;
            });

            return mockRepo;
        }
    }
}
