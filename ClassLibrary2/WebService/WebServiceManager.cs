using ClassLibrary2.Database;
using ClassLibrary2.EnumManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.WebService
{
    public class WebServiceManager<T> where T : class
    {
        public String DataConnectionResource { get; set; }

        public WebServiceManager(DataConnectionResource resource)
        {
            DataConnectionResource = EnumString.GetStringValue(resource);
        }

        public async Task<T> Get(Int32 id)
        {
            T item = default(T);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(DataConnectionResource);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(typeof(T).Name + "/" + id + "/");

                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return item;
        }

        public async Task<T> GetAll()
        {
            T item = default(T);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(DataConnectionResource);

                HttpResponseMessage response = await client.GetAsync(typeof(T).Name + "/");

                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return item;
        }

        /*public async Task<Boolean> PostToAPI<T>(T item)
        {
            Boolean isOK = false;

            using (HttpClient client = 
                new HttpClient())
            {
                HttpRequestMessage message = 
                    new HttpRequestMessage(
                        HttpMethod.Post, 
                        new Uri("http://pokeapi.co/api/v2/"));

                var test = JsonConvert.SerializeObject(item);

                message.Content = 
                    new HttpStringContent(
                        test);

                message.Content.Headers.ContentType =
                    new HttpMediaTypeHeaderValue("application/json");

                HttpResponseMessage response =
                    await client.SendRequestAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    isOK = true;
                }
            }

            return isOK;
        }*/
    }
}
