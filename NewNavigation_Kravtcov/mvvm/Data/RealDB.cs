using Microsoft.EntityFrameworkCore;
using NewNavigation_Kravtcov.mvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNavigation_Kravtcov.mvvm.Data
{
    public class RealDB : DbContext
    {
        // Таблица отделов
        public DbSet<Department> Departments { get; set; }

        // Таблица сотрудников
        public DbSet<Employee> Employees { get; set; }

        // Таблица пользователей
        public DbSet<User> Users { get; set; }

        // Конструктор
        public RealDB(DbContextOptions<RealDB> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=NewNavigation_Kravtcov.db");
        }
        // Настройка модели (опционально)
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Настройка модели Department
        //    modelBuilder.Entity<Department>(entity =>
        //    {
        //        // Уникальный индекс для поля Name
        //        entity.HasIndex(d => d.Name)
        //              .IsUnique();

        //        // Связь один-ко-многим с Employee
        //        entity.HasMany(d => d.Employees)
        //              .WithOne(e => e.Department)
        //              .HasForeignKey(e => e.DepartmentId)
        //              .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление
        //    });

        //    // Настройка модели Employee
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        // Уникальный индекс для комбинации FirstName и LastName
        //        entity.HasIndex(e => new { e.FirstName, e.LastName })
        //              .IsUnique();

        //        // Связь многие-к-одному с Department
        //        entity.HasOne(e => e.Department)
        //              .WithMany(d => d.Employees)
        //              .HasForeignKey(e => e.DepartmentId)
        //              .OnDelete(DeleteBehavior.Restrict); // Ограничение на удаление
        //    });

        //    // Настройка модели User
        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        // Уникальный индекс для поля Username
        //        entity.HasIndex(u => u.Username)
        //              .IsUnique();
        //    });
        //}

    }
}
