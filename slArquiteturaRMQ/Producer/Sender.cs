using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                var message = "Getting Started with .net core and RadbbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent a Message {0}", message);
            }

            Console.ReadKey();

        }
    }
}
