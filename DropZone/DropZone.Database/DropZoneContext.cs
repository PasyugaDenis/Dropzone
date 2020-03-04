using DropZone.Database.Models;
using System.Data.Entity;

namespace DropZone.Database
{
    public class DropZoneContext : DbContext
    {

        public DbSet<AAD> AADs { get; set; }

        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Models.DropZone> DropZones { get; set; }

        public DbSet<HashBlock> HashBlocks { get; set; }

        public DbSet<Jump> Jumps { get; set; }

        public DbSet<JumpBook> JumpBooks { get; set; }

        public DbSet<Parachute> Parachutes { get; set; }

        public DbSet<ParachuteSystem> ParachuteSystems { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Satchel> Satchels { get; set; }

        public DbSet<User> Users { get; set; }

        public DropZoneContext() : base("DbConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParachuteSystem>()
                .HasRequired(ps => ps.AAD)
                .WithRequiredPrincipal(aad => aad.ParachuteSystem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParachuteSystem>()
                .HasRequired(ps => ps.MainParachute);

            modelBuilder.Entity<ParachuteSystem>()
                .HasRequired(ps => ps.ReserveParachute);

            modelBuilder.Entity<ParachuteSystem>()
                .HasRequired(ps => ps.Satchel)
                .WithRequiredPrincipal(s => s.ParachuteSystem)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
