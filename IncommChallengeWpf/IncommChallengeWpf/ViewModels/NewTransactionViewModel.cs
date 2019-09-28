using IncommChallengeWpf.DataTypes;
using IncommChallengeWpf.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IncommChallengeWpf.ViewModels
{
    public class NewTransactionViewModel : ObservableObject
    {
        private RobustAccount account;
        public NewTransactionViewModel(RobustAccount account)
        {
            this.account = account;
        }
        public string Amount
        {
            get; set;
        }
        public string CounterParty
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }


        public bool Result
        {
            get; set;
        }

        public ICommand Confirm
        {
            get => new DelegateCommand(() =>
            {
                var api = IncommApi.Instance;
                int bal = (int)(double.Parse(Amount) * 100);
                api.NewTransaction(account.Id, bal, Description, CounterParty);
                Result = true;
            });
        }
    }
}
