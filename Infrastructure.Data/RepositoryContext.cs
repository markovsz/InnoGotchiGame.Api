using Domain.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class RepositoryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public DbSet<Pet> Pets { get; set; }
		public DbSet<Farm> Farms { get; set; }
		public DbSet<FarmFriend> FarmFriends { get; set; }
		public DbSet<FeedingEvent> FeedingEvents { get; set; }
		public DbSet<ThirstQuenchingEvent> ThirstQuenchingEvents { get; set; }
		public DbSet<UserInfo> UsersInfo { get; set; }

		public RepositoryContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Farm>().HasKey(e => e.Id);
			modelBuilder.Entity<Farm>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<Farm>().HasOne(e => e.UserInfo).WithOne(e => e.Farm).HasForeignKey<Farm>(e => e.UserId).OnDelete(DeleteBehavior.NoAction);
				
			modelBuilder.Entity<Pet>().HasKey(e => e.Id);
			modelBuilder.Entity<Pet>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Pet>().HasOne(e => e.Farm).WithMany(e => e.Pets).HasForeignKey(e => e.FarmId);

			modelBuilder.Entity<FarmFriend>().HasKey(e => e.Id);
			modelBuilder.Entity<FarmFriend>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<FarmFriend>().HasOne(e => e.Farm).WithMany(e => e.FarmFriends).HasForeignKey(e => e.FarmId);
			modelBuilder.Entity<FarmFriend>().HasOne(e => e.UserInfo).WithMany(e => e.FarmFriends).HasForeignKey(e => e.UserId);

			modelBuilder.Entity<FeedingEvent>().HasKey(e => e.Id);
			modelBuilder.Entity<FeedingEvent>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<FeedingEvent>().HasOne(e => e.Pet).WithMany(e => e.FeedingEvents).HasForeignKey(e => e.PetId);

			modelBuilder.Entity<ThirstQuenchingEvent>().HasKey(e => e.Id);
			modelBuilder.Entity<ThirstQuenchingEvent>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<ThirstQuenchingEvent>().HasOne(e => e.Pet).WithMany(e => e.ThirstQuenchingEvents).HasForeignKey(e => e.PetId);

			modelBuilder.Entity<UserInfo>().HasKey(e => e.UserId);
			modelBuilder.Entity<UserInfo>().HasOne(e => e.User).WithOne(e => e.UserInfo).HasForeignKey<UserInfo>(e => e.UserId);

			modelBuilder.Entity<IdentityRole<Guid>>().HasData(
				new IdentityRole<Guid> {
					Id = Guid.NewGuid(),
					Name = Infrastructure.Data.UserRoles.User,
					NormalizedName = Infrastructure.Data.UserRoles.User.ToUpper()
				}
			);
		}
	}
}
