using System;

namespace ConsoleAppEventExample
{
    public class TicketEventArgs : EventArgs
    {
        public Ticket Ticket { get; set; }

        public TicketEventArgs(Ticket ticket)
        {
            this.Ticket = ticket;
        }
    }
}