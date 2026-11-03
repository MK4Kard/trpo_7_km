using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Net;
using System.Text.Json;

namespace trpo_7
{
    public class Http
    {
        private static HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7010/"),
        };

        //public async Task<List<Medicine>> GetFromJsonMedicineAsync(string manufacturer, bool available)
        //{
        //    var response = await httpClient.GetFromJsonAsync<List<Medicine>>($"api/v1/Medicine?manufacturer={manufacturer}&available={available}");

        //    return response;
        //}

        public async Task<(List<Medicine>? data, string mess)> GetFromJsonMedicineAsync(string manufacturer, bool available)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"api/v1/Medicine?manufacturer={manufacturer}&available={available}");

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return (await response.Content.ReadFromJsonAsync<List<Medicine>>(), "Медикаменты найдены");
                    case HttpStatusCode.NoContent:
                        return (null, "Список пустой");
                    case HttpStatusCode.InternalServerError:
                        return (null, "Ошибка сервера");
                    default:
                        return (null, $"Код: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                return (null, $"Ошибка HTTP: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                return (null, "Запрос отменён или превышено время ожидания");
            }
            catch (JsonException)
            {
                return (null, "Ошибка обработки JSON");
            }
        }

        public async Task<(Medicine? medicine, string mess)> GetJson(int id)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"api/v1/Medicine/{id}");

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return (await response.Content.ReadFromJsonAsync<Medicine>(), $"Медикамент {id} найден");
                    case HttpStatusCode.NotFound:
                        return (null, "Медикамент не найден");
                    case HttpStatusCode.BadRequest:
                        return (null, "Неверные данные");
                    case HttpStatusCode.InternalServerError:
                        return (null, "Ошибка сервера");
                    default:
                        return (null, $"Код: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                return (null, $"Ошибка HTTP: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                return (null, "Запрос отменён или превышено время ожидания");
            }
            catch (JsonException)
            {
                return (null, "Ошибка обработки JSON");
            }
        }

        public async Task<string> CreateJson(Medicine medicine)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                    "api/v1/Medicine",
                    medicine
                );

                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        return "Медикамент создан";
                    case HttpStatusCode.BadRequest:
                        return "Неверные данные";
                    case HttpStatusCode.InternalServerError:
                        return "Ошибка сервера";
                    default:
                        return $"Код: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Ошибка HTTP: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                return "Запрос отменён или превышено время ожидания";
            }
            catch (JsonException)
            {
                return "Ошибка обработки JSON";
            }
        }

        public async Task<string> PutJson(Medicine medicine, int id)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.PutAsJsonAsync(
                    $"api/v1/Medicine/{id}",
                    medicine
                );

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        return "Медикамент изменен";
                    case HttpStatusCode.NotFound:
                        return "Медикамент не найден";
                    case HttpStatusCode.BadRequest:
                        return "Неверные данные";
                    case HttpStatusCode.InternalServerError:
                        return "Ошибка сервера";
                    default:
                        return $"Код: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Ошибка HTTP: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                return "Запрос отменён или превышено время ожидания";
            }
            catch (JsonException)
            {
                return "Ошибка обработки JSON";
            }
        }

        public async Task<string> PatchJson(MedicineDto medicine, int id)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.PatchAsJsonAsync(
                    $"api/v1/Medicine/{id}",
                    medicine
                );

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        return "Медикамент изменен";
                    case HttpStatusCode.NotFound:
                        return "Медикамент не найден";
                    case HttpStatusCode.BadRequest:
                        return "Неверные данные";
                    case HttpStatusCode.InternalServerError:
                        return "Ошибка сервера";
                    default:
                        return $"Код: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Ошибка HTTP: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                return "Запрос отменён или превышено время ожидания";
            }
            catch (JsonException)
            {
                return "Ошибка обработки JSON";
            }
        }

        public async Task<string> DeleteJson(int id)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync(
                    $"api/v1/Medicine/{id}"
                );

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        return "Медикамент удален";
                    case HttpStatusCode.NotFound:
                        return "Медикамент не найден";
                    case HttpStatusCode.BadRequest:
                        return "Неверные данные";
                    case HttpStatusCode.InternalServerError:
                        return "Ошибка сервера";
                    default:
                        return $"Код: {response.StatusCode}";
                }
            }
            catch (HttpRequestException ex)
            {
                return $"Ошибка HTTP: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                return "Запрос отменён или превышено время ожидания";
            }
            catch (JsonException)
            {
                return "Ошибка обработки JSON";
            }
        }
    }
}
