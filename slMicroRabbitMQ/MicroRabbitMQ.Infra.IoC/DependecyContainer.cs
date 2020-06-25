using System;
using MediatR;
using MicroRabbitMQ.Banking.Application.Intercafes;
using MicroRabbitMQ.Banking.Application.Services;
using MicroRabbitMQ.Banking.Data.Context;
using MicroRabbitMQ.Banking.Data.Repository;
using MicroRabbitMQ.Banking.Domain.CommandHandlers;
using MicroRabbitMQ.Banking.Domain.Commands;
using MicroRabbitMQ.Transfer.Domain.Events;
using MicroRabbitMQ.Banking.Domain.Interfaces;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Infra.Bus;
using MicroRabbitMQ.Transfer.Application.Intercafes;
using MicroRabbitMQ.Transfer.Data.Context;
using MicroRabbitMQ.Transfer.Data.Repository;
using MicroRabbitMQ.Transfer.Domain.EventHandlers;
using MicroRabbitMQ.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Infra.IoC
{
    public class DependecyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //domain bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {

                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);

            });

            //subscriptions
            services.AddTransient<TransferEventHandler>();

            //domain events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //domain banking commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();


            //application services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddDbContext<BankingDbContext>();
            services.AddDbContext<TransferDbContext>();

            services.AddMemoryCache();

            //
        }
    }
}
