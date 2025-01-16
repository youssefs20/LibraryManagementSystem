using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Repositories;
using LibraryManagmentSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LibraryManagmentSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Library2"));
            });

            builder.Services.AddIdentity<User, IdentityRole>(
                option =>
                {
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                }
                ).AddEntityFrameworkStores<LibraryContext>();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBooksCheckedOutRepository, BooksCheckedOutRepository>();
            builder.Services.AddScoped<IReturnRepository, ReturnRepository>();
            builder.Services.AddScoped<IBooksReturnedRepository, BooksReturnedRepository>();
            builder.Services.AddScoped<ICheckOutRepository, CheckOutRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IUsersBooks, UsersBooksRepository>();

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await EnsureRoleExists(roleManager, "Member");
                await EnsureRoleExists(roleManager, "Librarian");

                var adminCredentials = builder.Configuration.GetSection("AdminCredentials");
                string? username = adminCredentials["Username"];
                string? password = adminCredentials["Password"];


                // Create a new user with the librarian role
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                User user = new User()
                {
                    UserName = username,
                    PasswordHash = password
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Librarian");
                }
            }



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.Run();




            //check role exist or not
            async Task EnsureRoleExists(RoleManager<IdentityRole> roleManager, string roleName)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    IdentityResult result = await roleManager.CreateAsync(role);
                }
            }

        }
    }
}
