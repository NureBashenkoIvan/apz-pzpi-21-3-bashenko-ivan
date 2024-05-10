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
    public class MachineStatusConfiguration : IEntityTypeConfiguration<MachineStatus>
    {
        public void Configure(EntityTypeBuilder<MachineStatus> builder)
        {
            builder.HasData(
                new MachineStatus
                {
                    MachineStatusId = new Guid("0273be30-d656-406f-9c21-f70f3311349d"),
                    Name = "Operational",
                    Description = "The machine is in working order and fully operational."
                },
                new MachineStatus
                {
                    MachineStatusId = new Guid("d8e256ef-63c8-4ec9-9e5e-7b82a86fe9e4"),
                    Name = "Under Maintenance",
                    Description = "The machine is currently undergoing maintenance."
                },
                new MachineStatus
                {
                    MachineStatusId = new Guid("7a22dd92-879d-4854-92a0-3cef72465365"),
                    Name = "Needs Restocking",
                    Description = "The machine is out of stock and needs to be restocked."
                },
                new MachineStatus
                {
                    MachineStatusId = new Guid("48715752-3e1f-4646-aa2b-4bca312e36b6"),
                    Name = "Needs Inspection",
                    Description = "The machine needs to be inspected for safety and compliance."
                },
                new MachineStatus
                {
                    MachineStatusId = new Guid("3d3acb44-411c-4b29-94e7-02f273320e47"),
                    Name = "Under Cleaning",
                    Description = "The machine is currently being cleaned."
                }
            );
        }
    }
}
