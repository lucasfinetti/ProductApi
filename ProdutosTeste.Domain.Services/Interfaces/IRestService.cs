using ProdutosTeste.Domain.Services.Models;
using RestSharp;
using System.Threading.Tasks;

namespace ProdutosTeste.Domain.Services.Interfaces
{
    public interface IRestService
    {
        Task<IRestResponse> POST(RestModel model);
    }
}
