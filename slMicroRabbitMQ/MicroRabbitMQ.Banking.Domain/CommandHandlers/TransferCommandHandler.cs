using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroRabbitMQ.Banking.Domain.Commands;
using MicroRabbitMQ.Banking.Domain.Events;
using MicroRabbitMQ.Domain.Core.Bus;

namespace MicroRabbitMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {

        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {

            //publicar evento no RbbitMQ
            _bus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
