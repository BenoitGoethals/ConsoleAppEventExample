using System;

namespace ConsoleAppEventExample
{
    public class Ticket
    {
        public Ticket(DateTime dateTime, bool valid, TypeOfTicket ticketType)
        {
            DateTime = dateTime;
            Valid = valid;
            TicketType = ticketType;
        }

        protected bool Equals(Ticket other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ticket) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Ticket left, Ticket right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Ticket left, Ticket right)
        {
            return !Equals(left, right);
        }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(DateTime)}: {DateTime}, {nameof(Valid)}: {Valid}, {nameof(TicketType)}: {TicketType}";
        }

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Boolean Valid { get; set; }
        public TypeOfTicket TicketType { get; set; }
    }
}