using System.Collections.Generic;
using PetOwnerApplication.Domain.Models;

namespace PetOwnerApplication.Web.Services
{
    public interface JsonTransformer
    {
        List<Owner> ConvertFromJson(string json);
    }
}