using Contact.Application.Contracts.Persistence.Repositories.Rapors;
using Contact.Domain.Entities.Rapors;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Contracts.Persistence.Repositories.Rapors
{
    public class RaporRepository : RepositoryBase<Rapor>, IRaporRepository
    {
        public RaporRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
