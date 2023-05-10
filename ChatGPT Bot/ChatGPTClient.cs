using System;
using RestSharp;
using Newtonsoft.Json;

namespace ChatGPT_Bot
{
    public class ChatGPTClient
    {
        private readonly string _apiKey;
        private readonly RestClient _client;

        // Constructor que toma la clave API como parámetro
        public ChatGPTClient(string apiKey)
        {
            _apiKey = apiKey;
            // Inicializar el RestClient con el extremo de la API de ChatGPT
            _client = new RestClient("https://api.openai.com/v1/engines/text-davinci-003/completions");
        }

        // Agregaremos métodos aquí para interactuar con la API.

        // Método para enviar un mensaje a la API de ChatGPT y devolver la respuesta
        public string SendMessage(string message)
        {
            // Crear una nueva solicitud POST
            var request = new RestRequest("", Method.Post);
            // Establecer el encabezado de tipo de contenido (Content-Type)
            request.AddHeader("Content-Type", "application/json");
            // Establecer el encabezado de autorización con la clave API
            request.AddHeader("Authorization", $"Bearer {_apiKey}");

            // Crea el cuerpo de la solicitud con el mensaje y otros parámetros
            var requestBody = new
            {
                prompt = message,
                max_tokens = 100,
                n = 1,
                stop = (string?)null,
                temperature = 0.7,
            };

            // Agrega el cuerpo JSON a la solicitud
            request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

            // Ejecutar la solicitud y recibir la respuesta
            var response = _client.Execute(request);

            // Deserializar el contenido JSON de la respuesta
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content ?? string.Empty);

            // Extrae y devuelve el texto de respuesta del chatbot
            return jsonResponse?.choices[0]?.text?.ToString()?.Trim() ?? string.Empty;
        }
    }
}
