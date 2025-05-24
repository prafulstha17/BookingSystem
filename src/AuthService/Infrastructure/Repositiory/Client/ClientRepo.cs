using Application.Interface.Client;
using Application.Modules.Clients;
using Domain.Common;
using Domain.Entities.Client;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositiory.Client
{
    public class ClientRepo : IClientRepo
    {
        private readonly AuthDbContext _context;

        public ClientRepo(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<object>> InClient(InClient client)
        {
            var response = new BaseResponse<object>();
            try
            {
                var newClient = new Domain.Entities.Client.Client
                {
                    Name = client.Name,
                    Province = client.Province,
                    District = client.District,
                    City = client.City,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                    status = client.status,
                    CreatedAt = DateTime.UtcNow,
                    PrilePicture = client.PrilePicture,
                    Description = client.Description,
                    GoogleMapLink = client.GoogleMapLink

                };

                await _context.Clients.AddAsync(newClient);
                await _context.SaveChangesAsync();

                response.Code = "200";
                response.Status = "success";
                response.Data = null;
            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Status = "failed";
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<object>> UpClient(UpClient upClient)
        {
            var response = new BaseResponse<object>();
            try
            {
                var existingClient = await _context.Clients.FindAsync(upClient.ClientId);
                if (existingClient == null)
                {
                    response.Code = "404";
                    response.Status = "failed";
                    response.Message = "Client not found";
                    return response;
                }

                existingClient.Name = upClient.Name;
                existingClient.Province = upClient.Province;
                existingClient.District = upClient.District;
                existingClient.City = upClient.City;
                existingClient.PhoneNumber = upClient.PhoneNumber;
                existingClient.Email = upClient.Email;
                existingClient.status = upClient.status;
                existingClient.LastUpdated = DateTime.UtcNow;
                existingClient.PrilePicture = upClient.PrilePicture;
                existingClient.Description = upClient.Description;
                existingClient.GoogleMapLink = upClient.GoogleMapLink;

                await _context.SaveChangesAsync();

                response.Code = "200";
                response.Status = "success";
                response.Data = null ;
            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Status = "failed";
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<List<OutQryClient>>> QryKitchen(InQryClient inQryClient)
        {
            var response = new BaseResponse<List<OutQryClient>>();
            try
            {
                if (inQryClient.ClientId != null)
                {
                    var client = await _context.Clients.FindAsync(inQryClient.ClientId);
                    if (client == null)
                    {
                        response.Code = "404";
                        response.Status = "failed";
                        response.Message = "Client not found";
                        return response;
                    }
                    var outQryClient = new OutQryClient
                    {
                        ClientId = client.Id,
                        Name = client.Name,
                        Province = inQryClient.Province ?? "",
                        District = inQryClient.District ?? "",
                        City = inQryClient.City ?? "",
                        Email = client.Email,
                        status = client.status,
                        CreatedAt = client.CreatedAt,
                        LastUpdated = client.LastUpdated,
                        PrilePicture = client.PrilePicture,
                        Description = client.Description,
                        GoogleMapLink = client.GoogleMapLink
                    };
                    response.Code = "200";
                    response.Status = "success";
                    response.Data = new List<OutQryClient> { outQryClient };
                    return response;
                }

                var clients = await _context.Clients
     .Where(c => (inQryClient.Name == null || c.Name.Contains(inQryClient.Name)) &&
                 (inQryClient.PhoneNumber == null || c.PhoneNumber == inQryClient.PhoneNumber) &&
                 (inQryClient.Email == null || c.Email == inQryClient.Email) &&
                 (inQryClient.Province == null || c.Province.Contains(inQryClient.Province)) &&
                 (inQryClient.District == null || c.District.Contains(inQryClient.District)) &&
                 (inQryClient.City == null || c.City.Contains(inQryClient.City)) &&
                 (inQryClient.Status == null || c.status == inQryClient.Status))
     .Select(c => new OutQryClient
     {
         ClientId = c.Id,
         Name = c.Name,
         Province = c.Province,
         District = c.District,
         City = c.City,
         Email = c.Email,
         status = c.status,
         CreatedAt = c.CreatedAt,
         LastUpdated = c.LastUpdated,
         PrilePicture = c.PrilePicture,
         Description = c.Description,
         GoogleMapLink = c.GoogleMapLink
     })
     .ToListAsync();

                response.Code = "200";
                response.Status = "success";
                response.Data = clients;
            }
            catch (Exception ex)
            {
                response.Code = "500";
                response.Status = "failed";
                response.Message = ex.Message;
            }
            return response;
        }
    }
}