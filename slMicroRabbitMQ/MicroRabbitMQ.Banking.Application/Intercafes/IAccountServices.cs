using System;
using System.Collections.Generic;
using MicroRabbitMQ.Banking.Domain.Models;

namespace MicroRabbitMQ.Banking.Application.Intercafes
{
    public interface IAccountServices
    {
        IEnumerable<Account> GetAccounts();
    }
}
