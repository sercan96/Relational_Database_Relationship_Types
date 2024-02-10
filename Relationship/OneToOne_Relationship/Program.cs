using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static OneToOne_Relationship.Program;

namespace OneToOne_Relationship
{
    public class Employee // Principal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeAdress EmployeeAdress { get; set; }
    }
    public class EmployeeAdress // Dependent(Bağımlı) => Bağımlı olana foreign key eklenir. 
    {
        [Key,ForeignKey(nameof(Employee))]
        public int Id { get; set; }
        public string Adress { get; set; }
        public Employee Employee { get; set; }

    }
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext() : base("MyConnection")
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAdress> EmployeeAdresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasOptional(x => x.EmployeeAdress).WithRequired(x => x.Employee);
        }

    }
    internal class Program
    {
        // Navigation Property = Bir nesneni navigation property olduğunu ilgili propertynin türü entity türündense o zamannavigation property dir diyebiliriz. 

        static void Main(string[] args)
        {
        }
    }
}
