using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class ReportController
    {
        private readonly CaseDAO _caseDao = new CaseDAO();
        private readonly HearingDAO _hearingDao = new HearingDAO();

        private static int? LawyerFilter()
        {
            var user = AuthController.CurrentUser;
            if (user == null) return -1;  
            return user.Role == "Admin" ? null : user.Role == "Lawyer" ? user.UserId : -1;
        }

        public Dictionary<string, int> GetCaseCountsByStatus()
        {
            var cases = _caseDao.GetCases(LawyerFilter());

            return new Dictionary<string, int>
            {
                { "Open", cases.Count(c => c.Status == "Open") },
                { "In Progress", cases.Count(c => c.Status == "In Progress") },
                { "Closed", cases.Count(c => c.Status == "Closed") }
            };
        }

        public List<Hearing> GetHearingsThisWeek(out DateTime from, out DateTime to)
        {
            from = DateTime.Today;
            int daysToSunday = ((int)DayOfWeek.Sunday - (int)from.DayOfWeek + 7) % 7;
            to = from.AddDays(daysToSunday);

            DateTime start = from;
            DateTime end = to;

            return _hearingDao.GetHearings(LawyerFilter())
                              .Where(h => h.HearingDate.Date >= start && h.HearingDate.Date <= end)
                              .ToList();
        }

        public List<LegalCase> GetClosedCases()
        {
            return _caseDao.Search("", "", "Closed", LawyerFilter());
        }
    }
}