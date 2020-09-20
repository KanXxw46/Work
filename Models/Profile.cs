using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public class Profile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Address { get; set; }
        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
