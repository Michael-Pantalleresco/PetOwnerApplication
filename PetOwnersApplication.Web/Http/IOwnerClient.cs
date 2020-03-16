using RestSharp;

namespace PetOwnerApplicationlication.Http
{
    public interface IOwnerClient
    {
        IRestResponse GetOwnerDetails(string url);
    }
}