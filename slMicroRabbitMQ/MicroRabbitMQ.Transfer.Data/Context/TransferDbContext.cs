using System;
using MicroRabbitMQ.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbitMQ.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
       
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {

        }

        public TransferDbContext()
        {

        }

        public DbSet<TransferLog> TransferLogs { get; set; }

    }
}
