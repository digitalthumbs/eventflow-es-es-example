using EventFlow.Core;

namespace SampleEventFlowApp.Domain.Entities
{
    public class UserAttributeId : Identity<UserAttributeId>
    {
        public UserAttributeId(string value) : base(value)
        {
        }
    }
}