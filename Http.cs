using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Net;

namespace trpo_7
{
    public class Http
    {
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7010/"),
        };

        public async Task<List<Medicine>> GetFromJsonMedicineAsync(string manufacturer, bool available)
        {
            var response = await httpClient.GetFromJsonAsync<List<Medicine>>($"api/v1/Medicine?manufacturer={manufacturer}&available={available}");

            return response;
        }

        public async Task<Medicine> GetJson(int id)
        {
            var response = await httpClient.GetFromJsonAsync<Medicine>($"api/v1/Medicine/{id}");

            return response;
        }

        public async Task CreateJson(Medicine medicine)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                "api/v1/Medicine",
                medicine
            );
        }

        public async Task PutJson(Medicine medicine, int id)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(
                $"api/v1/Medicine/{id}",
                medicine
            );
        }

        public async Task PatchJson(MedicineDto medicine, int id)
        {
            HttpResponseMessage response = await httpClient.PatchAsJsonAsync(
                $"api/v1/Medicine/{id}",
                medicine
            );
        }

        public async Task DeleteJson(int id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(
                $"api/v1/Medicine/{id}"
            );

            //response.EnsureSuccessStatusCode();

            //var json = await response.Content.ReadAsStringAsync();
            //throw new Exception(json);
        }
    }
}
