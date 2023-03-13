namespace webusers.Services.UserModule
{
    public class UserModuleService : IUserModuleService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserModuleService( IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor ) {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetUserLogged() => int.Parse (
            _httpContextAccessor.HttpContext!.User.FindFirstValue( ClaimTypes.NameIdentifier )!
        );
        public async Task<ServiceResponse<GetModuleUserDto>> CreateModule( AddModuleUserDto userModule )
        {
            var serviceResponse = new ServiceResponse<GetModuleUserDto>();
            var module = _mapper.Map<Module>( userModule );
            var userid = GetUserLogged();
            module.User = await _context.Users.FirstOrDefaultAsync( u => u.Id == userid );
            _context.Modules.Add( _mapper.Map<Module>( module ));
            await _context.SaveChangesAsync();
            var moduleCreated = await _context.Modules.FirstOrDefaultAsync( c => c!.User!.Id == userid );
            if ( moduleCreated != null ) {
                serviceResponse.Data = _mapper.Map<GetModuleUserDto>( moduleCreated );
                serviceResponse.Status = true;
                serviceResponse.Message = "Usuario Creado";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetModuleUserDto>> GetOneModule(int id)
        {
            var serviceResponse = new ServiceResponse<GetModuleUserDto>();
            var module = await _context.Modules.FirstOrDefaultAsync(
                m => m.Id == id && m.User!.Id == GetUserLogged()
            );
            if ( module == null ) {
                serviceResponse.Status = false;
                serviceResponse.Message = "Usuario no encontrado";
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<GetModuleUserDto>( module );
            serviceResponse.Status = true;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetModuleUserDto>>> GetUserModules()
        {
            var serviceResponse = new ServiceResponse<List<GetModuleUserDto>>();
            serviceResponse.Data = await _context.Modules
                .Where( m => m.User!.Id == GetUserLogged() )
                .Select( m => _mapper.Map<GetModuleUserDto>( m ))
                .ToListAsync();
            return serviceResponse;
        }
    }
}