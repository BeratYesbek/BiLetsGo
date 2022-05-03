using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes
{
    public class TicketFile : IEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string PublicId { get; set; }

        public int TicketId { get; set; }
         
        [NotMapped]
        public IFormFile[] Files { get; set; }
    }
}
