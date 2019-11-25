using EventFlow.Commands;
using SampleEventFlowApp.Domain;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleEventFlowApp.Command
{
    // Command handler for our command
    public class ExampleCommandHandler
      : CommandHandler<ExampleAggregate, ExampleId, ExampleCommand>
    {
        public override Task ExecuteAsync(ExampleAggregate aggregate, ExampleCommand command, CancellationToken cancellationToken)
        {
            aggregate.SetMagicNumber(command.MagicNumber);
            return Task.FromResult(0);
        }
    }


    public class ExampleUpdateCommandHandler
      : CommandHandler<ExampleAggregate, ExampleId, ExampleUpdateCommand>
    {
        public override Task ExecuteAsync(ExampleAggregate aggregate, ExampleUpdateCommand command, CancellationToken cancellationToken)
        {
            aggregate.UpdateMagicNumber(command.MagicNumber);
            return Task.FromResult(0);
        }
    }
}
