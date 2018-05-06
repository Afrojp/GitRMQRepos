using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainRMQConsumerProg
{
    class Consumer
    {
        public void comsumeMessage()
        {
            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";

            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            //channel.QueueDeclare(queue:"Test-Q",durable:false,exclusive:false,autoDelete:false,arguments:null);
            channel.QueueDeclare("Test_Q", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
             {
                 var body = ea.Body;
                 var message = Encoding.UTF8.GetString(body);
                 Console.WriteLine("Consumed message -" + message);
             };

            channel.BasicConsume("Test_Q", true, consumer);
            //channel.BasicConsume("Test_Q", true, "myconsumer", consumer);
            Console.WriteLine("Waiting for message to consume...\n");
            Console.ReadLine();
       
        }
    }
}
