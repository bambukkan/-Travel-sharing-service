using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("trips")]
public class TripsController(ITripService tripService) : ControllerBase
{
    [HttpGet("by-Id")]
    public async Task<ActionResult<List<TripEntity>>> GetByUserId(Guid userId)
    {
        return Ok(await tripService.GetByUserId(userId));
    }

    [HttpGet("by-tripID")]
    public async Task<ActionResult<TripEntity>> GetById(Guid tripId)
    {
        var trip = await tripService.GetById(tripId);
        return trip is null ? NotFound() : Ok(trip);
    }

    [HttpGet("users-by-tripID")]
    public async Task<ActionResult<List<UserEntity>>> GetUsersByTripId(Guid tripId)
    {
        return Ok(await tripService.GetUsersByTripId(tripId));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TripEntity trip)
    {
        await tripService.Add(trip);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TripEntity trip)
    {
        await tripService.Update(trip);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid tripId)
    {
        await tripService.Delete(tripId);
        return Ok();
    }
}
