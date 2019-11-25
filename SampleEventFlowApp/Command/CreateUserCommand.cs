using EventFlow.Commands;
using SampleEventFlowApp.Domain;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Command
{
    public class CreateUserCommand : Command<SiteUserAggregate, SiteUserId>
    {
        public CreateUserCommand(SiteUserId aggregateId, string firstName) : base(aggregateId)
        {
            FirstName = firstName;
        }

        public string FirstName { get; }
    }
}
