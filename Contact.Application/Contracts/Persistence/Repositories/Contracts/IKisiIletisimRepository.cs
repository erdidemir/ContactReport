using Contact.Application.Contracts.Persistence.Repositories.Commons;
using Contact.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Contracts.Persistence.Repositories.Contracts
{
    public interface IKisiIletisimRepository : IRepositoryBase<KisiIletisim>
    {
        Task<IList<KisiIletisim>> GetKisiIletisimListByKisiId(Guid kisiId);
    }
}
