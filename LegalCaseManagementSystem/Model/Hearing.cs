using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Model
{
        public class Hearing
        {
            public int HearingId { get; set; }
            public int CaseId { get; set; }
            public DateTime HearingDate { get; set; }
            public TimeSpan HearingTime { get; set; }
            public string Court { get; set; } = string.Empty;
            public string CaseNumber { get; set; } = string.Empty;
            public string LawyerName { get; set; } = string.Empty;
        }
    }
