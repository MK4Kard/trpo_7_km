using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace trpo_7
{
    public class Http
    {
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7010/"),
        };

        public async Task<List<Medicine>> GetFromJsonMedicineAsync()
        {
            var response = await httpClient.GetFromJsonAsync<List<Medicine>>("api/v1/Medicine");

            return response;
        }

        public async Task CreateJson(Medicine medicine)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                "api/v1/Medicine",
                medicine
            );
        }
    }
}
