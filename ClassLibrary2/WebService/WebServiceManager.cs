using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.WebService
{
    public class WebServiceManager
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public WebServiceManager()
        {

        }

        public async Task<T> GetFromAPI<T>(Int32 id)
        {
            T item = default(T);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");

                HttpResponseMessage response = await client.GetAsync(typeof(T).Name.ToLower() + "/" + id + "/");

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
