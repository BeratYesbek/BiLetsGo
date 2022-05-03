using System;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes.Dto
{
    public class TicketCreateDto : IDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime EventStartedDate { get; set; }

        public DateTime EventFinishedDate { get; set; }

        public  IFormFile[] Files { get; set; }
    }
}
