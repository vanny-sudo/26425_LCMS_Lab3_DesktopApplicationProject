using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class SearchController
    {
        private readonly CaseDAO _dao = new CaseDAO();

        public List<LegalCase> Search(string caseNumber, string clientName, string status)
        {
            var user = AuthController.CurrentUser;
            if (user == null) return new List<LegalCase>();

            if (status == "All") status = string.Empty;

            if (user.Role != "Admin" && user.Role != "Lawyer") return new List<LegalCase>();

            int? lawyerId = user.Role == "Admin" ? null : user.UserId;

            return _dao.Search(caseNumber.Trim(), clientName.Trim(), status, lawyerId);
        }
    }
}