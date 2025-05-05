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
        public async Task<IActionResult> Login(string username, string password)
        {
            // Validate user credentials (this should check against your user database)
            bool isValidUser = await ValidateUserAsync(username, password);
            if (isValidUser)
            {
                // Set authentication cookie or session, as applicable
                // For example, using claims and identity
                // Redirect to the appropriate page after successful login
                return RedirectToAction("Index", "Reservasjons");
            }

            // If we get here, something failed; redisplay the form with an error message
            ModelState.AddModelError("", "Ugyldig brukernavn eller passord.");
            return View();
        }

        private async Task<bool> ValidateUserAsync(string username, string password)
        {
            // Replace with your user validation logic
            // Example: Check the database for valid user credentials
            // Returning true for the sake of this example.
            return username == "test" && password == "password"; // Simplified for demonstration
        }

        // GET: Account/Logout
        public async Task<IActionResult> Logout()
        {
            // Add your logout logic here (e.g., clearing session or authentication cookies)
            return RedirectToAction("Index", "Home"); // Redirect after logout
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
        public async Task<IActionResult> Register(string username, string password)
        {
            // Add your user registration logic here
            // For example, validating the input and saving the new user
            if (ModelState.IsValid)
            {
                // Check if username already exists
                bool userExists = await CheckIfUserExistsAsync(username);
                if (userExists)
                {
                    ModelState.AddModelError("", "Brukernavnet er allerede opptatt.");
                    return View();
                }

                // Save the user (this is simplified; implement your user creation logic)
                await CreateUserAsync(username, password);

                // Redirect to the login page or home page after successful registration
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        private async Task<bool> CheckIfUserExistsAsync(string username)
        {
            // Implement your logic to check if the user exists in a database
            // Return true if user exists, false otherwise
            return false; // This should check your user store
        }

        private async Task CreateUserAsync(string username, string password)
        {
            // Implement your logic to create a user in your user store
            // Hash the password and save user info
        }
    }
}