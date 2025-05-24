
namespace Application.Modules.Clients;

public class OutQryClient
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string City { get; set; }
   
    public string Email { get; set; }

    public string status { get; set; } = "Active";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastUpdated { get; set; }
    public string? PrilePicture { get; set; }
    public string? Description { get; set; }

    public string? GoogleMapLink { get; set; }
}

public class InQryClient
{
    public int? ClientId { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Status { get; set; }
    public string? Province { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }

}
