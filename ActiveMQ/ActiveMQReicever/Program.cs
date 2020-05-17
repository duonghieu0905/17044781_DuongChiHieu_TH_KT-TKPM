using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using System.Threading.Tasks;

using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace ActiveMQReicever
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory =new  ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue queue = new ActiveMQQueue("17044781_DuongChiHieu");
            IMessageConsumer consumer = session.CreateConsumer(queue);
            consumer.Listener += Consumer_Listener;
            while (true)
            {
             
            }

            
        }

        private static void Consumer_Listener(IMessage message)
        {
            if(message is ActiveMQTextMessage)
            {
                Console.WriteLine(((ActiveMQTextMessage)message).Text);
            }
           
        }
    }
}
