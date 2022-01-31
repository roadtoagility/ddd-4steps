using System;
using TutorialDDD.Domain.BusinessObjects;
using DFlow.Domain.Command;

namespace TutorialDDD.Business.CommandHandlers.Commands
{
    public class CreateActivityCommand : BaseCommand
    {
        public CreateActivityCommand(Guid projectId, int estimatedHours)
        {
            ProjectId = EntityId.From(projectId);
            EstimatedHours = Effort.From(estimatedHours);
        }

        public EntityId ProjectId { get; }
        public Effort EstimatedHours { get; }
    }
}