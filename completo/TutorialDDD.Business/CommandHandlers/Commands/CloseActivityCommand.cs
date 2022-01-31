using TutorialDDD.Domain.BusinessObjects;
using DFlow.Domain.Command;

namespace TutorialDDD.Business.CommandHandlers.Commands
{
    public class CloseActivityCommand : BaseCommand
    {
        public CloseActivityCommand(EntityId activityId, int estimatedHours)
        {
            ActivityId = activityId;
            EstimatedHours = Effort.From(estimatedHours);
        }

        public EntityId ActivityId { get; }
        public Effort EstimatedHours { get; }
    }
}