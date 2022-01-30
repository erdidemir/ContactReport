using EventBus.Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class RaporCreateEvent : IntegrationBaseEvent
    {
        public Guid RaporId { get; set; }
        public List<KonumModel> KonumModelList { get; set; }
        
    }
}
