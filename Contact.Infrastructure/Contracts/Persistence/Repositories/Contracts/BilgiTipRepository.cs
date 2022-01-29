using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Domain.Entities.Contacts;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Contracts.Persistence.Repositories.Contracts
{
    public class BilgiTipRepository : RepositoryBase<BilgiTip>, IBilgiTipRepository
    {
        public BilgiTipRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
