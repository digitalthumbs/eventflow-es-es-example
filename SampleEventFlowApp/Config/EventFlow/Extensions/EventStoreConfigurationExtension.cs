using EventFlow;
using EventFlow.EventStores.EventStore.Extensions;
using EventFlow.Extensions;
using EventFlow.MetadataProviders;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SampleEventFlowApp.Config.EventFlow.Extensions
{
    public static class EventStoreConfigurationExtension
    {
        public static IEventFlowOptions ConfigureEventStorePersistence(this IEventFlowOptions options, string esServerUrl = null)
        {

            string eventStoreUrl = esServerUrl ?? Environment.GetEnvironmentVariable("EVENTSTOREURL");
            string connectionString = $"ConnectTo={eventStoreUrl}; HeartBeatTimeout=500";
            Uri eventStoreUri = GetUriFromConnectionString(connectionString);

            ConnectionSettings connectionSettings = ConnectionSettings.Create()
                .EnableVerboseLogging()
                .KeepReconnecting()
                .KeepRetrying()
                .SetDefaultUserCredentials(new UserCredentials("admin", "changeit"))
                .Build();

            IEventFlowOptions eventFlowOptions = options
                .AddMetadataProvider<AddGuidMetadataProvider>()
                .UseEventStoreEventStore(eventStoreUri, connectionSettings);

            return eventFlowOptions;
        }

        private static Uri GetUriFromConnectionString(string connectionString)
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder { ConnectionString = connectionString };
            string connectTo = (string)builder["ConnectTo"];

            return connectTo == null ? null : new Uri(connectTo);
        }
    }
}
