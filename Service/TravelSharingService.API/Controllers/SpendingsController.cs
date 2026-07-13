using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("spendings")]
public class SpendingsController(ISpendingService spendingService) : ControllerBase
{
    [HttpGet("by-tripID")]
    public async Task<ActionResult<List<SpendingEntity>>> GetByTripId(Guid tripId)
    {
        return Ok(await spendingService.GetByTripId(tripId));
    }

    [HttpGet("by-Id")]
    public async Task<ActionResult<SpendingEntity>> GetById(Guid spendingId)
    {
        var spending = await spendingService.GetById(spendingId);
        return spending is null ? NotFound() : Ok(spending);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SpendingEntity spending)
    {
        await spendingService.Add(spending);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] SpendingEntity spending)
    {
        await spendingService.Update(spending);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid spendingId)
    {
        await spendingService.Delete(spendingId);
        return Ok();
    }
}
