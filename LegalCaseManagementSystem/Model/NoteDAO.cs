
using MySql.Data.MySqlClient;
using LegalCaseManagementSystem.Data;

namespace LegalCaseManagementSystem.Model
{
    public class NoteDAO
    {
        public List<CaseNote> GetNotes(int caseId)
        {
            var list = new List<CaseNote>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT NoteId, CaseId, NoteText, NoteDate FROM CaseNotes " +
                "WHERE CaseId = @id ORDER BY NoteDate DESC, NoteId DESC", con);
            cmd.Parameters.AddWithValue("@id", caseId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new CaseNote
                {
                    NoteId = reader.GetInt32("NoteId"),
                    CaseId = reader.GetInt32("CaseId"),
                    NoteText = reader.GetString("NoteText"),
                    NoteDate = reader.GetDateTime("NoteDate")
                });
            }
            return list;
        }

        public void Add(int caseId, string noteText)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "INSERT INTO CaseNotes (CaseId, NoteText) VALUES (@id, @text)", con);
            cmd.Parameters.AddWithValue("@id", caseId);
            cmd.Parameters.AddWithValue("@text", noteText);
            cmd.ExecuteNonQuery();
        }
    }
}