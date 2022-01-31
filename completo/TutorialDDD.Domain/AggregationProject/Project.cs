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

namespace TutorialDDD.Domain.AggregationProject
{
    public sealed class Project : BaseEntity<EntityId>
    {
        public Project(EntityId id, ProjectName name, VersionId version)
            : base(id, version)
        {
            Name = name;

            AppendValidationResult(Identity.ValidationStatus.Errors.ToImmutableList());
            AppendValidationResult(name.ValidationStatus.Errors.ToImmutableList());
        }

        public ProjectName Name { get; }

        public EntityId ClientId { get; }


        public static Project From(EntityId id, ProjectName name, VersionId version)
        {
            var project = new Project(id, name, version);
            return project;
        }


        public static Project NewRequest(ProjectName name, EntityId clientId)
        {
            return From(EntityId.GetNext(), name, VersionId.New());
        }

        public static Project Empty()
        {
            return From(EntityId.Empty(), ProjectName.Empty(), VersionId.Empty());
        }

        public override string ToString()
        {
            return
                $"[PROJECT]:[ID: {Identity} , Name: {Name}]";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Identity;
            yield return Name;

        }
    }
}