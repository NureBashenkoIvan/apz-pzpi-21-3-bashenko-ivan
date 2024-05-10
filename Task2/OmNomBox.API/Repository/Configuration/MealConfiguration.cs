using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasData(
                new Meal
                {
                    MealId = new Guid("b841ccd2-b246-4350-b785-a369d0556bd4"),
                    Name = "Oatmeal",
                    Description = "A healthy bowl of oatmeal with fruit and nuts.",
                    Price = 3.99
                },
                new Meal
                {
                    MealId = new Guid("b841ccd2-b246-4350-b756-a369d0556be4"),
                    Name = "Savory Herb-Crusted Chicken",
                    Description = "Indulge in succulent chicken breast, delicately seasoned a crispy golden coating.",
                    Price = 12.99
                },
                new Meal
                {
                    MealId = new Guid("fa881d8b-83a2-47b3-9d1d-15d1066d8987"),
                    Name = "Exotic Fruit Parfait",
                    Description = "Delight your senses with layers of tropical fruits, creamy Greek yogurt, and homemade granola.",
                    Price = 7.99
                }
            );
        }
    }
}
