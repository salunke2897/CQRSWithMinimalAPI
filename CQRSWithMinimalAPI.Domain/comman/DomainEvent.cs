using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSWithMinimalAPI.Domain.comman
{
    public abstract class DomainEvent
    {
        public DateTime OccurredOn { get; private set; } = DateTime.UtcNow;
    }
}
