﻿using System;
using MicroRabbitMQ.Domain.Core.Events;

namespace MicroRabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {

        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
