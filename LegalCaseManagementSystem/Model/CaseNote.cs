using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Model
{
        public class CaseNote
        {
            public int NoteId { get; set; }
            public int CaseId { get; set; }
            public string NoteText { get; set; } = string.Empty;
            public DateTime NoteDate { get; set; }
        }
    }

