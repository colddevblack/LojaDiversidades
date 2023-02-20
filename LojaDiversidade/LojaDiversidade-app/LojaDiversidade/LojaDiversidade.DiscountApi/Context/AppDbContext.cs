using Microsoft.EntityFrameworkCore;
using LojaDiversidade.DiscountApi.Models;

namespace LojaDiversidade.DiscountApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = 1,
            CouponCode = "LojaDiversidade_PROMO_10",
            Discount = 10
        });
        modelBuilder.Entity<Coupon>().HasData(new Coupon
        {
            CouponId = 2,
            CouponCode = "LojaDiversidade_PROMO_20",
            Discount = 20
        });
    }
}
