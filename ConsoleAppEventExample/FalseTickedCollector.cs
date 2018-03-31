using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventExample
{
   public sealed class FalseTickedCollector
    {
        private readonly List<Ticket> _ticketsBad=new List<Ticket>();

        public void Subscribe(TicketProcessor ticketProcessor)  
        {
            ticketProcessor.NotvalidEventHandler += TicketProcessor_Notvalid; ;
          
        }

        private void TicketProcessor_Notvalid(object sender, TicketEventArgs e)
        {
            _ticketsBad.Add(e.Ticket);
        }


        public Ticket[] Tickets()
        {
            return _ticketsBad.ToArray();
        }
    }
}
