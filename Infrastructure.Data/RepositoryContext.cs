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
		public DbSet<PetBody> PetBodies { get; set; }
		public DbSet<PetEyes> PetEyes { get; set; }
		public DbSet<PetNose> PetNoses { get; set; }
		public DbSet<PetMouth> PetMouths { get; set; }

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
            modelBuilder.Entity<Pet>().HasOne(e => e.Body).WithMany(e => e.RelatedPets).HasForeignKey(e => e.BodyId);
            modelBuilder.Entity<Pet>().HasOne(e => e.Eyes).WithMany(e => e.RelatedPets).HasForeignKey(e => e.EyesId);
            modelBuilder.Entity<Pet>().HasOne(e => e.Nose).WithMany(e => e.RelatedPets).HasForeignKey(e => e.NoseId);
            modelBuilder.Entity<Pet>().HasOne(e => e.Mouth).WithMany(e => e.RelatedPets).HasForeignKey(e => e.MouthId);

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

			modelBuilder.Entity<PetBody>().HasKey(e => e.Id);
			modelBuilder.Entity<PetBody>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<PetBody>().HasData(new PetBody() { Id = Guid.NewGuid(), PictureName = "body1.svg" },
												   new PetBody() { Id = Guid.NewGuid(), PictureName = "body2.svg" },
												   new PetBody() { Id = Guid.NewGuid(), PictureName = "body3.svg" },
												   new PetBody() { Id = Guid.NewGuid(), PictureName = "body4.svg" },
												   new PetBody() { Id = Guid.NewGuid(), PictureName = "body5.svg" });

			modelBuilder.Entity<PetEyes>().HasKey(e => e.Id);
			modelBuilder.Entity<PetEyes>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<PetEyes>().HasData(new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes1.svg" },
												   new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes2.svg" },
												   new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes3.svg" },
												   new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes4.svg" },
												   new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes5.svg" },
												   new PetEyes() { Id = Guid.NewGuid(), PictureName = "eyes6.svg" });

			modelBuilder.Entity<PetNose>().HasKey(e => e.Id);
			modelBuilder.Entity<PetNose>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<PetNose>().HasData(new PetNose() { Id = Guid.NewGuid(), PictureName = "nose1.svg" },
												   new PetNose() { Id = Guid.NewGuid(), PictureName = "nose2.svg" },
												   new PetNose() { Id = Guid.NewGuid(), PictureName = "nose3.svg" },
												   new PetNose() { Id = Guid.NewGuid(), PictureName = "nose4.svg" },
												   new PetNose() { Id = Guid.NewGuid(), PictureName = "nose5.svg" },
												   new PetNose() { Id = Guid.NewGuid(), PictureName = "nose6.svg" });

			modelBuilder.Entity<PetMouth>().HasKey(e => e.Id);
			modelBuilder.Entity<PetMouth>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<PetMouth>().HasData(new PetMouth() { Id = Guid.NewGuid(), PictureName = "mouth1.svg" },
												    new PetMouth() { Id = Guid.NewGuid(), PictureName = "mouth2.svg" },
												    new PetMouth() { Id = Guid.NewGuid(), PictureName = "mouth3.svg" },
												    new PetMouth() { Id = Guid.NewGuid(), PictureName = "mouth4.svg" },
												    new PetMouth() { Id = Guid.NewGuid(), PictureName = "mouth5.svg" });

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
