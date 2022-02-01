using System;
using TutorialDDD.Domain.BusinessObjects;
using DFlow.Domain.Command;

namespace TutorialDDD.Business.CommandHandlers.Commands
{
    public class CreateActivityCommand : BaseCommand
    {
        public CreateActivityCommand(Guid projectId)
        {
            ProjectId = EntityId.From(projectId);
        }

        public EntityId ProjectId { get; }
    }
}