using Project.ENTITIES.Concrete.Entities;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Concrete.Context
{
    public class ProjeContext:DbContext
    {
        public ProjeContext():base("ProjeContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ExpensMap());
            modelBuilder.Configurations.Add(new InvoiceBodyMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SalesMovementMap());
            modelBuilder.Configurations.Add(new ToDoMap());
            modelBuilder.Configurations.Add(new ShippingDetailMap());
            modelBuilder.Configurations.Add(new ShippingTrackingMap());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expens> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceBody> InvoiceBodies { get; set; }
        public DbSet<SalesMovement> SalesMovements { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<ShippingTracking> ShippingTrackings { get; set; }

    }
}
