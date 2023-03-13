using webusers.DTOS.User;

namespace webusers.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepo;
    public AuthController( IAuthRepository authrepo ) {
        _authRepo = authrepo;
    }
    [ HttpPost( "Register" ) ]
    public async Task<ActionResult<ServiceResponse<int>>> Register( UserRegisterDto request ) {
        var response = await _authRepo.Register(
            new User { UserName = request.Username }, request.Password
        );
        return response.Status ? Ok( response ) : BadRequest( response );
    }
    [ HttpPost( "Login" ) ]
    public async Task<ActionResult<ServiceResponse<int>>> Login( UserLoginDto request ) {
        var response = await _authRepo.Register(
            new User { UserName = request.Username }, request.Password
        );
        return response.Status ? Ok( response ) : BadRequest( response );
    }
}
