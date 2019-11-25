using EventFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleEventFlowApp.Domain.Entities
{
    public class SiteUser : Entity<SiteUserId>
    {
        private readonly List<UserAttributeValue> _attributeValues = new List<UserAttributeValue>();

        public IReadOnlyList<UserAttributeValue> AttributeValues => _attributeValues;

        public SiteUser(SiteUserId id, List<UserAttributeValue> attributeValues) : base(id)
        {
            if (attributeValues is null) throw new ArgumentNullException(nameof(attributeValues));

            _attributeValues = attributeValues;
        }

        public void AddAttributeValue(UserAttributeValue attributeValue)
        {
            _attributeValues.Add(attributeValue);

        }

        public void UpdateAttributeValue(UserAttributeValue attributeValue)
        {
            var idx = _attributeValues.FindIndex(x => x.UserAttributeId == attributeValue.UserAttributeId);
            _attributeValues[idx] = attributeValue;
        }

        public void RemoveAttributeValue(UserAttributeValue attributeValue)
        {
            _attributeValues.Remove(attributeValue);
        }
    }
}
