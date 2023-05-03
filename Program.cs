using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DejiClinic.Data;
using DejiClinic.Areas.Identity.Data;
using Microsoft.Extensions.Hosting;

namespace DejiClinic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");


            builder.Services.AddDbContext<AuthDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        connectionString,
                        ServerVersion.AutoDetect(connectionString)
                )
            );

            builder.Services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequireUppercase = false;
                Options.Password.RequiredUniqueChars = 0;
            });

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddMvc();

            var app = builder.Build();
            //var host = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "admin", "users" };
                foreach (var role in roles)
                {
                    if (!await rolemanager.RoleExistsAsync(role))
                        await rolemanager.CreateAsync(new IdentityRole(role));
                }
            }

            app.Run();
        }
    }
}
