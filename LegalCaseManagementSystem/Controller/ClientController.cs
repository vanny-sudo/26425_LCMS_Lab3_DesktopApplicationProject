using System.Text.RegularExpressions;
using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class ClientController
    {
        private readonly ClientDAO _dao = new ClientDAO();

        public List<Client> GetAll()
        {
            return _dao.GetAll();
        }

        public bool Save(Client client, out string message)
        {
            if (!Validate(client, out message))
                return false;

            try
            {
                if (client.ClientId == 0)
                {
                    _dao.Add(client);
                    message = "Client added successfully.";
                }
                else
                {
                    _dao.Update(client);
                    message = "Client updated successfully.";
                }
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        public bool Delete(int clientId, out string message)
        {
            try
            {
                if (_dao.HasCases(clientId))
                {
                    message = "This client has cases, so it cannot be deleted.";
                    return false;
                }

                _dao.Delete(clientId);
                message = "Client deleted successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        private static bool Validate(Client client, out string message)
        {
            if (string.IsNullOrWhiteSpace(client.FullName))
            {
                message = "Please type the client's name.";
                return false;
            }

            if (!Regex.IsMatch(client.Phone, @"^\+?[0-9 ]{9,15}$"))
            {
                message = "Please type a valid phone number (digits only, 9 to 15 characters).";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}