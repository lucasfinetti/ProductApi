using ProductApi.Domain.Services.Models;
using RestSharp;
using System.Threading.Tasks;

namespace ProductApi.Domain.Services.Interfaces
{
    public interface IRestService
    {
        Task<IRestResponse> POST(RestModel model);
    }
}
