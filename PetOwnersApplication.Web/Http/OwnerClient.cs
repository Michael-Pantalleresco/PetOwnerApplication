using Microsoft.Extensions.Configuration;
using RestSharp;

namespace PetOwnerApplicationlication.Http
{
    public class OwnerClient : IOwnerClient
    {
        private IConfiguration _configuration;
        
        public IRestResponse GetOwnerDetails(string url)
        {
            var client = new RestClient(url);

            var request =  new RestRequest();
            var response = client.Get(request);

            return response;
        }
    }
}