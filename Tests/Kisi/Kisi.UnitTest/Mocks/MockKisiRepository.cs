using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Domain.Entities.Contacts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisiler.UnitTest.Mocks
{
    public static class MockKisiRepository
    {
        public static Mock<IKisiRepository> GetKisiRepository()
        {
            var kisiList = new List<Kisi>()
            {
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Ahmet", Soyad="mehmet", Firma="ABC" },
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Ayşe", Soyad="Fatma", Firma="DEF" },
                new Kisi(){ Id = Guid.NewGuid(), Ad ="Mehmet", Soyad="Güneş", Firma="FGH" },
            };

            var mockRepo = new Mock<IKisiRepository>();

            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(kisiList);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Kisi>())).ReturnsAsync((Kisi kisi) =>
            {
                kisiList.Add(kisi);
                return kisi;
            });

            return mockRepo;
        }
    }
}
