using EventFlow.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleEventFlowApp.Domain.Entities
{
    public class UserAttribute : Entity<UserAttributeId>
    {
        public string TenantId { get; }
        public Type Type { get; }
        public string Name { get; }
        public string Description { get; }

        public UserAttribute(UserAttributeId id, Type type, string name, string description, string tenantId) : base(id)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Type = type;
            Name = name;
            TenantId = tenantId;
            Description = description;
        }
    }
}
