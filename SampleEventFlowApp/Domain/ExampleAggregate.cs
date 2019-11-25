using EventFlow.Aggregates;
using EventFlow.Exceptions;
using SampleEventFlowApp.Domain.Entities;
using SampleEventFlowApp.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain
{
    // The aggregate root
    public class ExampleAggregate : AggregateRoot<ExampleAggregate, ExampleId>,
      IEmit<ExampleEvent>
    {
        private int? _magicNumber;

        public ExampleAggregate(ExampleId id) : base(id) { }

        // Method invoked by our command
        public void SetMagicNumber(int magicNumber)
        {
            if (_magicNumber.HasValue)
                throw DomainError.With("Magic number already set");

            Emit(new ExampleEvent(magicNumber, DateTimeOffset.UtcNow));
        }

        public void UpdateMagicNumber(int magicNumber)
        {
            if (!_magicNumber.HasValue)
                throw DomainError.With("Magic never wasn't already set");

            Emit(new ExampleEvent(magicNumber, DateTimeOffset.UtcNow));
        }

        // We apply the event as part of the event sourcing system. EventFlow
        // provides several different methods for doing this, e.g. state objects,
        // the Apply method is merely the simplest
        public void Apply(ExampleEvent aggregateEvent)
        {
            _magicNumber = aggregateEvent.MagicNumber;
        }
    }
}
