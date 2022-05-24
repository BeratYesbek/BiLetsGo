using Business.Abstracts;
using Entity.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonsController : ControllerBase
    {
        private readonly ISalonService _salonService;
        public SalonsController(ISalonService salonService)
        {
            _salonService = salonService;
        }

        [HttpPost("add")]
        public IActionResult Add(Salon salon)
        {
            var result = _salonService.Add(salon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Salon salon)
        {
            var result = _salonService.Update(salon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Salon salon)
        {
            var result = _salonService.Delete(salon);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById{id}")]
        public IActionResult GetById(int id)
        {
            var result = _salonService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            ;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _salonService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

       
    }
}
