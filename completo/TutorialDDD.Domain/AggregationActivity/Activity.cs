// Copyright (C) 2020  Road to Agility
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

using System.Collections.Generic;
using System.Collections.Immutable;
using DFlow.Domain.BusinessObjects;
using TutorialDDD.Domain.BusinessObjects;

namespace TutorialDDD.Domain.AggregationActivity
{
    public sealed class Activity : BaseEntity<EntityId>
    {
        private Activity(EntityId id, EntityId projectId, VersionId version)
            : base(id, version)
        {
            ProjectId = projectId;
            ActivityStatus = ActivityStatus.NotStarted();

            AppendValidationResult(Identity.ValidationStatus.Errors.ToImmutableList());
            AppendValidationResult(projectId.ValidationStatus.Errors.ToImmutableList());
        }

        public EntityId ProjectId { get; }

        public ActivityStatus ActivityStatus { get; private set; }

        public override string ToString()
        {
            return $"[Activity]:[ID: {Identity}]";
        }

        public static Activity From(EntityId id, EntityId projectId, VersionId version)
        {
            var activity = new Activity(id, projectId, version);
            return activity;
        }

        public static Activity New(EntityId projectId)
        {
            return From(EntityId.GetNext(), projectId, VersionId.New());
        }

        public void Close()
        {
            ActivityStatus = ActivityStatus.Closed();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Identity;
        }
    }
}