using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static OneToOne_Relationship.Program;

namespace OneToOne_Relationship
{
    #region Default Convension
    /*
     * Her iki entity'de Navigation property ile birbirlerini tekil olarak referans ederek fiziksel bir ilişki olcağını beyan eder.
     * One to One ilişki türünde, dependent entity nin hangisi olduğunu default olarak belirleyebilmek kolay değildir.Bu durumda fiziksel olarak bir foreign keye karşılık bir colon tanımlayarak çözüm getirebiliyoruz.
     * Böylece foreign key e karşılık property ekleyerek lüzümsuz bir kolon eklemiş oluyoruz.
    */
    //public class Employee // Principal
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public EmployeeAdress EmployeeAdress { get; set; }
    //}
    //public class EmployeeAdress // Dependent(Bağımlı) => Bağımlı olana foreign key eklenir. 
    //{
    //    public int Id { get; set; }
    //    public int EmployeeID { get; set; }
    //    public string Adress { get; set; }
    //    public Employee Employee { get; set; }

    //}
    #endregion
    #region Data Annotation

    /*
     * Navigation Propertyler tanımlanmalıdır.
     * Foreign kolonunun ismi default converntionun dışında bir kolon olucaksa eğer Foreign attribute ile bunu bildirebilirsiniz.
     * Foreign kolonu oluşturulmak zorunda değildir.
     * 1'e 1 ilişkide ekstradan foreign key kolonuna ihtiyaç olmayacağından dolayı dependent entity deki Id kolonunun hem primary key hem de foreign key olarak kullanmayı tercih ediyıruz ve bu duruma özen gösterilmelidir diyoruz.
    */
    public class Employee // Principal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeAdress EmployeeAdress { get; set; }
    }
    public class EmployeeAdress // Dependent(Bağımlı) => Bağımlı olana foreign key eklenir. 
    {
        [Key, ForeignKey(nameof(Employee))]
        public int Id { get; set; }
        public string Adress { get; set; }
        public Employee Employee { get; set; }

    }
    #endregion
    #region Fluent Api

    // Entity ler üzerinden çalışmıyoruz. İlişkiyi OnModelCreating metodunda yapıyrouz.
    //public class Employee // Principal
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Surname { get; set; }
    //    public EmployeeAdress EmployeeAdress { get; set; }
    //}
    //public class EmployeeAdress // Dependent(Bağımlı) => Bağımlı olana foreign key eklenir. 
    //{        
    //    public int Id { get; set; }
    //    public string Adress { get; set; }
    //    public Employee Employee { get; set; }

    //}
    #endregion

    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext() : base("MyConnection")
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAdress> EmployeeAdresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployeeAdress>()
            //            .HasKey(e => e.Id);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(x => x.EmployeeAdress)
            //            .WithOne(ea => ea.Employee)
            //            .HasForeignKey(x => x.Id);
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
