using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKB.BankKlient.BLL.User;
using LiteDB;

namespace KKB.BankKlient.BLL.Account
{
    public class ServiceAccount
    {
        Random rnd = new Random();
        public Account GetAccount(User.User user, currency cur)
        {
            Account account = new Account();
            account.CreataDate = DateTime.Now.AddMonths(rnd.Next(1, 12) * -1);
            account.Number = cur.ToString().ToUpper() + rnd.Next();
            account.Balance = 0;
            account.UserId = user.Id;
            account.Currency = cur;
            return account;
        }
        public bool CreateAccountDb(Account account, out string message)
        {
            try
            {
                using (var db = new LiteDatabase(@"kkb.db"))
                {
                    var accounts = db.GetCollection<Account>("Account");

                    accounts.Insert(account);
                }
                message = "Создание счёта прошла успешно";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }
    };
}
