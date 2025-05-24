
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Client
{
    public class ClientGallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        public string image { get; set; } 
        public Client Client { get; set; } = null!;
    }
}
