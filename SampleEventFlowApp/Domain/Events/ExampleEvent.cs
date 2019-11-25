using EventFlow.Aggregates;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Events
{
    // A basic event containing some information
    public class ExampleEvent : AggregateEvent<ExampleAggregate, ExampleId>
    {
        public ExampleEvent(int magicNumber)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
