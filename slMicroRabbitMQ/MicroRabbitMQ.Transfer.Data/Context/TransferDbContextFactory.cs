using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroRabbitMQ.Transfer.Data.Context
{
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
       
       
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            optionsBuilder.UseMySql("Server=localhost;DataBase=db_procity2;Uid=root;Pwd=rootadmin");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
