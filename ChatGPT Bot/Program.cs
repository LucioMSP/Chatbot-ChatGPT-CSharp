using System;

namespace ChatGPT_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Añada su clave API de ChatGPT
            string apiKey = "tu CLAVE aquí";
            // Crea una instancia de ChatGPTClient con la clave API
            var chatGPTClient = new ChatGPTClient(apiKey);

            // Muestra un mensaje de bienvenida
            Console.WriteLine("Hola amigX, bienvenidX al chatbot de ChatGPT. Si quieres escapar, solo escribe 'salir'...");

            // Ingrese un ciclo para tomar la entrada del usuario y mostrar las respuestas del chatbot
            while (true)
            {
                // Solicitar al usuario la entrada
                Console.ForegroundColor = ConsoleColor.Green; // Establecer el color del texto en verde
                Console.Write("Tú: ");
                Console.ResetColor(); // Restablece el color del texto a su valor predeterminado
                string input = Console.ReadLine() ?? string.Empty;

                // Salir del bucle si el usuario escribe "salir"
                if (input.ToLower() == "salir")
                    break;

                // Envia la entrada del usuario a la API de ChatGPT y recibe una respuesta
                string response = chatGPTClient.SendMessage(input);

                // Se muestra la respuesta del chatbot
                Console.ForegroundColor = ConsoleColor.Blue; // Establecer el color del texto en azul
                Console.Write("Chatbot: ");
                Console.ResetColor(); // Restablece el color del texto a su valor predeterminado
                Console.WriteLine(response);
            }
        }
    }
}