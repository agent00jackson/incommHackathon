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
    public class NewAccountViewModel : ObservableObject
    {
        public string Balance
        {
            get; set;
        }

        public bool Result
        {
            get;set;
        }

        public ICommand ConfirmAccount { get => new DelegateCommand(()=>
        {
            var api = IncommApi.Instance;
            int bal = (int)(double.Parse(Balance) * 100);
            api.NewAccount(bal);
            Result = true;
            OnPropertyChanged("Result");
        });}
    }
}
