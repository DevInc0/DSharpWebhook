using DSharpWebhook.Discord.Message;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DSharpWebhook.Discord.Webhook
{
    public sealed class DiscordWebhook
    {
        public readonly Uri Uri;

        private readonly JsonSerializer _serializer;

        private readonly string _jsonFilePath;

        public static readonly MediaTypeHeaderValue JsonMediaType = MediaTypeHeaderValue.Parse("application/json");

        public DiscordWebhook(string uriString)
        {
            var number = uriString.Split('/')[5];
            var directory = Path.Combine(Directory.GetCurrentDirectory(), $"webhook_{number}");
            Directory.CreateDirectory(directory);

            Uri = new Uri(uriString);
            _serializer = new JsonSerializer();
            _jsonFilePath = Path.Combine(directory, $"{number}.json");

            FileStream fileSteam = File.Create(_jsonFilePath);

            fileSteam.Dispose();
        }

        public async Task SendMessageAsync(DiscordMessage message)
        {
            using (var streamWriter = new StreamWriter(_jsonFilePath))
            {
                using (var jsonWriter = new JsonTextWriter(streamWriter))
                {
                    _serializer.Serialize(jsonWriter, message);
                }
            }

            var jsonContent = new StringContent(File.ReadAllText(_jsonFilePath));
            jsonContent.Headers.ContentType = JsonMediaType;

            var httpContent = new MultipartFormDataContent($"------------------------{DateTime.Now.Ticks:x}")
            {
                { jsonContent, "payload_json" }
            };

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responce = await httpClient.PostAsync(Uri, httpContent);

                if (responce.IsSuccessStatusCode == false)
                {
                    throw new Exception(await responce.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
