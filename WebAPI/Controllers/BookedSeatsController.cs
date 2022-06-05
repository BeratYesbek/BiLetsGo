using Business.Abstracts;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedSeatsController : ControllerBase
    {
        private readonly IBookedSeatService _bookedSeatService;

        public BookedSeatsController(IBookedSeatService bookedSeatService)
        {
            _bookedSeatService = bookedSeatService;
        }

        [HttpPost("add")]
        public IActionResult Add(BookedSeat seat)
        {
            var result = _bookedSeatService.Add(seat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
