using BurgerApp.DAL.Entities.Concrate;
using BurgerApp.DAL.Entities.Concrate.MenuClasses;
using BurgerApp.DAL.Entities.Concrate.OtherClasses;
using BurgerApp.PL.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerApp.PL.Data;

public class BurgerAppContext : IdentityDbContext<BurgerAppUser, IdentityRole<string>, string>
{
    public BurgerAppContext(DbContextOptions<BurgerAppContext> options)
        : base(options)
    {
    }
    public DbSet<IdentityRole<string>> IdentityRoles { get; set; }
    public DbSet<Burger> Burgers { get; set; }
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<Cips> Cipies { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<ExtraMaterial> ExtraMetarials { get; set; }
    public DbSet<Menu> Menus { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Menu>()
               .HasOne(x => x.Burger)
               .WithMany(x => x.Menus)
               .HasForeignKey(x => x.BurgerId);

        builder.Entity<Menu>()
               .HasOne(x => x.Drink)
               .WithMany(x => x.Menus)
               .HasForeignKey(x => x.DrinkId);


        builder.Entity<Menu>()
               .HasOne(x => x.Cips)
               .WithMany(x => x.Menus)
               .HasForeignKey(x => x.CipsId);
        base.OnModelCreating(builder);
    }
}
