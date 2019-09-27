using IncommChallengeWpf.DataTypes;
using IncommChallengeWpf.REST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncommChallengeWpf.Models
{
    public class MainModel
    {
        public List<RobustAccount> Accounts = new List<RobustAccount>();
        private IncommApi incomm = new IncommApi();

        public MainModel()
        {
            RefreshAccounts();
        }

        public event EventHandler AccountsRefreshed;
        protected virtual void OnAccountsRefreshed(EventArgs e)
        {
            EventHandler handler = AccountsRefreshed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void RefreshAccounts()
        {
            incomm.GetAccounts().ContinueWith((aTask) =>
            {
                foreach(var a in aTask.Result)
                {
                    Accounts.Add(new RobustAccount());
                    Accounts.Add(new RobustAccount());
                    Accounts.Add(new RobustAccount());
                    OnAccountsRefreshed(EventArgs.Empty);
                }
            });
        }
    }
}
