using EventFlow.Aggregates;
using SampleEventFlowApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain
{
    public class SiteUserAggregate : AggregateRoot<SiteUserAggregate, SiteUserId>
    {
        
        public SiteUserAggregate(SiteUserId id) : base(id)
        {
        }
    }
}
