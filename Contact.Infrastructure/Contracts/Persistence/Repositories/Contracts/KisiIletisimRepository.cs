using Contact.Application.Contracts.Persistence.Repositories.Contracts;
using Contact.Domain.Entities.Contacts;
using Contact.Infrastructure.Contracts.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Contracts.Persistence.Repositories.Contracts
{
    public class KisiIletisimRepository : RepositoryBase<KisiIletisim>, IKisiIletisimRepository
    {
        private readonly ApplicationContext _dbContext; 
        public KisiIletisimRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<KisiIletisim>> GetKisiIletisimListByKisiId(Guid kisiId)
        {
            return await _dbContext.KisiIletisim.Where(p => p.KisiId == kisiId)
                .Include(p => p.Kisi)
                .Include(p => p.BilgiTip).ToListAsync();
        }
    }
}
