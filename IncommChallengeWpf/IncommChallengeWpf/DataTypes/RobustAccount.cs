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
            { "sbux", "/IncommChallengeWpf;component/Resources/Images/cfa.png"}
        };
        static Dictionary<string, string> FullNames = new Dictionary<string, string>
        {
            {"cfa", "Chick-fil-A"},
            {"sbux", "Starbucks"}
        };

        public string ImgSrc
        {
            get => Images[AcctType];
        }
        public readonly string AcctType;
        public string Name
        {
            get => FullNames[AcctType];
        }
        public int Balance
        {
            get => IncommAccount.Balance;
        }

        private List<RobustTransaction> _transactions = new List<RobustTransaction>();
        public List<RobustTransaction> Transactions
        {
            get => _transactions;
        }
        public void RefreshTransactions()
        {
            var api = IncommApi.Instance;
            api.GetTransactions(IncommAccount.Id).ContinueWith((txs) =>
            {
                foreach(var t in txs.Result)
                {
                    _transactions.Add(new RobustTransaction(t));
                }
            });

        }

        private readonly IncommAcct IncommAccount;
        public RobustAccount(IncommAcct IA)
        {
            IncommAccount = IA;
            AcctType = "cfa";
            RefreshTransactions();
        }
    }
}
