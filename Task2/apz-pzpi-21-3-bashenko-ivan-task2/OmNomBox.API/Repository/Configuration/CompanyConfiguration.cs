using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    CompanyId = new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"),
                    Name = "YummyBox",
                    Address = "3500 Deer Creek Road, Palo Alto, CA 94304"
                },
                new Company
                {
                    CompanyId = new Guid("77a0c320-00c6-413e-af46-304db9ddff7b"),
                    Name = "TastyMachines",
                    Address = "5550 Olphan Street, Montgomery, CA 94890"
                }
            );
        }
    }
}
