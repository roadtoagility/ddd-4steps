using AppFabric.Domain.BusinessObjects;
using DFlow.Persistence.Repositories;
using TutorialDDD.Domain.AggregationActivity;
using TutorialDDD.Domain.BusinessObjects;
using TutotrialDDD.Persistence.Model;

namespace TutorialDDD.Persistence.Model.Repositories
{
    public interface IActivityRepository : IRepository<ActivityState, Activity>
    {
        Activity Get(EntityId entityId);
    }
}