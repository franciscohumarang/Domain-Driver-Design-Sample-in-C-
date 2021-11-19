using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public   DbSet<Client> Clients { get; set; }
        public   DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public  DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<TaskEntry> TaskEntries { get; set; }
     
        
 

       
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("clients");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_employee");

                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("projects");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.TaskTypeId);

                entity.ToTable("task_types");

                entity.Property(e => e.TaskTypeId).HasColumnName("task_type_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TaskEntry>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.ToTable("tasks");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Descrption)
                    .HasColumnName("descrption")
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.IsBillable).HasColumnName("is_billable");
                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoggedDate)
                    .HasColumnName("logged_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(300);

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaskTypeId).HasColumnName("task_type_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TaskEntries)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_clients");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TaskEntries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TaskEntries)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_projects");

                entity.HasOne(d => d.TaskType)
                    .WithMany(p => p.TaskEntries)
                    .HasForeignKey(d => d.TaskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_task_types");
            });

      

            base.OnModelCreating(modelBuilder);

           // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
       
    }
}
