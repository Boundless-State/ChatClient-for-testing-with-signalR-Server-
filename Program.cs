using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Användarnamn: ");
            var user = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(user)) user = "Anon";

            var baseUrl = "https://localhost:7298";
            var connection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}/chat")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string, string, DateTime>("ReceiveMessage", (u, m, ts) =>
            {
                Console.WriteLine($"[{ts:HH:mm}] {u}: {m}");
            });

            try
            {
                await connection.StartAsync();
                Console.WriteLine("Ansluten till servern.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde inte ansluta: " + ex.Message);
                return;
            }

            Console.WriteLine("Skriv meddelanden (tom rad för att avsluta).");
            while (true)
            {
                var msg = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(msg)) break;
                await connection.InvokeAsync("SendMessage", user, msg);
            }

            await connection.StopAsync();
        }
    }
}

