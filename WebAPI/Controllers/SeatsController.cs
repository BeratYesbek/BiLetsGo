using Business.Abstracts;
using Entity.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;
        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost("add")]
        public IActionResult Add(Seat seat)
        {
            var result = _seatService.Add(seat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Seat seat)
        {
            var result = _seatService.Update(seat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Seat seat)
        {
            var result = _seatService.Delete(seat);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById{id}")]
        public IActionResult GetById(int id)
        {
            var result = _seatService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
;        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _seatService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getBySalonId/{salonId}")]
        public IActionResult GetBySeatId(int salonId)
        {
            var result = _seatService.GetBySalonId(salonId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
