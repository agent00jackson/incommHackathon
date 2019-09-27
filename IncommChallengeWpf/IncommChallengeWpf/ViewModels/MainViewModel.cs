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
