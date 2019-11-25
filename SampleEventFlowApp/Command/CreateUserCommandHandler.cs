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
    public class CreateUserCommandHandler : CommandHandler<SiteUserAggregate, SiteUserId, CreateUserCommand>
    {
        public override Task ExecuteAsync(SiteUserAggregate aggregate, CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(command.FirstName))
            {
                //aggregat..FirstName = command.FirstName;
            }

            return Task.FromResult(0);
        }
    }
}
