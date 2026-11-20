using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class CaseController
    {
        private readonly CaseDAO _caseDao = new CaseDAO();
        private readonly ClientDAO _clientDao = new ClientDAO();
        private readonly UserDAO _userDao = new UserDAO();

        public List<LegalCase> GetCases()
        {
            var user = AuthController.CurrentUser;
            if (user?.Role == "Admin") return _caseDao.GetCases(null);
            return user?.Role == "Lawyer" ? _caseDao.GetCases(user.UserId) : new List<LegalCase>();
        }

        public List<Client> GetClients() => _clientDao.GetAll();

        public List<User> GetLawyers() => _userDao.GetLawyers();

        public string GetNextCaseNumber() => _caseDao.GetNextCaseNumber();

        public bool OpenCase(LegalCase c, out string message)
        {
            var user = AuthController.CurrentUser;
            if (user?.Role != "Admin" && user?.Role != "Lawyer")
            {
                message = "Only an Admin or Lawyer can register a case.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(c.Title))
            {
                message = "Please type the case title.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(c.CaseType))
            {
                message = "Please choose the type of case.";
                return false;
            }
            if (c.ClientId == 0)
            {
                message = "Please choose the client.";
                return false;
            }
            if (c.LawyerId == 0 && user.Role == "Lawyer")
            {
                c.LawyerId = user.UserId;
            }

            if (c.LawyerId == 0)
            {
                message = "Please choose the lawyer in charge.";
                return false;
            }

            if (user.Role == "Lawyer" && c.LawyerId != user.UserId)
                c.LawyerId = user.UserId;

            c.Status = "Open";

            try
            {
                _caseDao.Add(c);
                message = "Case " + c.CaseNumber + " registered successfully with status Open.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        public bool AssignLawyer(int caseId, int lawyerId, out string message)
        {
            if (AuthController.CurrentUser?.Role != "Admin")
            {
                message = "Only the Admin can assign cases.";
                return false;
            }
            if (caseId == 0 || lawyerId == 0)
            {
                message = "Please select a case and a lawyer.";
                return false;
            }

            try
            {
                _caseDao.UpdateLawyer(caseId, lawyerId);
                message = "Lawyer assigned successfully.";
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