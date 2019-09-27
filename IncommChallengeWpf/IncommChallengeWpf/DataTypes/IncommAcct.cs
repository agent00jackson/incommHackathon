using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncommChallengeWpf.DataTypes
{
    
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
