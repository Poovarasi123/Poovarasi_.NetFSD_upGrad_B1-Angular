using Microsoft.AspNetCore.Mvc;
using BankManagementApp.Repositories;
using BankManagementApp.Models;

namespace BankManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountRepository _repo;

        public AccountController()
        {
            _repo = new AccountRepository();
        }

        // GET: Account (List)
        public IActionResult Index()
        {
            var accounts = _repo.GetAccounts();
            return View(accounts);
        }

        // GET: Account/Details/5
        public IActionResult Details(int id)
        {
            var account = _repo.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _repo.AddAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Edit/5
        public IActionResult Edit(int id)
        {
            var account = _repo.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5 (Confirmation Page)
        public IActionResult Delete(int id)
        {
            var account = _repo.GetAccount(id);
            if (account == null) return NotFound();
            return View(account);
        }

        // POST: Account/Delete/5 (Actual Delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }
    }
}