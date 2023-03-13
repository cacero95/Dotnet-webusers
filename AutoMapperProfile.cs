namespace webusers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Module, GetModuleUserDto>();
            CreateMap<AddModuleUserDto, Module>();
        }
    }
}