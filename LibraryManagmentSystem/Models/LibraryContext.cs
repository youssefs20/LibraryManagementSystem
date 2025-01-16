using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibraryManagmentSystem.Models
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersBooks>().HasKey(UB => new {UB.UserId,UB.BookId});
            base.OnModelCreating(builder);

            builder.Entity<BooksCheckedOut>()
            .HasOne(b => b.CheckOut)
            .WithMany(c => c.booksCheckedOuts)
            .HasForeignKey(b => b.CheckOutId)
            .OnDelete(DeleteBehavior.Cascade); // Enable cascade delete here

            builder.Entity<CheckOut>()
            .HasMany(c => c.booksCheckedOuts)
            .WithOne(bc => bc.CheckOut)
            .HasForeignKey(bc => bc.CheckOutId)
            .OnDelete(DeleteBehavior.Cascade); // Ensure cascade is set here

            // Ensure that Profile does not cascade delete
            builder.Entity<BooksCheckedOut>()
                .HasOne(b => b.Profile)
                .WithMany(p => p.BorrowedBooks)
                .HasForeignKey(b => b.ProfileId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion of Profile
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }

        public DbSet<Return> Returns { get; set; }

        public DbSet<BooksCheckedOut> BooksCheckedOuts { get; set; }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Return> returns { get; set; }

        public DbSet<BooksReturned> BooksReturned { get; set; }

        public DbSet<UsersBooks> UsersBooks { get; set; }
    }
}
