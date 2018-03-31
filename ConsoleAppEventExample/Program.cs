using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppEventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random=new Random();
            TicketProcessor ticketProcessor=new TicketProcessor();
            FalseTickedCollector collector = new FalseTickedCollector();
            collector.Subscribe(ticketProcessor);
            ticketProcessor.ExpireDateTime = DateTime.Now;
       

            for (int i = 1; i <= 10000; i++)
            {
                var ticket = new Ticket(DateTime.Now.AddDays(-10).AddDays(random.Next(1,20)), Convert.ToBoolean(random.Next(0,2)), (TypeOfTicket)random.Next(0, 3)){Id = i};
              //  Console.WriteLine(ticket);
                ticketProcessor.PushTicket(ticket);
               // Thread.Sleep(100);
            }

            Console.WriteLine("-------------");

            Console.WriteLine($"Ok Tickets {ticketProcessor.CountTickets()}");
            Console.WriteLine($"Type Tickets Normal {ticketProcessor.TypeTicket(TypeOfTicket.Normal).Count}");
            Console.WriteLine($"Type Tickets Economic {ticketProcessor.TypeTicket(TypeOfTicket.Economic).Count}");
            Console.WriteLine($"Type Tickets Vip {ticketProcessor.TypeTicket(TypeOfTicket.Vip).Count}");
            Console.WriteLine($"Bad Tickets {collector.Tickets().Length}");

            
            Console.ReadLine();
        }
    }
}
