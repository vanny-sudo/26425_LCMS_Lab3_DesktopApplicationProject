using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class ClientPortalController
    {
        private readonly CaseDAO _caseDao = new CaseDAO();
        private readonly HearingDAO _hearingDao = new HearingDAO();

        public List<LegalCase> GetCases()
        {
            int? clientId = GetClientId();
            return clientId == null ? new List<LegalCase>() : _caseDao.GetCasesForClient(clientId.Value);
        }

        public List<Hearing> GetHearings()
        {
            int? clientId = GetClientId();
            return clientId == null ? new List<Hearing>() : _hearingDao.GetHearingsForClient(clientId.Value);
        }

        private static int? GetClientId()
        {
            var user = AuthController.CurrentUser;
            if (user?.Role != "Client" || user.ClientId == null)
                return null;

            return user.ClientId;
        }
    }
}
