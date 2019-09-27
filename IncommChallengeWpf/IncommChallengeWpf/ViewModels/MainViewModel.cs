using IncommChallengeWpf.DataTypes;
using IncommChallengeWpf.Models;
using IncommChallengeWpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Input;

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
                OnNewPushpin(EventArgs.Empty);
            }
        }

        public List<Pushpin> Pushpins
        {
            get
            {
                return new List<Pushpin>();
            }
        }

        private Location _ourLocation;
        public Location OurPosition
        {
            get => _ourLocation;
            set => _ourLocation = value;
        }
        public MainViewModel()
        {
            model.AccountsRefreshed += new EventHandler(AccountsRefreshed);
            model.Watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(PositionChanged);
        }

        void AccountsRefreshed(object sender, EventArgs e)
        {
            OnPropertyChanged("Accounts");
            
        }
        
        void PositionChanged(object sender, EventArgs e)
        {
            double lat = model.Watcher.Position.Location.Latitude;
            double longi = model.Watcher.Position.Location.Longitude;
            _ourLocation = new Location(lat, longi);
            OnPropertyChanged("OurPosition");
        }

        public event EventHandler NewPushpin;
        protected virtual void OnNewPushpin(EventArgs e)
        {
            EventHandler handler = NewPushpin;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public ICommand RefreshAccounts
        {
            get => new DelegateCommand(this.model.RefreshAccounts);
        }

        public ICommand RefreshTransactions
        {
            get => new DelegateCommand(SelectedAccount.RefreshTransactions);
        }

        public ICommand NewAccount {get => new DelegateCommand(() =>
        {
            var dialog = new NewAccountDialog();
            if(dialog.ShowDialog() == true)
            {
                this.model.RefreshAccounts();
            }
        });}
    }
}
