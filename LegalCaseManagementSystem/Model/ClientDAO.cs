using MySql.Data.MySqlClient;
using LegalCaseManagementSystem.Data;

namespace LegalCaseManagementSystem.Model
{
    public class ClientDAO
    {
        public List<Client> GetAll()
        {
            var list = new List<Client>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT ClientId, FullName, Phone FROM Clients ORDER BY FullName", con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Client
                {
                    ClientId = reader.GetInt32("ClientId"),
                    FullName = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString("FullName")),
                    Phone = ProfileDisplay.Text(reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"))
                });
            }
            return list;
        }

        public void Add(Client client)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "INSERT INTO Clients (FullName, Phone) VALUES (@n, @p)", con);
            cmd.Parameters.AddWithValue("@n", client.FullName);
            cmd.Parameters.AddWithValue("@p", client.Phone);
            cmd.ExecuteNonQuery();
        }

        public void Update(Client client)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "UPDATE Clients SET FullName = @n, Phone = @p WHERE ClientId = @id", con);
            cmd.Parameters.AddWithValue("@n", client.FullName);
            cmd.Parameters.AddWithValue("@p", client.Phone);
            cmd.Parameters.AddWithValue("@id", client.ClientId);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int clientId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "DELETE FROM Clients WHERE ClientId = @id", con);
            cmd.Parameters.AddWithValue("@id", clientId);
            cmd.ExecuteNonQuery();
        }

        public bool HasCases(int clientId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM Cases WHERE ClientId = @id", con);
            cmd.Parameters.AddWithValue("@id", clientId);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}