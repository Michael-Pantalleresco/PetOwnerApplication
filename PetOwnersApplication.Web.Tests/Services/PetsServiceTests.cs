using System.Collections.Generic;
using FluentAssertions;
using PetOwnerApplication.Domain.Models;
using PetOwnersApp.Web.Models;
using Xunit;

namespace PetOwnerApplication.Web.Services.Tests
{
    public class PetsServiceTests
    {
        [Fact]
        public void Given_ListOfOwners_CreatePetsModel_Returns_PetsModel()
        {
            var result = PetsService.CreatePetsModel(CreateOwners());
            result.Should().BeEquivalentTo(CreatePetsModel());
        }

        [Fact]
        public void Given_ListOfOwnersWithNoPets_CreatePetsModel_Returns_ModelWithGenders()
        {
            var result = PetsService.CreatePetsModel(CreateOwnersWithNoPets());
            result.Should().BeEquivalentTo(CreateEmptyPetsModelWithGenders());
        }
        
        [Fact]
        public void Given_EmptyListOfOwners_CreatePetsModel_Returns_EmptyModel()
        {
            var result = PetsService.CreatePetsModel(new List<Owner>());
            result.Should().BeEquivalentTo(CreateEmptyPetsModel());
        }
        
        [Fact]
        public void Given_ListOfOwnersWithOnlyDogs_CreatePetsModel_Returns_ModelWithGenders()
        {
            var result = PetsService.CreatePetsModel(CreateDogOwners());
            result.Should().BeEquivalentTo(CreateEmptyPetsModelWithGenders());
        }
        
        private PetsModel CreatePetsModel()
        {
            return new PetsModel
            {
                pets = new Dictionary<string, List<string>>
                {
                    {
                        "Male", new List<string> { "Garfield" }
                    },
                    {
                        "Female", new List<string>{ "Garfield" }
                    }
                    
                }
            };
        }
        
        private PetsModel CreateEmptyPetsModelWithGenders()
        {
            return new PetsModel
            {
                pets = new Dictionary<string, List<string>>
                {
                    {
                        "Male", new List<string>()
                    },
                    {
                        "Female", new List<string>()
                    }
                    
                }
            };
        }
        
        private PetsModel CreateEmptyPetsModel()
        {
            return new PetsModel
            {
                pets = new Dictionary<string, List<string>>()
            };
        }
        
        private List<Owner> CreateOwners()
        {
            return new List<Owner>
            {
                new Owner
                {
                    Name = "Jennifer",
                    Gender = "Female",
                    Age = 18,
                    Pets = new List<Animal>
                    {
                        new Animal
                        {
                            Name = "Garfield",
                            Type = "Cat"
                        }
                    }
                },
                new Owner
                {
                    Name = "Bob",
                    Gender = "Male",
                    Age = 23,
                    Pets = new List<Animal>
                    {
                        new Animal
                        {
                            Name = "Garfield",
                            Type = "Cat"
                        },
                        new Animal
                        {
                            Name = "Fido",
                            Type = "Dog"
                        }
                    }
                },
                new Owner
                {
                    Name = "Michael",
                    Gender = "Male",
                    Age = 67,
                    Pets = new List<Animal>
                    {
                        new Animal
                        {
                            Name = "Fido",
                            Type = "Dog"
                        }
                    }
                }
            };
        }
        private List<Owner> CreateDogOwners()
        {
            return new List<Owner>
            {
                new Owner
                {
                    Name = "Jennifer",
                    Gender = "Female",
                    Age = 18,
                    Pets = new List<Animal>
                    {
                        new Animal
                        {
                            Name = "Garfield",
                            Type = "Dog"
                        }
                    }
                },
                new Owner
                {
                    Name = "Bob",
                    Gender = "Male",
                    Age = 23,
                    Pets = new List<Animal>
                    {
                        new Animal
                        {
                            Name = "Garfield",
                            Type = "Dog"
                        },
                        new Animal
                        {
                            Name = "Fido",
                            Type = "Dog"
                        }
                    }
                }
            };
        }
        private List<Owner> CreateOwnersWithNoPets()
        {
            return new List<Owner>
            {
                new Owner
                {
                    Name = "Jennifer",
                    Gender = "Female",
                    Age = 18,
                    Pets = null
                },
                new Owner
                {
                    Name = "Bob",
                    Gender = "Male",
                    Age = 23,
                    Pets = null
                }
            };
        }
    }
}
