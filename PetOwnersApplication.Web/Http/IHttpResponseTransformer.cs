using Microsoft.Extensions.Logging;
using RestSharp;

namespace PetOwnerApplicationlication.Http
{
    public interface IHttpResponseTransformer
    {
        string TransformToJson(IRestResponse response, ILogger logger);
    }
}