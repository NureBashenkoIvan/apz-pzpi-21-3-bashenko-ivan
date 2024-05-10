using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace OmNomBox.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<CreateUpdateOrderDto, Order>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateUpdateCompanyDto, Company>();
            CreateMap<MachineType, MachineTypeDto>();
            CreateMap<CreateUpdateMachineTypeDto, MachineType>();
            CreateMap<Machine, MachineDto>();
            CreateMap<CreateUpdateMachineDto, Machine>();
            CreateMap<MachineStatus, MachineStatusDto>();
            CreateMap<CreateUpdateMachineStatusDto, MachineStatus>();
            CreateMap<MachineSettings, MachineSettingsDto>();
            CreateMap<CreateUpdateMachineSettingsDto, MachineSettings>();
            CreateMap<Meal, MealDto>();
            CreateMap<CreateUpdateMealDto, Meal>();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<CreateUpdateManufacturerDto, Manufacturer>();
        }
    }
}
