using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncommChallengeWpf.DataTypes
{
    public class IncommTransactions
    {
        public readonly string Id;
        public readonly string CounterParty;
        public readonly string Type;
        public readonly string Status;
        public readonly string Description;
        public readonly int Amount;
        public readonly string Date;

        public IncommTransactions(string id, string counterParty, string type, string status, string description, int amount, string date)
        {
            Id = id;
            CounterParty = counterParty;
            Type = type;
            Status = status;
            Description = description;
            Amount = amount;
            Date = date;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + CounterParty.GetHashCode() + Type.GetHashCode() + Status.GetHashCode() + Amount + Date.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is IncommTransactions other)
            {
                return Id == other.Id &&
                    CounterParty == other.CounterParty &&
                    Type == other.Type && Status == other.Status && Description == other.Description &&
                    Amount == other.Amount && Date == other.Date;
            }

            return false;
        }
    }

}
