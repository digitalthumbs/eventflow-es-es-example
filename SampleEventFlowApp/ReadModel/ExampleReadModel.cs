using EventFlow.Aggregates;
using EventFlow.ReadStores;
using SampleEventFlowApp.Domain;
using SampleEventFlowApp.Domain.Entities;
using SampleEventFlowApp.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.ReadModel
{
    // Read model for our aggregate
    public class ExampleReadModel : IReadModel, IAmReadModelFor<ExampleAggregate, ExampleId, ExampleEvent>
    {
        public int MagicNumber { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<ExampleAggregate, ExampleId, ExampleEvent> domainEvent)
        {
            MagicNumber = domainEvent.AggregateEvent.MagicNumber;
            TimeStamp = domainEvent.AggregateEvent.TimeStamp;
        }
    }
}
