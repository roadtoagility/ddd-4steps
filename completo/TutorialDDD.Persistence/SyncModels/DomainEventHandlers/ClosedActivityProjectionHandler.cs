using System;
using System.Threading;
using System.Threading.Tasks;
using DFlow.Domain.Events;
using TutorialDDD.Domain.AggregationActivity.Events;

namespace TutorialDDD.Persistence.SyncModels.DomainEventHandlers
{
    public class ClosedActivityProjectionHandler : DomainEventHandler<ActivityClosedEvent>
    {
        protected override Task ExecuteHandle(ActivityClosedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}