﻿using IncommChallengeWpf.DataTypes;
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
using BingMapsSDSToolkit.GeocodeDataflowAPI;
using GoogleMapsApi.Entities.PlacesFind.Request;
using GoogleMapsApi.Entities.PlacesFind.Response;
using GoogleMapsApi;

namespace IncommChallengeWpf.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private readonly string BingKey = "**REMOVED**";
        private readonly string GoogleKey = "**REMOVED**";
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
                UpdatePushpins();
            }
        }

        async void UpdatePushpins()
        {
            pushpins.Clear();
            List<PlacesFindResponse> results = new List<PlacesFindResponse>();
            foreach (var t in SelectedAccount.Transactions)
            {
                var request = new PlacesFindRequest()
                {
                    ApiKey = GoogleKey,
                    Input = t.Description,
                    InputType = GoogleMapsApi.Entities.PlacesFind.Request.InputType.TextQuery,
                    Fields = "geometry"
                };

                var ans = await GoogleMaps.PlacesFind.QueryAsync(request);

                var place = ans.Candidates?.FirstOrDefault()?.Geometry?.Location;
                var pp = new Pushpin();
                pp.Location = new Location(place?.Latitude ?? 0, place?.Longitude ?? 0);
                pushpins.Add(pp);
            }

            OnNewPushpin(EventArgs.Empty);
        }

        private List<Pushpin> pushpins = new List<Pushpin>();
        public List<Pushpin> Pushpins
        {
            get
            {
                return pushpins;
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

        public ICommand NewTransaction
        {
            get => new DelegateCommand(() =>
            {
                var dialog = new NewTransaction(SelectedAccount);
                if (dialog.ShowDialog() == true)
                {
                    SelectedAccount.RefreshTransactions();
                }
            });
        }
    }
}
