﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            //channel.QueueDeclare(queue:"Test-Q",durable:false,exclusive:false,autoDelete:false,arguments:null);//another and good way to declare queue
            channel.QueueDeclare("Test_Q", false, false, false, null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
             {
                 var body = ea.Body;
                 var message = Encoding.UTF8.GetString(body);
                 Thread.Sleep(1000);
                 Console.WriteLine("Consumed message -" + message);

                 channel.BasicAck(deliveryTag: ea.DeliveryTag,multiple:true);//This is manual ack, will not lost all messages if consumer dies. Set autoACK: false when using manual ack

             };

            //channel.BasicConsume("Test_Q", true, consumer);// autoACK:true - will lost all message if consumer dies before work done
            channel.BasicConsume("Test_Q", false, "myconsumer", consumer);// autoACK:False - messages reside on Queue

            Console.WriteLine("Waiting for message to consume..\n");
            Console.ReadLine();
       
        }
    }
}
