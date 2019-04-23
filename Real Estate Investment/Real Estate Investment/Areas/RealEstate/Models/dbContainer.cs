using CodeFirstStoreFunctions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using RealEstateInvestment.MigrationsDb.dbContainer;

namespace RealEstateInvestment.Areas.RealEstate.Models
{
    public class dbContainer : DbContext
    {
        public dbContainer() : base("dbconn")
        {
            Database.SetInitializer(new dbContainerInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbContainer, RealEstateInvestment.MigrationsDb.dbContainer.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //Configure default schema
            modelBuilder.HasDefaultSchema("con");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add(new FunctionsConvention<dbContainer>("con"));
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPhone> CustomerPhones { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<TypeId> TypeIds { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUnitType> ProjectUnitsTypes { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitContent> UnitContents { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<DocType> DocTypes { get; set; }
        public DbSet<DocHeader> DocHeaders { get; set; }
        public DbSet<DocDetail> DocDetails { get; set; }
        public DbSet<ProjectOwner> ProjectOwners { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentMethodHeader> PaymentMethodHeaders { get; set; }
        public DbSet<PaymentMethodDetail> PaymentMethodDetails { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractModel> ContractModels { get; set; }
        public DbSet<ContractItem> ContractItems { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<ContractSys> ContractSyses { get; set; }
        public DbSet<ContractDeliverySpecification> ContractDeliverySpecifications { get; set; }
    }
}