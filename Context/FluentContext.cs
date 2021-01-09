using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using variant_14_4.Models;

namespace variant_14_4.Context
{
    /*
      Написати міграцію(міграції) необхідну для проеціювання наведеної моделі даних (надається викладачем окремо, 2) у SQL базу даних за допомогою EF Migrations. Створити цю базу.
      Стовбчик Employee.CityId повинен мати foreign key на стовбчик City.Id.
      У базі має бути створено загалом дві таблиці.
      Написати метод, що поверне усі доступні спеціалізації лікарів у конкретному місті. Оптимізувати код щоб у базу надсилався лише один запит  
    */
    class FluentContext : DbContext
    {
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Enginier> Enginiers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // employe
            modelBuilder.Entity<Employe>().HasKey(x => x.Id);

            modelBuilder.Entity<Employe>().Property(p => p.Name).HasMaxLength(120);

            modelBuilder.Entity<Employe>()
                .HasRequired(e => e.City)
                .WithMany(c => c.Employes)
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<Doctor>().Property(p => p.Spesialisation).IsRequired();


            modelBuilder.Entity<Employe>().ToTable("Employes");

            // city
            modelBuilder.Entity<City>().HasKey(x => x.Id);

            modelBuilder.Entity<City>().ToTable("Cities");

            base.OnModelCreating(modelBuilder);
        }
    }
}
