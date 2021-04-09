using Microsoft.AspNetCore.Mvc.Testing;
using SimplePasswordCheck.Core.Password.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SimplePasswordCheck.Tests.e2e.Controllers
{
    public class PasswordController_Tests : IClassFixture<WebApplicationFactory<SimplePasswordCheck.Startup>>
    {
        private readonly WebApplicationFactory<SimplePasswordCheck.Startup> _clientFactory;
        private readonly string passwordRoute = "/api/password/validate";
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public PasswordController_Tests(WebApplicationFactory<SimplePasswordCheck.Startup> clientFactory)
        {
            _clientFactory = clientFactory;

            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        [InlineData("AbTp9!feka")]
        [InlineData("AbTp9!fek123")]
        [InlineData("AbTp9!fek123()")]
        [InlineData("AbTp9!fek123)")]
        public async Task PostValidPasswordReturnValidResult(string password)
        {
            var client = _clientFactory.CreateClient();
            PasswordValidationRequest requestPayload = new PasswordValidationRequest
            {
                Password = password
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(passwordRoute, content);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var responsePayload = JsonSerializer.Deserialize<PasswordValidationResponse>(responseString, jsonSerializerOptions);

            Assert.True(responsePayload.Valid);
        }


        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public async Task PostInvalidPasswordReturnInvalidResult(string password)
        {
            var client = _clientFactory.CreateClient();
            PasswordValidationRequest requestPayload = new PasswordValidationRequest
            {
                Password = password
            };

            StringContent content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(passwordRoute, content);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            var responsePayload = JsonSerializer.Deserialize<PasswordValidationResponse>(responseString, jsonSerializerOptions);

            Assert.False(responsePayload.Valid);
        }
    }
}
