using EventFlow.Aggregates;
using EventFlow.Exceptions;
using SampleEventFlowApp.Domain.Entities;
using SampleEventFlowApp.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleEventFlowApp.Domain
{
    [AggregateName("UserAttribute")]
    public class UserAttributeAggregate : AggregateRoot<UserAttributeAggregate, UserAttributeId>
    {
        private UserAttribute _entity;
        public UserAttributeAggregate(UserAttributeId id) : base(id)
        {
            Register<UserAttributeAddedEvent>(e => _entity = e.UserAttributeEntity);
            Register<UserAttributeDeletedEvent>(x => { });
        }

        public void SetUserAttribute(UserAttribute userAttribute)
        {
            if (_entity != null)
            {
                throw DomainError.With($"UserAttribute '{Id}' already exists in the collection of UserAttributes");
            }

            Emit(new UserAttributeAddedEvent(userAttribute));
        }

        public void DeleteUserAttribute()
        {
            Emit(new UserAttributeDeletedEvent());
        }
    }
}
