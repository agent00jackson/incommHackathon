using IncommChallengeWpf.DataTypes;
using IncommChallengeWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncommChallengeWpf.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public readonly MainModel model = new MainModel();
        public ObservableCollection<RobustAccount> Accounts
        {
            get
            {
                return new ObservableCollection<RobustAccount>(model.Accounts);
            }
        }

        private RobustAccount _selectedAccount;
        public RobustAccount SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        public MainViewModel()
        {
            model.AccountsRefreshed += new EventHandler(AccountsRefreshed);
        }

        void AccountsRefreshed(object sender, EventArgs e)
        {
            OnPropertyChanged("Accounts");
        }
    }
}
