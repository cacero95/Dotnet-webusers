namespace webusers.Services.UserModule
{
    public interface IUserModuleService
    {
        Task<ServiceResponse<List<GetModuleUserDto>>> GetUserModules(); 
        Task<ServiceResponse<GetModuleUserDto>> GetOneModule( int id );
        Task<ServiceResponse<GetModuleUserDto>> CreateModule( AddModuleUserDto userModule );
    }
}