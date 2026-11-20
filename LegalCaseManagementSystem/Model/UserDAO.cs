using LegalCaseManagementSystem.Data;
using MySql.Data.MySqlClient;

namespace LegalCaseManagementSystem.Model
{
    public class UserDAO
    {
        public User? GetByCredentials(string username, string passwordHash)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT UserId, ClientId, Username, FullName, Phone, Address, DateOfBirth, " +
                "CASE " +
                "WHEN LOWER(TRIM(Role)) = 'admin' THEN 'Admin' " +
                "WHEN LOWER(TRIM(Role)) = 'lawyer' THEN 'Lawyer' " +
                "WHEN LOWER(TRIM(Role)) = 'client' THEN 'Client' " +
                "WHEN ClientId IS NOT NULL AND COALESCE(TRIM(Role), '') = '' THEN 'Client' " +
                "ELSE COALESCE(TRIM(Role), '') END AS Role " +
                "FROM Users " +
                "WHERE Username = @username AND PasswordHash = @passwordHash", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passwordHash", passwordHash);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new User
            {
                UserId = reader.GetInt32("UserId"),
                ClientId = reader.IsDBNull(reader.GetOrdinal("ClientId"))
                    ? null
                    : reader.GetInt32("ClientId"),
                Username = reader.GetString("Username"),
                FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                Role = reader.GetString("Role"),
                Phone = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone")),
                Address = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address")),
                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth"))
                    ? null
                    : reader.GetDateTime("DateOfBirth")
            };
        }

