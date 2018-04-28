using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    class Producer1
    {

        public void pubSingleMsg()
        {

            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";

            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            channel.QueueDeclare("Test_Q", false, false, false, null);

            string message = "Hi this is a message from publisher.";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("","Test_Q", null, body);

            Console.WriteLine("Published message-"+ message);

            Console.ReadLine();
            channel.Dispose();
            conn.Dispose();
        }



        public void pubMultipleMsg()
        {
            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";

            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            channel.QueueDeclare("Test_Q", false, false, false, null);                    

            for(var i=0;i<5;i++)
            {
                string message =string.Format(i+ " message from publisher.");
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "Test_Q", null, body);

                Console.WriteLine("Published message- "+ message);
            }

           
            Console.ReadLine();
            channel.Dispose();
            conn.Dispose();

        }
    }
}
