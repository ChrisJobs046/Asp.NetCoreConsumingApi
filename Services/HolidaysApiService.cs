using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Asp.NetCoreConsumingApi.Models;

namespace Asp.NetCoreConsumingApi.Services
{
    public class HolidaysApiService : IHolidaysApiService
    {

        private static readonly HttpClient client;

        static HolidaysApiService(){


            client = new HttpClient(){

                BaseAddress = new Uri("https://date.nager.at")
            };
        }
        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();

            /*
            Llamamos los datos de la url.
            A continuación, realizamos una llamada a la API mediante 
            el método GetAsync que envía una solicitud GET al Uri especificado como una operación asincrónica.
            El método devuelve el objeto System.Net.Http.HttpResponseMessage que representa un mensaje de 
            respuesta HTTP que incluye el código de estado y los datos.
            */
            var response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode){

                //A continuación, llamamos al método ReadAsStringAsync que serializa el contenido HTTP en una cadena.
                var stringResponse = await response.Content.ReadAsStringAsync();

                //Por último, estamos usando JsonSerializer para deserializar la cadena de respuesta JSON en una lista de objetos HolidayModel.
                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else{

                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}