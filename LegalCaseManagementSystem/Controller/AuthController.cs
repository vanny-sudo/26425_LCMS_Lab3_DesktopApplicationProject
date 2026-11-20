using System.Security.Cryptography;
using System.Text;
using LegalCaseManagementSystem.Model;
using MySql.Data.MySqlClient;

namespace LegalCaseManagementSystem.Controller
{
    public class AuthController
    {
        private readonly UserDAO _userDao = new UserDAO();

        public static User? CurrentUser { get; private set; }

        public bool Login(string username, string password, out string message)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                message = "Please type your username and password.";
                return false;
            }

            try
            {
                var user = _userDao.GetByCredentials(username.Trim(), HashPassword(password));
                if (user == null)
                {
                    message = "Wrong username or password.";
                    return false;
                }

                string normalizedRole = user.Role.Trim();
                if (normalizedRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    normalizedRole = "Admin";
                else if (normalizedRole.Equals("lawyer", StringComparison.OrdinalIgnoreCase))
                    normalizedRole = "Lawyer";
                else if (normalizedRole.Equals("client", StringComparison.OrdinalIgnoreCase))
                    normalizedRole = "Client";
                else
                {
                    message = "The account has an unsupported database role ('" +
                              user.Role + "'). Set this user's Role to Client, Lawyer, or Admin.";
                    return false;
                }

                user.Role = normalizedRole;

                CurrentUser = user;
                message = "Welcome " + user.FullName;
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();   
        }

        public bool RegisterUser(string fullName, string phone, string username,
            string password, string role, out string message)
        {
            fullName = fullName.Trim();
            phone = phone.Trim();
            username = username.Trim();

            if (role != "Admin" && role != "Client" && role != "Lawyer")
            {
                message = "Please choose Admin, Client, or Lawyer.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                message = "Please type your full name.";
                return false;
            }

            if (role == "Client" && string.IsNullOrWhiteSpace(phone))
            {
                message = "Please type your phone number.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                message = "Please choose a username and password.";
                return false;
            }

            try
            {
                var user = new User
                {
                    Username = username,
                    FullName = fullName,
                    Role = role,
                    Phone = string.IsNullOrWhiteSpace(phone) ? "+1 555 300 0000" : phone,
                    Address = "1 Legal Services Avenue, Central District",
                    DateOfBirth = new DateTime(1985, 1, 15)
                };

                if (role == "Client")
                {
                    _userDao.RegisterClient(
                        new Client
                        {
                            FullName = fullName,
                            Phone = user.Phone,
                            Address = user.Address,
                            DateOfBirth = user.DateOfBirth
                        },
                        user,
                        HashPassword(password));
                }
                else
                {
                    _userDao.Add(user, HashPassword(password));
                }

                message = "Registration successful. You can now log in.";
                return true;
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                message = "That username already exists.";
                return false;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }
    }
}