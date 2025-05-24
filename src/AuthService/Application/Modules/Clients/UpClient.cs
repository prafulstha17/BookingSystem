using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.Clients
{
    public class UpClient
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; }
        public string? PrilePicture { get; set; }
        public string? Description { get; set; }

        public string? GoogleMapLink { get; set; }
    }
}
