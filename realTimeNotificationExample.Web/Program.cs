using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace realTimeNotificationExample.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            #region Connection
            //Console.WriteLine("Press a key to start listening..");
            //        Console.ReadKey();
            //        var connection = new HubConnectionBuilder()
            //            .ConfigureLogging(configure => configure.AddConsole())
            //            .WithUrl("https://localhost:44362/notificationhub")
            //            .AddMessagePackProtocol()
            //            .Build();

            //connection.On<string>("BroadcastTextMessage", (message) =>
            //            Console.WriteLine($"{message}"));

            //        connection.StartAsync().GetAwaiter().GetResult();

            //Console.WriteLine("Listening. Press a key to quit");
            //        Console.ReadKey(); 
            #endregion
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
