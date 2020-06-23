using System;
using System.Collections.Generic;
using MicroRabbitMQ.Banking.Application.Models;
using MicroRabbitMQ.Banking.Domain.Models;

namespace MicroRabbitMQ.Banking.Application.Intercafes
{
    public interface IAccountServices
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
