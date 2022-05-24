using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concretes
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
