using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using FamilyCore.Module.BusinessObjects.Accounting;
using FamilyCore.Module.BusinessObjects.Contacts;
using FamilyCore.Module.BusinessObjects.Shared;

namespace FamilyCore.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class FamilyCoreContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<FamilyCoreEFCoreDbContext>()
            .UseMySql(";", ServerVersion.AutoDetect(";"))
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new FamilyCoreEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class FamilyCoreDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FamilyCoreEFCoreDbContext> {
	public FamilyCoreEFCoreDbContext CreateDbContext(string[] args) {
		var optionsBuilder = new DbContextOptionsBuilder<FamilyCoreEFCoreDbContext>();
        //Setup MySQL Connection String
        var connStr = "server=localhost;port=3306;user=root;password=Snafu201;database=FamilyCore;";
		optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new FamilyCoreEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(FamilyCoreContextInitializer))]
public class FamilyCoreEFCoreDbContext : DbContext {
	public FamilyCoreEFCoreDbContext(DbContextOptions<FamilyCoreEFCoreDbContext> options) : base(options) {
	}
	public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<ModelDifference> ModelDifferences { get; set; }
	public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	public DbSet<PermissionPolicyRole> Roles { get; set; }
	public DbSet<FamilyCore.Module.BusinessObjects.ApplicationUser> Users { get; set; }
	public DbSet<FileData> FileData { get; set; }
	public DbSet<ReportDataV2> ReportDataV2 { get; set; }
	public DbSet<DashboardData> DashboardData { get; set; }
    public DbSet<AuditDataItemPersistent> AuditData { get; set; }
    public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }
    public DbSet<Event> Event { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Payee> Payees { get; set; }
    public DbSet<PayeeContact> PayeeContacts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
       
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.AuditItems)
            .WithOne(p => p.AuditedObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.OldItems)
            .WithOne(p => p.OldObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.NewItems)
            .WithOne(p => p.NewObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.UserItems)
            .WithOne(p => p.UserObject);
        modelBuilder.Entity<ModelDifference>()
            .HasMany(t => t.Aspects)
            .WithOne(t => t.Owner)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasMany(e => e.Credits)
                .WithOne(e => e.ToAccount)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Debits)
                .WithOne(e => e.FromAccount)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}

public class FamilyCoreAuditingDbContext : DbContext {
    public FamilyCoreAuditingDbContext(DbContextOptions<FamilyCoreAuditingDbContext> options) : base(options) {
    }
    public DbSet<AuditDataItemPersistent> AuditData { get; set; }
    public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.AuditItems)
            .WithOne(p => p.AuditedObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.OldItems)
            .WithOne(p => p.OldObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.NewItems)
            .WithOne(p => p.NewObject);
        modelBuilder.Entity<AuditEFCoreWeakReference>()
            .HasMany(p => p.UserItems)
            .WithOne(p => p.UserObject);
    }
}
