using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Model
{
    public class LegalCase
    {
            public int CaseId { get; set; }
            public string CaseNumber { get; set; } = string.Empty;
            public string Title { get; set; } = string.Empty;
            public string CaseType { get; set; } = string.Empty;
            public int ClientId { get; set; }
            public int LawyerId { get; set; }
            public DateTime DateOpened { get; set; }
            public string Status { get; set; } = "Open";  
            public string NextHearing { get; set; } = "Not scheduled";

            public string ClientName { get; set; } = string.Empty;
            public string LawyerName { get; set; } = string.Empty;
        }
    }

