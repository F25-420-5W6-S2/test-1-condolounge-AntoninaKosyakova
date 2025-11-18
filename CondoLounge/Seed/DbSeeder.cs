using CondoLounge.Data;
using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Principal;

namespace CondoLounge.Seed
{
    //
    // DbSeeder.cs -- sets up default roles, users, and sample data
    //
    public static class DbSeeder
    {
        // Main method that runs all the seeding steps
        public static async Task SeedAsync(IServiceProvider sp)
        {
            // Create a scoped service provider to access the database and identity services
            using var scope = sp.CreateScope();

            // Retrieving dependencies from DI
            var ctx =scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager =scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            // Apply pending migrations
            await ctx.Database.MigrateAsync();

            //
            // --- Seed Roles ---
            //
            string[] roles = { "Admin", "Default" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<int>
                    {
                        Name = role
                    });
            }

            //
            // --- Seed initial Building ---
            //
            var BuildingId = "1";
            if (!ctx.Buildings.Any(g => g.BuildingId == BuildingId))
            {
                ctx.Buildings.Add(new Building { BuildingId = BuildingId });
                await ctx.SaveChangesAsync();
            }


            var adminEmail = "admin@example.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if(admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(admin, "Password123!");
                await userManager.AddToRoleAsync(admin, "Admin");

                var condos = new List<Condo>
                {
                    new Condo { CondoNumber = "101", Address = "123 avenue, Lachine, QC, CA", BuildingId = BuildingId },
                    new Condo { CondoNumber = "102", Address = "123 avenue, Lachine, QC, CA", BuildingId = BuildingId }
                };

                ctx.Condos.AddRange(condos);
                await ctx.SaveChangesAsync();

                admin.Condos = condos;

                await userManager.UpdateAsync(admin);

                
            }

            Console.WriteLine("Database seeding completed successfully.");


            ////
            //// --- Seed initial Building ---
            ////
            //var BuildingId = "1";
            //if (!ctx.Buildings.Any(g => g.BuildingId == BuildingId))
            //{
            //    ctx.Buildings.Add(new Building { BuildingId = BuildingId });
            //    await ctx.SaveChangesAsync();
            //}

            ////
            //// --- Create Admin User with sample Condos ---
            ////
            //var admin = new ApplicationUser
            //{
            //    UserName = "admin@example.com",
            //    Email = "admin@example.com",              
            //    Condos = new List<Condo>
            //    {
            //        new Condo { CondoNumber = "101", Address = "123 avenue, Lachine, QC, CA", BuildingId = BuildingId },
            //        new Condo { CondoNumber = "102", Address = "123 avenue, Lachine, QC, CA", BuildingId = BuildingId }
            //    }
            //};

            //if (await userManager.FindByEmailAsync(admin.Email) == null)
            //{
            //    await userManager.CreateAsync(admin, "Password123!");
            //    await userManager.AddToRoleAsync(admin, "Admin");
            //}

            //Console.WriteLine("Database seeding completed successfully.");
        }
    }

}
