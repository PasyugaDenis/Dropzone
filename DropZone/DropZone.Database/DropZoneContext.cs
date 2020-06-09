using DropZone.Database.Models;
using System;
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

        public DropZoneContext() : base("DropZoneContext")
        {
            Database.CommandTimeout = 1000;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().ToTable("Aircrafts");

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
