using System;
using MediatR;
using System.Collections.Generic;

namespace fkd.pay.api.Domain.SeedWork
{
    public class Entity
    {
        private Guid _id;
        
        public virtual Guid Id
        {
            get { return _id; }
        }

        protected void SetId()
        {
            _id = Guid.NewGuid();
        } 
        protected void SetId(Guid id)
        {
            _id = id;
        }
        
        #region domain events

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvent()
        {
            _domainEvents?.Clear();
        }
        #endregion
    }
}