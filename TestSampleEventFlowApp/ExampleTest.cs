using EventFlow;
using EventFlow.Elasticsearch.Extensions;
using EventFlow.Extensions;
using EventFlow.Queries;
using FluentAssertions;
using Nest;
using SampleEventFlowApp.Command;
using SampleEventFlowApp.Config.EventFlow.Extensions;
using SampleEventFlowApp.Domain;
using SampleEventFlowApp.Domain.Entities;
using SampleEventFlowApp.Domain.Events;
using SampleEventFlowApp.ReadModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestSampleEventFlowApp
{
    public class ExampleTest
    {
        public ExampleTest(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; }

        [Fact]
        public async Task Example()
        {
            Environment.SetEnvironmentVariable("EVENTSTOREURL", "tcp://localhost:1113");

            string elasticSearchUrl = @"http://localhost:9200"; //Environment.GetEnvironmentVariable("ELASTICSEARCHURL");
            Uri node = new Uri(elasticSearchUrl);
            Nest.ConnectionSettings settings = new Nest.ConnectionSettings(node);
            settings.DisableDirectStreaming();
            ElasticClient elasticClient = new ElasticClient(settings);

            // We wire up EventFlow with all of our classes. Instead of adding events,
            // commands, etc. explicitly, we could have used the the simpler
            // AddDefaults(Assembly) instead.
            using (var resolver = EventFlowOptions.New
              .AddEvents(typeof(ExampleEvent))
              .AddCommands(typeof(ExampleCommand), typeof(ExampleUpdateCommand))
              .AddCommandHandlers(typeof(ExampleCommandHandler), typeof(ExampleUpdateCommandHandler))
              .ConfigureEventStorePersistence("tcp://localhost:1113")
              .ConfigureElasticsearch(() => elasticClient)
              .UseElasticsearchReadModel<ExampleReadModel>()
              //.UseInMemoryReadStoreFor<ExampleReadModel>()
              .CreateResolver())
            {


                var id = "example-f66477e4-06f2-4002-84e0-c67f7ab3371c";
                var queryProcessor = resolver.Resolve<IQueryProcessor>();
                var exampleReadModel = await queryProcessor.ProcessAsync(
                  new ReadModelByIdQuery<ExampleReadModel>(id), CancellationToken.None)
                  .ConfigureAwait(false);



                for (int i = 0; i < 10; i++)
                {
                    var rndMagicNum = new Random().Next();

                    // Create a new identity for our aggregate root
                    var exampleId = ExampleId.New;

                    // Resolve the command bus and use it to publish a command
                    var commandBus = resolver.Resolve<ICommandBus>();
                    await commandBus.PublishAsync(
                      new ExampleCommand(exampleId, rndMagicNum), CancellationToken.None)
                      .ConfigureAwait(false);


                    await commandBus.PublishAsync(
                     new ExampleUpdateCommand(exampleId, 1), CancellationToken.None)
                     .ConfigureAwait(false);


                    // Resolve the query handler and use the built-in query for fetching
                    // read models by identity to get our read model representing the
                    // state of our aggregate root
                    //var queryProcessor = resolver.Resolve<IQueryProcessor>();
                    //var exampleReadModel = await queryProcessor.ProcessAsync(
                    //  new ReadModelByIdQuery<ExampleReadModel>(exampleId), CancellationToken.None)
                    //   .ConfigureAwait(false);

                    // Verify that the read model has the expected magic number
                    exampleReadModel.MagicNumber.Should().Be(1);

                    Output.WriteLine(exampleId.Value);
                }
            }
        }
    }
}
