using System.Collections.Generic;
using System.Linq;

namespace PetOwnerApplication.Domain.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Animal> Pets { get; set; }
 
        
    }
}