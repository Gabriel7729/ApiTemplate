using System.Reflection;
using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Core.Entities.PersonasAggregate;
using ApiTemplate.Core.Entities.ValidationsAggregate;
using ApiTemplate.Infrastructure.Data.Extensions;
using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Persona> Personas => Set<Persona>();
  public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
  public DbSet<VehiculoEvento> VehiculoEventos => Set<VehiculoEvento>();
  public DbSet<VerificationCode> VerificationCodes => Set<VerificationCode>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    foreach (var type in modelBuilder.Model.GetEntityTypes())
    {
      if (typeof(EntityBase).IsAssignableFrom(type.ClrType))
        modelBuilder.SetSoftDeleteFilter(type.ClrType);
    }
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
  private void SetAuditEntities()
  {
    foreach (var entry in ChangeTracker.Entries<EntityBase>())
    {
      switch (entry.State)
      {
        case EntityState.Added:

          //if (entry.Entity.Id > 0)
          //{
          //    entry.State = EntityState.Modified;
          //    goto case EntityState.Modified;
          //}

          entry.Entity.Deleted = false;
          entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
          break;

        case EntityState.Modified:
          entry.Property(x => x.CreatedDate).IsModified = false;
          entry.Property(x => x.CreatedBy).IsModified = false;
          entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
          break;

        case EntityState.Deleted:
          entry.Property(x => x.CreatedDate).IsModified = false;
          entry.Property(x => x.CreatedBy).IsModified = false;
          entry.State = EntityState.Modified;
          entry.Entity.Deleted = true;
          entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
          break;

        default:
          break;
      }
    }
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    SetAuditEntities();
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    SetAuditEntities();
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
