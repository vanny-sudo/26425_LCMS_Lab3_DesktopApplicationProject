using System;
using System.Collections.Generic;
using System.Text;

namespace LegalCaseManagementSystem.Model
{
    public class Client
    {
            public int ClientId { get; set; }
            public string FullName { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime? DateOfBirth { get; set; }
        }
    }
