using CleanArchEMS.Domain.Common;
using CleanArchEMS.Domain.Common.Interfaces;
using CleanArchEMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchEMS.Persistance.Contexts
{
    /// <summary>
    /// EMSContext represente la BD
    /// </summary>
    public class EMSDbContext : DbContext
    {
        //1- Evenement
        private readonly IDomainEventDispatcher _dispatcher;

        //2-Constructor 
   
        public EMSDbContext(DbContextOptions<EMSDbContext> options,IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        //3-Propriétes de Navigation
        public DbSet<Student>Students => Set<Student>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<IssuieingBook> IssuueingDetails => Set<IssuieingBook>();

        //4-
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //5-
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            //ignorer les événements si aucun répartiteur n'est fourni
            if (_dispatcher == null) return result;

            //distribuer les événements uniquement si la sauvegarde a réussi
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;

        }
        //6-
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
