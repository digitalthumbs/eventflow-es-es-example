using EventFlow.Commands;
using SampleEventFlowApp.Domain;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Command
{
    // Command for update magic number
    public class ExampleCommand : Command<ExampleAggregate, ExampleId>
    {
        public ExampleCommand(
          ExampleId aggregateId,
          int magicNumber)
          : base(aggregateId)
        {
            MagicNumber = magicNumber;
        }

        public int MagicNumber { get; }
    }
}
