using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Matter.Services.External.Helpers
{
    public static class ApiHelper
    {        
        public static async Task<T> GetDataFromApi<T>(HttpClient httpClient, string uri)
        {
            T returnedSchema;
            try
            {
                var options = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                options.Converters.Add(new JsonStringEnumConverter());

                returnedSchema = await httpClient.GetFromJsonAsync<T>(uri, options);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return default;

                throw;
            }

            return returnedSchema;
        }
    }
}