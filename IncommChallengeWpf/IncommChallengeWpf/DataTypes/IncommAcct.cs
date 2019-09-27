﻿using System;
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
    }
    
    public class IncommAcct
    {
        public readonly string Id;
        public readonly string Owner;
        public readonly int Balance;

        public IncommAcct(string id, string owner, int balance)
        {
            Id = id;
            Owner = owner;
            Balance = balance;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Owner.GetHashCode() + Balance;
        }

        public override bool Equals(object obj)
        {
            if(obj is IncommAcct other)
            {
                return Id == other.Id &&
                    Owner == other.Owner &&
                    Balance == other.Balance;
            }

            return false;
        }
    }
}
