using EventFlow.Aggregates;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Events
{
    public class UserAttributeAddedEvent : AggregateEvent<UserAttributeAggregate, UserAttributeId>
    {
        public UserAttribute UserAttributeEntity { get; }

        public UserAttributeAddedEvent(UserAttribute userAttribute)
        {
            UserAttributeEntity = userAttribute;
        }
    }
}
