using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperShop.Prism.Models;

namespace SuperShop.Prism.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetListAsync<T>(
           string urlBase,
           string servicePrefix,
           string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJudW5vc2FsZ3VlaXJvMjNAZ21haWwuY29tIiwianRpIjoiMDI2YzBjODEtMzMyNy00ZWZjLWEwMTctYzdhMDk1ZmYyM2E3IiwiZXhwIjoxNzI4Mzk4NjAyLCJpc3MiOiJsb2NhbGhvc3QiLCJhdWQiOiJ1c2VycyJ9.B_L8fWa0veOLkUzNNHBwomZ0v-s5fokCoed1fYAsGIs"
                );

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}
