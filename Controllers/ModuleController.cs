namespace webusers.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : ControllerBase
{
    private readonly IUserModuleService _userModule;
    public ModuleController( IUserModuleService userModule ) {
        _userModule = userModule;
    }
    [ HttpGet( "GetModules" ) ]
    public async Task<ActionResult<ServiceResponse<List<GetModuleUserDto>>>> GetModules() {
        return Ok( await _userModule.GetUserModules());
    }

    [ HttpGet( "{id}" ) ]
    public async Task<ActionResult<ServiceResponse<List<GetModuleUserDto>>>> GetModule( int id ) {
        return Ok( await _userModule.GetOneModule( id ));
    }
    [ HttpPost ]
    public async Task<ActionResult<ServiceResponse<GetModuleUserDto>>> CreateModule( AddModuleUserDto module ) {
        return Ok( await _userModule.CreateModule( module ));
    }
}
