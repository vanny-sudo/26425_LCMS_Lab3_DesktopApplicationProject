using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class HearingController
    {
        private readonly HearingDAO _dao = new HearingDAO();
        private readonly CaseController _caseController = new CaseController();

        public List<Hearing> GetHearings()
        {
            var user = AuthController.CurrentUser;
            if (user == null) return new List<Hearing>();

            return user.Role == "Admin" ? _dao.GetHearings(null) :
                user.Role == "Lawyer" ? _dao.GetHearings(user.UserId) : new List<Hearing>();
        }

        public List<LegalCase> GetSchedulableCases()
        {
            return _caseController.GetCases()
                                  .Where(c => c.Status != "Closed")
                                  .ToList();
        }

        public bool Schedule(Hearing hearing, out string message)
        {
            if (hearing.CaseId == 0)
            {
                message = "Please choose the case.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(hearing.Court))
            {
                message = "Please type the name of the court.";
                return false;
            }
            if (hearing.HearingDate.Date < DateTime.Today)
            {
                message = "The hearing date cannot be in the past.";
                return false;
            }

            try
            {
                if (AuthController.CurrentUser?.Role != "Admin" &&
                    !_caseController.GetCases().Any(c => c.CaseId == hearing.CaseId))
                {
                    message = "You can only schedule hearings for your own cases.";
                    return false;
                }

                if (_dao.HasClash(hearing.CaseId, hearing.HearingDate, hearing.HearingTime))
                {
                    message = "Clash! This lawyer already has a hearing on " +
                              hearing.HearingDate.ToString("dd/MM/yyyy") + " at " +
                              hearing.HearingTime.ToString(@"hh\:mm") +
                              ". Please choose another date or time.";
                    return false;
                }

                _dao.Add(hearing);
                message = "Hearing scheduled successfully.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        public bool Cancel(int hearingId, out string message)
        {
            if (hearingId == 0)
            {
                message = "Please click a hearing in the list first.";
                return false;
            }

            try
            {
                if (AuthController.CurrentUser?.Role != "Admin" &&
                    !GetHearings().Any(h => h.HearingId == hearingId))
                {
                    message = "You can only cancel your own hearings.";
                    return false;
                }

                _dao.Delete(hearingId);
                message = "Hearing cancelled.";
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