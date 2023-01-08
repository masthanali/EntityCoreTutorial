using EntityCoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCoreTutorial
{
    public class CrudOperation
    {
        AlwebieeContext _context;

        public CrudOperation()
        {
            _context = new AlwebieeContext();
        }

        public bool SaveData(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateData(int Id, Account account)
        {
            try
            {
                var connectionname = _context.Accounts.Find(Id);
                connectionname.Name = account.Name;
                connectionname.Emailid = account.Emailid;
                connectionname.Phonenumber = account.Phonenumber;
                connectionname.Isadmin = account.Isadmin;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteData(int Id)
        {
            try
            {
                var connectionname = _context.Accounts.Find(Id);
                _context.Accounts.Remove(connectionname);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }


        public Account GetAccount(int Id)
        {
            try
            {
                return _context.Accounts.Find(Id);
            }
            catch (Exception)
            {
                return null;

            }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                return _context.Accounts.ToList().Take(10).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
