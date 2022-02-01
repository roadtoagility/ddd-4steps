// Copyright (C) 2021  Road to Agility
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Library General Public
// License as published by the Free Software Foundation; either
// version 2 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Library General Public License for more details.
//
// You should have received a copy of the GNU Library General Public
// License along with this library; if not, write to the
// Free Software Foundation, Inc., 51 Franklin St, Fifth Floor,
// Boston, MA  02110-1301, USA.
//

using System.Diagnostics;
using TutorialDDD.Domain.AggregationActivity.Events;
using TutorialDDD.Domain.BusinessObjects;
using DFlow.Domain.Aggregates;

namespace TutorialDDD.Domain.AggregationActivity
{
    public class ActivityAggregationRoot : ObjectBasedAggregationRoot<Activity, EntityId>
    {
        public ActivityAggregationRoot(Activity activity)
        {
            Debug.Assert(activity.IsValid);
            Apply(activity);
            
            if (activity.IsNew())
            {
                Raise(ActivityCreatedEvent.For(activity));
            }
        }

        public void Close()
        {
            if (AggregateRootEntity.IsValid)
            {
                Apply(AggregateRootEntity);
                Raise(ActivityClosedEvent.For(AggregateRootEntity));
            }

            AppendValidationResult(AggregateRootEntity.Failures);
        }
    }
}