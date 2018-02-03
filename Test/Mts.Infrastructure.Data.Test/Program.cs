using AutoMapper;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Options;
using Mts.Core.Common;
using Mts.Core.Dto.Config;
using Mts.Core.Entity;
using Mts.Core.Interface.Repository;
using Mts.Infrastructure.Data.Repository;
using Mts.Infrastructure.Service;
using Mts.Infrastructure.Service.Services;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dto = Mts.Core.Dto;
namespace Mts.Infrastructure.Data.Test
{
    class Program
    {
        private static CrudRepository<Business> repo;
        private static MtsContext entities;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<MtsContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            entities = new MtsContext(optionsBuilder.Options);
            repo = new CrudRepository<Business>(entities);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Dto.RegistrationRequest, RegistrationRequest>();
            });

            IOptions<SmtpConfig> option = Options.Create<SmtpConfig>(new SmtpConfig
            {
                Password = "newbie04",
                Port = 587,
                Server = "smtp.gmail.com",
                Username = "francis.cebu@basecamptech.ph"
            });

            IMapper iMapper = config.CreateMapper();
            var accountService = new AccountService(new CrudRepository<RegistrationRequest>(entities), iMapper, new Cryptography(), new EmailService(option));
            accountService.RequestRegistration("francis.cebu@basecamptech.ph").Wait();

            //InsertBusiness();
            //GetRecord().Wait();
            //UpdateRecord().Wait();
            //ListRecords();
        }

        public static void InsertBusiness()
        {
            using (var tx = entities.Database.BeginTransaction())
            {
                repo.Save(new Business
                {
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    NatureOfBusiness = "test",
                    Name = "Test",
                    Website = "website"
                }).Wait();
            }
        }

        public static async Task GetRecord()
        {
            var record = await repo.Get(1);
        }

        public static async Task UpdateRecord()
        {
            using (var tx = entities.Database.BeginTransaction())
            {
                var record = await repo.Get(1);
                record.Name = "Test Editied";
                await repo.Update(record);
                tx.Commit();
            }
        }

        public static void ListRecords()
        {
            var records = repo.List();
            var hasRecord = records.Any();
        }
    }
}
