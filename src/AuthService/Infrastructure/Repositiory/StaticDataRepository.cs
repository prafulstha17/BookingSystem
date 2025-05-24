
using Application.Interface.Common;
using Domain.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositiory;

public class StaticDataRepository : IStaticDataRepository
{
    private readonly AuthDbContext _context;
    public StaticDataRepository(AuthDbContext context)
    {
        _context = context;
    }
    public async Task<BaseResponse<List<StaticData>>> GetByKeyAsync(string key)
    {
        var response = new BaseResponse<List<StaticData>>();
        try
        {
           var data = await _context.StaticData.Where(x => x.Key == key && x.Sts == "Active").ToListAsync();
            if (data != null && data.Count > 0)
            {
                response.Code = "200";
                response.Status = "success";
                response.Data = data;
                return response;
            }
            else
            {
                response.Code = "404";
                response.Status = "Key Not Found";
                return response;
            }
        }
        catch (Exception ex)
        {
            response.Code = "500";
            response.Status = "failed";
            return response;
        }
    }

}
