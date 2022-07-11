using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DocLibrary.Helper.HttpHandlerHelper
{
    public class HttpHandler : IHttpHandler
    {
        private readonly HttpClient _httpClient;

        public HttpHandler(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient), "Can not be null!");
        }

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Service Error - Code {response.StatusCode}");

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> PostAsync<T>(string url, object obj)
        {
            try
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, httpContent);
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Service Error - Code {response.StatusCode}");

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        Task<T> IHttpHandler.GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        Task<T> IHttpHandler.PostAsync<T>(string url, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
