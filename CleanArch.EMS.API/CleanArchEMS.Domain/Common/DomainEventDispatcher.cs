using CleanArchEMS.Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Domain.Common
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        #region Attributs
        private readonly IMediator _mediator;

        #endregion

        #region Constructor DI
        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Ovveride Methods
        public async Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents)
        {
            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.DomainEvents.ToArray();

                entity.ClearDomainEvents();

                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
        }
        #endregion
    }
}
