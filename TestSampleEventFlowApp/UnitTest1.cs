using EventFlow;
using EventFlow.Extensions;
using EventFlow.Queries;
using SampleEventFlowApp.Command;
using SampleEventFlowApp.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SampleEventFlowApp.Domain.Events;
using SampleEventFlowApp.Domain.Entities;

namespace TestSampleEventFlowApp
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            using var resolver = EventFlowOptions.New
                //.AddEvents(typeof(UserStringAttributeAddedEvent))
                .AddCommands(typeof(CreateUserCommand))
                .AddCommandHandlers(typeof(CreateUserCommandHandler))
                //.UseInMemoryReadStoreFor<UserReadModel>()
                .CreateResolver();
            
            // Create a new identity for our aggregate root
            var namespaceId = Guid.NewGuid();
            var userId = SiteUserId.NewDeterministic(namespaceId, "david@grigoli.com");

            // Resolve the command bus and use it to publish a command
            var commandBus = resolver.Resolve<ICommandBus>();
            await commandBus.PublishAsync(
              new CreateUserCommand(userId, "David"), CancellationToken.None)
              .ConfigureAwait(false);

            // Resolve the query handler and use the built-in query for fetching
            // read models by identity to get our read model representing the
            // state of our aggregate root
            var queryProcessor = resolver.Resolve<IQueryProcessor>();
            //var exampleReadModel = await queryProcessor.ProcessAsync(
            //  new ReadModelByIdQuery<UserReadModel>(userId), CancellationToken.None)
            //  .ConfigureAwait(false);

            //// Verify that the read model has the expected magic number
            //exampleReadModel.FirstName.Should().Be("David");
        }
    }
}