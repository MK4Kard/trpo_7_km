using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task GetMedicinesAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("api/medicine");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

            }
            else
            {
                
            }
        }
    }
}
