using Domain.Common;


namespace Application.Interface.Common
{
    public interface IStaticDataRepository
    {
        Task<BaseResponse<List<StaticData>>> GetByKeyAsync(string key);

    }
}
