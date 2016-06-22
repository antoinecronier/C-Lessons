using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App2.Models;

namespace App2.WebManager
{
    public class PokeAPI
    {
        public async Task GetFromAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("pokemon/2/");

                    if (response.IsSuccessStatusCode)
                    {
                        String stream = await response.Content.ReadAsStringAsync();
                        var item = JsonConvert.DeserializeObject<Pokemon>(stream);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        public async Task<T> GetFromAPI<T>(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync(typeof(T).Name.ToLower() + "/" + id + "/");

                    if (response.IsSuccessStatusCode)
                    {
                        String stream = await response.Content.ReadAsStringAsync();
                        var item = JsonConvert.DeserializeObject<T>(stream);
                        return item;
                    }
                }
                catch (Exception e)
                {
                    return default(T);
                }
            }
            return default(T);
        }
    }
}
