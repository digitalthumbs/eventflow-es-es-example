using EventFlow.Core;

namespace SampleEventFlowApp.Domain.Entities
{
    public class SiteUserId : Identity<SiteUserId>
    {
        public SiteUserId(string value) : base(value)
        {
        }
    }
}