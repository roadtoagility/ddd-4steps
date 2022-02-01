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


using System;
using TutorialDDD.Business.CommandHandlers.Commands;
using TutorialDDD.Business.CommandHandlers.Factories;
using TutorialDDD.Domain.AggregationActivity;
using TutorialDDD.Tests.Domain.Data;
using Xunit;

namespace TutorialDDD.Tests.Domain
{
    public class ActivityAggregateTests
    {
        //O esforço não pode ser superior a 8 horas
        [Theory]
        [InlineData("d3a70308-b2cd-4b86-ae13-5d9e2f515177")]
        public void ShouldNotAllowEffortBiggerThan8Hours(Guid projectId)
        {
            var aggFactory = new ActivityCreateAggregateFactory();
            Assert.Throws<ArgumentException>(()=> aggFactory.Create(new CreateActivityCommand(projectId)));
        }
        
        //Não é possível concluir uma atividade com esforço pendente
        [Theory]
        [ClassData(typeof(GenerateValidActivityTestingData))]
        public void ShouldNotAllowCloseActivityWithPendingEffort(Activity activity)
        {
            var aggFactory = new ActivityReconstructAggregateFactory();
            var activityAgg = aggFactory.Create(activity);
            activityAgg.Close();
        
            Assert.False(activityAgg.IsValid);
        }
    }
}