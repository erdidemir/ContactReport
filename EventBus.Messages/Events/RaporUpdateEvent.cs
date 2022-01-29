using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class RaporUpdateEvent: IntegrationBaseEvent
    {
        public Guid RaporId { get; set; }

        public string RaporUrl { get; set; }

    }
}
