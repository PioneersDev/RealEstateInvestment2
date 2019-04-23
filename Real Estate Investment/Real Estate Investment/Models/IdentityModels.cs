using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System;
using RealEstateInvestment.MigrationsSecurity.ApplicationDbContext;

namespace RealEstateInvestment.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<int> { }
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
    }

    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IRole<int>
    {
        [Column(Order = 2)]
        public string Description { get; set; }

        public ApplicationRole() : base() { }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationRole(string name, string description)
            : this(name)
        {
            this.Description = description;
        }

        public ICollection<RoleApplication> RoleApplications { get; set; }
        public ICollection<RoleMenu> RoleMenues { get; set; }

    }


    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<int>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public ICollection<UserCompany> UserCompanies { get; set; }
        public ICollection<UserApplication> UserApplications { get; set; }
        public ICollection<UserMenu> UserMenues { get; set; }
        public ICollection<UserNotification> UserNotifications { get; set; }
        public ICollection<Request> Requests { get; set; }
    }


    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, int,
        ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, RealEstateInvestment.MigrationsSecurity.ApplicationDbContext.Configuration>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("au");
            // Configure Asp Net Identity Tables
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            var roles = modelBuilder.Entity<ApplicationRole>().ToTable("Role");
            var usercompanyroles = modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRole");
            roles.Property(r => r.Name).IsRequired().HasMaxLength(256).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = false }));
            modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<Company>().ToTable("Company");
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<MenuFlag> MenuFlags { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<RoleApplication> RoleApplications { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<ApproveDefinition> ApproveDefinitions { get; set; }
        public DbSet<ApproveDetail> ApproveDetails { get; set; }
        public DbSet<ApproveStep> ApproveSteps { get; set; }
        public DbSet<ApproveUser> ApproveUsers { get; set; }
        public DbSet<StepStatusDefinition> StepStatusDefinitions { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
    }


    public class ApplicationUserStore :
    UserStore<ApplicationUser, ApplicationRole, int,
    ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUserStore<ApplicationUser, int>, IDisposable
    {
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }


    public class ApplicationRoleStore
    : RoleStore<ApplicationRole, int, ApplicationUserRole>,
    IQueryableRoleStore<ApplicationRole, int>,
    IRoleStore<ApplicationRole, int>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}