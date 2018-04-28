using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
            Producer1 p = new Producer1();
            //p.pubSingleMsg();
            p.pubMultipleMsg();
            Console.ReadLine();
        }
    }
}
