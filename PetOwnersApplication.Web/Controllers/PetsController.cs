using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetOwnerApplication.Web.Services;
using PetOwnerApplicationlication.Http;
using PetOwnersApp.Web.Models;

namespace PetOwnerApplicationlication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ILogger<PetsController> _logger;
        private IConfiguration _configuration;
        private IOwnerClient _ownerClient;
        private string url;
        private JsonTransformer _jsonTransformer;
        private IHttpResponseTransformer _httpResponseTransformer;

        public PetsController(ILogger<PetsController> logger, 
            IConfiguration configuration,
            IOwnerClient ownerClient,
            JsonTransformer jsonTransformer,
            IHttpResponseTransformer httpResponseTransformer
            )
        {
            _logger = logger;
            _configuration = configuration;
            _ownerClient = ownerClient;
            _jsonTransformer = jsonTransformer;
            _httpResponseTransformer = httpResponseTransformer;
            url = _configuration.GetSection("OwnerUrl").Value;
        }

        [HttpGet]
        public PetsModel Get()
        {
            var response = _ownerClient.GetOwnerDetails(url);
            var owners = _jsonTransformer.ConvertFromJson(_httpResponseTransformer.TransformToJson(response, _logger));
            return PetsService.CreatePetsModel(owners);
        }
    }
}
