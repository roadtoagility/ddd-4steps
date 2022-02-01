using TutorialDDD.Domain.BusinessObjects;
using DFlow.Domain.Command;

namespace TutorialDDD.Business.CommandHandlers.Commands
{
    public class CloseActivityCommand : BaseCommand
    {
        public CloseActivityCommand(EntityId activityId)
        {
            ActivityId = activityId;
        }

        public EntityId ActivityId { get; }
    }
}