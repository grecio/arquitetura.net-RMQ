using System;
using MicroRabbitMQ.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbitMQ.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
       
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {

        }

        public BankingDbContext()
        {

        }

        public DbSet<Account> Accounts { get; set; }

    }
}
