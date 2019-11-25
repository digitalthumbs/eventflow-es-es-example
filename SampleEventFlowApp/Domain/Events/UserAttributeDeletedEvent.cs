using EventFlow.Aggregates;
using EventFlow.EventStores;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Events
{
    [EventVersion("UserAttributeDeleted", 1)]
    class UserAttributeDeletedEvent: AggregateEvent<UserAttributeAggregate, UserAttributeId>
    {
    }
}
