using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Data
{
    
        public static class DatabaseHelper
        {
            private const string ConnectionString =
                "Server=localhost;Port=3306;Database=LCMS_db;Uid=root;Pwd=;";

            public static MySqlConnection GetConnection()
            {
                return new MySqlConnection(ConnectionString);
            }

            public static bool TestConnection(out string message)
            {
                try
                {
                    using (var con = GetConnection())
                    {
                        con.Open();
                        message = "Connected to LCMS_db successfully.";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
        }
    }
