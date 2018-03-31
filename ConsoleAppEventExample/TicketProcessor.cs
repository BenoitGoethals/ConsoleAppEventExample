using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppEventExample
{
    public class TicketProcessor
    {
        public List<Ticket> Tickets=new List<Ticket>();

        public event  EventHandler<TicketEventArgs>  NotvalidEventHandler;

        public DateTime ExpireDateTime { get; set; }
        public void PushTicket(Ticket ticket)
        {
            ProcesTicket(ticket);
        }



        private void ProcesTicket(Ticket ticket)
        {
            if (ticket.DateTime.CompareTo(ExpireDateTime)==-1 || ticket.Valid==false)
            {
                NotvalidEventHandler?.Invoke(this, new TicketEventArgs(ticket));
            }
            else
            {
                Tickets.Add(ticket);
              
            }

        }
        
        public List<Ticket> TypeTicket(TypeOfTicket typeOfTicket)
        {
            return Tickets.Where(x => x.TicketType == typeOfTicket).ToList();
        }

        public int CountTickets()
        {
            return Tickets.Count;
        }


        public override string ToString()
        {
            return $"{nameof(Tickets)}: {Tickets}, {nameof(ExpireDateTime)}: {ExpireDateTime}";
        }
    }

}