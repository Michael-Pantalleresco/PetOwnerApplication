using System.Collections.Generic;
using FluentAssertions;
using PetOwnerApplication.Domain.Models;
using Xunit;

namespace PetOwnerApplication.Web.Services.Tests
{
    public class OwnerJsonTransformerTests
    {
        private JsonTransformer _jsonTransformer;
        

        public OwnerJsonTransformerTests()
        {
            _jsonTransformer = new OwnerJsonTransformer();
        }

        [Fact]
        public void Given_JsonString_ConvertFromJson_Return_ListOfOwners()
        {
            var json = "[{\"name\": \"Bob\",\"gender\": \"Male\",\"age\": 23,\"pets\": [{\"name\": \"Garfield\",\"type\": \"Cat\"},{\"name\": \"Fido\",\"type\": \"Dog\"}]},{\"name\": \"Jennifer\",\"gender\": \"Female\",\"age\": 18,\"pets\": [{\"name\": \"Garfield\",\"type\": \"Cat\"}]}]";

            var result = _jsonTransformer.ConvertFromJson(json);
            var expectedResult = CreateOwners();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Given_EmptyListJsonString_ConvertFromJson_Returns_EmptyListOfOwners()
        {
            var json = "[]";
            var result = _jsonTransformer.ConvertFromJson(json);
            result.Should().BeEmpty();
        }
        
        [Fact]
        public void Given_EmptyJsonString_ConvertFromJson_Returns_Null()
        {
            var json = "";
            var result = _jsonTransformer.ConvertFromJson(json);
            result.Should().BeNull();
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
                }
            };
        }
    }
}
