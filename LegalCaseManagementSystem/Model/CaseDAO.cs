using MySql.Data.MySqlClient;
using LegalCaseManagementSystem.Data;

namespace LegalCaseManagementSystem.Model
{
    public class CaseDAO
    {
        public List<LegalCase> GetCases(int? lawyerId)
        {
            var list = new List<LegalCase>();

            string sql =
                "SELECT c.CaseId, c.CaseNumber, c.Title, c.CaseType, c.ClientId, " +
                "       c.LawyerId, c.DateOpened, c.Status, " +
                "       COALESCE(DATE_FORMAT((SELECT MIN(CONCAT(h.HearingDate, ' ', h.HearingTime)) " +
                "       FROM Hearings h WHERE h.CaseId = c.CaseId AND h.HearingDate >= CURDATE()), " +
                "       '%d/%m/%Y %H:%i'), 'Not scheduled') AS NextHearing, " +
                "       cl.FullName AS ClientName, u.FullName AS LawyerName " +
                "FROM Cases c " +
                "JOIN Clients cl ON cl.ClientId = c.ClientId " +
                "JOIN Users u ON u.UserId = c.LawyerId ";

            if (lawyerId != null)
                sql += "WHERE c.LawyerId = @l ";

            sql += "ORDER BY c.CaseId DESC";

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            if (lawyerId != null)
                cmd.Parameters.AddWithValue("@l", lawyerId.Value);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LegalCase
                {
                    CaseId = reader.GetInt32("CaseId"),
                    CaseNumber = reader.GetString("CaseNumber"),
                    Title = reader.GetString("Title"),
                    CaseType = reader.GetString("CaseType"),
                    ClientId = reader.GetInt32("ClientId"),
                    LawyerId = reader.GetInt32("LawyerId"),
                    DateOpened = reader.GetDateTime("DateOpened"),
                    Status = reader.GetString("Status"),
                    NextHearing = reader.GetString("NextHearing"),
                    ClientName = reader.GetString("ClientName"),
                    LawyerName = reader.GetString("LawyerName")
                });
            }
            return list;
        }

        public void Add(LegalCase c)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "INSERT INTO Cases (CaseNumber, Title, CaseType, ClientId, LawyerId, DateOpened, Status) " +
                "VALUES (@num, @title, @type, @client, @lawyer, @date, @status)", con);
            cmd.Parameters.AddWithValue("@num", c.CaseNumber);
            cmd.Parameters.AddWithValue("@title", c.Title);
            cmd.Parameters.AddWithValue("@type", c.CaseType);
            cmd.Parameters.AddWithValue("@client", c.ClientId);
            cmd.Parameters.AddWithValue("@lawyer", c.LawyerId);
            cmd.Parameters.AddWithValue("@date", c.DateOpened.Date);
            cmd.Parameters.AddWithValue("@status", c.Status);
            cmd.ExecuteNonQuery();
        }

        public void UpdateLawyer(int caseId, int lawyerId)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "UPDATE Cases SET LawyerId = @l WHERE CaseId = @id", con);
            cmd.Parameters.AddWithValue("@l", lawyerId);
            cmd.Parameters.AddWithValue("@id", caseId);
            cmd.ExecuteNonQuery();
        }

        public string GetNextCaseNumber()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT IFNULL(MAX(CaseId), 0) + 1 FROM Cases", con);
            int next = Convert.ToInt32(cmd.ExecuteScalar());

            return "LC-" + DateTime.Now.Year + "-" + next.ToString("D3");
        }

        public void UpdateStatus(int caseId, string status)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "UPDATE Cases SET Status = @s WHERE CaseId = @id", con);
            cmd.Parameters.AddWithValue("@s", status);
            cmd.Parameters.AddWithValue("@id", caseId);
            cmd.ExecuteNonQuery();
        }

        public List<LegalCase> Search(string caseNumber, string clientName,
                                      string status, int? lawyerId)
        {
            var list = new List<LegalCase>();

            string sql =
                "SELECT c.CaseId, c.CaseNumber, c.Title, c.CaseType, c.ClientId, " +
                "       c.LawyerId, c.DateOpened, c.Status, " +
                "       COALESCE(DATE_FORMAT((SELECT MIN(CONCAT(h.HearingDate, ' ', h.HearingTime)) " +
                "       FROM Hearings h WHERE h.CaseId = c.CaseId AND h.HearingDate >= CURDATE()), " +
                "       '%d/%m/%Y %H:%i'), 'Not scheduled') AS NextHearing, " +
                "       cl.FullName AS ClientName, u.FullName AS LawyerName " +
                "FROM Cases c " +
                "JOIN Clients cl ON cl.ClientId = c.ClientId " +
                "JOIN Users u ON u.UserId = c.LawyerId " +
                "WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(caseNumber))
                sql += "AND c.CaseNumber LIKE @num ";
            if (!string.IsNullOrEmpty(clientName))
                sql += "AND cl.FullName LIKE @client ";
            if (!string.IsNullOrEmpty(status))
                sql += "AND c.Status = @status ";
            if (lawyerId != null)
                sql += "AND c.LawyerId = @l ";

            sql += "ORDER BY c.CaseId DESC";

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(sql, con);
            if (!string.IsNullOrEmpty(caseNumber))
                cmd.Parameters.AddWithValue("@num", "%" + caseNumber + "%");
            if (!string.IsNullOrEmpty(clientName))
                cmd.Parameters.AddWithValue("@client", "%" + clientName + "%");
            if (!string.IsNullOrEmpty(status))
                cmd.Parameters.AddWithValue("@status", status);
            if (lawyerId != null)
                cmd.Parameters.AddWithValue("@l", lawyerId.Value);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LegalCase
                {
                    CaseId = reader.GetInt32("CaseId"),
                    CaseNumber = reader.GetString("CaseNumber"),
                    Title = reader.GetString("Title"),
                    CaseType = reader.GetString("CaseType"),
                    ClientId = reader.GetInt32("ClientId"),
                    LawyerId = reader.GetInt32("LawyerId"),
                    DateOpened = reader.GetDateTime("DateOpened"),
                    Status = reader.GetString("Status"),
                        NextHearing = reader.GetString("NextHearing"),
                    ClientName = reader.GetString("ClientName"),
                    LawyerName = reader.GetString("LawyerName")
                });
            }
            return list;
        }

        public List<LegalCase> GetCasesForClient(int clientId)
        {
            var list = new List<LegalCase>();

            using var con = DatabaseHelper.GetConnection();
            con.Open();

            using var cmd = new MySqlCommand(
                "SELECT c.CaseId, c.CaseNumber, c.Title, c.CaseType, c.ClientId, " +
                "c.LawyerId, c.DateOpened, c.Status, cl.FullName AS ClientName, " +
                "u.FullName AS LawyerName FROM Cases c " +
                "JOIN Clients cl ON cl.ClientId = c.ClientId " +
                "JOIN Users u ON u.UserId = c.LawyerId " +
                "WHERE c.ClientId = @client ORDER BY c.CaseId DESC", con);
            cmd.Parameters.AddWithValue("@client", clientId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new LegalCase
                {
                    CaseId = reader.GetInt32("CaseId"),
                    CaseNumber = reader.GetString("CaseNumber"),
                    Title = reader.GetString("Title"),
                    CaseType = reader.GetString("CaseType"),
                    ClientId = reader.GetInt32("ClientId"),
                    LawyerId = reader.GetInt32("LawyerId"),
                    DateOpened = reader.GetDateTime("DateOpened"),
                    Status = reader.GetString("Status"),
                    ClientName = reader.GetString("ClientName"),
                    LawyerName = reader.GetString("LawyerName")
                });
            }
            return list;
        }
    }
}