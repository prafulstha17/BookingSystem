using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Client
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
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
        public ICollection<ClientGallery> ClientGalleries { get; set; } = new List<ClientGallery>();
    }
}
