﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.DAL.EF
{
	public class ApplicationDbContext : IdentityDbContext<User, Role, int>
	{
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<SubjectGroup> SubjectGroups { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.ToTable("AspNetUsers")
				.HasDiscriminator<int>("UserType")
				.HasValue<User>((int)RoleValue.User)
				.HasValue<Student>((int)RoleValue.Student)
				.HasValue<Parent>((int)RoleValue.Parent)
				.HasValue<Teacher>((int)RoleValue.Teacher);

            modelBuilder.Entity<SubjectGroup>()
               .HasKey(sg => new { sg.GroupId, sg.SubjectId });

            modelBuilder.Entity<SubjectGroup>()
                .HasOne(s => s.Subject)
                .WithMany(sg => sg.SubjectGroups)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.DateOfIssue, g.StudentId, g.SubjectId });

            modelBuilder.Entity<Grade>()
                .HasOne(s => s.Student)
                .WithMany(sg => sg.Grades)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}