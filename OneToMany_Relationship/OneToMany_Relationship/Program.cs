using OneToMany_Relationship.DesignPattern.SingletonPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany_Relationship
{
    /* 
     * 1- Add Migration --- 
     * 2- Update Database
    */
    #region Default Convension

    /* 
     * İki tablo arasındaki ilişkisel yapıyı entity sınıfları üzerinden navigation property eşliğinde yapmamızı sağlayan bir yöntemdir.
     * Default Convension yönteminde bire çok ilişkiyi kurarken foreign key kolonuna karşılık gelen bir property tanımlamak mecburiyetinde değiliz. Eğer tanımlamazsak Ef bunu kenid tanımlayacak.Tanımlarsak tanımladığımızı baz alıcaktır.
    */
    //public class Employee // Dependent Entity(Employees)
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    // If we don't add DepartmentID key, Ef will add it automatically.
    //    public Department Department { get; set; } // Navigation Property
    //}

    //public class Department
    //{
    //    public int Id { get; set; }
    //    public string DepartmentName { get; set; }
    //    public List<Employee> Employees { get; set; } // List or Collection
    //}

    #endregion

    #region Data Annotation

    // Default Convention yönteminde foreign key kolonuna karşılık gelen property tanımladığımızda bu property ismi temel geleneksel entity kurallarına uymuyorsa eğerdata annotationlar ile müdahalede bulunabiliriz.
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } // Navigation Property
    }

    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int Room { get; set; }
        public List<Employee> Employees { get; set; } // List or Collection
    }
    #endregion

    #region Fluent Api
    //public class Employee
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int DId { get; set; } // Foreign Key olduğunu belirtmek için OnModelCreating'den tanımlanması gerekir.
    //    public Department Department { get; set; } // Navigation Property
    //}

    //public class Department
    //{
    //    public int Id { get; set; }
    //    public string DepartmentName { get; set; }
    //    public List<Employee> Employees { get; set; } // List or Collection
    //}
    #endregion

    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext() : base("MyConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AddDepartment();
            //AddEmployee();
            //AddEmployeeByDepartment();
        }

        static void AddEmployee()
        {
            using (var db = new ECommerceDbContext())
            {
                db.Employees.AddRange(new List<Employee>()
                {
                    new Employee{Name = "Sercan",Surname ="Sağlam", DepartmentId =1 },
                    new Employee{Name = "Ahmet",Surname ="Tönur", DepartmentId =2},
                    new Employee{Name = "Murat",Surname ="Dalkılıç", DepartmentId =1},
                });

                db.SaveChanges();
                foreach (var item in db.Employees)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        static void AddDepartment()
        {
            using (var db = new ECommerceDbContext())
            {       
                db.Departments.AddRange(new List<Department>()
                {
                    new Department{DepartmentName = "Arge",Room = 32},
                    new Department{DepartmentName = "Enginnering",Room =21},
                    new Department{DepartmentName = "IK",Room =12},
                });
  
                db.SaveChanges();
            }
        }

        static void AddEmployeeByDepartment()
        {
            using (var db = new ECommerceDbContext())
            {
                var department = db.Departments.FirstOrDefault(d => d.DepartmentName == "Enginnering");
      
                department.Employees.AddRange(new List<Employee>()
                {
                    new Employee{Name = "Sena", Surname ="Şanlı"},  // employee.DepartmentId = Id; 
                    new Employee{Name = "Tuncer", Surname ="Atakul"}, // employee.DepartmentId = Id;
                    new Employee{Name = "Murat", Surname ="Boz"},// employee.DepartmentId = Id;

                    /*
                     * Yeni eklenen Employee nesneleri, var olan bir departmana eklenirken, bu departmanın Id değeri Employee nesnesinin DepartmentId özelliğine atanmalıdır. Bu Id sayesinde employee nesnesinin Department nesnesine ilgili DepartmentId nin bilgileri gelecektir.
                    */
                });

                db.SaveChanges();

                foreach (var item in department.Employees)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

    }
}
