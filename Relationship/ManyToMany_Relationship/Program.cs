using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany_Relationship
{
    /* 
     * 1- Add Migration --- 
     * 2- Update Database
    */
    #region Default Convension

    /* 
     * İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız.
     * (ICollection,List)
     * Default Convention'da cross table'ı(ara tablo) manuel oluşturmak zorunda değiliz. EF Core tasarıma uygun şekilde cross table'i kendisi otomatik basacak ve genereta edecektir.
     * Ve oluşturulan cross table'ın içerisinde composite primary key'i(ikili unik anahtar) otomatik oluşturmuş olacaktır.
    */
    //public class Book // Dependent Entity(Book)
    //{
    //    public int Id { get; set; }
    //    public string BookName { get; set; }
    //    public List<Author> Authors { get; set; }

    //}

    //public class Author
    //{
    //    public int Id { get; set; }
    //    public string AuthorName { get; set; }
    //    public List<Book> Books { get; set;}
    //}



    #endregion

    #region Data Annotation

    //Cross Table(Ara Tablo-BookAuthor) manuel olarak oluşturulmak zorundadır.
    // Entity'lerde oluşturduğumuz cross table entity si ile bire çok ilişki kurulmalı.
    // CT'da composite primary key'i data annotation(attributes) lar ile manuel kuramıyoruz. Bunun için Fluent Api ile çalışma yapmamız gerekiyor.
    // Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet propertysi olarak bildirmek mecburiyetinden değiliz.

    //public class Book // Dependent Entity(Book)  (Kitap ile KitapYazar arasında -- OneToMany)
    //{
    //    public int Id { get; set; }
    //    public string BookName { get; set; }
    //    public List<BookAuthor> Authors { get; set; }

    //}

    //public class BookAuthor 
    //{
    //    public int BookId { get; set; }
    //    public int AuthorId { get; set; }
    //    public Book Book { get; set; }
    //    public Author Author { get; set; }

    //}

    //public class Author //(Yazar ile KitapYazar arasında -- OneToMany)
    //{
    //    public int Id { get; set; }
    //    public string AuthorName { get; set; }

    }
    #endregion

    #region Fluent Api

    /*
     * Cross Table manuel olarak oluşturmak zorunda
     * DBSet olarak eklenmesine gerek yok
     * Composite PK HasKey metodu ile kurulmalı
    */
    public class Book // Dependent Entity(Book)  (Kitap ile KitapYazar arasında -- OneToMany)
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public List<BookAuthor> Authors { get; set; }

    }

    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }

    }

    public class Author //(Yazar ile KitapYazar arasında -- OneToMany)
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

    }
    #endregion

    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext() : base("MyConnection")
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        //Data Anotation
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookAuthor>()
        //                .HasKey(ba => new
        //                {
        //                    ba.BookId,
        //                    ba.AuthorId
        //                });
        //}

        // Fluent Api
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookAuthor>()
        //               .HasKey(ba => new { ba.BookId, ba.AuthorId });

        //    modelBuilder.Entity<BookAuthor>()
        //                   .HasOne(ba => ba.Book)
        //                   .HasMany(b => Authors)
        //                   .HasForeignKey(ba => ba.BookId);

        //    modelBuilder.Entity<BookAuthor>()
        //                    .HasOne(ba => ba.Author)
        //                    .HasMany(a => Books)
        //                    .HasForeignKey(ba => ba.AuthorId);
        //}

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
