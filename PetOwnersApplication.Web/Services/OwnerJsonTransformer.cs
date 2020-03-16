using System.Collections.Generic;
using Newtonsoft.Json;
using PetOwnerApplication.Domain.Models;

namespace PetOwnerApplication.Web.Services
{
    public class OwnerJsonTransformer : JsonTransformer
    {
        public List<Owner> ConvertFromJson(string json)
        {
            var owners = JsonConvert.DeserializeObject<List<Owner>>(json);

            return owners;
        }
    }
}