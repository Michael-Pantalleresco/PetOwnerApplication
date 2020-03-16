using Microsoft.Extensions.Logging;
using RestSharp;

namespace PetOwnerApplicationlication.Http
{
    public class HttpResponseTransformer : IHttpResponseTransformer
    {
        public string TransformToJson(IRestResponse response, ILogger logger)
        {
            string json;
            if (response.IsSuccessful)
            {
                json = response.Content;
            }
            else
            {
                logger.LogError($"The response was unsuccessful with a status code of {response.StatusCode} and messge {response.ErrorMessage}");
                json = "[]";
            }
            return json;
        }
    }
}