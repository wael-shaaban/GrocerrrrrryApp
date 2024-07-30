using Microsoft.EntityFrameworkCore;

namespace GerogercyApp.Api.Data.Entities
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(Role.GetInitialRoles());
            modelBuilder.Entity<User>().HasData(User.GetInitialUsers());
            modelBuilder.Entity<Category>().HasData(Category.GetInitialData());
            modelBuilder.Entity<Offer>().HasData(Offer.GetInitialData());
        }
    }
}
//IEntityTypeConfiguration