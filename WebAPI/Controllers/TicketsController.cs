using AutoMapper;
using Business.Abstracts;
using Entity.Concretes;
using Entity.Concretes.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] TicketCreateDto ticketCreateDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketCreateDto);
            var ticketfile = _mapper.Map<TicketFile>(ticketCreateDto);
            var result = await _ticketService.Add(ticket, ticketfile);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] TicketUpdateDto ticketUpdateDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketUpdateDto);
            var ticketfile = _mapper.Map<TicketFile>(ticketUpdateDto);
            var result = await _ticketService.Update(ticket, ticketfile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Ticket ticket)
        {
            var result = _ticketService.Delete(ticket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById{id}")]
        public IActionResult GetById(int id)
        {
            var result = _ticketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _ticketService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getAllDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _ticketService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getTicketDetailById/{ticketID}")]
        public IActionResult GetTicketDetailById(int ticketID)
        {
            var result = _ticketService.GetTicketDetailById(ticketID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
