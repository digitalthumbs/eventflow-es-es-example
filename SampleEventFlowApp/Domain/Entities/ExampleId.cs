using EventFlow.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Entities
{
    // Represents the aggregate identity (ID)
    public class ExampleId : Identity<ExampleId>
    {
        public ExampleId(string value) : base(value) { }
    }
}
