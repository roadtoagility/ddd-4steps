using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TutorialDDD.Domain.AggregationActivity;
using TutorialDDD.Domain.BusinessObjects;
using TutotrialDDD.Persistence;
using TutotrialDDD.Persistence.Model;

namespace TutorialDDD.Persistence.Model.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        public ActivityRepository(TutorialDddDbContext context)
        {
            DbContext = context;
        }

        private TutorialDddDbContext DbContext { get; }

        public Activity Get(EntityId entityId)
        {
            throw new NotImplementedException();
        }

        public void Add(Activity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Activity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> Find(Expression<Func<ActivityState, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> FindAsync(Expression<Func<ActivityState, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Activity>> FindAsync(Expression<Func<ActivityState, bool>> predicate,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}