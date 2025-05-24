using Application.Modules.Clients;
using Domain.Common;

namespace Application.Interface.Client
{
    public interface IClientRepo 
    {
        public Task<BaseResponse<object>> InClient(InClient client);
        public Task<BaseResponse<object>> UpClient(UpClient upClient);
        public Task<BaseResponse<List<OutQryClient>>> QryKitchen(InQryClient inQryClient);
    }
}
