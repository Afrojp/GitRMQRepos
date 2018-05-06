using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainRMQConsumerProg
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer c = new Consumer();
            c.comsumeMessage();
           
            Console.ReadLine();
        }
    }
}
