using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class UserController
    {
        private readonly UserDAO _dao = new UserDAO();

        private static bool IsAdmin => AuthController.CurrentUser?.Role == "Admin";

        public List<User> GetAll() => IsAdmin ? _dao.GetAll() : new List<User>();

        public User GetOwnProfile(out string message)
        {
            var user = AuthController.CurrentUser;
            if (user == null)
            {
                message = "No signed-in user was found.";
                return new User();
            }

            try
            {
                var profile = _dao.GetOwnProfile(user, out _);
                message = "";
                return profile;
            }
            catch (Exception ex)
            {
                message = "Could not load your profile: " + ex.Message;
                return new User();
            }
        }

        public bool Update(int userId, string fullName, string username, string password,
                           string confirmPassword, string role, out string message)
        {
            if (!IsAdmin)
            {
                message = "Only the Admin can manage users.";
                return false;
            }
            if (userId <= 0 || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username))
            {
                message = "Please complete the user details.";
                return false;
            }
            if (role != "Client" && role != "Lawyer" && role != "Admin")
            {
                message = "Please choose a valid role.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(password) && password != confirmPassword)
            {
                message = "Passwords do not match.";
                return false;
            }

            try
            {
                var existing = _dao.GetById(userId) ?? throw new InvalidOperationException("The selected user no longer exists.");
                existing.FullName = fullName.Trim();
                existing.Username = username.Trim();
                existing.Role = role;
                var hash = string.IsNullOrWhiteSpace(password) ? null : AuthController.HashPassword(password);
                _dao.UpdateManagedUser(existing, hash);
                message = "User updated successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Could not update the user: " + ex.Message;
                return false;
            }
        }

        public bool Delete(int userId, out string message)
        {
            if (!IsAdmin)
            {
                message = "Only the Admin can manage users.";
                return false;
            }
            if (AuthController.CurrentUser?.UserId == userId)
            {
                message = "You cannot delete the administrator account currently in use.";
                return false;
            }

            try
            {
                var user = _dao.GetById(userId) ?? throw new InvalidOperationException("The selected user no longer exists.");
                _dao.DeleteManagedUser(user.UserId, user.ClientId);
                message = "User deleted successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Could not delete the user: " + ex.Message;
                return false;
            }
        }

        public bool UpdateOwnProfile(User profile, out string message)
        {
            var currentUser = AuthController.CurrentUser;
            if (currentUser == null || currentUser.UserId != profile.UserId)
            {
                message = "You can only update your own profile.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(profile.FullName))
            {
                message = "Please enter your full name.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(profile.Phone))
            {
                message = "Please enter your contact number.";
                return false;
            }
            if (profile.DateOfBirth.HasValue && profile.DateOfBirth.Value.Date > DateTime.Today)
            {
                message = "Date of birth cannot be in the future.";
                return false;
            }

            try
            {
                profile.FullName = profile.FullName.Trim();
                profile.Phone = profile.Phone.Trim();
                profile.Address = profile.Address.Trim();
                _dao.UpdateOwnProfile(profile, null);
                AuthController.CurrentUser!.FullName = profile.FullName;
                AuthController.CurrentUser.Phone = profile.Phone;
                AuthController.CurrentUser.Address = profile.Address;
                AuthController.CurrentUser.DateOfBirth = profile.DateOfBirth;
                message = "Profile updated successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Could not update your profile: " + ex.Message;
                return false;
            }
        }

        public bool Create(string fullName, string username, string password, string confirmPassword,
                           string role, out string message)
        {
            if (!IsAdmin)
            {
                message = "Only the Admin can manage users.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                message = "Please complete the user details.";
                return false;
            }
            if (password != confirmPassword)
            {
                message = "Passwords do not match.";
                return false;
            }
            if (role != "Client" && role != "Lawyer")
            {
                message = "Please choose Client or Lawyer.";
                return false;
            }

            try
            {
                var user = new User
                {
                    FullName = fullName.Trim(),
                    Username = username.Trim(),
                    Role = role,
                    Phone = "+1 555 200 0000",
                    Address = "1 Legal Services Avenue, Central District",
                    DateOfBirth = new DateTime(1985, 1, 15)
                };
                if (role == "Client")
                {
                    _dao.RegisterClient(
                        new Client
                        {
                            FullName = user.FullName,
                            Phone = user.Phone,
                            Address = user.Address,
                            DateOfBirth = user.DateOfBirth
                        },
                        user,
                        AuthController.HashPassword(password));
                }
                else
                {
                    _dao.Add(user, AuthController.HashPassword(password));
                }
                message = "User created successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }
    }
}
