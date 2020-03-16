using System.Collections.Generic;
using System.Linq;
using PetOwnerApplication.Domain.Models;
using PetOwnersApp.Web.Models;

namespace PetOwnerApplication.Web.Services
{
    public class PetsService
    {
        public static PetsModel CreatePetsModel(List<Owner> owners)
        {
            var petsDic = new Dictionary<string, List<string>>();
            foreach (var gender in owners.GroupBy(s => s.Gender).ToList())
            {
                var pets = new List<string>();
                foreach (var owner in owners.Where(s => s.Gender == gender.Key && s.Pets != null).ToList())
                {
                    foreach (var pet in owner.Pets)
                    {
                        if(!pets.Contains(pet.Name) && pet.Type.ToLower() == "cat")
                            pets.Add(pet.Name);
                    }
                }
                pets.Sort();
                petsDic.Add(gender.Key, pets);
            }
            return new PetsModel { pets = petsDic};
        }
    }
}