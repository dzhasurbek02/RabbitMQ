using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Publisher.DTO;
using SharedFiles;

namespace Publisher.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IBusControl _busControl; //IPublishEndpoint _publishEndpoint;

    public UsersController(IBusControl busControl)
    {
        _busControl = busControl;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder(UserDto userDto)
    {
        await _busControl.Publish<UserCreated>(new
        {
            Id = Guid.NewGuid(),
            userDto.UserName,
            userDto.Password
        });

        return Ok();
    }
}