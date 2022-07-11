using DocLibrary.Helper.ApiResultHelper;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DocLibrary.WebApi.Tests
{
    // TODO: TEST METHODS ...
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Startup> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task Get_By_Id_Document()
        {
            var testId = 1;
            var response = await _client.GetAsync($"/api/document/GetByDocumentId/{testId}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var apiResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult<bool>>(responseString);
            Assert.True(apiResult.Data);
            Assert.Equal(200, apiResult.HttpStatusCode);
        }
    }
}
