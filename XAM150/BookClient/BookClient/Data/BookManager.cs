using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
    public class BookManager
    {
        const string Url = "http://xam150.azurewebsites.net/api/books/";
        private string authorizationKey;

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var client = await GetClient();
            var sBooks = await client.GetStringAsync(Url);

            return JsonConvert.DeserializeObject<IEnumerable<Book>>(sBooks);
        }

        public async Task<Book> Add(string title, string author, string genre)
        {
            var book = new Book()
            {
                Title = title,
                Genre = genre,
                Authors = new List<string>() { author },
                PublishDate = DateTime.Now
            };

            var client = await GetClient();
            var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Url, content);

            return JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
        }

        public async Task Update(Book book)
        {
            var client = await GetClient();
            var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(Url + book.ISBN, content);
        }

        public async Task Delete(string isbn)
        {
            var client = await GetClient();
            var response = await client.DeleteAsync(Url + isbn);
        }

        private async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url + "login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }
    }
}

