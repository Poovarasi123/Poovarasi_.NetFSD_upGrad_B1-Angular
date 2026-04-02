using BankManagementApp.Data;
using BankManagementApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankManagementApp.Repositories
{
    public class AccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository()
        {
            _context = new ApplicationDbContext();
        }

        // 1. GET ALL ACCOUNTS
        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        // 2. GET SINGLE ACCOUNT BY ID
        public Account? GetAccount(int id)
        {
            // Find is the fastest way to get a record by its Primary Key
            return _context.Accounts.Find(id);
        }

        // 3. ADD ACCOUNT
        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        // 4. UPDATE ACCOUNT
        public void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }

        // 5. DELETE ACCOUNT
        public void DeleteAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
        }
    }
}