using Microsoft.EntityFrameworkCore;

namespace Api.Data.Entities
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(Role.GetInitialData());
            modelBuilder.Entity<User>().HasData(User.GetInitialData());
            modelBuilder.Entity<Category>().HasData(Category.GetInitialData());
            modelBuilder.Entity<Offer>().HasData(Offer.GetInitialData());
            modelBuilder.Entity<Product>().HasData(Product.GetInitialData());
        }
    }
}
//IEntityTypeConfiguration