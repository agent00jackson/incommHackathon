using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IncommChallengeWpf.DataTypes
{
    public class RobustAccount
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

        private readonly IncommAcct IncommAcct;
        public RobustAccount()
        {
            AcctType = "cfa";
        }
    }
}
