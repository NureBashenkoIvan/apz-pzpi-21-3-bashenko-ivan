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
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(
                new Manufacturer
                {
                    ManufacturerId = new Guid("f0933116-3861-4beb-9ad7-18fd36e8c01a"),
                    Name = "Canteen"
                },
                new Manufacturer
                {
                    ManufacturerId = new Guid("81da0139-729f-4e0b-b942-a91771011388"),
                    Name = "Vendo"
                },
                new Manufacturer
                {
                    ManufacturerId = new Guid("fc9b2456-7cb6-4dcf-b2e3-b567fe259d4d"),
                    Name = "Crane"
                },
                new Manufacturer
                {
                    ManufacturerId = new Guid("de4f7117-f89c-4c4d-8dcd-81d21013d476"),
                    Name = "Royal"
                }
            );
        }
    }
}
