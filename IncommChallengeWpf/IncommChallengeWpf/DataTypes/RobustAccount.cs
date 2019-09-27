using IncommChallengeWpf.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IncommChallengeWpf.DataTypes
{
    public class RobustAccount : ObservableObject
    {
        static Dictionary<string, string> Images = new Dictionary<string, string>{
            { "cfa", "/IncommChallengeWpf;component/Resources/Images/cfa.png"},
            { "sbux", "/IncommChallengeWpf;component/Resources/Images/sbux.jpg"}
        };
        static Dictionary<string, string> FullNames = new Dictionary<string, string>
        {
            {"cfa", "Chick-fil-A"},
            {"sbux", "Starbucks"}
        };
        static List<string> AccountTypes = new List<string>
        {
            "cfa",
            "sbux"
        };

        public string ImgSrc
        {
            get => Images[AcctType];
        }
        public string AcctType
        {
            get
            {
                int val = 0;
                foreach (char c in Id)
                    val += (char)c;
                val = val % AccountTypes.Count();
                return AccountTypes[val];
            }
        }
        public string Name
        {
            get => FullNames[AcctType];
        }
        public string Balance
        {
            get
            {
                double ret = (double)IncommAccount.Balance / 100;
                return string.Format("${0:0.00}", ret);
            }
        }
        public string Id
        {
            get => IncommAccount.Id;
        }

        private List<RobustTransaction> _transactions = new List<RobustTransaction>();
        public List<RobustTransaction> Transactions
        {
            get => _transactions;
        }
        public void RefreshTransactions()
        {
            var api = IncommApi.Instance;
            api.GetTransactions(IncommAccount.Id).ContinueWith(async (txs) =>
            {
                var res = await txs;
                foreach(var t in res)
                {
                    _transactions.Add(new RobustTransaction(t));
                    OnPropertyChanged("SelectedAccount.Transactions");
                }
            });

        }

        private readonly IncommAcct IncommAccount;
        public RobustAccount(IncommAcct IA)
        {
            IncommAccount = IA;
            RefreshTransactions();
        }
    }
}
