using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Cloud.Cloudinary;
using Microsoft.AspNetCore.Http;

namespace Entity.Concretes
{
    public class TicketFile : Cloudinary,IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }


        [NotMapped]
        [JsonIgnore]
        public IFormFile[] Files { get; set; }

    }
}
