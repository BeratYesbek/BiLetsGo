using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.Dto
{
    public class TicketUpdateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime EventStartedDate { get; set; }

        public DateTime EventFinishedDate { get; set; }

        public IFormFile[] Files { get; set; }
    }
}
