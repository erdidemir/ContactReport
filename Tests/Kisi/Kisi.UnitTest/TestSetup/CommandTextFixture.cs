using AutoMapper;
using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Application.Mappings;
using Contact.Infrastructure.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisiler.UnitTest.TestSetup
{
    public class CommandTextFixture
    {
        public ApplicationContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IKisiRepository KisiRepository { get; set; }

        public CommandTextFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").EnableSensitiveDataLogging().Options;

            Context = new ApplicationContext(options);
            Context.Database.EnsureCreated();
            Context.AddKisiler();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
    }
}
