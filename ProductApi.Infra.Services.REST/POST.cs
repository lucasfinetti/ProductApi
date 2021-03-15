using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;

namespace ProdutosTeste.Infra.Services.REST
{
    public static class POST
    {
        public async static Task<IRestResponse> Send(string url, dynamic body, string username, string password)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            client.Authenticator = new HttpBasicAuthenticator(username, password);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);
            return await client.ExecuteAsync(request);
        }
    }
}
