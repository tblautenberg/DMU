using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace YourProject.Controllers
{
    public class HomeController : Controller
    {
        // Displays the login page (GET request)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            string connectionString = "Server=mysql98.unoeuro.com;Port=3306;Database=blautenberg_com_db;User Id=blautenberg_com;Password=Hauro12345;";
            string dbMessage;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Hash the provided password
                    string hashedPassword = HashPassword(password);

                    // SQL query to check if the username and hashed password match
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword); // Use PasswordHash here

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            // Set success message and redirect to MainPage
                            ViewData["SuccessMessage"] = "Login successful!";
                            return RedirectToAction("Main"); // Redirect to MainPage


                        }
                        else
                        {
                            // If login fails, return to the login page with an error
                            ModelState.AddModelError("", "Invalid username or password");
                            ViewData["ErrorMessage"] = "Invalid username or password.";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                dbMessage = $"Failed to connect to the database: {ex.Message}";
                ViewData["DbMessage"] = dbMessage;
            }
            catch (Exception ex)
            {
                dbMessage = $"An error occurred: {ex.Message}";
                ViewData["DbMessage"] = dbMessage;
            }

            return View("Login"); // Return to the Login view if login fails or an error occurs
        }



        // Hash the password using SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Optional: This method can be kept if needed, or removed if unrelated to login
        // Test database connection (may not be necessary for login)
        [HttpPost]
        public IActionResult TestDbConnection(string username, string password)
        {
            string connectionString = "Server=mysql98.unoeuro.com;Port=3306;Database=blautenberg_com_db;User Id=blautenberg_com;Password=Hauro12345;";
            string dbMessage;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to check if the username and password match
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); // Here use hashed password for actual login

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            dbMessage = "Login successful! Credentials are correct.";
                        }
                        else
                        {
                            dbMessage = "Invalid username or password.";
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Specific MySQL exception handling
                dbMessage = $"Failed to connect to the database: {ex.Message}";
            }
            catch (Exception ex)
            {
                // General exception handling
                dbMessage = $"An error occurred: {ex.Message}";
            }

            ViewData["DbMessage"] = dbMessage;
            return View("Login");
        }
    }
}
