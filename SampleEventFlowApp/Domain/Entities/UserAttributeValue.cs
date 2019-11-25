using EventFlow.Entities;
using EventFlow.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Entities
{
    public class UserAttributeValue : ValueObject
    {
        public UserAttributeId UserAttributeId {get;}
        public string Value { get; }

        public UserAttributeValue(UserAttributeId userAttributeId, string value)
        {
            if (userAttributeId is null) throw new ArgumentNullException(nameof(userAttributeId));

            UserAttributeId = userAttributeId;
            Value = value;
        }
    }
}
