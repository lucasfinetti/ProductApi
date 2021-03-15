using ProductApi.Domain.Services.Interfaces;
using ProductApi.Domain.Services.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace ProductApi.Domain.Services.Services
{
    public class RestService : IRestService
    {
        public async Task<IRestResponse> POST(RestModel model)
        {
            var client = new RestClient(model.URL);
            var request = new RestRequest(Method.POST);
            client.Authenticator = new HttpBasicAuthenticator(model.Username, model.Password);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(model.Body);
            return await client.ExecuteAsync(request);
        }
    }
}
