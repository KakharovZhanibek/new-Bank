using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKB.BankKlient.BLL.Account
{
    public enum currency { usd,kzt,rur}
    public class Account
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public DateTime CreataDate { get; set; }
        public currency Currency { get; set; }
        public  decimal Balance { get; set; }
    }
}