        private static void EnsureProfileColumns()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var command = new MySqlCommand(
                "ALTER TABLE Users " +
                "ADD COLUMN IF NOT EXISTS Phone VARCHAR(50) NULL, " +
                "ADD COLUMN IF NOT EXISTS Address VARCHAR(255) NULL, " +
                "ADD COLUMN IF NOT EXISTS DateOfBirth DATE NULL;", con);
            command.ExecuteNonQuery();
        }

        public User GetOwnProfile(User currentUser, out Client? client)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var command = new MySqlCommand(
                "SELECT UserId, ClientId, Username, FullName, Role, Phone, Address, DateOfBirth " +
                "FROM Users WHERE UserId = @userId", con);
            command.Parameters.AddWithValue("@userId", currentUser.UserId);
            using var reader = command.ExecuteReader();
            if (!reader.Read())
                throw new InvalidOperationException("The signed-in user could not be found.");

            var profile = new User
            {
                UserId = reader.GetInt32("UserId"),
                ClientId = reader.IsDBNull(reader.GetOrdinal("ClientId")) ? null : reader.GetInt32("ClientId"),
                Username = reader.GetString("Username"),
                FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                Role = reader.GetString("Role"),
                Phone = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone")),
                Address = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address")),
                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth")) ? null : reader.GetDateTime("DateOfBirth")
            };
            client = null;
            return profile;
        }

        public Client? GetClientProfile(int clientId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var cmd = new MySqlCommand(
                "SELECT ClientId, FullName, Phone, Address, DateOfBirth " +
                "FROM Clients WHERE ClientId = @id", con);
            cmd.Parameters.AddWithValue("@id", clientId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new Client
            {
                ClientId = reader.GetInt32("ClientId"),
                FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                Phone = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone")),
                Address = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString("Address")),
                DateOfBirth = reader.IsDBNull(reader.GetOrdinal("DateOfBirth"))
                    ? null
                    : reader.GetDateTime("DateOfBirth")
            };
        }

        public void UpdateOwnProfile(User user, Client? client)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var transaction = con.BeginTransaction();
            try
            {
                using var userCommand = new MySqlCommand(
                    "UPDATE Users SET FullName = @fullName, Phone = @phone, " +
                    "Address = @address, DateOfBirth = @dateOfBirth WHERE UserId = @userId", con, transaction);
                userCommand.Parameters.AddWithValue("@fullName", user.FullName);
                userCommand.Parameters.AddWithValue("@phone", user.Phone);
                userCommand.Parameters.AddWithValue("@address", user.Address);
                userCommand.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth.HasValue ? user.DateOfBirth.Value.Date : DBNull.Value);
                userCommand.Parameters.AddWithValue("@userId", user.UserId);
                userCommand.ExecuteNonQuery();

                if (user.ClientId.HasValue)
                {
                    using var clientCommand = new MySqlCommand(
                "UPDATE Clients SET FullName = @clientFullName, Phone = @clientPhone, " +
                        "Address = @clientAddress, DateOfBirth = @clientDateOfBirth " +
                        "WHERE ClientId = @clientId " +
                        "AND EXISTS (SELECT 1 FROM Users WHERE UserId = @userId AND ClientId = @clientId)",
                        con, transaction);
                    clientCommand.Parameters.AddWithValue("@clientFullName", user.FullName);
                    clientCommand.Parameters.AddWithValue("@clientPhone", user.Phone);
                    clientCommand.Parameters.AddWithValue("@clientAddress", user.Address);
                    clientCommand.Parameters.AddWithValue("@clientDateOfBirth", user.DateOfBirth.HasValue ? user.DateOfBirth.Value.Date : DBNull.Value);
                    clientCommand.Parameters.AddWithValue("@clientId", user.ClientId.Value);
                    clientCommand.Parameters.AddWithValue("@userId", user.UserId);
                    clientCommand.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public List<User> GetLawyers()
        {
            var list = new List<User>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT UserId, Username, FullName, Role FROM Users " +
                "WHERE Role = 'Lawyer' ORDER BY FullName", con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User
                {
                    UserId = reader.GetInt32("UserId"),
                    Username = reader.GetString("Username"),
                    FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                    Role = reader.GetString("Role")
                });
            }
            return list;
        }

        public User? GetById(int userId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var cmd = new MySqlCommand(
                "SELECT UserId, ClientId, Username, FullName, Role, Phone FROM Users WHERE UserId = @userId", con);
            cmd.Parameters.AddWithValue("@userId", userId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new User
            {
                UserId = reader.GetInt32("UserId"),
                ClientId = reader.IsDBNull(reader.GetOrdinal("ClientId")) ? null : reader.GetInt32("ClientId"),
                Username = reader.GetString("Username"),
                FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                Role = reader.GetString("Role"),
                Phone = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"))
            };
        }

        public List<User> GetAll()
        {
            var list = new List<User>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT UserId, ClientId, Username, FullName, Role, Phone, Address, DateOfBirth FROM Users ORDER BY FullName", con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new User
                {
                    UserId = reader.GetInt32("UserId"),
                    ClientId = reader.IsDBNull(reader.GetOrdinal("ClientId")) ? null : reader.GetInt32("ClientId"),
                    Username = reader.GetString("Username"),
                    FullName = reader.GetString("FullName"),
                    Role = reader.GetString("Role")
                });
            }
            return list;
        }

        public void UpdateManagedUser(User user, string? passwordHash)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var transaction = con.BeginTransaction();

            try
            {
                int? clientId = user.ClientId;
                if (user.Role == "Client" && !clientId.HasValue)
                {
                    using var clientCommand = new MySqlCommand(
                        "INSERT INTO Clients (FullName, Phone) VALUES (@fullName, @phone)", con, transaction);
                    clientCommand.Parameters.AddWithValue("@fullName", user.FullName);
                    clientCommand.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(user.Phone) ? "Not provided" : user.Phone);
                    clientCommand.ExecuteNonQuery();
                    clientId = Convert.ToInt32(clientCommand.LastInsertedId);
                }

                string sql = passwordHash == null
                    ? "UPDATE Users SET Username = @username, FullName = @fullName, Role = @role, ClientId = @clientId, Phone = @phone WHERE UserId = @userId"
                    : "UPDATE Users SET Username = @username, PasswordHash = @passwordHash, FullName = @fullName, Role = @role, ClientId = @clientId, Phone = @phone WHERE UserId = @userId";
                using var userCommand = new MySqlCommand(sql, con, transaction);
                userCommand.Parameters.AddWithValue("@username", user.Username);
                userCommand.Parameters.AddWithValue("@fullName", user.FullName);
                userCommand.Parameters.AddWithValue("@role", user.Role);
                userCommand.Parameters.AddWithValue("@clientId", clientId.HasValue ? clientId.Value : DBNull.Value);
                userCommand.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(user.Phone) ? DBNull.Value : user.Phone);
                userCommand.Parameters.AddWithValue("@userId", user.UserId);
                if (passwordHash != null) userCommand.Parameters.AddWithValue("@passwordHash", passwordHash);
                userCommand.ExecuteNonQuery();

                if (clientId.HasValue)
                {
                    using var clientUpdate = new MySqlCommand(
                        "UPDATE Clients SET FullName = @fullName, Phone = @phone WHERE ClientId = @clientId",
                        con, transaction);
                    clientUpdate.Parameters.AddWithValue("@fullName", user.FullName);
                    clientUpdate.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(user.Phone) ? "Not provided" : user.Phone);
                    clientUpdate.Parameters.AddWithValue("@clientId", clientId.Value);
                    clientUpdate.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void DeleteManagedUser(int userId, int? clientId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var transaction = con.BeginTransaction();
            try
            {
                if (clientId.HasValue)
                {
                    using var caseCheck = new MySqlCommand(
                        "SELECT COUNT(*) FROM Cases WHERE ClientId = @clientId", con, transaction);
                    caseCheck.Parameters.AddWithValue("@clientId", clientId.Value);
                    if (Convert.ToInt32(caseCheck.ExecuteScalar()) > 0)
                        throw new InvalidOperationException("This client cannot be deleted because cases are linked to the account.");
                }

                using var userCommand = new MySqlCommand("DELETE FROM Users WHERE UserId = @userId", con, transaction);
                userCommand.Parameters.AddWithValue("@userId", userId);
                userCommand.ExecuteNonQuery();

                if (clientId.HasValue)
                {
                    using var clientCommand = new MySqlCommand("DELETE FROM Clients WHERE ClientId = @clientId", con, transaction);
                    clientCommand.Parameters.AddWithValue("@clientId", clientId.Value);
                    clientCommand.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Add(User user, string passwordHash)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "INSERT INTO Users (Username, PasswordHash, FullName, Role, Phone, Address, DateOfBirth) " +
                "VALUES (@username, @passwordHash, @fullName, @role, @phone, @address, @dateOfBirth)", con);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
            cmd.Parameters.AddWithValue("@fullName", user.FullName);
            cmd.Parameters.AddWithValue("@role", user.Role);
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@address", user.Address);
            cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth.HasValue ? user.DateOfBirth.Value.Date : DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        public void RegisterClient(Client client, User user, string passwordHash)
        {
            EnsureProfileColumns();
            using var con = DatabaseHelper.GetConnection();
            con.Open();
            using var transaction = con.BeginTransaction();

            try
            {
                using var clientCommand = new MySqlCommand(
                    "INSERT INTO Clients (FullName, Phone, Address, DateOfBirth) VALUES (@fullName, @phone, @address, @dateOfBirth)",
                    con, transaction);
                clientCommand.Parameters.AddWithValue("@fullName", client.FullName);
                clientCommand.Parameters.AddWithValue("@phone", client.Phone);
                clientCommand.Parameters.AddWithValue("@address", client.Address);
                clientCommand.Parameters.AddWithValue("@dateOfBirth", client.DateOfBirth.HasValue ? client.DateOfBirth.Value.Date : DBNull.Value);
                clientCommand.ExecuteNonQuery();

                int clientId = Convert.ToInt32(clientCommand.LastInsertedId);

                using var userCommand = new MySqlCommand(
                    "INSERT INTO Users (Username, PasswordHash, FullName, Role, ClientId, Phone, Address, DateOfBirth) " +
                    "VALUES (@username, @passwordHash, @fullName, 'Client', @clientId, @phone, @address, @dateOfBirth)",
                    con, transaction);
                userCommand.Parameters.AddWithValue("@username", user.Username);
                userCommand.Parameters.AddWithValue("@passwordHash", passwordHash);
                userCommand.Parameters.AddWithValue("@fullName", user.FullName);
                userCommand.Parameters.AddWithValue("@clientId", clientId);
                userCommand.Parameters.AddWithValue("@phone", client.Phone);
                userCommand.Parameters.AddWithValue("@address", client.Address);
                userCommand.Parameters.AddWithValue("@dateOfBirth", client.DateOfBirth.HasValue ? client.DateOfBirth.Value.Date : DBNull.Value);
                userCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
