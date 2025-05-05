using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Validate user credentials (this should check against your user database)
            bool isValidUser = await ValidateUserAsync(email, password);
            if (isValidUser)
            {
                // Set authentication cookie or session, as applicable
                return RedirectToAction("Create", "Reservasjons");
            }

            ModelState.AddModelError("", "Ugyldig e-post eller passord.");
            return View();
        }

        private async Task<bool> ValidateUserAsync(string email, string password)
        {
            // Replace with your logic to validate user using email
            return email == "test@example.com" && password == "password"; // Example simplification
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            // Add your logout logic
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string email, string password)
        {
            if (ModelState.IsValid)
            {
                bool userExists = await CheckIfUserExistsAsync(email); // Updated parameter name
                if (userExists)
                {
                    ModelState.AddModelError("", "E-postadressen er allerede opptatt."); // Updated error message
                    return View();
                }

                await CreateUserAsync(email, password);
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        private async Task<bool> CheckIfUserExistsAsync(string email)
        {
            // Implement your logic to check if the user exists in a database
            return false; // Simplified
        }

        private async Task CreateUserAsync(string email, string password)
        {
            // Implement your logic to create a user in your user store
        }
    }
}
