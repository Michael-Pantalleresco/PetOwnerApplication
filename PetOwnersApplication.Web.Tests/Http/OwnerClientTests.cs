using System;
using FluentAssertions;
using PetOwnerApplicationlication.Http;
using Xunit;

namespace PetOwnersApplication.Web.Tests.Http
{
    public class OwnerClientTests
    {
        private readonly IOwnerClient _ownerClient;

        public OwnerClientTests()
        {
            _ownerClient = new OwnerClient();
        }

        [Fact]
        public void Given_OwnerClient_HitsEndpoint_Returns_OK_and_Json()
        {
            var result = _ownerClient.GetOwnerDetails("http://agl-developer-test.azurewebsites.net/people.json");
            var expected = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
            result.StatusCode.Should().Be(200);
            result.Content.Should().Be(expected);
        }

        [Fact]
        public void Given_OwnerClient_CantHitEndpoint_Returns_NotFound()
        {
            var result = _ownerClient.GetOwnerDetails("http://agl-developer-test.azurewebsites.net/people.jsons");
            result.StatusCode.Should().Be(404);
        }
    }
}