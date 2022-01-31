using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]

        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CratedDate { get; private set; }

        [JsonConstructor]
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CratedDate = DateTime.Now;
        }

        public IntegrationEvent(Guid id, DateTime createdDate)
        {
            Id = id;
            CratedDate = createdDate;
        }
    }
}
