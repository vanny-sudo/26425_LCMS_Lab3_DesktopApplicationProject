using MySql.Data.MySqlClient;
using LegalCaseManagementSystem.Data;

namespace LegalCaseManagementSystem.Model
{
    public class HearingDAO
    {
        public List<Hearing> GetHearings(int? lawyerId)
        {
            var list = new List<Hearing>();

            string sql =
                "SELECT h.HearingId, h.CaseId, h.HearingDate, h.HearingTime, h.Court, " +
                "       c.CaseNumber, u.FullName AS LawyerName " +
                "FROM Hearings h " +
                "JOIN Cases c ON c.CaseId = h.CaseId " +
                "JOIN Users u ON u.UserId = c.LawyerId ";

            if (lawyerId != null)
                sql += "WHERE c.LawyerId = @l ";

            sql += "ORDER BY h.HearingDate, h.HearingTime";

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            if (lawyerId != null)
                cmd.Parameters.AddWithValue("@l", lawyerId.Value);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Hearing
                {
                    HearingId = reader.GetInt32("HearingId"),
                    CaseId = reader.GetInt32("CaseId"),
                    HearingDate = reader.GetDateTime("HearingDate"),
                    HearingTime = reader.GetTimeSpan("HearingTime"),
                    Court = reader.GetString("Court"),
                    CaseNumber = reader.GetString("CaseNumber"),
                    LawyerName = reader.GetString("LawyerName")
                });
            }
            return list;
        }

        public List<Hearing> GetHearingsForClient(int clientId)
        {
            var list = new List<Hearing>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT h.HearingId, h.CaseId, h.HearingDate, h.HearingTime, h.Court, " +
                "c.CaseNumber, u.FullName AS LawyerName FROM Hearings h " +
                "JOIN Cases c ON c.CaseId = h.CaseId " +
                "JOIN Users u ON u.UserId = c.LawyerId " +
                "WHERE c.ClientId = @client " +
                "ORDER BY h.HearingDate, h.HearingTime", con);
            cmd.Parameters.AddWithValue("@client", clientId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Hearing
                {
                    HearingId = reader.GetInt32("HearingId"),
                    CaseId = reader.GetInt32("CaseId"),
                    HearingDate = reader.GetDateTime("HearingDate"),
                    HearingTime = reader.GetTimeSpan("HearingTime"),
                    Court = reader.GetString("Court"),
                    CaseNumber = reader.GetString("CaseNumber"),
                    LawyerName = reader.GetString("LawyerName")
                });
            }
            return list;
        }

        public bool HasClash(int caseId, DateTime date, TimeSpan time)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql =
                "SELECT COUNT(*) FROM Hearings h " +
                "JOIN Cases c ON c.CaseId = h.CaseId " +
                "WHERE c.LawyerId = (SELECT LawyerId FROM Cases WHERE CaseId = @case) " +
                "AND h.HearingDate = @d AND h.HearingTime = @t";

            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@case", caseId);
            cmd.Parameters.AddWithValue("@d", date.Date);
            cmd.Parameters.AddWithValue("@t", time);

            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Add(Hearing h)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "INSERT INTO Hearings (CaseId, HearingDate, HearingTime, Court) " +
                "VALUES (@case, @d, @t, @court)", con);
            cmd.Parameters.AddWithValue("@case", h.CaseId);
            cmd.Parameters.AddWithValue("@d", h.HearingDate.Date);
            cmd.Parameters.AddWithValue("@t", h.HearingTime);
            cmd.Parameters.AddWithValue("@court", h.Court);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int hearingId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "DELETE FROM Hearings WHERE HearingId = @id", con);
            cmd.Parameters.AddWithValue("@id", hearingId);
            cmd.ExecuteNonQuery();
        }
    }
}
