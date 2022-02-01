using System;
using System.Threading;
using System.Threading.Tasks;
using DFlow.Domain.Events;
using TutorialDDD.Domain.AggregationActivity.Events;

namespace TutorialDDD.Persistence.SyncModels.DomainEventHandlers
{
    public class CreatedActivityProjectionHandler : DomainEventHandler<ActivityCreatedEvent>
    {
        protected override Task ExecuteHandle(ActivityCreatedEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}