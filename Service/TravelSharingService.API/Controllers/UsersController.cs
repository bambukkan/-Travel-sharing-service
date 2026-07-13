using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("users")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserEntity>>> GetAll()
    {
        return Ok(await userService.GetAll());
    }

    [HttpGet("by-id")]
    public async Task<ActionResult<UserEntity>> GetById(Guid userId)
    {
        var user = await userService.GetById(userId);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpGet("by-email")]
    public async Task<ActionResult<UserEntity>> GetByEmail([FromQuery] string email)
    {
        var user = await userService.GetByEmail(email);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpGet("by-tripID")]
    public async Task<ActionResult<List<UserEntity>>> GetByTripId(Guid tripId)
    {
        return Ok(await userService.GetByTripId(tripId));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserEntity user)
    {
        await userService.Add(user);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserEntity user)
    {
        await userService.Update(user);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid userId)
    {
        await userService.Delete(userId);
        return Ok();
    }
}
