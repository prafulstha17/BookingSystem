using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{

    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public bool IsVerified { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        // 🔗 Foreign Key to Role
        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public int? ClientId { get; set; }
        public Client.Client? Client { get; set; } = null!;

    }

}

