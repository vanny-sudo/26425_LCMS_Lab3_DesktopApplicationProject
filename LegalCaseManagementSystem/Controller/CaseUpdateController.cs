using LegalCaseManagementSystem.Model;

namespace LegalCaseManagementSystem.Controller
{
    public class CaseUpdateController
    {
        private static readonly string[] AllowedStatuses = { "Open", "In Progress", "Closed" };

        private readonly CaseDAO _caseDao = new CaseDAO();
        private readonly NoteDAO _noteDao = new NoteDAO();
        private readonly CaseController _caseController = new CaseController();

        public List<LegalCase> GetCases()
        {
            return _caseController.GetCases();
        }

        private bool CanAccess(int caseId)
        {
            return _caseController.GetCases().Any(c => c.CaseId == caseId);
        }

        public List<CaseNote> GetNotes(int caseId)
        {
            if (!CanAccess(caseId)) return new List<CaseNote>();
            return _noteDao.GetNotes(caseId);
        }

        public bool UpdateStatus(int caseId, string status, out string message)
        {
            if (caseId == 0)
            {
                message = "Please choose a case first.";
                return false;
            }
            if (!AllowedStatuses.Contains(status))
            {
                message = "Please choose a status.";
                return false;
            }

            try
            {
                if (!CanAccess(caseId))
                {
                    message = "You are not allowed to update this case.";
                    return false;
                }

                _caseDao.UpdateStatus(caseId, status);
                message = "Status changed to " + status + ".";
                return true;
            }
            catch (Exception ex)
            {
                message = "Database error: " + ex.Message;
                return false;
            }
        }

        public bool AddNote(int caseId, string noteText, out string message)
        {
            if (caseId == 0)
            {
                message = "Please choose a case first.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(noteText))
            {
                message = "Please type the note.";
                return false;
            }
            if (noteText.Length > 500)
            {
                message = "The note is too long (maximum 500 characters).";
                return false;
            }

            try
            {
                if (!CanAccess(caseId))
                {
                    message = "You are not allowed to add a note to this case.";
                    return false;
                }

                _noteDao.Add(caseId, noteText.Trim());
                message = "Note added successfully.";
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