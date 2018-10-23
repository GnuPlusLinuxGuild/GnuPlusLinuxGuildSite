using Microsoft.AspNetCore.Mvc;
using System.Linq;

using GnuPlusLinux.Models.Member;
using GnuPlusLinuxDAL;

namespace GnuPlusLinux.Controllers
{
    public class MemberController : Controller
    {
        // Page Titles
        public const string RegistrationPageTitle = "Register";

        private AccountContext _context;

        public MemberController(AccountContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register(int? id)
        {
            RegistrationViewModel model =
                new RegistrationViewModel(RegistrationPageTitle);

            Account currentAccount = new Account();

            if ((id ?? 0) > 0)
            {
                currentAccount = _context.accounts
                    .Where(a => a.accountId == id)
                    .FirstOrDefault();
            }

            model.account = currentAccount;

            return View("Register", model);
        }

        [HttpPost]
        public IActionResult Register(Account userAccount)
        {
            RegistrationViewModel model =
                new RegistrationViewModel(RegistrationPageTitle);

            if (ModelState.IsValid)
            {
                var savedAccount = _context.accounts
                    .Where(a => a.accountId == userAccount.accountId)
                    .FirstOrDefault();

                if (savedAccount == null)
                {
                    _context.accounts.Add(userAccount);
                }
                else
                {
                    savedAccount = userAccount;
                }

                _context.SaveChanges();
                return RedirectToAction("Register", new 
                    { id = userAccount.accountId });
            }

            model.account = userAccount;
            return View("Register", model);
        }
    }
}