using System;
using MediatR;
using MicroRabbitMQ.Banking.Application.Intercafes;
using MicroRabbitMQ.Banking.Application.Services;
using MicroRabbitMQ.Banking.Data.Context;
using MicroRabbitMQ.Banking.Data.Repository;
using MicroRabbitMQ.Banking.Domain.CommandHandlers;
using MicroRabbitMQ.Banking.Domain.Commands;
using MicroRabbitMQ.Banking.Domain.Interfaces;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Infra.IoC
{
    public class DependecyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //domain bankind commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();



            //application services
            services.AddTransient<IAccountServices, AccountService>();

            //data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddDbContext<BankingDbContext>();
            services.AddMemoryCache();

            //
        }
    }
}
